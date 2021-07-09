using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using YCC.Data.Entities;

namespace YCC.BackendApi.IdentityServer
{
    public class CustomProfileService : IProfileService
    {
        private readonly ILogger<CustomProfileService> _logger;
        private readonly UserManager<AppUser> _userManager;
        public CustomProfileService(UserManager<AppUser> userManager,
            ILogger<CustomProfileService> logger)
        {
            _logger = logger;
            _userManager = userManager;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject?.GetSubjectId();
            if (sub == null)
            {
                throw new Exception("No sub claim present");
            }
            var user = await _userManager.FindByIdAsync(sub);
            if (user == null)
            {
                _logger.LogWarning("No user found matching subject Id: {0}", sub);
            }
            else
            {
                //them custom zo claim, mac dinh k co role
                var claims = new List<Claim>
                {
                    //new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString(CultureInfo.InvariantCulture)),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString("eee")),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString("eee")),
                    new Claim(JwtClaimTypes.Name, user.Email),
                    new Claim(JwtClaimTypes.Email, user.Email),
                };
                //_userManager expose ra cua ID4, lay ra cai role
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var userRole in userRoles)
                {
                    //tao ra Claim voi role moi lay ra
                    //de check coi user co dung role admin k
                    claims.Add(new Claim(JwtClaimTypes.Role, userRole));
                }

                context.IssuedClaims.AddRange(claims);
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}
