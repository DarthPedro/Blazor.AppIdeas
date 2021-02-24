namespace Blazor.AppIdeas.Converters.Tests.Pages
{
    static class RomanDecimalConvertExpectedResults
    {
        internal const string DefaultRenderResult =
@"    <div class=""col-lg-8 col-md-10 offset-lg-2 offset-md-1 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Roman-Decimal Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group col-lg-6 col-md-12"">
          <label for=""roman"">Roman Numeral:</label>
          <input type=""text"" class=""form-control"" id=""roman"" placeholder=""Enter roman numeral"" />
        </div>
        <div class=""form-group col-lg-6 col-md-12"">
          <label for=""decimal"">Decimal:</label>
          <input type=""text"" class=""form-control"" id=""decimal"" placeholder=""Enter decimal number"" />
        </div>
        <div class=""alert alert-danger col-12 ml-1"" style=""display: none"">
          <strong>Error:</strong>
        </div>
      </form>
      <div class=""text-center"">
        <input id=""btn-convert-decimal"" class=""btn btn-outline-primary"" type=""button"" value=""Convert to Decimal"" />
        <input id=""btn-convert-roman"" class=""btn btn-outline-primary"" type=""button"" value=""Convert to Roman Numeral"" />
      </div>
    </div>
";

        internal const string RomanErrorResult =
@"    <div class=""col-lg-8 col-md-10 offset-lg-2 offset-md-1 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Roman-Decimal Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group col-lg-6 col-md-12"">
          <label for=""roman"">Roman Numeral:</label>
          <input type=""text"" class=""form-control"" id=""roman"" placeholder=""Enter roman numeral"" />
        </div>
        <div class=""form-group col-lg-6 col-md-12"">
          <label for=""decimal"">Decimal:</label>
          <input type=""text"" class=""form-control"" id=""decimal"" placeholder=""Enter decimal number"" />
        </div>
        <div class=""alert alert-danger col-12 ml-1"" style=""display: normal"">
          <strong>Error:</strong> Roman numerals only support the following characters: I, V, X, L, C, D, M.
        </div>
      </form>
      <div class=""text-center"">
        <input id=""btn-convert-decimal"" class=""btn btn-outline-primary"" type=""button"" value=""Convert to Decimal"" />
        <input id=""btn-convert-roman"" class=""btn btn-outline-primary"" type=""button"" value=""Convert to Roman Numeral"" />
      </div>
    </div>
";

        internal const string ConvertToDecimalResult =
@"    <div class=""col-lg-8 col-md-10 offset-lg-2 offset-md-1 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Roman-Decimal Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group col-lg-6 col-md-12"">
          <label for=""roman"">Roman Numeral:</label>
          <input type=""text"" class=""form-control"" id=""roman"" placeholder=""Enter roman numeral"" value=""CI"" />
        </div>
        <div class=""form-group col-lg-6 col-md-12"">
          <label for=""decimal"">Decimal:</label>
          <input type=""text"" class=""form-control"" id=""decimal"" placeholder=""Enter decimal number"" value=""101"" />
        </div>
        <div class=""alert alert-danger col-12 ml-1"" style=""display: none"">
          <strong>Error:</strong>
        </div>
      </form>
      <div class=""text-center"">
        <input id=""btn-convert-decimal"" class=""btn btn-outline-primary"" type=""button"" value=""Convert to Decimal"" />
        <input id=""btn-convert-roman"" class=""btn btn-outline-primary"" type=""button"" value=""Convert to Roman Numeral"" />
      </div>
    </div>
";

        internal const string ConvertToRomanResult =
@"    <div class=""col-lg-8 col-md-10 offset-lg-2 offset-md-1 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Roman-Decimal Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group col-lg-6 col-md-12"">
          <label for=""roman"">Roman Numeral:</label>
          <input type=""text"" class=""form-control"" id=""roman"" placeholder=""Enter roman numeral"" value=""VII"" />
        </div>
        <div class=""form-group col-lg-6 col-md-12"">
          <label for=""decimal"">Decimal:</label>
          <input type=""text"" class=""form-control"" id=""decimal"" placeholder=""Enter decimal number"" value=""7"" />
        </div>
        <div class=""alert alert-danger col-12 ml-1"" style=""display: none"">
          <strong>Error:</strong>
        </div>
      </form>
      <div class=""text-center"">
        <input id=""btn-convert-decimal"" class=""btn btn-outline-primary"" type=""button"" value=""Convert to Decimal"" />
        <input id=""btn-convert-roman"" class=""btn btn-outline-primary"" type=""button"" value=""Convert to Roman Numeral"" />
      </div>
    </div>
";
    }
}
