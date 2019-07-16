using Flunt.Validations;
using StaminaApp.Core.Entidades;
using StaminaApp.Domain.ObjetoValores;

namespace StaminaApp.Domain.Inventario.Entidades
{
    public class PrestadorServico : Entidade
    {
        public PrestadorServico(string nome, Documento documento, Telefone telefone, Email email, Endereco endereco, string responsavel)
        {
            Nome = nome;
            Documento = documento;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            Responsavel = responsavel;

            AddNotifications(Documento, Endereco, Telefone, Email,Endereco,new Contract()
                .Requires()
                .HasMaxLen(Responsavel,50,"Fabricante.Responsavel","Nome do responsável deve até 50 caracteres")
            );
        }

        public string Nome { get; private set; }
        public Documento Documento { get; private set; }
        public Telefone Telefone { get; private set; }
        public Email Email { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Responsavel { get; private set; }
    }
}