using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using StaminaApp.Core.Commands;

namespace StaminaApp.Domain.Compania.Commands
{
    public class EditarEmpresaCommand : Notifiable, IRequest<ICommandResult>
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
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterOrEqualsThan(Id, 0, "Id", "Id Inválido.")
                .HasMinLen(RazaoSocial, 1, "RazaoSocial", "Razao social deve conter pelo menos 1 caracteres")
                .HasMaxLen(RazaoSocial, 100, "RazaoSocial", "Razao social deve conter até 100 caracteres")
                .IsGreaterOrEqualsThan(Numero, 0, "Numero", "Numero deve ser maior que zero.")
                .HasMaxLen(Rua, 100, "Rua", "Rua deve conter até 100 caracteres")
                .HasMaxLen(Bairro, 100, "Bairro", "Bairro deve conter até 100 caracteres")
                .HasMaxLen(Cidade, 50, "Cidade", "Cidade deve conter até 50 caracteres")
                .HasMaxLen(Estato, 50, "Estato", "Estato deve conter até 50 caracteres")
                .HasMaxLen(Pais, 50, "Pais", "Pais deve conter até 50 caracteres")
                .HasMaxLen(CodigoPostal, 50, "CodigoPostal", "Nome deve conter até 50 caracteres")
                .HasMaxLen(Complemento, 100, "Complemento", "Complemento deve conter até 50 caracteres")
            );
        }
    }
}