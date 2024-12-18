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

        public DIService()
        {
            this._configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            this._serviceDescriptors = new ServiceCollection()
                .AddSingleton(this._configuration);

            this._serviceProvider = this._serviceDescriptors.BuildServiceProvider();
        }

        public IConfiguration Configuration { get => this._configuration; }
        public IServiceProvider ServiceProvider { get => this._serviceProvider; }
    }
}
