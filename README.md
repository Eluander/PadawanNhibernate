## Projeto Padawan NHibernate
Padawan são crianças que faziam treinamentos para se tornarem um cavaleiro Jedi, os cavaleiros do lado bom da força.
Somos crianças em treinamento para sermos um JediNate (Jedi + NHibernate)

Estudos voltado a NHibernate, configurações, mapeamentos, migrations, etc

Todos os pacotes a serem instalados :
```
Install-Package Flunt

Install-Package NHibernate
Install-Package FluentMigrator
Install-Package FluentMigrator.Tools
```
## Dicas e sugestões

Em produção , para melhor performace, usa-se :
### new SchemaUpdate(cfg).Execute(false, false);

```csharp
var config = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(AppSettings.ConnectionString))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .ExposeConfiguration(cfg =>
                    {
                        new SchemaUpdate(cfg).Execute(false, false);
                        cfg.SetProperty("use_proxy_validator", "false");
                        cfg.SetProperty("show_sql", "true");
                    })
                .BuildConfiguration();
```
Ou se preferir,
```
  Coloque aqui @Eluander #if DEBUG #else
```