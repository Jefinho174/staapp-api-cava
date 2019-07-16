using Flunt.Validations;
using StaminaApp.Core.ObjetoValores;

namespace StaminaApp.Domain.ObjetoValores
{
    public class Nome : ObjetoValor
    {
        public Nome(string primeiroNome, string segundoNome)
        {
            PrimeiroNome = primeiroNome;
            SegundoNome = segundoNome;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(PrimeiroNome,2,"Nome.PrimeiroNome","Nome deve conter pelo menos 2 caracteres")
                .HasMinLen(SegundoNome,2,"Nome.SegundoNome","Nome deve conter pelo menos 2 caracteres")
                .HasMaxLen(PrimeiroNome,50,"Nome.SegundoNome","Nome deve conter até 50 caracteres")
                .HasMaxLen(SegundoNome,50,"Nome.SegundoNome","Nome deve conter até 50 caracteres")
            );
        }

        public string PrimeiroNome { get; private set; }
        public string SegundoNome { get; private set; }
        
    }
}