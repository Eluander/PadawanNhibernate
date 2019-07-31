using FluentMigrator;
using Padawan.Shared;

namespace Padawan.Infra.Migrations
{
    [Migration(1)]
    public class M0001_AccountMigration : Migration
    {
        private const string TABLE = "Account";

        public override void Down()
        {
            // Nothing
        }

        public override void Up()
        {
            IfDatabase("SqlServer").Create.Table(TABLE).InSchema(Constantes.SCHEMA)
                .WithColumn("Id").AsInt64()
                .PrimaryKey("pk_Account")
                .Identity()

                .WithColumn("Name").AsString(160)

                .WithColumn("CreatedByUserId").AsInt64().Nullable()
                .WithColumn("CreatedDate").AsDateTime().Nullable()
                .WithColumn("MachineNameOrIPCreate").AsString(60);
        }
    }
}
