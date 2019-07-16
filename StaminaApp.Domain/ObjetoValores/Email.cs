using Flunt.Validations;
using StaminaApp.Core.ObjetoValores;

namespace StaminaApp.Domain.ObjetoValores
{
    public class Email : ObjetoValor
    {
        public Email(string endereco)
        {
            Endereco = endereco;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Endereco,"Email.Endereco","E-mail inválido")
            );
        }

        public string Endereco { get; private set; }
    }
}