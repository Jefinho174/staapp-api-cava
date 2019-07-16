using System;
using Flunt.Notifications;
using Flunt.Validations;
using StaminaApp.Core.Commands;
using StaminaApp.Domain.Enum;

namespace StaminaApp.Domain.Funcionarios.Commands
{
    public class ComandoInserirPessoa : Notifiable, ICommand
    {

        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public ESexo Sexo { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(PrimeiroNome,2,"PrimeiroNome","Nome deve conter pelo menos 2 caracteres")
                .HasMinLen(SegundoNome,2,"SegundoNome","Nome deve conter pelo menos 2 caracteres")
                .HasMaxLen(PrimeiroNome,50,"SegundoNome","Nome deve conter até 50 caracteres")
                .HasMaxLen(SegundoNome,50,"SegundoNome","Nome deve conter até 50 caracteres")
                .IsLowerThan(DataNascimento,DateTime.Now,"DataNascimento","Data de nascimento não pode ser futura")
            );
        }
    }
}