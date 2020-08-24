using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace SocialMedia.Api.Helpers
{
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public EnvironmentVariables(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public string GetUrl(string servicio)
        {
            string appSettingsName = "appsettings";
            if (hostingEnvironment.IsDevelopment())
                appSettingsName = $"{appSettingsName}.Development";

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"{appSettingsName}.json");

            IConfigurationRoot configuration = builder.Build();
            string url = configuration[servicio];

            return hostingEnvironment.IsProduction()
                ? Environment.GetEnvironmentVariable(url)
                : url;
        }
    }
}