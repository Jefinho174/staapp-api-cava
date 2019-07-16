using System;
using Flunt.Validations;
using StaminaApp.Core.Entidades;
using StaminaApp.Domain.Enum;

namespace StaminaApp.Domain.Inventario.Entidades
{
    public class Item : Entidade
    {
        public Item(string codigoPatrimonial, Fabricante fabricante, Categoria categoria, EStatusProduto statusProduto, string numeroSerie, string modelo, EEstadoConservacao estadoConservacao, int anoFabricacao, DateTime dataAquisicao, int numeroNota, decimal depreciacaoAnual,decimal valor)
        {
            CodigoPatrimonial = codigoPatrimonial;
            Fabricante = fabricante;
            Categoria = categoria;
            StatusProduto = statusProduto;
            NumeroSerie = numeroSerie;
            Modelo = modelo;
            EstadoConservacao = estadoConservacao;
            AnoFabricacao = anoFabricacao;
            DataAquisicao = dataAquisicao;
            NumeroNota = numeroNota;
            DepreciacaoAnual = depreciacaoAnual;
            Valor = valor;

            AddNotifications(Fabricante,Categoria,new Contract()
                .Requires()
                .HasMinLen(CodigoPatrimonial,1,"Item.CodigoPatrimonial","Codígo patrimonial deve conter pelo menos 1 caracteres")
                .HasMaxLen(NumeroSerie,50,"Item.NumeroSerie","Numero série deve até 50 caracteres")
                .HasMaxLen(Modelo,50,"Item.Modelo","Numero série deve até 50 caracteres")
            );
        }

        public string CodigoPatrimonial { get; private set; }
        public Fabricante Fabricante { get; private set; }
        public Categoria Categoria { get; private set; }
        public EStatusProduto StatusProduto { get; private set; }
        public string NumeroSerie { get; private set; }
        public string Modelo { get; private set; }
        public EEstadoConservacao EstadoConservacao { get; private set; }
        public int AnoFabricacao { get; private set; }
        public DateTime DataAquisicao { get; private set; }
        public int NumeroNota { get; private set; }
        public decimal DepreciacaoAnual { get; private set; }
        public decimal Valor { get; private set; }
    }
}