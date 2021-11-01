using eInvoice.Models.AppSettings;
using eInvoice.Models.Enums;
using eInvoice.Models.Models;
using eInvoice.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.WebAPI.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate next;
        private readonly Jwt jwtSettings;
        private readonly Apis apiSettings;

        public AuthenticationMiddleware(RequestDelegate next, IOptions<Jwt> jwtSettings, IOptions<Apis> apiSettings)
        {
            this.next = next;
            this.jwtSettings = jwtSettings.Value;
            this.apiSettings = apiSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, userService, token);

            await next(context);
        }

        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(jwtSettings.Key);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetById(userId);
            }
            catch
            {
                // check for token issuer if jwt validation fails
                var securityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var issClaim = securityToken.Claims.First(c => c.Type == "iss").Value;
                var clientId = securityToken.Claims.First(c => c.Type == "client_id").Value;
                if (issClaim.Equals(apiSettings.IdentityService, StringComparison.OrdinalIgnoreCase) && clientId.Equals(apiSettings.ClientId, StringComparison.OrdinalIgnoreCase))
                {
                    context.Items["User"] = new User
                    {
                        Username = clientId,
                        Role = UserRole.Admin
                    };
                }
            }
        }
    }
}
