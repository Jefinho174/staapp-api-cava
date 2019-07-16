using Flunt.Validations;
using StaminaApp.Core.Entidades;

namespace StaminaApp.Domain.Compania.Entidades
{
    public class CentroCusto : Entidade
    {
        public CentroCusto(string codigoControCusto, string descricao)
        {
            CodigoControCusto = codigoControCusto;
            Descricao = descricao;

            AddNotifications(new Contract()
                .HasMinLen(CodigoControCusto, 1, "CentroCusto.CodigoControCusto", "Código do contro de custo deve conter pelo menos 1 caracteres")
                .HasMaxLen(CodigoControCusto, 50, "CentroCusto.CodigoControCusto", "Código do contro de custo deve conter até 50 caracteres")
                .HasMaxLen(Descricao, 100, "CentroCusto.Descricao", "Descrição deve conter até 50 caracteres")
            );
        }

        public string CodigoControCusto { get; private set; }
        public string Descricao { get; private set; }
    }
}