using CompraSemana.Core.Service.DTO;
using CompraSemana.Core.Service.Interfaces;
using CompraSemana.Core.Util.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompraSemana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _produtoService.ObterTodosProdutos());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _produtoService.ObterProdutoPorId(id);

            if (result == null)
            {
                throw new ServiceException("O produto solicitado não foi localizado.");
            }

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [Consumes("application/json")]
        public async Task<IActionResult> Post([FromBody] ProdutoDTO produto)
        {
            return Ok(await _produtoService.Adicionar(produto));
        }

        [HttpPut("{id}")]
        [Authorize]
        [Consumes("application/json")]
        public async Task<IActionResult> Update(int id, ProdutoDTO produto)
        {
            if (id != produto.Id)
            {
                throw new ServiceException("O produto informado não foi localizado.");
            }

            var _categoria = await _produtoService.ObterProdutoPorId(id);

            if (_categoria == null)
            {
                throw new ServiceException("O produto informado não foi localizado.");
            }

            return Ok(await _produtoService.Atualizar(produto));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var _categoria = await _produtoService.ObterProdutoPorId(id);

            if (_categoria == null)
            {
                throw new ServiceException("O produto informado não foi localizado.");
            }

            return Ok(await _produtoService.Deletar(id));
        }
    }
}
