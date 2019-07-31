using FluentNHibernate.Mapping;
using Padawan.Domain.Entities;

namespace Padawan.Infra.Maps
{
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Table("[Account]");
            Id(x => x.Id, "[Id]").GeneratedBy.Identity();

            Map(x => x.Name, "Name").CustomSqlType("VARCHAR(150)").Not.Nullable();

            Map(x => x.CreatedByUserId, "CreatedByUserId").CustomSqlType("BIGINT"); 
            Map(x => x.CreatedDate, "CreatedDate").CustomSqlType("DATETIME");
        }
    }
}
