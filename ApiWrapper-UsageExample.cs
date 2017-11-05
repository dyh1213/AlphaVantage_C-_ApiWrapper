using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var parameters = new List<AlphaVantageApiWrapper.ApiParam>
                {
                    new AlphaVantageApiWrapper.ApiParam("function", AlphaVantageApiWrapper.AvFuncationEnum.Sma.ToDescription()),
                    new AlphaVantageApiWrapper.ApiParam("symbol", ticker),
                    new AlphaVantageApiWrapper.ApiParam("interval", AlphaVantageApiWrapper.AvIntervalEnum.Daily.ToDescription()),
                    new AlphaVantageApiWrapper.ApiParam("time_period", "5"),
                    new AlphaVantageApiWrapper.ApiParam("series_type", AlphaVantageApiWrapper.AvSeriesType.Open.ToDescription()),
                };

                //Start Collecting SMA values

                var SMA_5 = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "20";
                var SMA_20 = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "50";
                var SMA_50 = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "200";
                var SMA_200 = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);

                //Change function to EMA
                parameters.FirstOrDefault(x => x.ParamName == "function").ParamValue = AlphaVantageApiWrapper.AvFuncationEnum.Sma.ToDescription();

                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "5";
                var EMA_5 = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "20";
                var EMA_20 = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "50";
                var EMA_50 = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "200";
                var EMA_200 = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);

                //Change function to RSI
                parameters.FirstOrDefault(x => x.ParamName == "function").ParamValue = AlphaVantageApiWrapper.AvFuncationEnum.Rsi.ToDescription();

                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "7";
                var RSI_7 = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "14";
                var RSI_14 = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "24";
                var RSI_24 = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "50";
                var RSI_50 = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);

                //Change function to MACD
                parameters.FirstOrDefault(x => x.ParamName == "function").ParamValue = AlphaVantageApiWrapper.AvFuncationEnum.Macd.ToDescription();
                //Remove time period to use default values (slow 12, fast 26)
                var itemToRemove = parameters.FirstOrDefault(x => x.ParamName == "time_period");
                parameters.Remove(itemToRemove);
                var MACD = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);

                //Change function to STOCK
                parameters.FirstOrDefault(x => x.ParamName == "function").ParamValue = AlphaVantageApiWrapper.AvFuncationEnum.Stoch.ToDescription();
                var STOCH = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);
            }
        }
    }
}
