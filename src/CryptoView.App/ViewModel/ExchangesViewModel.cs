using CryptoView.App.Utils;
using CryptoView.CoinCapApi.Entities;
using CryptoView.CoinCapApi;
using System.Windows.Input;
using CryptoView.App.Helpers;

namespace CryptoView.App.ViewModel;

class ExchangesViewModel : ViewModelBase
{
    private readonly CoinCapService assetsService = new CoinCapService();
    private readonly WindowService windowService = new WindowService();

    private Asset? _asset1;
    private Asset? _asset2;

    private string _searchQuery1 = "";
    private string _searchQuery2 = "";

    private decimal _exchangeRate;

    public string SearchQuery1
    {
        get => _searchQuery1;
        set
        {
            _searchQuery1 = value;
            OnPropertyChanged(nameof(SearchQuery1));
        }
    }

    public string SearchQuery2
    {
        get => _searchQuery2;
        set
        {
            _searchQuery2 = value;
            OnPropertyChanged(nameof(SearchQuery2));
        }
    }

    private const int Skip = 1;
    private const int Take = 1;
    public Asset? Asset1
    {
        get => _asset1;
        set
        {
            _asset1 = value;
            OnPropertyChanged(nameof(Asset1));
            CalculateExchangeRate();
        }
    }
    
    public Asset? Asset2
    {
        get => _asset2;
        set
        {
            _asset2 = value;
            OnPropertyChanged(nameof(Asset2));
            CalculateExchangeRate();
        }
    }

    public decimal ExchangeRate
    {
        get => _exchangeRate;
        set
        {
            _exchangeRate = value;
            OnPropertyChanged(nameof(ExchangeRate));
        }
    }

    public ICommand GetAssetsCommand { get; }
    public ICommand NextCommand { get; }
    public ICommand PreviousCommand { get; }
    public ICommand SearchAsset1Command { get; }
    public ICommand SearchAsset2Command { get; }
    public ICommand OpenCurrencyCommand { get; }

    public ExchangesViewModel()
    {
        OnPropertyChanged();
        SearchAsset1Command = new AsyncCommand(FetchAsset1);
        SearchAsset2Command = new AsyncCommand(FetchAsset2);
    }

    public void CalculateExchangeRate()
    {
        if(Asset1 is null || Asset2 is null) return;

        ExchangeRate = Asset1.PriceUsd.ToDecimal() / Asset2.PriceUsd.ToDecimal();
    }

    public async Task FetchAsset1()
    {
        Asset1 = await assetsService.GetAssetAsync(SearchQuery1);
    }

    public async Task FetchAsset2()
    {
        Asset2 = await assetsService.GetAssetAsync(SearchQuery2);
    }
}
