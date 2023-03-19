using Microsoft.Extensions.Configuration;
using System.CommandLine;

namespace SnipeITdotNET.Managers
{
    internal interface IManager
    {
        public abstract static Command BuildCommands(IConfiguration config);
    }
}
