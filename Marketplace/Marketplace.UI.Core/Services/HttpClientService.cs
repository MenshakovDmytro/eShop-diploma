﻿using System.Text;
using Infrastructure.Services.Interfaces;
using Marketplace.Models.Configurations;
using Marketplace.UI.Core.Exceptions;
using Marketplace.UI.Core.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Marketplace.UI.Core.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientService(
            IHttpClientFactory httpClientFactory,
            IOptions<AppSettings> appSettings,
            IJsonSerializer jsonSerializer)
        {
            _appSettings = appSettings;
            _jsonSerializer = jsonSerializer;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TResponse> PostAsync<TResponse, TRequest>(string uri, TRequest body) =>
            await SendAsync<TResponse, TRequest>(uri, HttpMethod.Post, body);

        public async Task<TResponse> PutAsync<TResponse, TRequest>(string uri, TRequest body) =>
            await SendAsync<TResponse, TRequest>(uri, HttpMethod.Put, body);

        public async Task<TResponse> DeleteAsync<TResponse>(string uri) =>
            await SendAsync<TResponse, object?>(uri, HttpMethod.Delete, null);

        public async Task<TResponse> GetAsync<TResponse>(string uri) =>
            await SendAsync<TResponse, object?>(uri, HttpMethod.Get, null);

        private async Task<TResponse> SendAsync<TResponse, TRequest>(string uri, HttpMethod method, TRequest? content)
        {
            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromMinutes(_appSettings.Value.RequestTimeoutInMinutes);

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(uri),
                Method = method
            };

            if (content != null)
            {
                request.Content = new StringContent(_jsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
            }

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength > 0)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var deserializedResponse = _jsonSerializer.Deserialize<TResponse>(responseContent);

                return deserializedResponse!;
            }

            throw new HttpResponseException($"Request failed with status code {(int)response.StatusCode}");
        }
    }
}