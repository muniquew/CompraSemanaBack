using AutoMapper;
using CompraSemana.Core.Models;
using CompraSemana.Core.Service.DTO;

namespace CompraSemana.Core.Service.Mapping
{
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<Unidade, UnidadeDTO>();
        }
    }
}
