using System;
using AutoMapper;
using StaminaApp.Domain.Compania.Entidades;

namespace StaminaApp.Infra.Entidades.Compania
{
    public class SetorDTO : DTO<Setor,SetorDTO>
    {
        public int Id { get; set; }
        public int IdCentroCusto { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }

        public SetorDTO GetDto(Setor entidade)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<Setor, SetorDTO>()
                .ForMember(dest => dest.IdCentroCusto, opt => opt.MapFrom(src => src.CentroCusto.Id))
            );
            var mapper = config.CreateMapper();
            return mapper.Map<SetorDTO>(entidade);
        }
    }
}