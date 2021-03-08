namespace Blazor.AppIdeas.Converters.Tests.Pages
{
    static class CurrencyConverterExpectedResults
    {
        internal const string DefaultRenderResult =
@"  <div class=""col-12 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Currency Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group input-group col-lg-5 col-md-12"">
          <div class=""input-group-prepend"">
              <span class=""input-group-text"">$</span>
          </div>
          <input id=""convert-from-value"" min=""0.00"" step=""0.01"" placeholder=""Enter amount""
                 type=""number"" class=""form-control valid"" value=""0"" />
          <select id=""convert-from-currency-id"" style=""margin-top: 1px"" class=""col-12 valid"" value=""USD"">
            <option value=""USD"" selected="""">United States Dollar [USD]
            </option>
            <option value=""YEN"">Japanese Yen [YEN]
            </option>
            <option value=""EUR"">Euro [EUR]
            </option>
            <option value=""PES"">Mexican Peso [PES]
            </option>
            <option value=""CAD"">Canadian Dollar [CAD]
            </option>
          </select>
        </div>
        <div class=""form-group col-lg-2 col-md-12 text-center"">
          <button id=""btn-swap"" style=""width: 48px"" class=""btn btn-outline-primary col-lg-12 col-sm-6"">
            <span class=""oi oi-loop-circular"" aria-hidden=""true""></span>
          </button>
        </div>
        <div class=""form-group input-group col-lg-5 col-md-12"">
          <div class=""input-group-prepend"">
              <span class=""input-group-text"">E</span>
          </div>
          <label id=""convert-to-value"" class=""form-control mb-0"">0</label>
          <select id=""convert-to-currency-id"" style=""margin-top: 1px"" class=""col-12 valid"" value=""EUR"">
            <option value=""USD"">United States Dollar [USD]
            </option>
            <option value=""YEN"">Japanese Yen [YEN]
            </option>
            <option value=""EUR"" selected="""">Euro [EUR]
            </option>
            <option value=""PES"">Mexican Peso [PES]
            </option>
            <option value=""CAD"">Canadian Dollar [CAD]
            </option>
          </select>
        </div>
      </form>
      <div class=""text-center"">
        <input type=""button"" id=""btn-convert"" class=""btn btn-outline-primary"" value=""Convert"" />
      </div>
    </div>
";

        internal const string ErrorResult =
@"  <div class=""col-12 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Currency Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group input-group col-lg-5 col-md-12"">
          <div class=""input-group-prepend"">
              <span class=""input-group-text"">$</span>
          </div>
          <input id=""convert-from-value"" min=""0.00"" step=""0.01"" placeholder=""Enter amount""
                 type=""number"" class=""form-control valid"" value=""0"" />
          <select id=""convert-from-currency-id"" style=""margin-top: 1px"" class=""col-12 valid"" value=""USD"">
            <option value=""USD"" selected="""">United States Dollar [USD]
            </option>
            <option value=""YEN"">Japanese Yen [YEN]
            </option>
            <option value=""EUR"">Euro [EUR]
            </option>
            <option value=""PES"">Mexican Peso [PES]
            </option>
            <option value=""CAD"">Canadian Dollar [CAD]
            </option>
          </select>
        </div>
        <div class=""form-group col-lg-2 col-md-12 text-center"">
          <button id=""btn-swap"" style=""width: 48px"" class=""btn btn-outline-primary col-lg-12 col-sm-6"">
            <span class=""oi oi-loop-circular"" aria-hidden=""true""></span>
          </button>
        </div>
        <div class=""form-group input-group col-lg-5 col-md-12"">
          <div class=""input-group-prepend"">
              <span class=""input-group-text"">P</span>
          </div>
          <label id=""convert-to-value"" class=""form-control mb-0"">0</label>
          <select id=""convert-to-currency-id"" style=""margin-top: 1px"" class=""col-12 valid"" value=""PES"">
            <option value=""USD"">United States Dollar [USD]
            </option>
            <option value=""YEN"">Japanese Yen [YEN]
            </option>
            <option value=""EUR"">Euro [EUR]
            </option>
            <option value=""PES"" selected="""">Mexican Peso [PES]
            </option>
            <option value=""CAD"">Canadian Dollar [CAD]
            </option>
          </select>
        </div>
        <div class=""alert alert-danger col-12 ml-1"">
          <strong>Error:</strong>
          Unable to convert between currencies. One of the identified items was in an invalid format..
        </div>
      </form>
      <div class=""text-center"">
        <input type=""button"" id=""btn-convert"" class=""btn btn-outline-primary"" value=""Convert"" />
      </div>
    </div>
";

        internal const string ConvertCurrencyResult =
@"  <div class=""col-12 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Currency Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group input-group col-lg-5 col-md-12"">
          <div class=""input-group-prepend"">
              <span class=""input-group-text"">$</span>
          </div>
          <input id=""convert-from-value"" min=""0.00"" step=""0.01"" placeholder=""Enter amount""
                 type=""number"" class=""form-control valid"" value=""100"" />
          <select id=""convert-from-currency-id"" style=""margin-top: 1px"" class=""col-12 valid"" value=""USD"">
            <option value=""USD"" selected="""">United States Dollar [USD]
            </option>
            <option value=""YEN"">Japanese Yen [YEN]
            </option>
            <option value=""EUR"">Euro [EUR]
            </option>
            <option value=""PES"">Mexican Peso [PES]
            </option>
            <option value=""CAD"">Canadian Dollar [CAD]
            </option>
          </select>
        </div>
        <div class=""form-group col-lg-2 col-md-12 text-center"">
          <button id=""btn-swap"" style=""width: 48px"" class=""btn btn-outline-primary col-lg-12 col-sm-6"">
            <span class=""oi oi-loop-circular"" aria-hidden=""true""></span>
          </button>
          <label class=""col-lg-12 col-sm-6 mt-2"">
            <strong>Rate:</strong>
            0.81357
          </label>
        </div>
        <div class=""form-group input-group col-lg-5 col-md-12"">
          <div class=""input-group-prepend"">
              <span class=""input-group-text"">E</span>
          </div>
          <label id=""convert-to-value"" class=""form-control mb-0"">81.36</label>
          <select id=""convert-to-currency-id"" style=""margin-top: 1px"" class=""col-12 valid"" value=""EUR"">
            <option value=""USD"">United States Dollar [USD]
            </option>
            <option value=""YEN"">Japanese Yen [YEN]
            </option>
            <option value=""EUR"" selected="""">Euro [EUR]
            </option>
            <option value=""PES"">Mexican Peso [PES]
            </option>
            <option value=""CAD"">Canadian Dollar [CAD]
            </option>
          </select>
        </div>
      </form>
      <div class=""text-center"">
        <input type=""button"" id=""btn-convert"" class=""btn btn-outline-primary"" value=""Convert"" />
      </div>
    </div>
";

        internal const string SwapCurrenciesResult =
@"  <div class=""col-12 mt-3 pb-3 container"">
      <h3 class=""mt-3"">Currency Converter</h3>
      <hr>
      <form class=""form-row"">
        <div class=""form-group input-group col-lg-5 col-md-12"">
          <div class=""input-group-prepend"">
              <span class=""input-group-text"">$</span>
          </div>
          <input id=""convert-from-value"" min=""0.00"" step=""0.01"" placeholder=""Enter amount""
                 type=""number"" class=""form-control valid"" value=""100"" />
          <select id=""convert-from-currency-id"" style=""margin-top: 1px"" class=""col-12 valid"" value=""USD"">
            <option value=""USD"" selected="""">United States Dollar [USD]
            </option>
            <option value=""YEN"">Japanese Yen [YEN]
            </option>
            <option value=""EUR"">Euro [EUR]
            </option>
            <option value=""PES"">Mexican Peso [PES]
            </option>
            <option value=""CAD"">Canadian Dollar [CAD]
            </option>
          </select>
        </div>
        <div class=""form-group col-lg-2 col-md-12 text-center"">
          <button id=""btn-swap"" style=""width: 48px"" class=""btn btn-outline-primary col-lg-12 col-sm-6"">
            <span class=""oi oi-loop-circular"" aria-hidden=""true""></span>
          </button>
          <label class=""col-lg-12 col-sm-6 mt-2"">
            <strong>Rate:</strong>
            0.81357
          </label>
        </div>
        <div class=""form-group input-group col-lg-5 col-md-12"">
          <div class=""input-group-prepend"">
              <span class=""input-group-text"">E</span>
          </div>
          <label id=""convert-to-value"" class=""form-control mb-0"">81.36</label>
          <select id=""convert-to-currency-id"" style=""margin-top: 1px"" class=""col-12 valid"" value=""EUR"">
            <option value=""USD"">United States Dollar [USD]
            </option>
            <option value=""YEN"">Japanese Yen [YEN]
            </option>
            <option value=""EUR"" selected="""">Euro [EUR]
            </option>
            <option value=""PES"">Mexican Peso [PES]
            </option>
            <option value=""CAD"">Canadian Dollar [CAD]
            </option>
          </select>
        </div>
      </form>
      <div class=""text-center"">
        <input type=""button"" id=""btn-convert"" class=""btn btn-outline-primary"" value=""Convert"" />
      </div>
    </div>
";
    }
}
