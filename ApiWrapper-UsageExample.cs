using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantRanksLibraries.Helpers;
using static QuantRanksLibraries.Helpers.AlphaVantageApiWrapper;

namespace AlphaVantageApiWrapper
{
    public static class AlphaVantageApiDbLoader
    {
        public static async Task TestAsync()
        {
            var API_KEY = "ENTER YOUR FREE API KEY HERE";

            var StockTickers = new List<string> {"AAPL"};

            foreach (var ticker in StockTickers)
            {
                var parameters = new List<ApiParam>
                {
                    new ApiParam("function", AvFuncationEnum.Sma.ToDescription()),
                    new ApiParam("symbol", ticker),
                    new ApiParam("interval", AvIntervalEnum.Daily.ToDescription()),
                    new ApiParam("time_period", "5"),
                    new ApiParam("series_type", AvSeriesType.Open.ToDescription()),
                };

                //Start Collecting SMA values

                var SMA_5 = await GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "20";
                var SMA_20 = await GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "50";
                var SMA_50 = await GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "200";
                var SMA_200 = await GetTechnical(parameters, API_KEY);

                //Change function to EMA
                parameters.FirstOrDefault(x => x.ParamName == "function").ParamValue = AvFuncationEnum.Sma.ToDescription();

                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "5";
                var EMA_5 = await GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "20";
                var EMA_20 = await GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "50";
                var EMA_50 = await GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "200";
                var EMA_200 = await GetTechnical(parameters, API_KEY);

                //Change function to RSI
                parameters.FirstOrDefault(x => x.ParamName == "function").ParamValue = AvFuncationEnum.Rsi.ToDescription();

                parameters.FirstOrDefault(x => x.ParamName == "time_perio ").ParamValue = "7";
                var RSI_7 = await GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "14";
                var RSI_14 = await GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "24";
                var RSI_24 = await GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "50";
                var RSI_50 = await GetTechnical(parameters, API_KEY);

                //Change function to MACD
                parameters.FirstOrDefault(x => x.ParamName == "function").ParamValue = AvFuncationEnum.Macd.ToDescription();
                //Remove time period to use default values (slow 12, fast 26)
                var itemToRemove = parameters.FirstOrDefault(x => x.ParamName == "time_period");
                parameters.Remove(itemToRemove);
                var MACD = await GetTechnical(parameters, API_KEY);

                //Change function to STOCK
                parameters.FirstOrDefault(x => x.ParamName == "function").ParamValue = AvFuncationEnum.Stoch.ToDescription();
                var STOCH = await GetTechnical(parameters, API_KEY);
            }
        }
    }
}
