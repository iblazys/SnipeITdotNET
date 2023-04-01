using SnipeITdotNET.Model.Assets;

namespace SnipeITdotNET.Model
{
    public interface IApiModel
    {
        long Id { get; set; }
        string Name { get; set; }
        SnipeDate CreatedAt { get; set; }
        SnipeDate UpdatedAt { get; set; }

        Dictionary<string, string> BuildHeaders();
    }
}
