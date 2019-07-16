using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using StaminaApp.Core.Entidades;
using StaminaApp.Domain.ObjetoValores;

namespace StaminaApp.Domain.Compania.Entidades
{
    public class Empresa : Entidade
    {
        public Empresa(string razaoSocial, Documento cnpj, Documento inscricaoEstadual, Documento inscricaoMunicipal, Endereco endereco)
        {
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            InscricaoMunicipal = inscricaoMunicipal;
            Endereco = endereco;

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

    }
}