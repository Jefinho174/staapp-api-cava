using Flunt.Validations;
using StaminaApp.Core.Entidades;

namespace StaminaApp.Domain.Funcionarios.Entidades
{
    public class Cargo : Entidade
    {
        public Cargo(string titulo, string descricao, int nivel)
        {
            Titulo = titulo;
            Descricao = descricao;
            Nivel = nivel;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Titulo,1,"Cargo.Titulo","Titulo deve conter pelo menos 2 caracteres")
                .HasMaxLen(Titulo,50,"Cargo.Titulo","Nome deve conter até 50 caracteres")
                .HasMaxLen(Descricao,100,"Cargo.Descricao","Nome deve conter até 100 caracteres")
            );
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public int Nivel { get; private set; }
    }
}