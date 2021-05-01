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
    public class UnidadeController : ControllerBase
    {
        private readonly IUnidadeService _unidadeService;

        public UnidadeController(IUnidadeService unidadeService)
        {
            _unidadeService = unidadeService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unidadeService.ObterTodasUnidades());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unidadeService.ObterUnidadePorId(id);

            if (result == null)
            {
                throw new ServiceException("A unidade solicitada não foi localizada.");
            }

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [Consumes("application/json")]
        public async Task<IActionResult> Post([FromBody] UnidadeDTO unidade)
        {
            return Ok(await _unidadeService.Adicionar(unidade));
        }

        [HttpPut("{id}")]
        [Authorize]
        [Consumes("application/json")]
        public async Task<IActionResult> Update(int id, UnidadeDTO unidade)
        {
            if (id != unidade.Id)
            {
                throw new ServiceException("A unidade informada não foi localizada.");
            }

            var _unidade = await _unidadeService.ObterUnidadePorId(id);

            if (_unidade == null)
            {
                throw new ServiceException("A unidade informada não foi localizada.");
            }

            return Ok(await _unidadeService.Atualizar(unidade));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var _categoria = await _unidadeService.ObterUnidadePorId(id);

            if (_categoria == null)
            {
                throw new ServiceException("A unidade informada não foi localizada.");
            }

            return Ok(await _unidadeService.Deletar(id));
        }
    }
}
