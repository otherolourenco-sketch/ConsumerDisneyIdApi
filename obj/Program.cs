using System.Net.Http.Json;
using System.Text.Json.Serialization;

const string endpoint = "https://api.disneyapi.dev/character/423";

using HttpClient httpClient = new();

try
{
    CharacterResponse? response =
        await httpClient.GetFromJsonAsync<CharacterResponse>(endpoint);

    CharacterData? character = response?.Data;

    if (character is null)
    {
        Console.WriteLine("Não foi possível obter os dados do personagem.");
        return;
    }

    Console.WriteLine("=== Disney API ===");
    Console.WriteLine($"Nome: {character.Name}");
    Console.WriteLine($"Imagem: {character.ImageUrl}");
}
catch (HttpRequestException ex)
{
    Console.WriteLine("Erro ao acessar a Disney API.");
    Console.WriteLine($"Detalhes: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine("Ocorreu um erro inesperado.");
    Console.WriteLine($"Detalhes: {ex.Message}");
}

public class CharacterResponse
{
    [JsonPropertyName("data")]
    public CharacterData? Data { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }
}

public class CharacterData
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }
}