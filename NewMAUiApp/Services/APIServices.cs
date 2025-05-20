using System;
using System.Net.Http.Json;
using System.Text.Json;
using NewMAUiApp.Models;

namespace NewMAUiApp.Services;

public class APIServices : IAPIServices
{
    HttpClient _httpClient;
    JsonSerializerOptions _serializerOptions;
    public APIServices()
    {
        _httpClient = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
    public async Task<List<ProductlistModel>> GetPostsAsync()
    {
        var Items = new List<ProductlistModel>();
        try
        {

            Uri uri = new Uri(string.Format("https://meijer-maui-test-default-rtdb.firebaseio.com/products.json", string.Empty));
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Items = JsonSerializer.Deserialize<List<ProductlistModel>>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            // Log or handle error as needed
            Console.WriteLine($"API Error: {ex.Message}");
        }
#pragma warning disable CS8603 // Possible null reference return.
        return Items;
#pragma warning restore CS8603 // Possible null reference return.
    }
    public async Task<ProductDetailsModel> GetDetailsAsync(int Id)
    {
        var Items = new ProductDetailsModel();
        try
        {

            Uri uri = new Uri(string.Format("https://meijer-maui-test-default-rtdb.firebaseio.com/product-details/{0}.json",Id));
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Items = JsonSerializer.Deserialize<ProductDetailsModel>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            // Log or handle error as needed
            Console.WriteLine($"API Error: {ex.Message}");
        }
#pragma warning disable CS8603 // Possible null reference return.
        return Items;
#pragma warning restore CS8603 // Possible null reference return.
    }
   
}
