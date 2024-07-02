using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CryptoView.App.Utils;

class WindowService
{
    public void ShowWindow(ViewModelBase viewModel)
    {
        var win = new Window();
        Uri iconUri = new Uri("pack://application:,,,/icons8-coin-100.png", UriKind.RelativeOrAbsolute);

        win.Icon = BitmapFrame.Create(iconUri);
        win.Content = viewModel;
        win.Show();
    }
}
