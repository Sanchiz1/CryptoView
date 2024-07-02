using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CryptoView.App.Helpers;

static class StringExtensions
{
    public static decimal ToDecimal(this string str)
    {
        return Convert.ToDecimal(str);
    }
}
