using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;

namespace Blazor.AppIdeas.Converters.Services
{
    public interface IBrowserFileAdapter
    {
        Task<string> ReadTextAsync(IBrowserFile file);
    }
}
