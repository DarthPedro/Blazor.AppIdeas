namespace Blazor.AppIdeas.Converters.Tests.Pages
{
    static class BinaryDecimalConvertExpectedResults
    {
        internal const string DefaultRenderResult =
@"    <div class=""col-lg-8 col-md-10 offset-lg-2 offset-md-1 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Binary-Decimal Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group col-lg-6 col-md-12"">
          <label for=""binary"">Binary:</label>
          <input type=""text"" class=""form-control"" id=""binary"" placeholder=""Enter binary number"" />
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
        <input id=""btn-convert-binary"" class=""btn btn-outline-primary"" type=""button"" value=""Convert to Binary"" />
      </div>
    </div>
";

        internal const string BinaryErrorResult =
@"    <div class=""col-lg-8 col-md-10 offset-lg-2 offset-md-1 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Binary-Decimal Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group col-lg-6 col-md-12"">
          <label for=""binary"">Binary:</label>
          <input type=""text"" class=""form-control"" id=""binary"" placeholder=""Enter binary number"" />
        </div>
        <div class=""form-group col-lg-6 col-md-12"">
          <label for=""decimal"">Decimal:</label>
          <input type=""text"" class=""form-control"" id=""decimal"" placeholder=""Enter decimal number"" />
        </div>
        <div class=""alert alert-danger col-12 ml-1"" style=""display: normal"">
          <strong>Error:</strong> Binary must be a valid number with only 0s and 1s.
        </div>
      </form>
      <div class=""text-center"">
        <input id=""btn-convert-decimal"" class=""btn btn-outline-primary"" type=""button"" value=""Convert to Decimal"" />
        <input id=""btn-convert-binary"" class=""btn btn-outline-primary"" type=""button"" value=""Convert to Binary"" />
      </div>
    </div>
";

        internal const string ConvertToDecimalResult =
@"    <div class=""col-lg-8 col-md-10 offset-lg-2 offset-md-1 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Binary-Decimal Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group col-lg-6 col-md-12"">
          <label for=""binary"">Binary:</label>
          <input type=""text"" class=""form-control"" id=""binary"" placeholder=""Enter binary number"" value=""101"" />
        </div>
        <div class=""form-group col-lg-6 col-md-12"">
          <label for=""decimal"">Decimal:</label>
          <input type=""text"" class=""form-control"" id=""decimal"" placeholder=""Enter decimal number"" value=""5"" />
        </div>
        <div class=""alert alert-danger col-12 ml-1"" style=""display: none"">
          <strong>Error:</strong>
        </div>
      </form>
      <div class=""text-center"">
        <input id=""btn-convert-decimal"" class=""btn btn-outline-primary"" type=""button"" value=""Convert to Decimal"" />
        <input id=""btn-convert-binary"" class=""btn btn-outline-primary"" type=""button"" value=""Convert to Binary"" />
      </div>
    </div>
";

        internal const string ConvertToBinaryResult =
@"    <div class=""col-lg-8 col-md-10 offset-lg-2 offset-md-1 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Binary-Decimal Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group col-lg-6 col-md-12"">
          <label for=""binary"">Binary:</label>
          <input type=""text"" class=""form-control"" id=""binary"" placeholder=""Enter binary number"" value=""111"" />
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
        <input id=""btn-convert-binary"" class=""btn btn-outline-primary"" type=""button"" value=""Convert to Binary"" />
      </div>
    </div>
";
    }
}
