using System.Collections.Generic;

namespace StaminaApp.Core.Commands
{
    public class CommandResultObject<T> : ICommandResult where T : class  
    {
        public CommandResultObject()
        {

        }
        
        public CommandResultObject(string codigoResposta, bool success, string message,T retorno)
        {
            CodigoResposta = codigoResposta;
            Success = success;
            Message = message;
            Retorno = retorno;
        }

        public CommandResultObject(string codigoResposta, bool success, string message, T retorno, List<string> notificacoes)
        {
            CodigoResposta = codigoResposta;
            Success = success;
            Message = message;
            Notificacoes = notificacoes;
            Retorno = retorno;
        }

        public string CodigoResposta { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Notificacoes { get; set; }
        public T Retorno { get; private set; }

        public void AddNotificacoes(string message){
            if(Notificacoes == null)
                Notificacoes = new List<string>();
            Notificacoes.Add(message);
        }
    }
}