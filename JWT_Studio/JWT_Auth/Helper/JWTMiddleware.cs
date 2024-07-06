using Microsoft.Extensions.Options;
using JWT_Auth.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JWT_Auth.Helper
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSetting _appSetting;

        public JWTMiddleware(RequestDelegate next, IOptions<AppSetting> appSetting)
        {
            _next = next;
            _appSetting = appSetting.Value;
          
        }
        public async Task Invoke(HttpContext context,IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, userService, token);
            
            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenhandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
                tokenhandler.ValidateToken(token, new TokenValidationParameters
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
            }
        }
    }
}
