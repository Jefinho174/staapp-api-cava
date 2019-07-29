using System.Collections.Generic;
using StaminaApp.Domain.Compania.Entidades;

namespace StaminaApp.Domain.Repositorios
{
    public interface IEmpresaRepositorio
    {
        // Validações
        bool ExisteCnpj(ref Empresa empresa);
        IEnumerable<CentroCusto> ExisteCodigoCentroCusto(ref Empresa empresa);

        // Persistência
        Empresa InsertEmpresa(Empresa empresa);
        Empresa UpdateEmpresa(Empresa empresa);
        bool DeleteEmpresa(int idEntity);
        bool InserirCentroCusto(ref Empresa empresa);
        bool UpdateCentroCusto(CentroCusto empresa);
        bool DeleteCentroCusto(CentroCusto empresa);

        // Consultas
        IEnumerable<Empresa> FindAllEmpresas();
        Empresa FindEmpresa(int id);

        IEnumerable<CentroCusto> FindAllCentroCusto();
        CentroCusto FindCentroCusto(int id);
    }
}