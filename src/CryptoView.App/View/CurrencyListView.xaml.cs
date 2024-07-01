using CryptoView.CoinCapApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoView.App.View
{
    /// <summary>
    /// Interaction logic for CurrencyListView.xaml
    /// </summary>
    public partial class CurrencyListView : UserControl
    {
        public CurrencyListView()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AssetsService service = new AssetsService();

                var res = await service.GetAssetsAsync();
                MessageBox.Show(res.ToString());
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
