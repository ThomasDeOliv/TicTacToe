using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace TicTacTor.SingleResponsabilityRefactoring.Services
{
    internal class DIService
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _serviceDescriptors;
        private readonly IServiceProvider _serviceProvider;

        private readonly string? _env;

        public DIService()
        {
#if DEBUG
            this._env = "development";
#else
            this._env = null;
#endif
            string configFile = !string.IsNullOrEmpty(this._env) ? $"appsettings{this._env}.json" : $"appsettings.json";

            this._configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configFile, optional: false, reloadOnChange: true)
                .Build();

            this._serviceDescriptors = new ServiceCollection()
                .AddSingleton(this._configuration);

            this._serviceProvider = this._serviceDescriptors.BuildServiceProvider();
        }

        public IConfiguration Configuration { get => this._configuration; }
        public IServiceProvider ServiceProvider { get => this._serviceProvider; }
    }
}
