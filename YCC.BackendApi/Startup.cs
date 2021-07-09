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
            // RS: Add ASP Identity(NOT AddDefaultIdentity)
            services.AddIdentity<AppUser, AppRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<YCCDbContext>()
                .AddDefaultTokenProviders();
            // RS: Add IdentityServer4
            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            })
            .AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources)
            .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
            .AddInMemoryClients(IdentityServerConfig.Clients)
            .AddAspNetIdentity<AppUser>()
            .AddProfileService<CustomProfileService>()
            .AddDeveloperSigningCredential();

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
            //services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();
            //services.AddTransient<IValidator<RegisterRequest>, RegisterRequestValidator>();
            //services.AddControllers()
            //    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());
            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/CustomAuthentication/Login";
            });
            services.AddAuthentication()
                .AddLocalApi("Bearer", option =>
                {
                    option.ExpectedScope = "rookieshop.api";
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(LocalApi.PolicyName, policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireAuthenticatedUser();
                });

                options.AddPolicy("ADMIN_ROLE_POLICY", policy =>
                    policy.Requirements.Add(new AdminRoleRequirement()));
            });
            // RS
            services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());
            // RS: Add Authentication and Scope to Swagger UI
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Movies Demo", Version = "v1" });
                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                //      Enter 'Bearer' [space] and then your token in the text input below.
                //      \r\n\r\nExample: 'Bearer 12345abcdef'",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer"
                //});
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri("/connect/token", UriKind.Relative),
                            AuthorizationUrl = new Uri("/connect/authorize", UriKind.Relative),
                            Scopes = new Dictionary<string, string> { { "rookieshop.api", "Rookie Shop API" } }
                        },
                    },
                });
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                //  {
                //    {
                //      new OpenApiSecurityScheme
                //      {
                //        Reference = new OpenApiReference
                //          {
                //            Type = ReferenceType.SecurityScheme,
                //            Id = "Bearer"
                //          },
                //          Scheme = "oauth2",
                //          Name = "Bearer",
                //          In = ParameterLocation.Header,
                //        },
                //        new List<string>()
                //      }
                //    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>{ "rookieshop.api" }
                    }
                            });
            });
            services.AddRazorPages();

            //string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            //string signingKey = Configuration.GetValue<string>("Tokens:Key");
            //byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

            //services.AddAuthentication(opt =>
            //{
            //    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.RequireHttpsMetadata = false;
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuer = true,
            //        ValidIssuer = issuer,
            //        ValidateAudience = true,
            //        ValidAudience = issuer,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ClockSkew = System.TimeSpan.Zero,
            //        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
            //    };
            //});
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId("swagger");
                c.OAuthClientSecret("secret");
                c.OAuthUsePkce();
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Movies Demo V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=CustomAuthentication}/{action=Login}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
