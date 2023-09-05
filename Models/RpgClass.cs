using System.Text.Json.Serialization;

namespace rpg_dotnet.vscode.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1,
        Mage = 2,
        Ranger = 3

    }
}