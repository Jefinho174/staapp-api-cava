using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using StaminaApp.Infra.EntidadeMap.Compania;

namespace StaminaApp.Infra.EntidadeMap
{
    public class MapeamentoEntidades
    {
        public static bool MapeamentoCarreado = false;

        public static void LoadEntidadesMap()
        {
            if (!MapeamentoCarreado)
            {
                FluentMapper.Initialize(config =>
                {
                    config.AddMap(new CentroCustoDTOMap());
                    config.AddMap(new EmpresaDTOMap());
                    config.AddMap(new SetorDTOMap());
                    config.ForDommel();
                });
                MapeamentoCarreado = !MapeamentoCarreado;
            }
        }
    }
}