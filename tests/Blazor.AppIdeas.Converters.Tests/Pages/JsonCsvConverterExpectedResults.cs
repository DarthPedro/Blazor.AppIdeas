namespace Blazor.AppIdeas.Converters.Tests.Pages
{
    static class JsonCsvConverterExpectedResults
    {
        internal const string DefaultRenderResult =
@"  <div class=""col-12 mt-3 pb-2 mb-3 container"">
      <h3 class=""mt-3"">JSON-CSV Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group col-lg-5 col-md-12"">
          <textarea id=""convert-from-value"" placeholder=""Type JSON or CSV..."" rows=""8""
                    class=""form-control valid""></textarea>
          <div class=""button-wrap"">
            <label class=""btn btn-secondary"" for=""convert-open-file"">
              <span class=""oi oi-cloud-upload"" aria-hidden=""true""></span>
              Load File
            </label>
            <input id=""convert-open-file"" style=""width: 100%"" type=""file"">
          </div>
        </div>
        <div class=""col-lg-2 col-md-12"">
          <button id=""btn-convert-csv"" class=""btn btn-primary col-lg-10 offset-lg-1 col-4 mb-lg-1 mb-3"">
            To CSV
          </button>
          <button id=""btn-convert-json"" class=""btn btn-primary col-lg-10 offset-lg-1 col-4 mb-lg-1 mb-3"">
            To JSON
          </button>
          <button id=""btn-clear"" class=""btn btn-primary col-lg-10 offset-lg-1 col-3 mb-lg-1 mb-3"">
            Clear
          </button>
        </div>
        <div class=""form-group col-lg-5 col-12"">
          <textarea id=""converted-value"" rows=""8"" readonly="""" class=""form-control valid"" ></textarea>
          <div>
            <button id=""download-file"" class=""btn btn-outline-secondary text-nowrap""
                    style=""width: 52%"" disabled="""" >
              <span class=""oi oi-cloud-download"" aria-hidden=""true""></span>
              Download File
            </button>
            <button id=""clipboard-copy"" class=""btn btn-outline-secondary""
                    style=""width: 46.5%; margin-left: -2px"" disabled="""">
              <span class=""oi oi-clipboard"" aria-hidden=""true""></span>
              Copy
            </button>
          </div>
        </div>
      </form>
    </div>
";

        internal const string ErrorResult =
@"  <div class=""col-12 mt-3 pb-2 mb-3 container"">
      <h3 class=""mt-3"">JSON-CSV Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group col-lg-5 col-md-12"">
          <textarea id=""convert-from-value"" placeholder=""Type JSON or CSV..."" rows=""8""
                    class=""form-control valid""></textarea>
          <div class=""button-wrap"">
            <label class=""btn btn-secondary"" for=""convert-open-file"">
              <span class=""oi oi-cloud-upload"" aria-hidden=""true""></span>
              Load File
            </label>
            <input id=""convert-open-file"" style=""width: 100%"" type=""file"">
          </div>
        </div>
        <div class=""col-lg-2 col-md-12"">
          <button id=""btn-convert-csv"" class=""btn btn-primary col-lg-10 offset-lg-1 col-4 mb-lg-1 mb-3"">
            To CSV
          </button>
          <button id=""btn-convert-json"" class=""btn btn-primary col-lg-10 offset-lg-1 col-4 mb-lg-1 mb-3"">
            To JSON
          </button>
          <button id=""btn-clear"" class=""btn btn-primary col-lg-10 offset-lg-1 col-3 mb-lg-1 mb-3"">
            Clear
          </button>
        </div>
        <div class=""form-group col-lg-5 col-12"">
          <textarea id=""converted-value"" rows=""8"" readonly="""" class=""form-control valid"" ></textarea>
          <div>
            <button id=""download-file"" class=""btn btn-outline-secondary text-nowrap""
                    style=""width: 52%"" disabled="""" >
              <span class=""oi oi-cloud-download"" aria-hidden=""true""></span>
              Download File
            </button>
            <button id=""clipboard-copy"" class=""btn btn-outline-secondary""
                    style=""width: 46.5%; margin-left: -2px"" disabled="""">
              <span class=""oi oi-clipboard"" aria-hidden=""true""></span>
              Copy
            </button>
          </div>
        </div>
        <div class=""alert alert-danger col-12 ml-1"">
          <strong>Error:</strong>
          Cannot parse source text. Value cannot be null. (Parameter 'text')</div>
      </form>
    </div>
";
    }
}
