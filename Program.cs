using Microsoft.Extensions.Configuration;
using System.CommandLine;

class Program
{
    private static IConfiguration? config;
      
    static async Task Main(string[] args)
    {
        // Require and load appsettings.ini
        IConfiguration configuration = new ConfigurationBuilder()
            .AddIniFile("appsettings.ini", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

        // TODO Exception handling above

        config = configuration;

        var rootCommand = CommandLine.Build(config);
        await rootCommand.InvokeAsync(args);
    }
}
