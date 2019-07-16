using System;
using Flunt.Validations;
using StaminaApp.Core.Entidades;
using StaminaApp.Domain.Compania.Entidades;

namespace StaminaApp.Domain.Funcionarios.Entidades
{
    public class Funcionario : Entidade
    {
        public Funcionario(Pessoa pessoa, Setor setor, Cargo cargo, Escolaridade escolaridade, DateTime dataAdmissao, string matricula)
        {
            Pessoa = pessoa;
            Setor = setor;
            Cargo = cargo;
            Escolaridade = escolaridade;
            DataAdmissao = dataAdmissao;
            Matricula = matricula;
            
            AddNotifications(Pessoa,Setor,Cargo,Escolaridade, new Contract()
                .Requires()
                .HasMaxLen(Matricula,100,"Funcionario.Matricula","Matricula deve conter até 100 caracteres")
                .IsGreaterThan(DataAdmissao,DateTime.Now.AddDays(5),"Funcionario.DataAdmissao","Data de Admissão maior que data limite para admissão")
            );
        }

        public Pessoa Pessoa { get; set; }
        public Setor Setor { get; set; }
        public Cargo Cargo { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public DateTime DataAdmissao { get; private set; }
        public string Matricula { get; set; }
    }
}