using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YCC.Application.Catalog.Products;
using YCC.Application.Common;
using YCC.Data.EF;
using YCC.Data.Entities;
using YCC.Utilities.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using YCC.Application.Catalog.Categories;
using YCC.Application.System.Languages;
using YCC.Application.System.Roles;
using YCC.Application.System.Users;
using YCC.Application.Utilities.Slides;
using YCC.ViewModels.System.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using static IdentityServer4.IdentityServerConstants;
using YCC.BackendApi.IdentityServer;
using YCC.BackendApi.Security.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using YCC.BackendApi.Security.Authorization.Handlers;

namespace YCC.BackendApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<YCCDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(SystemConstants.MainConnectionString)));
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<YCCDbContext>()
                .AddDefaultTokenProviders();
            // RS: Add ASP Identity(NOT AddDefaultIdentity)
            //services.AddIdentity<AppUser, AppRole>(options => options.SignIn.RequireConfirmedAccount = false)
            //    .AddEntityFrameworkStores<YCCDbContext>()
            //    .AddDefaultTokenProviders();
            // RS: Add IdentityServer4
            //services.AddIdentityServer(options =>
            //{
            //    options.Events.RaiseErrorEvents = true;
            //    options.Events.RaiseInformationEvents = true;
            //    options.Events.RaiseFailureEvents = true;
            //    options.Events.RaiseSuccessEvents = true;
            //    options.EmitStaticAudienceClaim = true;
            //})
            //.AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources)
            //.AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
            //.AddInMemoryClients(IdentityServerConfig.Clients)
            //.AddAspNetIdentity<AppUser>()
            //.AddProfileService<CustomProfileService>()
            //.AddDeveloperSigningCredential();
            services.AddTransient<IStorageService, FileStorageService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<ISlideService, SlideService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Rookie Solution", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
            });
            // RS:
            //services.ConfigureApplicationCookie(config =>
            //{
            //    config.LoginPath = "/CustomAuthentication/Login";
            //});
            string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = Configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });
            // RS:
            //services.AddAuthentication()
            //    .AddLocalApi("Bearer", option =>
            //    {
            //        option.ExpectedScope = "rookieshop.api";
            //    });
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy(LocalApi.PolicyName, policy =>
            //    {
            //        policy.AddAuthenticationSchemes("Bearer");
            //        policy.RequireAuthenticatedUser();
            //    });

            //    options.AddPolicy("ADMIN_ROLE_POLICY", policy =>
            //        policy.Requirements.Add(new AdminRoleRequirement()));
            //});
            //services.AddSingleton<IAuthorizationHandler, AdminRoleHandler>();
            // RS
            //services.AddControllersWithViews();
            // RS: Add Authentication and Scope to Swagger UI
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Rookie Shop", Version = "v1" });
            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        Type = SecuritySchemeType.OAuth2,
            //        Flows = new OpenApiOAuthFlows
            //        {
            //            AuthorizationCode = new OpenApiOAuthFlow
            //            {
            //                TokenUrl = new Uri("/connect/token", UriKind.Relative),
            //                AuthorizationUrl = new Uri("/connect/authorize", UriKind.Relative),
            //                Scopes = new Dictionary<string, string> { { "rookieshop.api", "Rookie Shop API" } }
            //            },
            //        },
            //    });
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //                {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            //            },
            //            new List<string>{ "rookieshop.api" }
            //        }
            //                });
            //});
            //services.AddRazorPages();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            // RS: 
            //app.UseIdentityServer();
            app.UseAuthorization();
            app.UseSwagger();
            // RS:
            //app.UseSwaggerUI(c =>
            //{
            //    c.OAuthClientId("swagger");
            //    c.OAuthClientSecret("secret");
            //    c.OAuthUsePkce();
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Rookie V1");
            //});
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Rookie V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                // RS:
                //endpoints.MapRazorPages();
            });
        }
    }
}
