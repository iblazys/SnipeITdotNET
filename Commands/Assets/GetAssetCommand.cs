using RestSharp;
using SnipeITdotNET.Api;
using System.CommandLine;
using System.Diagnostics;

namespace SnipeITdotNET.Commands.Assets
{
    internal class GetAssetCommand : Command
    {
        public GetAssetCommand() : base(name: "getbyid", "Gets an asset from the SnipeIT API")
        {
            var id = new Argument<int>("id", "id of the desired asset");
          
            AddArgument(id);

            this.SetHandler((ctx) =>
            {
                var inputArgValue = ctx.ParseResult.GetValueForArgument(id);

                /* Options can be null if not required, arguments cannot be null.
                if (inputOptionValue is not null)
                {
                    Constants.Color.WriteLine($"Upper = '{inputOptionValue.ToUpper()}'");
                }
                */

                ctx.ExitCode = 0;

                Console.WriteLine($"Getting asset with id {inputArgValue}");

                // Do API request here.
                //var request = new ApiRequest();
                Stopwatch sw = Stopwatch.StartNew();

                //var response = request.Get("api/v1/hardware");

                sw.Stop();
                

                // Output api request

                //Console.WriteLine($"Got {response.ContentLength} bytes in {sw.ElapsedMilliseconds} ms");
            });
        }
    }
}
