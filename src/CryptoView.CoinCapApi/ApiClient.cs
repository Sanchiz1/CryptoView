using CryptoView.CoinCapApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoView.CoinCapApi;
internal class ApiClient
{
    public readonly HttpClient _client;

    public ApiClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<T> GetAsync<T>(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await _client.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri), cancellationToken)
                .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(responseContent);
    }
}
