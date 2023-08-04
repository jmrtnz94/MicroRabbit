using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using MicroRabbit.MVC.Models.DTO;

namespace MicroRabbit.MVC.Services;

public class TransferService : ITransferService
{
    private readonly HttpClient _apiClient;

    public TransferService(HttpClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task Transfer(TransferDto transferDto)
    {
        const string uri = "https://localhost:7216/api/Banking";
        var transferContent = new StringContent(JsonSerializer.Serialize(transferDto),
            Encoding.UTF8, "application/json");
        
        var response = await _apiClient.PostAsync($"{uri}", transferContent);
        response.EnsureSuccessStatusCode();
    }
}