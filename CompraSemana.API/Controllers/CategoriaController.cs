using CompraSemana.Core.Service.DTO;
using CompraSemana.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using CompraSemana.Core.Util.Exception;

namespace CompraSemana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        /// <summary>
        /// Buscar todas categorias
        /// </summary>
        /// <returns>Lista de categorias</returns>
        /// GET: api/categoria
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoriaService.ObterTodasCategorias());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoriaService.ObterCategoriaPorId(id);

            if (result == null)
            {
                throw new ServiceException("A categoria solicitada não foi localizada.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaDTO categoria)
        {
            return Ok(await _categoriaService.Adicionar(categoria));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoriaDTO categoria)
        {
            if (id != categoria.Id)
            {
                throw new ServiceException("A categoria informada não foi localizada.");
            }

            var _categoria = await _categoriaService.ObterCategoriaPorId(id);

            if (_categoria == null)
            {
                throw new ServiceException("A categoria informada não foi localizada.");
            }

            return Ok(await _categoriaService.Atualizar(categoria));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var _categoria = await _categoriaService.ObterCategoriaPorId(id);

            if (_categoria == null)
            {
                throw new ServiceException("A categoria informada não foi localizada.");
            }

            return Ok(await _categoriaService.Deletar(id));
        }

    }


}
