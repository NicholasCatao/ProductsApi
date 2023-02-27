using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProdutosApi.Application.DTO.DTO;
using ProdutosApi.Application.Interfaces;
using ProdutosApi.Domain.Enums;
using ProdutosApi.Domain.Interfaces;
using ProdutosApi.Domain.Resquest;
using ProdutosApi.Domain.Validators;
using ProdutosApi.Model;

namespace ProductApi.Controllers.v1
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoValidator _produtoValidator;
        private readonly IProdutoAppService _produtoAppService;

        public ProdutosController(IProdutoValidator produtoValidator, IProdutoAppService produtoAppService)
        {
            _produtoValidator = produtoValidator;
            _produtoAppService = produtoAppService;
        }

        [Route("v1/produto")]

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Produto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> ObterProdutosAsync([FromQuery] FiltroProduto filtroProduto)
        {
            var result = await _produtoAppService.ObterProdutosAsync(filtroProduto);
            return result != null ? Ok(result) : NoContent();
        }


        [HttpGet("v1/produto/{codigoProduto}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> ObterProdutoAsync([FromRoute] int codigoProduto)
        {
            var result = await _produtoAppService.ObterProdutoAsync(codigoProduto);
            return result != null ? Ok(result) : NoContent();
        }

        [HttpPost("v1/produto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> CadastrarProdutoAsync([FromBody] Produto produto)
        {
            var validation = await _produtoValidator.ValidateAsync(produto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors?.Select(e => e.ErrorMessage));
            }


            var result = await _produtoAppService.CadastrarProdutoAsync(produto);
            return result is 0 ? NoContent() : Ok(result);
        }

        [HttpPut("v1/produto/{codigoProduto}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> AlterarProdutoAsync([FromRoute] int codigoProduto, [FromBody] Produto produto)
        {
            var validation = await _produtoValidator.ValidateAsync(produto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors?.Select(e => e.ErrorMessage));
            }

            var result = await _produtoAppService.AlterarProdutoAsync(produto, codigoProduto);
            return result is true ? Ok(result) : NoContent();
        }


        [HttpDelete("v1/produto/{codigoProduto}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> CancelarProdutoAsync([FromRoute] int codigoProduto, bool situacao)
        {
            var result = await _produtoAppService.CancelarProdutoAsync(codigoProduto, situacao);
            return result is true ? Ok(result) : NoContent();
        }
    }
}
