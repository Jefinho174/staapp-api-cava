using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using StaminaApp.Core.Commands;

namespace StaminaApp.Domain.Compania.Commands
{
    public class DeletarEmpresaCommand : Notifiable, IRequest<ICommandResult>
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterOrEqualsThan(Id, 0, "Id", "Id Inválido.")
                .HasMaxLen(Cnpj, 50, "Cnpj", "Cnpj deve conter até 50 caracteres")
            );
        }
    }
}