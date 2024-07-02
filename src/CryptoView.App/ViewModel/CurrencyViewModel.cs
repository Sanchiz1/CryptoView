using CryptoView.App.Utils;
using CryptoView.CoinCapApi;
using CryptoView.CoinCapApi.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CryptoView.App.ViewModel;

class CurrencyViewModel : ViewModelBase
{
    private readonly AssetsService assetsService = new AssetsService();

    private string _assetId = "";
    private Asset _asset;

    public string AssetId
    {
        get => _assetId;
        set
        {
            _assetId = value;
            OnPropertyChanged(nameof(AssetId));
            _ = FetchAsset();
        }
    }
    public Asset Asset
    {
        get => _asset;
        set
        {
            _asset = value;
            OnPropertyChanged(nameof(Asset));
        }
    }

    public ICommand VisitCommand { get; }
    public CurrencyViewModel()
    {
        VisitCommand = new RelayCommand<object>(_ => Visit());
    }

    public void Visit()
    {
        if (Asset == null) return;

        Process.Start(
            new ProcessStartInfo(
                "cmd", $"/c start {Asset.Explorer}"
            )
            { CreateNoWindow = true }
        );
    }

    public async Task FetchAsset()
    {
        Asset = await assetsService.GetAssetAsync(AssetId);
    }
}
