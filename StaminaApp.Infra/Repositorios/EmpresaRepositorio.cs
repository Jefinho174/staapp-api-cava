using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using StaminaApp.Domain.Compania.Entidades;
using StaminaApp.Domain.Repositorios;

namespace StaminaApp.Infra.Repositorios
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {

        private string MysqlComandoConecxao;
        public EmpresaRepositorio(string conecxao){
            MysqlComandoConecxao = conecxao;
        }

        public bool ExisteCnpj(string cnpj)
        {
            if(string.IsNullOrEmpty(cnpj))
                return false;

            using (var db = new MySqlConnection(MysqlComandoConecxao))
            {
                var respostaDb = db.Query<int>("SELECT COUNT(*) tb_empresa WHERE cnpj = @Cnpj", new { Cnpj = cnpj }).FirstOrDefault();
                if(respostaDb > 0)
                    return true;
            }
            return false;
        }

        public bool CadastrarEmpresa(Empresa empresa)
        {

            throw new System.NotImplementedException();
        }

        public bool EditarEmpresa(Empresa empresa)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletarEmpresa(int idEntity)
        {
            throw new System.NotImplementedException();
        }

        
    }
}