using System;
using Flunt.Validations;
using StaminaApp.Core.Entidades;
using StaminaApp.Domain.Enum;
using StaminaApp.Domain.ObjetoValores;

namespace StaminaApp.Domain.Funcionarios.Entidades
{
    public class Pessoa : Entidade
    {
        public Nome Nome { get; private set; }
        public Documento Cpf { get; set; }
        public Documento Rg { get; set; }
        public ESexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }

        public Pessoa(Nome nome, Documento cpf, Documento rg, ESexo sexo, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            Rg = rg;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            
            AddNotifications(Cpf,Rg, new Contract()
                .Requires()
                .IsLowerThan(DataNascimento,DateTime.Now,"Pessoa.DataNascimento","Data de nascimento não pode ser futura")
            );
        }
    }
}