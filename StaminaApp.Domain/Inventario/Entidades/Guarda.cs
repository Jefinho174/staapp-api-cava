using Flunt.Validations;
using StaminaApp.Core.Entidades;
using StaminaApp.Domain.Funcionarios.Entidades;
using StaminaApp.Domain.ObjetoValores;

namespace StaminaApp.Domain.Inventario.Entidades
{
    public class Guarda : Entidade
    {
        public Guarda(Item item, Funcionario responsavel, Endereco localizacao, string local)
        {
            Item = item;
            Responsavel = responsavel;
            Localizacao = localizacao;
            Local = local;

             AddNotifications(Item, Responsavel,Localizacao,new Contract()
                .Requires()
                .HasMaxLen(Local,250,"Guarda.Local","Local deve até 250 caracteres")
            );
        }

        public Item Item { get; private set; } 
        public Funcionario Responsavel { get; private set; }
        public Endereco  Localizacao { get; private set; }
        public string Local { get; private set; }
    }
}