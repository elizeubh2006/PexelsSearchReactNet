using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using PexelApiSearch.Application.PexelsServices.DTOs;
using PexelApiSearch.Application.PexelsServices.Interfaces;

namespace PexelApiSearch.Infra.PexelsExternalServices.Services.Implementations
{
    public class PexelsExternalService : IPexelsExternalService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PexelsExternalService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<PexelsResponseDto?> SearchPhotosAsync(string query, int per_page, int page)
        {
            var apiKey = _configuration["Pexels:ApiKey"];
            var baseUrl = _configuration["Pexels:BaseUrl"];

            if (string.IsNullOrWhiteSpace(apiKey))
                throw new InvalidOperationException("A chave da API Pexels não está configurada.");

            if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
                _httpClient.DefaultRequestHeaders.Add("Authorization", apiKey);

            var url = $"{baseUrl}/search?page={page}&query={query}&per_page={per_page}";

            try
            {
                var response = await _httpClient.GetFromJsonAsync<PexelsResponseDto>(url);
                return response;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Erro ao consumir a API Pexels: {ex.Message}", ex);
            }
        }
    }
}

