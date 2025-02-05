using System.Text.Json.Serialization;

namespace CodeTest.Shared.Contracts;

public class StarWarsPersonResponse
{
    public string? Name { get; set; }

    [JsonPropertyName("birth_year")]
    public string? BirthYear { get; set; }

    [JsonPropertyName("eye_color")]
    public string? EyeColor { get; set; }

    public string? Gender { get; set; }

    [JsonPropertyName("hair_color")]
    public string? HairColor { get; set; }

    public string? Height { get; set; }
    public string? Mass { get; set; }

    [JsonPropertyName("skin_color")]
    public string? SkinColor { get; set; }

    public string? Homeworld { get; set; }
    public List<string> Films { get; set; } = new();
    public List<string> Species { get; set; } = new();
    public List<string> Starships { get; set; } = new();
    public List<string> Vehicles { get; set; } = new();
    public string? Url { get; set; }
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }
}