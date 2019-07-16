using System.Collections.Generic;

namespace StaminaApp.Core.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {

        }
        public CommandResult(string codigoResposta, bool success, string message)
        {
            CodigoResposta = codigoResposta;
            Success = success;
            Message = message;
        }

        public CommandResult(string codigoResposta, bool success, string message, List<string> notificacoes)
        {
            CodigoResposta = codigoResposta;
            Success = success;
            Message = message;
            Notificacoes = notificacoes;
        }

        public string CodigoResposta { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Notificacoes { get; set; }
    }
}