using AutoMapper;
using CompraSemana.Core.Service.Mapping;

namespace CompraSemana.Core.Service.DTO
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToDtoProfile());
                cfg.AddProfile(new DtoToModel());
            });
        }
    }
}
