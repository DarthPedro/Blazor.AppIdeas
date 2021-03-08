using Blazor.AppIdeas.Converters.Models;
using Blazor.AppIdeas.Converters.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.AppIdeas.Converters.ViewModels
{
    public class CurrencyConverterViewModel
    {
        private const string _defaultConvertFrom = "USD";
        private const string _defaultConvertTo = "EUR";
        private readonly ICurrencyServiceClient _serviceClient;

        public CurrencyConverterViewModel(ICurrencyServiceClient client)
        {
            _serviceClient = client ?? throw new ArgumentNullException(nameof(client));
        }

        public decimal ConvertFromValue { get; set; }

        public string ConvertFromCurrencyId { get; set; }

        public string ConvertFromCurrencySymbol =>
            FindCurrencySymbol(ConvertFromCurrencyId);

        public decimal ConvertToValue { get; private set; }
        
        public string ConvertToCurrencyId { get; set; }

        public string ConvertToCurrencySymbol =>
            FindCurrencySymbol(ConvertToCurrencyId);

        public IEnumerable<CurrencyDescriptor> Currencies { get; private set; } =
            new List<CurrencyDescriptor>();

        public decimal? ConversionRate { get; private set; }

        public string ErrorMessage { get; private set; }

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        public async Task Initialize()
        {
            try
            {
                Currencies = await _serviceClient.GetCurrencies()
                                                 .ConfigureAwait(false);
                ConvertFromCurrencyId = _defaultConvertFrom;
                ConvertToCurrencyId = _defaultConvertTo;
            }
            catch
            {
                ErrorMessage = "Cannot load currency list from service.";
            }
        }

        public async Task Convert()
        {
            try
            {
                ErrorMessage = null;
                if (ConvertFromValue < 0)
                    throw new ArgumentOutOfRangeException(nameof(ConvertFromValue));

                var conversionRate = await _serviceClient.GetConversionRate(
                                                            ConvertFromCurrencyId,
                                                            ConvertToCurrencyId)
                                                         .ConfigureAwait(false);

                ConversionRate = conversionRate.Rate;
                ConvertToValue = Math.Round(ConvertFromValue * ConversionRate.Value, 2);
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Unable to convert between currencies. {ex.Message}.";
            }
        }

        public async Task SwapCurrencies()
        {
            var temp = ConvertFromCurrencyId;
            ConvertFromCurrencyId = ConvertToCurrencyId;
            ConvertToCurrencyId = temp;

            await Convert().ConfigureAwait(false);
        }

        private string FindCurrencySymbol(string currencyId)
        {
            if (string.IsNullOrEmpty(currencyId))
            {
                return string.Empty;
            }

            var result = Currencies.First(p => p.Id == currencyId)
                                   .CurrencySymbol;
            return result ?? string.Empty;
        }
    }
}
