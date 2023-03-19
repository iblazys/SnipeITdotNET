using Microsoft.Extensions.Configuration;
using SnipeITdotNET.Commands.Assets;
using System.CommandLine;

namespace SnipeITdotNET.Managers
{
    internal class AssetManager : IManager
    {
        public static Command BuildCommands(IConfiguration config)
        {
            var asset = new Command("asset", "Asset management")
            {
                new GetAssetCommand(),
                new GetByTagCommand(config)
            };

            return asset;
        }

        public static void SaveToFile(string fileName)
        {
            // Determine extension
            // Convert file
            // Save
            Console.WriteLine($"Saved to file: {fileName}");
        }
    }
}
