using System.IO;
using System.Net;
using System.Text;
using CryptoView.CoinCapApi.Endpoints;

namespace CryptoView.CoinCapApi;
public class CoinCapUriBuilder
{
    private StringBuilder uriStringBuilder { get; set; }

    public CoinCapUriBuilder()
    {
        uriStringBuilder = new StringBuilder();

        uriStringBuilder.Append(CoinCapEndpoints.BaseEndPoint);
    }


    public CoinCapUriBuilder Assets()
    {
        uriStringBuilder.Append(CoinCapEndpoints.Assets);

        return this;
    }

    public CoinCapUriBuilder WithParam(string param)
    {
        uriStringBuilder.Append($"/{param}");

        return this;
    }

    public CoinCapUriBuilder WithQueryParams(Dictionary<string, object> parameters)
    {
        var urlParameters = new List<string>();
        foreach (var parameter in parameters)
        {
            if (parameter.Value is null || string.IsNullOrWhiteSpace(parameter.Value.ToString())) 
                continue;

            var value = parameter.Value.ToString();

            if (!string.IsNullOrEmpty(value)) 
                urlParameters.Add($"{parameter.Key}={value.ToLower()}");
        }

        if (urlParameters.Count > 0) 
            uriStringBuilder.Append($"?{string.Join("&", urlParameters)}");

        return this;
    }

    public Uri Build()
    {
        var uri = new Uri(uriStringBuilder.ToString());

        uriStringBuilder.Clear().Append(CoinCapEndpoints.BaseEndPoint);

        return uri;
    }
}
