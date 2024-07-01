using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoView.CoinCapApi.Entities;
public class DataType<T>
{
    [JsonPropertyName("data")]
    public required T Data { get; set; }
}
