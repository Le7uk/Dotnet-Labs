using System.Text.Json.Serialization;

namespace FakeStoreApiClient
{
    public class User
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("email")] public string Email { get; set; }
        [JsonPropertyName("username")] public string Username { get; set; }
    }
}