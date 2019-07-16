using Flunt.Validations;
using StaminaApp.Core.ObjetoValores;

namespace StaminaApp.Domain.ObjetoValores
{
    public class Telefone : ObjetoValor
    {
        public Telefone(int ddd, string numero)
        {
            DDD = ddd;
            Numero = numero;

            AddNotifications(new Contract()
               .Requires()
               .HasMaxLen(Numero, 20, "Telefone.Numero", "Numero deve conter até 20 caracteres")
            );
        }

        public int DDD { get; private set; }
        public string Numero { get; private set; }
    }
}