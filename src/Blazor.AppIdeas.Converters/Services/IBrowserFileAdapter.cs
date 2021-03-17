using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Blazor.AppIdeas.Converters.Services
{
    public interface IBrowserFileAdapter
    {
        public enum FileType
        {
            JSON = 0,
            CSV = 1
        }

        Task<string> ReadTextAsync(IBrowserFile file);

        Task SaveTextAsAsync(IJSRuntime js, string filename, FileType fileType, string data);
    }
}
