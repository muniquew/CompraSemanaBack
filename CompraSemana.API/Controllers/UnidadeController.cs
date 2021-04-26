using CompraSemana.Core.Service.DTO;
using CompraSemana.Core.Service.Interfaces;
using CompraSemana.Core.Util.Exception;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Get()
        {
            return Ok(await _unidadeService.ObterTodasUnidades());
        }

        [HttpGet("{id}")]
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
        public async Task<IActionResult> Post([FromBody] UnidadeDTO unidade)
        {
            return Ok(await _unidadeService.Adicionar(unidade));
        }

        [HttpPut("{id}")]
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
