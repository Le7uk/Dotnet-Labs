using System.Net.Http.Json;
using FakeStoreApiClient;

var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("https://fakestoreapi.com/");

var product = await httpClient.GetFromJsonAsync<Product>("products/1");
Console.WriteLine($"Before update: {product.Title}, Price: {product.Price}");

product.Price = 1000;
var response = await httpClient.PutAsJsonAsync("products/1", product);
var updated = await response.Content.ReadFromJsonAsync<Product>();
Console.WriteLine($"After update: {updated.Title}, Price: {updated.Price}");