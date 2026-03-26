using System.Text.Json.Serialization;

namespace FakeStoreApiClient
{
    public class Cart
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("userId")] public int UserId { get; set; }
        [JsonPropertyName("date")] public string Date { get; set; }
    }
}