using Flunt.Validations;
using StaminaApp.Core.Entidades;

namespace StaminaApp.Domain.Inventario.Entidades
{
    public class Categoria : Entidade
    {
        public Categoria(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Titulo,1,"Categoria.Titulo","Categoria deve conter pelo menos 1 caracteres")
                .HasMaxLen(Titulo,50,"Categoria.Titulo","Categoria deve até 50 caracteres")
                .HasMaxLen(Descricao,100,"Categoria.Titulo","Descrição deve até 100 caracteres")
            );
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
    }
}