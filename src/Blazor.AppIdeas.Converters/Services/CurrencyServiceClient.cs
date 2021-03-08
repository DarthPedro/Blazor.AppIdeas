using Blazor.AppIdeas.Converters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blazor.AppIdeas.Converters.Services
{
    public class CurrencyServiceClient : ICurrencyServiceClient
    {
        private readonly string _serviceCurrencyUrl =
            "https://free.currconv.com/api/v7/currencies?apiKey=e49bfc9cd7ad694b2dd9";
        private readonly string _serviceConvertUrl =
            "https://free.currconv.com/api/v7/convert?apiKey=e49bfc9cd7ad694b2dd9&compact=y";

        private readonly HttpClient _httpClient;

        public CurrencyServiceClient(HttpClient http)
        {
            _httpClient = http ?? throw new ArgumentNullException(nameof(http));
        }

        public CurrencyServiceClient(HttpClient http, string currencyUrl, string convertUrl)
            : this(http)
        {
            _serviceCurrencyUrl = currencyUrl;
            _serviceConvertUrl = convertUrl;
        }

        public async Task<IEnumerable<CurrencyDescriptor>> GetCurrencies()
        {
            using var response = await GetValidServiceResponse(_serviceCurrencyUrl)
                                        .ConfigureAwait(false);

            using var doc = await LoadJsonDocument(response).ConfigureAwait(false);

            return ParseCurrencies(doc);
        }

        public async Task<CurrencyConversion> GetConversionRate(
            string convertFromId,
            string convertToId)
        {
            string conversionId = $"{convertFromId}_{convertToId}";
            string fullUrl = $"{_serviceConvertUrl}&q={conversionId}";

            using var response = await GetValidServiceResponse(fullUrl)
                                       .ConfigureAwait(false);
            using var doc = await LoadJsonDocument(response)
                                  .ConfigureAwait(false);

            return ParseCurrencyConversionRate(
                doc, convertFromId, convertToId, conversionId);
        }

        private async Task<HttpResponseMessage> GetValidServiceResponse(string url)
        {
            var response = await _httpClient.GetAsync(url)
                                            .ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"Response status code does not indicate success: {response.StatusCode}.");
            }

            return response;
        }

        private async Task<JsonDocument> LoadJsonDocument(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStreamAsync()
                                             .ConfigureAwait(false);
            return JsonDocument.Parse(json);
        }

        private IEnumerable<CurrencyDescriptor> ParseCurrencies(JsonDocument doc)
        {
            var results = new List<CurrencyDescriptor>();

            var element = doc.RootElement.GetProperty("results");
            foreach(var item in element.EnumerateObject())
            {
                var currency = ParseCurrencyDescriptor(item.Value);
                results.Add(currency);
            }

            return results.OrderBy(p => p.CurrencyName);
        }

        private CurrencyDescriptor ParseCurrencyDescriptor(JsonElement descriptorElement)
        {
            var id = descriptorElement.GetProperty("id").GetString();
            var name = descriptorElement.GetProperty("currencyName").GetString();
            var symbol = string.Empty;

            if (descriptorElement.TryGetProperty(
                "currencySymbol", out JsonElement symbolElement))
            {
                symbol = symbolElement.GetString();
            }

            return new CurrencyDescriptor
            {
                Id = id,
                CurrencyName = name,
                CurrencySymbol = symbol
            };
        }

        private CurrencyConversion ParseCurrencyConversionRate(
            JsonDocument doc, string convertFromId, string convertToId, string nodeName)
        {
            var element = doc.RootElement.GetProperty(nodeName);
            var val = element.GetProperty("val").GetDecimal();

            return new CurrencyConversion(convertFromId, convertToId, val); ;
        }
    }
}
