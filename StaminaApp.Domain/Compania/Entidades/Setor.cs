using Flunt.Validations;
using StaminaApp.Core.Entidades;

namespace StaminaApp.Domain.Compania.Entidades
{
    public class Setor : Entidade
    {
        protected Setor(){}
        public Setor(string titulo, string descricao, CentroCusto centroCusto)
        {
            Titulo = titulo;
            Descricao = descricao;
            CentroCusto = centroCusto;

            AddNotifications(CentroCusto,  new Contract()
                .HasMaxLen(Titulo, 100, "Setor.Titulo", "Título deve conter até 100 caracteres")
                .HasMaxLen(Descricao, 100, "Setor.Descricao", "Descrição deve conter até 1 caracteres")
            );
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public CentroCusto CentroCusto { get; private set; }
    }
}