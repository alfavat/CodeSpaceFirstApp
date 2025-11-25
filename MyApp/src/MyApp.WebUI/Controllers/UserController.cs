using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using MyApp.WebUI.ViewModels.User;

namespace MyApp.WebUI.Controllers;

public class UserController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public UserController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.GetAsync("api/Users");
            response.EnsureSuccessStatusCode(); // Throws if the response is not 2xx

            var content = await response.Content.ReadAsStringAsync();

            var users = JsonSerializer.Deserialize<List<UserViewModel>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });

            return View(users);

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return View(new List<UserViewModel>());
        }
    }
}