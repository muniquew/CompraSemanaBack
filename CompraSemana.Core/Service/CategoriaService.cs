using AutoMapper;
using CompraSemana.Core.Data.Interfaces;
using CompraSemana.Core.Models;
using CompraSemana.Core.Service.DTO;
using CompraSemana.Core.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<CategoriaDTO> ObterCategoriaPorId(int id)
        {
            try
            {
                var categoria = await _categoriaRepository.ConsultarUnico(id);

                return _mapper.Map<CategoriaDTO>(categoria);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<CategoriaDTO>> ObterTodasCategorias()
        {
            try
            {
                var categorias = await _categoriaRepository.ConsultarTodos();

                if (categorias != null)
                {
                    return _mapper.Map<ICollection<CategoriaDTO>>(categorias);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Adicionar(CategoriaDTO categoria)
        {
            var _categoria = _mapper.Map<CategoriaDTO, Categoria>(categoria);
            return await _categoriaRepository.Adicionar(_categoria);
        }

        public async Task<bool> Atualizar(CategoriaDTO categoria)
        {
            var _categoria = _mapper.Map<CategoriaDTO, Categoria>(categoria);
            return await _categoriaRepository.Atualizar(_categoria);
        }

        public async Task<bool> Deletar(int id)
        {
            return await _categoriaRepository.Deletar(id);
        }
    }
}
