namespace Blazor.AppIdeas.Converters.Tests.Pages
{
    static class DollarCentsConverterExpectedResults
    {
        internal const string DefaultRenderResult =
@"  <div class=""row"">
      <div class=""col-lg-6 col-md-12 pr-lg-0"">
        <div class=""mt-3 pb-3 container"">
          <h3 class=""mt-3"">Dollar to Cents Converter</h3>
          <hr>
          <form class=""form-row"">
            <div class=""form-group col-12"">
              <label for=""dollar"">Dollar value:</label>
              <input id=""dollar"" type=""number"" class=""form-control""
                     placeholder=""Enter dollar value"" min=""0.00"" max=""1000.00"" step=""0.01"" />
            </div>
          </form>
          <div class=""text-center"">
            <input id=""btn-convert"" class=""btn btn-outline-primary"" type=""button""
                   value=""Convert to Cents"" />
          </div>
        </div>
      </div>
    </div>
";

        internal const string DollarValueErrorResult =
@"  <div class=""row"">
      <div class=""col-lg-6 col-md-12 pr-lg-0"">
        <div class=""mt-3 pb-3 container"">
          <h3 class=""mt-3"">Dollar to Cents Converter</h3>
          <hr>
          <form class=""form-row"">
            <div class=""form-group col-12"">
              <label for=""dollar"">Dollar value:</label>
              <input id=""dollar"" type=""number"" class=""form-control""
                     placeholder=""Enter dollar value"" min=""0.00"" max=""1000.00"" step=""0.01"" />
            </div>
            <div class=""alert alert-danger col-12 ml-1"">
              <strong>Error:</strong>
              The dollar value must be a valid number between 0.00 and 1000.00.
            </div>
          </form>
          <div class=""text-center"">
            <input id=""btn-convert"" class=""btn btn-outline-primary"" type=""button""
                   value=""Convert to Cents"" />
          </div>
        </div>
      </div>
    </div>
";

        internal const string ConvertResult =
@"  <div class=""row"">
      <div class=""col-lg-6 col-md-12 pr-lg-0"">
        <div class=""mt-3 pb-3 container"">
          <h3 class=""mt-3"">Dollar to Cents Converter</h3>
          <hr>
          <form class=""form-row"">
            <div class=""form-group col-12"">
              <label for=""dollar"">Dollar value:</label>
              <input id=""dollar"" type=""number"" class=""form-control"" value=""1.49""
                     placeholder=""Enter dollar value"" min=""0.00"" max=""1000.00"" step=""0.01"" />
            </div>
          </form>
          <div class=""text-center"">
            <input id=""btn-convert"" class=""btn btn-outline-primary"" type=""button""
                   value=""Convert to Cents"" />
          </div>
        </div>
      </div>
      <div class=""col-lg-6 col-md-12"">
        <div class=""mt-3 pb-3 container"">
          <h5 class=""mt-3"">Results: 149 cents</h5>
          <hr>
          <table class=""table table-striped table-bordered col-10 offset-1"">
            <thead class=""thead-light"">
              <tr>
                <td>
                  <strong>Coins</strong>
                </td>
                <td class=""text-center"">
                  <strong>Count</strong>
                </td>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Quarters (25¢)</td>
                <td class=""text-center"">5</td>
              </tr>
              <tr>
                <td>Dimes (10¢)</td>
                <td class=""text-center"">2</td>
              </tr>
              <tr>
                <td>Nickels (5¢)</td>
                <td class=""text-center"">0</td>
              </tr>
              <tr>
                <td>Pennies (1¢)</td>
                <td class=""text-center"">4</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>

    </div>
";
    }
}
