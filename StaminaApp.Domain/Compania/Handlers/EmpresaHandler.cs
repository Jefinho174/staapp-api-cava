using Flunt.Notifications;
using StaminaApp.Core.Commands;
using StaminaApp.Core.Handler;
using StaminaApp.Domain.Compania.Commands;
using StaminaApp.Domain.Compania.Entidades;
using StaminaApp.Domain.Enum;
using StaminaApp.Domain.ObjetoValores;
using StaminaApp.Domain.Repositorios;

namespace StaminaApp.Domain.Compania.Handlers
{
    public class EmpresaHandler :
        Notifiable,
        IHandler<CadastrarEmpresaCommand>
    {

        private readonly IEmpresaRepositorio _repositorio;
        
        public EmpresaHandler(IEmpresaRepositorio repositorio){
            _repositorio = repositorio;
        }

        public ICommandResult Handler(CadastrarEmpresaCommand command)
        {
            var resposta = new CommandResult();
            command.Validate();
            if(command.Invalid){
                foreach (var notification in command.Notifications)
                {
                    resposta.AddNotificacoes(notification.Message);
                }
                resposta.Message = "Não foi possível realizar cadastro da empresa";
                resposta.Success = false;
                resposta.CodigoResposta = "EMP01";
                return resposta;
            }

            Documento cnpj = new Documento(command.Cnpj,ETipoDocumento.CNPJ);
            Documento inscricaoEstadual = new Documento(command.InscricaoEstadual,ETipoDocumento.INSCRICAO_ESTADUAL);
            Documento inscricaoMunicipal = new Documento(command.InscricaoMunicipal,ETipoDocumento.INSCRICAO_MUNICIPAL);
            
            Endereco endereco = new Endereco(command.Rua,command.Numero,command.Bairro,command.Cidade,command.Estato,command.Pais,command.CodigoPostal,command.Complemento);
            Empresa empresa = new Empresa(command.RazaoSocial,cnpj,inscricaoEstadual,inscricaoMunicipal,endereco);
            if(empresa.Valid){
                if(_repositorio.CadastrarEmpresa(empresa)){
                    resposta.CodigoResposta = "SMP01";
                    resposta.Success = true;
                    resposta.Message = "Empresa cadastrada com sucesso";
                }
            }else{
                foreach (var notification in empresa.Notifications)
                {
                    resposta.AddNotificacoes(notification.Message);
                }
                resposta.Message = "Não foi possível realizar cadastro da empresa";
                resposta.Success = false;
                resposta.CodigoResposta = "EMP02";
            }
            return resposta;
        }
    }
}