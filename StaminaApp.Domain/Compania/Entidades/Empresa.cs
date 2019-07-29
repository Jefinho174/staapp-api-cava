using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using StaminaApp.Core.Entidades;
using StaminaApp.Domain.Enum;
using StaminaApp.Domain.ObjetoValores;

namespace StaminaApp.Domain.Compania.Entidades
{
    public class Empresa : Entidade
    {
        protected Empresa(){

        }
        public Empresa(string razaoSocial, Documento cnpj, Documento inscricaoEstadual, Documento inscricaoMunicipal, Endereco endereco)
        {
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            InscricaoMunicipal = inscricaoMunicipal;
            Endereco = endereco;
            _controsCusto = new List<CentroCusto>();
            _setores = new List<Setor>();

            AddNotifications(Cnpj, Endereco, InscricaoEstadual, InscricaoMunicipal, new Contract()
                .HasMinLen(RazaoSocial, 1, "Empresa.RazaoSocial", "Razao social deve conter pelo menos 1 caracteres")
                .HasMaxLen(RazaoSocial, 100, "Empresa.RazaoSocial", "Razao social deve conter até 100 caracteres")
            );
        }

        public string RazaoSocial { get; private set; }
        public Documento Cnpj { get; private set; }
        public Documento InscricaoEstadual { get; private set; }
        public Documento InscricaoMunicipal { get; private set; }
        public Endereco Endereco { get; private set; }
        private IList<CentroCusto> _controsCusto;
        public IReadOnlyCollection<CentroCusto> CentrosCusto { get { return _controsCusto.ToArray(); } }
        private IList<Setor> _setores;
        public IReadOnlyCollection<Setor> Setores { get { return _setores.ToArray(); } }

        public void AddCentroCusto(CentroCusto centroCusto)
        {
            if (!(_controsCusto.Where(x => x.CodigoControCusto.Equals(centroCusto.CodigoControCusto)).Count() > 0))
            {
                _controsCusto.Add(centroCusto);
            }
        }

        public void RemoverCentroCusto(CentroCusto centroCusto)
        {
            if (_controsCusto.Where(x => x.CodigoControCusto.Equals(centroCusto.CodigoControCusto)).Count() > 0)
            {
                _controsCusto.ToList().RemoveAll(x => x.CodigoControCusto.Equals(centroCusto.CodigoControCusto));
            }
        }

        public static class EmpresaFactory
        {
            public static Empresa NewObject(int id, string razaoSocial, string cnpj, string inscricaoEstadual,
                                            string inscricaoMunicipal,string rua, int numero, string bairro, string cidade,
                                            string estato, string pais, string codigoPostal, string complemento, DateTime dataCriaco,DateTime? dataFinalizacao = null)
            {
                Documento cnpjDocumento = new Documento(cnpj, ETipoDocumento.CNPJ);
                Documento inscricaoEstadualDocumento = new Documento(inscricaoEstadual, ETipoDocumento.INSCRICAO_ESTADUAL);
                Documento inscricaoMunicipalDocumento = new Documento(inscricaoMunicipal, ETipoDocumento.INSCRICAO_MUNICIPAL);
                Endereco enderecoDocumento = new Endereco(rua, numero, bairro, cidade, estato, pais, codigoPostal, complemento);
                Empresa empresa = new Empresa(razaoSocial, cnpjDocumento, inscricaoEstadualDocumento, inscricaoMunicipalDocumento, enderecoDocumento);
                empresa.Id = id;
                empresa.DataCriacao = dataCriaco;
                empresa.DataFinalizacao = dataFinalizacao;
                return empresa;
            }
        }
    }
}