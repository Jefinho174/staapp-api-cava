using Flunt.Notifications;
using StaminaApp.Core.Commands;
using StaminaApp.Core.Handler;
using StaminaApp.Domain.Compania.Commands;

namespace StaminaApp.Domain.Compania.Handlers
{
    public class EmpresaHandler :
        Notifiable,
        IHandler<CadastrarEmpresaCommand>
    {
        public ICommandResult Handler(CadastrarEmpresaCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new CommandResult("EMP01",false,"Não foi possível realizar cadastro da empresa");
            throw new System.NotImplementedException();
        }
    }
}