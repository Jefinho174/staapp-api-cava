using System.Collections.Generic;
using StaminaApp.Core.Entidades;

namespace StaminaApp.Core.Repositorios
{
    public interface IRepositorioBase<TEntidade> where TEntidade : Entidade
    {
        IEnumerable<TEntidade> GetAll();
        TEntidade GetById(int id);
        TEntidade Insert(TEntidade entity);
        bool Update(TEntidade entity);
        bool Delete(int id);
    }
}