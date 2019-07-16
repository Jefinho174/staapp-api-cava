using StaminaApp.Domain.Compania.Entidades;

namespace StaminaApp.Domain.Repositorios
{
    public interface IEmpresaRepositorio
    {

        // Validações
        bool ExisteCnpj(string cnpj);
        


        // Persistência
        bool CadastrarEmpresa(Empresa empresa);
        bool EditarEmpresa(Empresa empresa);
        bool DeletarEmpresa(int idEntity);
    }
}