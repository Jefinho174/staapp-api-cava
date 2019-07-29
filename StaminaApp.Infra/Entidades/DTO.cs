using StaminaApp.Core.Entidades;

namespace StaminaApp.Infra.Entidades
{
    public interface  DTO<DomainType,DtoBase> where DomainType : Entidade where DtoBase : class
    {
        DtoBase GetDto(DomainType entidade);
    }
}