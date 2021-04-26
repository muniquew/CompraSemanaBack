using AutoMapper;
using CompraSemana.Core.Data.Interfaces;
using CompraSemana.Core.Models;
using CompraSemana.Core.Service.DTO;
using CompraSemana.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraSemana.Core.Service
{
    public class UnidadeService : IUnidadeService
    {
        private readonly IUnidadeRepository _unidadeRepository;
        private readonly IMapper _mapper;

        public UnidadeService(IUnidadeRepository unidadeRepository, IMapper mapper)
        {
            _unidadeRepository = unidadeRepository;
            _mapper = mapper;
        }

        public async Task<UnidadeDTO> ObterUnidadePorId(int id)
        {
            var unidade = await _unidadeRepository.ConsultarUnico(id);
            return _mapper.Map<UnidadeDTO>(unidade);
        }

        public async Task<IEnumerable<UnidadeDTO>> ObterTodasUnidades()
        {
            var unidades = await _unidadeRepository.ConsultarTodos();

            if (unidades != null)
            {
                return _mapper.Map<ICollection<UnidadeDTO>>(unidades);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Adicionar(UnidadeDTO unidade)
        {
            var _unidade = _mapper.Map<UnidadeDTO, Unidade>(unidade);
            return await _unidadeRepository.Adicionar(_unidade);
        }

        public async Task<bool> Atualizar(UnidadeDTO unidade)
        {
            var _unidade = _mapper.Map<UnidadeDTO, Unidade>(unidade);
            return await _unidadeRepository.Atualizar(_unidade);
        }

        public async Task<bool> Deletar(int id)
        {
            return await _unidadeRepository.Deletar(id);
        }
    }
}
