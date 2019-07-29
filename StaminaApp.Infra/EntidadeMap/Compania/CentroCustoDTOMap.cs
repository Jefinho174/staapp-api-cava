using Dapper.FluentMap.Dommel.Mapping;
using StaminaApp.Infra.Entidades.Compania;

namespace StaminaApp.Infra.EntidadeMap.Compania
{
    public class CentroCustoDTOMap : DommelEntityMap<CentroCustoDTO>
    {
        public CentroCustoDTOMap(){
            ToTable("tb_contro_custo");
            Map(x => x.Id).ToColumn("id").IsIdentity().IsKey();
            Map(x => x.IdEmpresa).ToColumn("id_empresa");
            Map(x => x.CodigoControCusto).ToColumn("codigo");
            Map(x => x.Descricao).ToColumn("descricao");
            Map(x => x.DataCriacao).ToColumn("data_cadastro");
            Map(x => x.DataFinalizacao).ToColumn("data_finalizacao");
        }
    }
}