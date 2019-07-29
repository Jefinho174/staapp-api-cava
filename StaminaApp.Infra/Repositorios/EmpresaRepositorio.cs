using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dommel;
using MySql.Data.MySqlClient;
using StaminaApp.Domain.Compania.Entidades;
using StaminaApp.Domain.Enum;
using StaminaApp.Domain.ObjetoValores;
using StaminaApp.Domain.Repositorios;
using StaminaApp.Infra.EntidadeMap;
using StaminaApp.Infra.Entidades;
using StaminaApp.Infra.Entidades.Compania;

namespace StaminaApp.Infra.Repositorios
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {

        private string MysqlComandoConecxao;
        public EmpresaRepositorio(string conecxao)
        {
            MysqlComandoConecxao = conecxao;
        }

        // Validações
        public bool ExisteCnpj(ref Empresa empresa)
        {
            using (var db = new MySqlConnection(MysqlComandoConecxao))
            {
                var respostaDb = 0;
                if(empresa.Id != 0){
                    respostaDb = db.Query<int>("SELECT COUNT(*) FROM tb_empresa WHERE cnpj = @Cnpj AND id <> @Id", new { Cnpj = empresa.Cnpj.Numero, Id = empresa.Id }).FirstOrDefault();
                }else{
                    respostaDb = db.Query<int>("SELECT COUNT(*) FROM tb_empresa WHERE cnpj = @Cnpj", new { Cnpj = empresa.Cnpj.Numero }).FirstOrDefault();
                }
                if (respostaDb > 0)
                    return true;
            }
            return false;
        }

        public IEnumerable<CentroCusto> ExisteCodigoCentroCusto(ref Empresa empresa)
        {
            List<CentroCusto> centroCustoLista = new List<CentroCusto>();
            foreach (var centroCusto in empresa.CentrosCusto.Where(x => x.Id.Equals(0)))
            {
                if (!string.IsNullOrEmpty(centroCusto.CodigoControCusto))
                {
                    using (var db = new MySqlConnection(MysqlComandoConecxao))
                    {
                        var respostaDb = db.Query<int>("SELECT COUNT(*) FROM tb_contro_custo WHERE codigo = @Codigo AND id_empresa = @IdEmpresa", new { Codigo = centroCusto.CodigoControCusto, IdEmpresa = empresa.Id }).FirstOrDefault();
                        if (respostaDb > 0)
                            centroCustoLista.Add(centroCusto);
                    }
                }
            }
            return centroCustoLista;
        }

        // Persistências
        public Empresa InsertEmpresa(Empresa empresa)
        {
            // var objectInsert = new
            // {
            //     RazaoSocial = empresa.RazaoSocial,
            //     Cnpj = empresa.Cnpj.Numero,
            //     InscricaoEstadual = empresa.InscricaoEstadual.Numero,
            //     InscricaoMunicipal = empresa.InscricaoMunicipal.Numero,
            //     Rua = empresa.Endereco.Rua,
            //     Numero = empresa.Endereco.Numero,
            //     Bairro = empresa.Endereco.Bairro,
            //     Cidade = empresa.Endereco.Cidade,
            //     Estato = empresa.Endereco.Estato,
            //     Pais = empresa.Endereco.Pais,
            //     CodigoPostal = empresa.Endereco.CodigoPostal,
            //     Complemento = empresa.Endereco.Complemento,
            //     DataCriacao = empresa.DataCriacao,
            //     DataFinalizacao = empresa.DataFinalizacao
            // };

            using (var db = new MySqlConnection(MysqlComandoConecxao))
            {
                // var query = $@"INSERT INTO tb_empresa
                //             (razao_social,
                //             cnpj,
                //             inscricao_estadual,
                //             inscricao_municipal,
                //             rua,
                //             numero,
                //             bairro,
                //             estado,
                //             cidade,
                //             pais,
                //             codigo_postal,
                //             complemento,
                //             data_cadastro,
                //             data_finalizacao)
                //             VALUES
                //             (@RazaoSocial,
                //             @Cnpj,
                //             @InscricaoEstadual,
                //             @InscricaoMunicipal,
                //             @Rua,
                //             @Numero,
                //             @Bairro,
                //             @Cidade,
                //             @Estato,
                //             @Pais,
                //             @CodigoPostal,
                //             @Complemento,
                //             @DataCriacao,
                //             @DataFinalizacao);
                //             SELECT LAST_INSERT_ID();";
                var respostaDb = db.Insert(new EmpresaDTO().GetDto(empresa));
                if (Convert.ToInt32(respostaDb) > 0)
                {
                    empresa.Id = Convert.ToInt32(respostaDb);
                }
                return empresa;
            }
        }
        public Empresa UpdateEmpresa(Empresa empresa)
        {
            var objectInsert = new
            {
                Id = empresa.Id,
                RazaoSocial = empresa.RazaoSocial,
                Cnpj = empresa.Cnpj.Numero,
                InscricaoEstadual = empresa.InscricaoEstadual.Numero,
                InscricaoMunicipal = empresa.InscricaoMunicipal.Numero,
                Rua = empresa.Endereco.Rua,
                Numero = empresa.Endereco.Numero,
                Bairro = empresa.Endereco.Bairro,
                Cidade = empresa.Endereco.Cidade,
                Estato = empresa.Endereco.Estato,
                Pais = empresa.Endereco.Pais,
                CodigoPostal = empresa.Endereco.CodigoPostal,
                Complemento = empresa.Endereco.Complemento,
                DataCriacao = empresa.DataCriacao,
            };

            using (var db = new MySqlConnection(MysqlComandoConecxao))
            {
                var query = $@"UPDATE tb_empresa 
                            SET razao_social = @RazaoSocial,
                            cnpj = @Cnpj,
                            inscricao_estadual = @InscricaoEstadual,
                            inscricao_municipal = @InscricaoMunicipal,
                            rua = @Rua,
                            numero = @Numero,
                            bairro = @Bairro,
                            estado = @Estato,
                            cidade = @Cidade,
                            pais = @Pais,
                            codigo_postal = @CodigoPostal,
                            complemento = @Complemento,
                            data_cadastro = @DataCriacao WHERE id = @Id;";
                var respostaDb = db.Query<int>(query, objectInsert).FirstOrDefault();
                if (respostaDb > 0)
                {
                    empresa.Id = respostaDb;
                }
                return empresa;
            }
        }
        public bool DeleteEmpresa(int id){
            using (var db = new MySqlConnection(MysqlComandoConecxao))
            {
                var query = $@"DELETE FROM tb_empresa WHERE id = @Id;";
                var respostaDb = db.Execute(query, new {Id = id});
                return (respostaDb > 0) ? true : false;
            }
        }
        public bool InserirCentroCusto(ref Empresa empresa)
        {
            List<dynamic> listObjectInsert = new List<dynamic>();
            foreach (var centroCusto in empresa.CentrosCusto.Where(x => x.Id.Equals(0)))
            {
                listObjectInsert.Add(new
                {
                    IdEmpresa = empresa.Id,
                    CodigoCentroCusto = centroCusto.CodigoControCusto,
                    Descricao = centroCusto.Descricao,
                    DataCadastro = centroCusto.DataCriacao
                });
            }
            var query = $@"INSERT INTO 
                            tb_contro_custo(
                            id_empresa,
                            codigo,
                            descricao,
                            data_cadastro)
                            VALUES (@IdEmpresa,
                                    @CodigoCentroCusto,
                                    @Descricao,
                                    @DataCadastro);";
            using (var db = new MySqlConnection(MysqlComandoConecxao))
            {
                var respostaDb = db.Execute(query, listObjectInsert);
                if (respostaDb > 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Consultas
        public IEnumerable<Empresa> FindAllEmpresas()
        {
            List<Empresa> lista = new List<Empresa>();
            return lista;
        }
        public Empresa FindEmpresa(int id)
        {
            using (var db = new MySqlConnection(MysqlComandoConecxao))
            {
                var respostaDb = db.Query("SELECT * FROM tb_empresa WHERE id = @Id", new { Id = id }).FirstOrDefault();
                if(respostaDb != null){
                    var empresa = Empresa.EmpresaFactory.NewObject(
                        respostaDb.id,
                        respostaDb.razao_social,
                        respostaDb.cnpj,
                        respostaDb.inscricao_estadual,
                        respostaDb.inscricao_municipal,
                        respostaDb.rua,
                        respostaDb.numero,
                        respostaDb.bairro,
                        respostaDb.cidade,
                        respostaDb.estado,
                        respostaDb.pais,
                        respostaDb.codigo_postal,
                        respostaDb.complemento,
                        respostaDb.data_cadastro,
                        respostaDb.data_finalizacao
                    );
                    return empresa;
                }
            }
            return null;
        }

        public IEnumerable<CentroCusto> FindAllCentroCusto()
        {
            using(var db = new MySqlConnection(MysqlComandoConecxao)){

            }
            throw new NotImplementedException();
        }

        public CentroCusto FindCentroCusto(int id)
        {
            using(var db = new MySqlConnection(MysqlComandoConecxao)){
                var respostaDb = db.Query("SELECT * FROM tb_contro_custo WHERE id = @Id", new {Id = id}).FirstOrDefault();
                if(respostaDb != null){
                    return CentroCusto.CentroCustoFactory.NewObject(respostaDb.id,respostaDb.codigo,respostaDb.descricao,respostaDb.data_cadastro,respostaDb.data_finalizacao);
                }
            }
            return null;
        }

        public bool UpdateCentroCusto(CentroCusto centroCusto)
        {
            var query = $@"UPDATE tb_contro_custo SET 
                            codigo = @CodigoCentroCusto,
                            descricao = @Descricao,
                            data_cadastro = @DataCadastro";
            using (var db = new MySqlConnection(MysqlComandoConecxao))
            {
                var respostaDb = db.Execute(query, new {CodigoCentroCusto = centroCusto.CodigoControCusto,
                                                        Descricao = centroCusto.Descricao,
                                                        DataCadastro = centroCusto.DataCriacao});
                if (respostaDb > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DeleteCentroCusto(CentroCusto empresa)
        {
            throw new NotImplementedException();
        }
    }
}