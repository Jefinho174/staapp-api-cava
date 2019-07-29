using System;
using AutoMapper;
using StaminaApp.Domain.Compania.Entidades;

namespace StaminaApp.Infra.Entidades.Compania
{
    public class EmpresaDTO : DTO<Empresa,EmpresaDTO>
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estato { get; set; }
        public string Pais { get; set; }
        public string CodigoPostal { get; set; }
        public string Complemento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }

        public EmpresaDTO GetDto(Empresa entidade)
        {
                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Empresa, EmpresaDTO>()
                                                    .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj.Numero))
                                                    .ForMember(dest => dest.InscricaoEstadual, opt => opt.MapFrom(src => src.InscricaoEstadual.Numero))
                                                    .ForMember(dest => dest.InscricaoMunicipal, opt => opt.MapFrom(src => src.InscricaoMunicipal.Numero))
                                                    .ForMember(dest => dest.Rua, opt => opt.MapFrom(src => src.Endereco.Rua))
                                                    .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Endereco.Numero))
                                                    .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Endereco.Bairro))
                                                    .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Endereco.Cidade))
                                                    .ForMember(dest => dest.Estato, opt => opt.MapFrom(src => src.Endereco.Estato))
                                                    .ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.Endereco.Pais))
                                                    .ForMember(dest => dest.CodigoPostal, opt => opt.MapFrom(src => src.Endereco.CodigoPostal))
                                                    .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => src.Endereco.Complemento))
                                                );
            var mapper = config.CreateMapper();
            return mapper.Map<EmpresaDTO>(entidade);
        }
    }

    
}