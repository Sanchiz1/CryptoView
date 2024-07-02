using CryptoView.App.Utils;
using System.Windows.Input;

namespace CryptoView.App.ViewModel;

class NavigationViewModel : ViewModelBase
{
    private object _currentView;
    public object CurrentView
    {
        get { return _currentView; }
        set { _currentView = value; OnPropertyChanged(); }
    }

    public ICommand CurrencyListCommand { get; set; }
    public ICommand ExchangesCommand { get; set; }

    private void CurrencyList(object obj) => CurrentView = new CurrencyListViewModel();
    private void Exchanges(object obj) => CurrentView = new ExchangesViewModel();

    public NavigationViewModel()
    {
        CurrencyListCommand = new RelayCommand<object>(CurrencyList);
        ExchangesCommand = new RelayCommand<object>(Exchanges);
        CurrentView = new CurrencyListViewModel();
    }
}
