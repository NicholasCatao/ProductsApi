using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ProdutosApi.Application.DTO.DTO;
using ProdutosApi.Application.Interfaces;
using ProdutosApi.Domain.Resquest;
using ProdutosApi.Domain.Validators;
using ProdutosApi.Model;

namespace ProductApi.Controllers.v1
{
    public class ProdutosController : Controller
    {
        [Route("v1/produto")]

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Produto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> ObterProdutosAsync([FromServices] IProdutoAppService produtoAppService, [FromQuery] FiltroProduto filtroProduto)
        {
            var result = await produtoAppService.ObterProdutosAsync(filtroProduto);
            return result != null ? Ok(result) : NoContent();
        }


        [HttpGet("v1/produto/{codigoProduto}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> ObterProdutoAsync([FromServices] IProdutoAppService produtoAppService, [FromRoute] int codigoProduto)
        {
            var result = await produtoAppService.ObterProdutoAsync(codigoProduto);
            return result != null ? Ok(result) : NoContent();
        }

        [HttpPost("v1/produto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> CadastrarProdutoAsync([FromServices] IProdutoAppService produtoAppService, [FromBody, CustomizeValidator(RuleSet = ValidationRules.Incluir)] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var result = await produtoAppService.CadastrarProdutoAsync(produto);
            return result is 0 ? NoContent() : Ok(result);
        }

        [HttpPut("v1/produto/{codigoProduto}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> AlterarProdutoAsync([FromServices] IProdutoAppService produtoAppService, [FromRoute] int codigoProduto, [FromBody, CustomizeValidator(RuleSet = ValidationRules.Alterar)] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var result = await produtoAppService.AlterarProdutoAsync(produto, codigoProduto);
            return result is true ? Ok(result) : NoContent();
        }


        [HttpDelete("v1/produto/{codigoProduto}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> CancelarProdutoAsync([FromServices] IProdutoAppService produtoAppService, [FromRoute] int codigoProduto, bool situacao)
        {
            var result = await produtoAppService.CancelarProdutoAsync(codigoProduto, situacao);
            return result is true ? Ok(result) : NoContent();
        }
    }
}
