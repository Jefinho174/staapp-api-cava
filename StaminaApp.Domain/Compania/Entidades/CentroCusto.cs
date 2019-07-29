using System;
using Flunt.Validations;
using StaminaApp.Core.Entidades;

namespace StaminaApp.Domain.Compania.Entidades
{
    public class CentroCusto : Entidade
    {
        protected CentroCusto(){}
        public CentroCusto(string codigoControCusto, string descricao)
        {
            CodigoControCusto = codigoControCusto;
            Descricao = descricao;

            AddNotifications(new Contract()
                .HasMaxLen(CodigoControCusto, 50, "CentroCusto.CodigoControCusto", "Código do contro de custo deve conter até 50 caracteres")
                .HasMaxLen(Descricao, 100, "CentroCusto.Descricao", "Descrição deve conter até 50 caracteres")
            );
        }

        public string CodigoControCusto { get; private set; }
        public string Descricao { get; private set; }

        public static class CentroCustoFactory
        {
            public static CentroCusto NewObject(int id,string codigoControCusto, string descricao, DateTime dataCadastro, DateTime dataFinalizaacao){
                return new CentroCusto{
                    Id = id,
                    CodigoControCusto = codigoControCusto,
                    Descricao = descricao,
                    DataCriacao = dataCadastro,
                    DataFinalizacao = dataFinalizaacao
                };
            }
        }
    }
}