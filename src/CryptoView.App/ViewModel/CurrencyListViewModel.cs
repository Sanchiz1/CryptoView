using CryptoView.App.Utils;
using CryptoView.CoinCapApi;
using CryptoView.CoinCapApi.Entities;
using System.Windows.Input;

namespace CryptoView.App.ViewModel;

class CurrencyListViewModel : ViewModelBase
{
    private readonly AssetsService assetsService = new AssetsService();

    private IEnumerable<Asset> _assets = new List<Asset>();

    private string _searchQuery = "";

    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            _searchQuery = value;
            OnPropertyChanged(nameof(SearchQuery));
        }
    }

    private int _skip = 0;

    public int Skip
    {
        get => _skip;
        set
        {
            _skip = value;
            OnPropertyChanged(nameof(Skip));
        }
    }

    private const int Take = 10;
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
    public ICommand NextCommand { get; }
    public ICommand PreviousCommand { get; }
    public ICommand SearchCommand { get; }

    public CurrencyListViewModel()
    {
        OnPropertyChanged();
        GetAssetsCommand = new AsyncCommand(FetchAssets);
        NextCommand = new RelayCommand(_ => NextPage());
        PreviousCommand = new RelayCommand(_ => PreviousPage());
        SearchCommand = new RelayCommand(_ => Search());
        _ = FetchAssets();
    }
    private void NextPage()
    {
        Skip+=Take;
        _ = FetchAssets();
    }

    private void PreviousPage()
    {
        if (Skip <= Take)
        {
            Skip = 0;
        }
        else
        {
            Skip -= Take;
        }
        _ = FetchAssets();
    }

    private void Search()
    {
        Skip = 0;
        _ = FetchAssets();
    }

    public async Task FetchAssets()
    {
        Assets = await assetsService.GetAssetsAsync(Take, Skip, SearchQuery);
    }
}
