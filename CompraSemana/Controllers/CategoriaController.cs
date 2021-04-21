using AutoMapper;
using CompraSemana.Core.Service.DTO;
using CompraSemana.Core.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<IEnumerable<CategoriaDTO>> Get()
        {
            return await _categoriaService.ObterTodasCategorias();
        }

        [HttpGet("{id}")]
        public async Task<CategoriaDTO> Get(int id)
        {
            return await _categoriaService.ObterCategoriaPorId(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaDTO categoria)
        {
            return Ok(await _categoriaService.Adicionar(categoria));
        }

    }


}
