using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using StaminaApp.Domain.Repositorios;

namespace StaminaApp.Infra.Repositorios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private string MysqlComandoConecxao;
        public FuncionarioRepositorio(string conecxao){
            MysqlComandoConecxao = conecxao;
        }
        public bool ExisteCpf(string cpf)
        {
            using (var db = new MySqlConnection(MysqlComandoConecxao))
            {
                var respostaDb = db.Query<int>("SELECT COUNT(*) tb_pessoas WHERE cfp = @Cfp", new { Cfp = cpf }).FirstOrDefault();
                if(respostaDb > 0)
                    return true;
            }
            return false;
        }
    }
}