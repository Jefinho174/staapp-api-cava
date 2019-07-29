using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using StaminaApp.Core.Commands;

namespace StaminaApp.Domain.Compania.Commands
{
    public class EditarCentroCustoCommand : Notifiable, IRequest<ICommandResult>
    {
        public int IdEmpresa { get; set; }
        public int IdControCusto { get; set; }
        public string CodigoControCusto { get; set; }
        public string Descricao { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .IsGreaterOrEqualsThan(IdEmpresa, 0, "IdEmpresa", "Código de empresa não e valido")
                .IsGreaterOrEqualsThan(IdControCusto, 0, "IdEmpresa", "Código do centro de custo não e valido")
                .HasMaxLen(CodigoControCusto, 50, "CodigoControCusto", "Código do contro de custo deve conter até 50 caracteres")
                .HasMaxLen(Descricao, 100, "CentroCusto.Descricao", "Descrição deve conter até 50 caracteres")
            );
        }
    }
}