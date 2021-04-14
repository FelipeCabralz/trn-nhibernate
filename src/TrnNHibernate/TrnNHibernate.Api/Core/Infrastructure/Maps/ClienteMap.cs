using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using TrnNHibernate.Entidades;

namespace TrnNHibernate.Api.Core.Infrastructure.Maps
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Id(x => x.Id)
                .Column("CD_CLIENTE")
                .GeneratedBy.Identity();

            Map(x => x.Nome)
                .Column("NM_CLIENTE")
                .CustomSqlType("varchar(100)")
                .Not.Nullable();

            Map(x => x.Email)
                .Column("TXT_EMAIL")
                .CustomSqlType("varchar(80)")
                .Not.Nullable();

            Map(x => x.Senha)
                .Column("TXT_SENHA")
                .CustomSqlType("varchar(1024)")
                .Not.Nullable();
        }
    }
}