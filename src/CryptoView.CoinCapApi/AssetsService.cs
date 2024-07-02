using CryptoView.CoinCapApi.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    public async Task<IEnumerable<Asset>> GetAssetsAsync(int limit, int offset, string search)
    {
        var res = await _client.GetAsync<DataType<IEnumerable<Asset>>>(
                _uriBuilder.Assets().WithQueryParams(new Dictionary<string, object>()
                {
                    {"limit", limit },
                    {"offset", offset },
                    {"search", search }
                }).Build())
                .ConfigureAwait(false);
        return res.Data;
    }

    public async Task<Asset> GetAssetAsync(string assetId)
    {
        var res = await _client.GetAsync<DataType<Asset>>(
                _uriBuilder.Assets().WithParam(assetId).Build())
                .ConfigureAwait(false);
        return res.Data;
    }
}
