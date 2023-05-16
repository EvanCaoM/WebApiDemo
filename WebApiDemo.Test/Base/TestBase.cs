using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Extensions;

namespace WebApiDemo.Test.Base
{
    public class TestBase
    {

        public IConfiguration Configuration;

        public ServiceProvider Services;

        static TestBase()
        {
        }

        public TestBase()
        {
            var builder = new ConfigurationBuilder();
            Configuration = builder.AddJsonFile("appsettings.json").Build();

            var services = new ServiceCollection();
            services.AddSingleton(Configuration);
            services.AddMediatRServices();
            //services.AddSqlServerDomainContext(Configuration.GetValue<string>("SqlServer"));
            services.AddMySqlDomainContext(Configuration.GetValue<string>("Mysql"));
            services.AddRepositories();
            Services = services.BuildServiceProvider();
        }
    }
}
