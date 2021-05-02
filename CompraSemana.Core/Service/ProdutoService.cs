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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> ObterProdutoPorId(int id)
        {
            var produto = await _produtoRepository.ConsultarUnico(id);
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterTodosProdutos()
        {
            var produtos = await _produtoRepository.ConsultarTodos();

            if (produtos != null)
            {
                return _mapper.Map<ICollection<ProdutoDTO>>(produtos);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Adicionar(ProdutoDTO produto)
        {
            var _produto = _mapper.Map<ProdutoDTO, Produto>(produto);
            return await _produtoRepository.Adicionar(_produto);
        }

        public async Task<bool> Atualizar(ProdutoDTO produto)
        {
            var _produto = _mapper.Map<ProdutoDTO, Produto>(produto);
            return await _produtoRepository.Atualizar(_produto);
        }

        public async Task<bool> Deletar(int id)
        {
            return await _produtoRepository.Deletar(id);
        }
    }
}
