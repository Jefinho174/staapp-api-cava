using StaminaApp.Core.ObjetoValores;
using StaminaApp.Domain.Enum;

namespace StaminaApp.Domain.ObjetoValores
{
    public class Documento : ObjetoValor
    {
        public Documento(string numero, ETipoDocumento tipo)
        {
            Numero = numero;
            Tipo = tipo;
        }

        public string Numero { get; private set; }
        public ETipoDocumento Tipo { get; private set; }

        private bool Validar(){
            if (Tipo == ETipoDocumento.CNPJ && Numero.Length == 14)
                return true;

            if (Tipo == ETipoDocumento.CPF && Numero.Length == 11)
                return true;
            return false;
        }
    }
}