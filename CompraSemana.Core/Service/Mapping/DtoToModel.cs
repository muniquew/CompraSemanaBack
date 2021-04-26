using AutoMapper;
using CompraSemana.Core.Models;
using CompraSemana.Core.Service.DTO;

namespace CompraSemana.Core.Service.Mapping
{
    public class DtoToModel : Profile
    {
        public DtoToModel()
        {
            CreateMap<CategoriaDTO, Categoria>();
            CreateMap<UnidadeDTO, Unidade>();
        }
    }
}
