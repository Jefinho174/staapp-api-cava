using StaminaApp.Core.Entidades;
using StaminaApp.Domain.ObjetoValores;

namespace StaminaApp.Domain.Funcionarios.Entidades
{
    public class Contato : Entidade
    {
        public Contato(Pessoa pessoa, Email email, Telefone telefone, string observacao)
        {
            Pessoa = pessoa;
            Email = email;
            Telefone = telefone;
            Observacao = observacao;
            AddNotifications(Pessoa,Email,Telefone);
        }

        public Pessoa Pessoa { get; private set; }
        public Email Email { get; set; }
        public Telefone Telefone { get; set; }
        public string Observacao { get; private set; }
    }
}