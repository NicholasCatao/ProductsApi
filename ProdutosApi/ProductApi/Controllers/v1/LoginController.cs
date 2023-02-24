using Microsoft.AspNetCore.Mvc;
using ProdutosApi.Application.DTO.DTO;
using ProdutosApi.Application.Interfaces;
using ProdutosApi.Domain.Interfaces;
using ProdutosApi.Domain.Response;
using ProdutosApi.Domain.Resquest;
using ProdutosApi.Model;

namespace ProductApi.Controllers.v1
{
    public class LoginController : Controller
    {
        private readonly IAuthAppService _authAppService;

        public LoginController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        [HttpPost("v1/Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticateResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            var userResult = await _authAppService.GetToken(user.Email, user.Password);


            return BadRequest();


            return null;
        }
    }
}
