using System.CommandLine;
using Microsoft.Extensions.Configuration;
using SnipeITdotNET.Commands;
using SnipeITdotNET.Managers;

class CommandLine
{
    public static RootCommand Build(IConfiguration config) 
    {
        var root = new RootCommand("SnipeITdotNET: SnipeIT API Tool");

        // Build command managers
        root.AddCommand(AssetManager.BuildCommands(config));

        root.AddGlobalOption(new Option<bool>("--silent", "Disables diagnostics output"));
        
        // Automatically invoke -h
        root.SetHandler(() => root.Invoke("-h"));

        return root;
    }
}
