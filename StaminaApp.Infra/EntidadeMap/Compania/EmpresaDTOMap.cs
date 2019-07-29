using Dapper.FluentMap.Dommel.Mapping;
using StaminaApp.Infra.Entidades.Compania;

namespace StaminaApp.Infra.EntidadeMap.Compania
{
    public class EmpresaDTOMap : DommelEntityMap<EmpresaDTO>
    {
        public EmpresaDTOMap(){
            ToTable("tb_empresa");
            Map(x => x.Id).ToColumn("id").IsIdentity().IsKey();
            Map(x => x.RazaoSocial).ToColumn("razao_social");
            Map(x => x.Cnpj).ToColumn("cnpj");
            Map(x => x.InscricaoEstadual).ToColumn("inscricao_estadual");
            Map(x => x.InscricaoMunicipal).ToColumn("inscricao_municipal");
            Map(x => x.Rua).ToColumn("rua");
            Map(x => x.Numero).ToColumn("numero");
            Map(x => x.Bairro).ToColumn("bairro");
            Map(x => x.Estato).ToColumn("estado");
            Map(x => x.Cidade).ToColumn("cidade");
            Map(x => x.Pais).ToColumn("pais");
            Map(x => x.CodigoPostal).ToColumn("codigo_postal");
            Map(x => x.Complemento).ToColumn("complemento");
            Map(x => x.DataCriacao).ToColumn("data_cadastro");
            Map(x => x.DataFinalizacao).ToColumn("data_finalizacao");
        }
    }
}