using CompraSemana.Core.Data.Interfaces;
using CompraSemana.Core.Models;
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
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Categoria> ObterCategoriaPorId(int id)
        {
            try
            {
                var categoria = await _categoriaRepository.ConsultarUnico(id);

                return categoria;
            }
            catch(Exception)
            {
                return null;
            }
        }
        public async Task<string> ObterTodasCategorias()
        {
            try
            {
                var categorias = await _categoriaRepository.ConsultarTodos();

                if(categorias != null)
                {
                    return JsonConvert.SerializeObject(categorias);
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

        public async Task<bool> Adicionar(string json)
        {
            var categoria = JsonConvert.DeserializeObject<Categoria>(json);
            return await _categoriaRepository.Adicionar(categoria);
        }
    }
}
