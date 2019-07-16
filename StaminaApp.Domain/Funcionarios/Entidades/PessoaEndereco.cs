using Flunt.Validations;
using StaminaApp.Core.Entidades;
using StaminaApp.Domain.ObjetoValores;

namespace StaminaApp.Domain.Funcionarios.Entidades
{
    public class PessoaEndereco : Entidade
    {
        public PessoaEndereco(Pessoa pessoa, Endereco endereco, string observacao)
        {
            Pessoa = pessoa;
            Endereco = endereco;
            Observacao = observacao;
            AddNotifications(Pessoa,Endereco);
        }

        public Pessoa Pessoa { get; private set; }
        public Endereco Endereco { get; set; }
        public string Observacao { get; set; }
    }
}