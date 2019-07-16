using Flunt.Notifications;
using StaminaApp.Core.Commands;
using StaminaApp.Core.Handler;
using StaminaApp.Domain.Enum;
using StaminaApp.Domain.Funcionarios.Commands;
using StaminaApp.Domain.Funcionarios.Entidades;
using StaminaApp.Domain.ObjetoValores;
using StaminaApp.Domain.Repositorios;

namespace StaminaApp.Domain.Funcionarios.Handlers
{
    public class PessoaHandler :
        Notifiable,
        IHandler<ComandoInserirPessoa>
    {

        private readonly IFuncionarioRepositorio _repositorio;

        public PessoaHandler(IFuncionarioRepositorio repositorio){
            _repositorio = repositorio;
        }

        public ICommandResult Handler(ComandoInserirPessoa command)
        {
            command.Validate();
            if(command.Invalid){
                //return new CommandResult(false,"Não foi possível cadastrar está pessoa");
            }

            if(_repositorio.ExisteCpf(command.Cpf)){
                AddNotification("Cpf","Este CPF já foi cadastrado");
            }

            var nome = new Nome(command.PrimeiroNome,command.SegundoNome);
            var cpf = new Documento(command.Cpf,ETipoDocumento.CPF);
            var rg = new Documento(command.Cpf,ETipoDocumento.RG);
            var pessoa = new Pessoa(nome,cpf,rg,command.Sexo,command.DataNascimento);

            throw new System.NotImplementedException();
        }
    }
}