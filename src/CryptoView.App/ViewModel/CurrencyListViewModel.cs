using CryptoView.App.Utils;
using CryptoView.CoinCapApi;
using CryptoView.CoinCapApi.Entities;
using System.Windows.Input;

namespace CryptoView.App.ViewModel;

class CurrencyListViewModel : ViewModelBase
{
    private readonly AssetsService assetsService = new AssetsService();
    private IEnumerable<Asset> _assets = new List<Asset>();

    public IEnumerable<Asset> Assets
    {
        get => _assets;
        set
        {
            _assets = value;
            OnPropertyChanged(nameof(Assets));
        }
    }

    public ICommand GetAssetsCommand { get; }

    public CurrencyListViewModel()
    {
        OnPropertyChanged();
        GetAssetsCommand = new AsyncCommand(FetchAssets);
        _ = FetchAssets();
    }

    public async Task FetchAssets()
    {
        Assets = await assetsService.GetAssetsAsync();
    }
}
