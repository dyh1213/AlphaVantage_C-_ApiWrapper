# AlphaVantage C# API Wrapper

The repository includes a simple API wrapper for retrieving the technical stock data from the Alpha Vantage API (www.alphavantage.co).

After making a call the data is sorted into a list of dates, each containing a list of TechnicalDataObjects, comprised of the name and value of that object.
 
### Supported Data

This supports all technical indicators, regardless of their input or output values. I believe it can be used for the TimeSeriesData as well, but I did not try it as I have no use for it.

### Example Usage

The function GetTechnical(paramteres, API_Key) receieved a list of parameters for the call, and returns the data as a c# list.

The below parameters list would call the SMA function for the ticker "AAPL", using a daily data interval, taking intoo each SMA the last 5 days, and using the open price instead of close. 

There are some enums to help with the most frequent data inputs.

```C# 
var parameters = new List<ApiParam>
{
	new ApiParam("function", AvFuncationEnum.Sma.ToDescription()),
	new ApiParam("symbol", ticker),
	new ApiParam("interval", AvIntervalEnum.Daily.ToDescription()),
	new ApiParam("time_period", "5"),
	new ApiParam("series_type", AvSeriesType.Open.ToDescription()),
};
```

You can then modify the parameters and get different variations of the same function, or call a different one alltogether.

```C# 
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

parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "7";
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
```

