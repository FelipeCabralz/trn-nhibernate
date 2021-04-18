using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrnNHibernate.Entidades;

namespace TrnNHibernate.Api.Core.Infrastructure.Maps
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Id(x => x.Id)
                .Column("CD_PRODUTO")
                .GeneratedBy.Identity();
            
            Map(x => x.Nome)
                .Column("NM_PRODUTO")
                .CustomSqlType("varchar(100)")
                .Not.Nullable();
            
            Map(x => x.PrecoUnitario)
                .Column("PRECO_PRODUTO")
                .CustomSqlType("decimal")
                .Not.Nullable();

            Map(x => x.QuantidadeEstoque)
                .Column("QTD_ESTOQUE")
                .CustomSqlType("int")
                .Not.Nullable();
        }
    }
}
