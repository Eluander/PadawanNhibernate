using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Padawan.Shared;
using System.Reflection;

namespace Padawan.Infra.Context
{
    public sealed class PadawanNHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory()
        {
            var config = Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(AppSettings.ConnectionString))
                            .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                                .ExposeConfiguration(cfg =>
                                {
                                    new SchemaUpdate(cfg).Execute(false, true);
                                    cfg.SetProperty("use_proxy_validator", "false");
                                    cfg.SetProperty("show_sql", "true");
                                })
                            .BuildConfiguration();

            _sessionFactory = config.BuildSessionFactory();

            return _sessionFactory;
        }
        public static ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}  
