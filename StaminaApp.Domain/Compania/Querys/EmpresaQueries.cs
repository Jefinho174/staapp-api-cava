using System.Collections.Generic;
using StaminaApp.Domain.Compania.Entidades;
using StaminaApp.Domain.Repositorios;

namespace StaminaApp.Domain.Compania.Querys
{
    public class EmpresaQueries
    {
        private readonly IEmpresaRepositorio _repositorio;
        public EmpresaQueries(IEmpresaRepositorio repositorio){
            _repositorio = repositorio;
        }
        
        public IEnumerable<Empresa> ListarEmpresas(){
            return _repositorio.FindAllEmpresas();
        }
    }
}