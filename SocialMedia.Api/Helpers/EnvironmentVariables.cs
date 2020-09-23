using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Api.Helpers
{
    public class EnvironmentVariables : IEnvironmentVariables
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EnvironmentVariables(IWebHostEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }

        public string GetUrl(string servicio)
        {
            var appSettingsName = "appsettings";
            if (_hostingEnvironment.IsDevelopment())
                appSettingsName = $"{appSettingsName}.Development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"{appSettingsName}.json");

            var configuration = builder.Build();
            var url = configuration[servicio];

            return _hostingEnvironment.IsProduction()
                ? Environment.GetEnvironmentVariable(url)
                : url;
        }
    }
}