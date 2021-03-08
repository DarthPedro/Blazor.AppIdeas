using Blazor.AppIdeas.Converters.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.AppIdeas.Converters.Services
{
    public interface ICurrencyServiceClient
    {
        Task<CurrencyConversion> GetConversionRate(string convertFromId, string convertToId);

        Task<IEnumerable<CurrencyDescriptor>> GetCurrencies();
    }
}
