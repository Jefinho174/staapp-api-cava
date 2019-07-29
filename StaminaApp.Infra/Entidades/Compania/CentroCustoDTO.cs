using System;
using AutoMapper;
using StaminaApp.Domain.Compania.Entidades;

namespace StaminaApp.Infra.Entidades.Compania
{
    public class CentroCustoDTO : DTO<CentroCusto,CentroCustoDTO>
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string CodigoControCusto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }

        public CentroCustoDTO GetDto(CentroCusto entidade)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CentroCusto, CentroCustoDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<CentroCustoDTO>(entidade);
        }
    }
}