using CryptoView.CoinCapApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CryptoView.CoinCapApi;
public class AssetsService
{
    private readonly ApiClient _client;
    private readonly CoinCapUriBuilder _uriBuilder;
    public AssetsService()
    {
        _client = new ApiClient(new HttpClient());
        _uriBuilder = new CoinCapUriBuilder();
    }
    public async Task<IEnumerable<Asset>> GetAssetsAsync()
    {
        var res = await _client.GetAsync<DataType<IEnumerable<Asset>>>(
                _uriBuilder.Assets().Build())
                .ConfigureAwait(false);
        return res.Data;
    }
}
