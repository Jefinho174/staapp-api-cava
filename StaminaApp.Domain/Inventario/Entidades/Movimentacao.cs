using System;
using Flunt.Validations;
using StaminaApp.Core.Entidades;
using StaminaApp.Domain.Enum;
using StaminaApp.Domain.Funcionarios.Entidades;

namespace StaminaApp.Domain.Inventario.Entidades
{
    public class Movimentacao : Entidade
    {
        public Movimentacao(Item item, DateTime dataMovimentacao, EStatusMovimentacao statusMovimentacao, Funcionario funcionario)
        {
            Item = item;
            DataMovimentacao = dataMovimentacao;
            StatusMovimentacao = statusMovimentacao;
            Funcionario = funcionario;

            AddNotifications(Item, Funcionario,new Contract()
                .Requires()
            );
        }

        public Item Item { get; private set; }
        public DateTime DataMovimentacao { get; private set; }
        public EStatusMovimentacao StatusMovimentacao { get; private set; }
        public Funcionario Funcionario { get; private set; }
    }
}