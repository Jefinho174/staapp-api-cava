using Flunt.Validations;
using StaminaApp.Core.Entidades;

namespace StaminaApp.Domain.Funcionarios.Entidades
{
    public class Profissao : Entidade
    {
        public Profissao(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Titulo,1,"Cargo.Titulo","Titulo deve conter pelo menos 2 caracteres")
                .HasMaxLen(Titulo,50,"Cargo.Titulo","Nome deve conter até 50 caracteres")
                .HasMaxLen(Descricao,100,"Cargo.Descricao","Nome deve conter até 100 caracteres")
            );
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
    }
}