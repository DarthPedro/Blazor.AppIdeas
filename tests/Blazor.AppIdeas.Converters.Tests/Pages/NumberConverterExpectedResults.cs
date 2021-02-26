namespace Blazor.AppIdeas.Converters.Tests.Pages
{
    static class NumberConverterExpectedResults
    {
        internal const string DefaultRenderResult =
@"    <div class=""col-lg-8 col-md-10 offset-lg-2 offset-md-1 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Ultra Number Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group col-lg-6 col-md-12"">
          <input class=""form-control valid"" id=""entry-value"" placeholder=""Enter number"" />
          <select id=""entry-number-system"" style=""margin-top: 1px"" class=""col-12 valid"" value=""Binary"" >
            <option value=""Binary"">Binary</option>
            <option value=""Octal"">Octal</option>
            <option value=""Decimal"">Decimal</option>
            <option value=""Hexadecimal"">Hexadecimal</option>
            <option value=""Roman"">Roman</option>
          </select>
        </div>
        <div class=""form-group col-lg-6 col-md-12"">
          <input class=""form-control valid"" id=""result-value"" placeholder=""Result..."" readonly />
          <select id=""result-number-system"" style=""margin-top: 1px"" class=""col-12 valid"" value=""Decimal"">
            <option value=""Binary"">Binary</option>
            <option value=""Octal"">Octal</option>
            <option value=""Decimal"" selected="""">Decimal</option>
            <option value=""Hexadecimal"">Hexadecimal</option>
            <option value=""Roman"">Roman</option>
          </select>
        </div>
      </form>
      <div class=""text-center"">
        <input id=""btn-convert"" class=""btn btn-outline-primary"" type=""button"" value=""Convert"" />
      </div>
    </div>
";

        internal const string ErrorResult =
@"    <div class=""col-lg-8 col-md-10 offset-lg-2 offset-md-1 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Ultra Number Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group col-lg-6 col-md-12"">
          <input class=""form-control valid"" id=""entry-value"" placeholder=""Enter number"" />
          <select id=""entry-number-system"" style=""margin-top: 1px"" class=""col-12 valid"" value=""Binary"" >
            <option value=""Binary"">Binary</option>
            <option value=""Octal"">Octal</option>
            <option value=""Decimal"">Decimal</option>
            <option value=""Hexadecimal"">Hexadecimal</option>
            <option value=""Roman"">Roman</option>
          </select>
        </div>
        <div class=""form-group col-lg-6 col-md-12"">
          <input class=""form-control valid"" id=""result-value"" placeholder=""Result..."" readonly />
          <select id=""result-number-system"" style=""margin-top: 1px"" class=""col-12 valid"" value=""Decimal"">
            <option value=""Binary"">Binary</option>
            <option value=""Octal"">Octal</option>
            <option value=""Decimal"" selected="""">Decimal</option>
            <option value=""Hexadecimal"">Hexadecimal</option>
            <option value=""Roman"">Roman</option>
          </select>
        </div>
        <div class=""alert alert-danger col-12 ml-1"">
          <strong>Error:</strong> Binary numbers only support digits: 0s and 1s.
        </div>
      </form>
      <div class=""text-center"">
        <input id=""btn-convert"" class=""btn btn-outline-primary"" type=""button"" value=""Convert"" />
      </div>
    </div>
";

        internal const string ConvertToDecimalResult =
@"    <div class=""col-lg-8 col-md-10 offset-lg-2 offset-md-1 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Ultra Number Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group col-lg-6 col-md-12"">
          <input class=""form-control valid"" id=""entry-value"" placeholder=""Enter number"" value=""13""/>
          <select id=""entry-number-system"" style=""margin-top: 1px"" class=""col-12 valid"" value=""Octal"" >
            <option value=""Binary"">Binary</option>
            <option value=""Octal"">Octal</option>
            <option value=""Decimal"">Decimal</option>
            <option value=""Hexadecimal"">Hexadecimal</option>
            <option value=""Roman"">Roman</option>
          </select>
        </div>
        <div class=""form-group col-lg-6 col-md-12"">
          <input class=""form-control valid"" id=""result-value"" placeholder=""Result..."" readonly value=""11"" />
          <select id=""result-number-system"" style=""margin-top: 1px"" class=""col-12 valid"" value=""Decimal"">
            <option value=""Binary"">Binary</option>
            <option value=""Octal"">Octal</option>
            <option value=""Decimal"" selected="""">Decimal</option>
            <option value=""Hexadecimal"">Hexadecimal</option>
            <option value=""Roman"">Roman</option>
          </select>
        </div>
      </form>
      <div class=""text-center"">
        <input id=""btn-convert"" class=""btn btn-outline-primary"" type=""button"" value=""Convert"" />
      </div>
    </div>
";
    }
}
