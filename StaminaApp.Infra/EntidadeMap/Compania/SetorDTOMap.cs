using Dapper.FluentMap.Dommel.Mapping;
using StaminaApp.Infra.Entidades.Compania;

namespace StaminaApp.Infra.EntidadeMap.Compania
{
    public class SetorDTOMap : DommelEntityMap<SetorDTO>
    {
        public SetorDTOMap(){
            ToTable("tb_setor");
            Map(x => x.Id).ToColumn("id").IsIdentity().IsKey();
            Map(x => x.IdCentroCusto).ToColumn("id_centro_custo");
            Map(x => x.Titulo).ToColumn("titulo");
            Map(x => x.Descricao).ToColumn("descricao");
            Map(x => x.DataCriacao).ToColumn("data_cadastro");
            Map(x => x.DataFinalizacao).ToColumn("data_finalizacao");
        }
    }
}