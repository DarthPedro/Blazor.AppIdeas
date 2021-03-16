using Microsoft.AspNetCore.Components.Forms;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.AppIdeas.Converters.Services
{
    public class BrowserFileAdapter : IBrowserFileAdapter
    {
        public async Task<string> ReadTextAsync(IBrowserFile browserFile)
        {
            _ = browserFile ?? throw new ArgumentNullException(nameof(browserFile));

            using var file = browserFile.OpenReadStream();
            using var reader = new StreamReader(file, Encoding.UTF8);

            return await reader.ReadToEndAsync().ConfigureAwait(false);
        }
    }
}
