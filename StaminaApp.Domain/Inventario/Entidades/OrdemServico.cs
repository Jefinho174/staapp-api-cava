using System;
using Flunt.Validations;
using StaminaApp.Core.Entidades;

namespace StaminaApp.Domain.Inventario.Entidades
{
    public class OrdemServico : Entidade
    {
        public OrdemServico(PrestadorServico prestador, string numero, DateTime dataInicio, DateTime dataFim, string descricao, decimal valor)
        {
            Prestador = prestador;
            Numero = numero;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Descricao = descricao;
            Valor = valor;

             AddNotifications(Prestador,new Contract()
                .Requires()
                .HasMaxLen(Numero,50,"OrdemServico.Numero","Numero deve até 50 caracteres")
            );
        }

        public PrestadorServico Prestador { get; private set; }
        public string Numero { get; private set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
    }
}