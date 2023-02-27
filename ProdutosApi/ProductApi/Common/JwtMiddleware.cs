using Microsoft.Extensions.Options;
using ProdutosApi.Application.Interfaces;
using ProdutosApi.Infrastructure.Common;
using ProdutosApi.Infrastructure.Common.Interfaces;
using ProdutosApi.Infrastructure.CrossCutting.Model;

namespace ProductApi.Common
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task InvokeAsync(HttpContext context, IAuthAppService authAppService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = authAppService.GetUserbyIdAsync(Convert.ToInt32(userId));

            }

            await _next(context);

        }
    }
}
