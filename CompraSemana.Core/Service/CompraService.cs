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
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IMapper _mapper;

        public CompraService(ICompraRepository compraRepository, IMapper mapper)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
        }

        public async Task<CompraDTO> ObterCompraPorId(int id)
        {
            var categoria = await _compraRepository.ConsultarUnico(id);
            return _mapper.Map<CompraDTO>(categoria);
        }

        public async Task<IEnumerable<CompraDTO>> ObterTodasCompras()
        {
            var compras = await _compraRepository.ConsultarTodos();

            if (compras != null)
            {
                return _mapper.Map<ICollection<CompraDTO>>(compras);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Adicionar(CompraDTO compra)
        {
            var _compra = _mapper.Map<CompraDTO, Compra>(compra);
            return await _compraRepository.Adicionar(_compra);
        }

        public async Task<bool> Atualizar(CompraDTO compra)
        {
            var _compra = _mapper.Map<CompraDTO, Compra>(compra);
            return await _compraRepository.Atualizar(_compra);
        }

        public async Task<bool> Deletar(int id)
        {
            return await _compraRepository.Deletar(id);
        }
    }
}
