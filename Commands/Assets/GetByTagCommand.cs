using Microsoft.Extensions.Configuration;
using RestSharp;
using SnipeITdotNET.Api;
using SnipeITdotNET.Managers;
using System.Collections.Specialized;
using System.CommandLine;
using System.Net;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Web;

namespace SnipeITdotNET.Commands.Assets
{
    internal class GetByTagCommand : Command
    {
        public GetByTagCommand(IConfiguration config) : base(name: "getbytag", "Gets an asset by tag from the SnipeIT API")
        {
            // Command arguments and options
            var tag = new Argument<int>("tag", "asset tag of the desired asset");
            var deleted = new Option<bool>(new string[] { "--deleted", "-d" }, "include deleted items");

            // Options not used by SnipeIT
            var outputFile = new Option<string>(new string[] { "--output", "-o" }, "output file name with extension (.json, .xlsx)");

            AddArgument(tag);
            AddOption(deleted);
            AddOption(outputFile);

            // Build a query string
            NameValueCollection optionString = HttpUtility.ParseQueryString(string.Empty);
            optionString.Add("deleted", "false");

            // Load config data
            var apiKey = config.GetValue<string>("APIKey");
            var baseUrl = config.GetValue<string>("WebAddress");

            // Handle
            this.SetHandler((ctx) =>
            {
                // Read args and options
                var tagValue = ctx.ParseResult.GetValueForArgument(tag);
                var deletedValue = ctx.ParseResult.GetValueForOption(deleted);
                var outputValue = ctx.ParseResult.GetValueForOption(outputFile);
                var silentValue = ctx.ParseResult.GetValueForOption(new Option<bool>("--silent"));

                if (deletedValue)
                {
                    optionString.Set("deleted", "true");
                }

                // Build and execute request - todo, own class
                var request = new ApiRequest(apiKey, baseUrl, $"api/v1/hardware/bytag/{tagValue}?{optionString}");
                var response = request.Execute(Method.Get);

                // GetByTag returns a single item, no total and rows fields.
                AssetRow? asset = JsonSerializer.Deserialize<AssetRow>(response.Content);

                // If the total is 0, deserialize as ErrorResponse
                if (asset.asset_tag == null)
                {
                    ErrorResponse error = JsonSerializer.Deserialize<ErrorResponse>(response.Content);
                    Console.WriteLine($"Status: {error.status} - {error.messages}");
                    return;
                }

                if(outputValue != null)
                {
                    //AssetManager.SaveToFile(asset);
                }

                // Verbose logging
                if(!silentValue)
                {
                    Console.WriteLine($"Got asset: {asset.asset_tag}");
                    Console.WriteLine(JsonSerializer.Serialize(asset, new JsonSerializerOptions { WriteIndented = true }));
                }
            });
        }
    }
}
