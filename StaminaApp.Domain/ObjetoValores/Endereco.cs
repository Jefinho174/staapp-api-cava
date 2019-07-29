using Flunt.Validations;
using StaminaApp.Core.ObjetoValores;

namespace StaminaApp.Domain.ObjetoValores
{
    public class Endereco : ObjetoValor
    {
        public Endereco(string rua, int numero, string bairro, string cidade, string estato, string pais, string codigoPostal, string complemento)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estato = estato;
            Pais = pais;
            CodigoPostal = codigoPostal;
            Complemento = complemento;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterOrEqualsThan(Numero,0,"Endereco.Numero","Numero deve ser maior que zero.")
                .HasMaxLen(Rua,100,"Endereco.Rua","Rua deve conter até 100 caracteres")
                .HasMaxLen(Bairro,100,"Endereco.Bairro","Bairro deve conter até 100 caracteres")
                .HasMaxLen(Cidade,50,"Endereco.Cidade","Cidade deve conter até 50 caracteres")
                .HasMaxLen(Estato,50,"Endereco.Estato","Estato deve conter até 50 caracteres")
                .HasMaxLen(Pais,50,"Endereco.Pais","Pais deve conter até 50 caracteres")
                .HasMaxLen(CodigoPostal,50,"Endereco.CodigoPostal","Nome deve conter até 50 caracteres")
                .HasMaxLen(Complemento,100,"Endereco.Complemento","Complemento deve conter até 50 caracteres")
            );
        }

        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estato { get; private set; }
        public string Pais { get; private set; }
        public string CodigoPostal { get; private set; }
        public string Complemento { get; private set; }
    }
}