using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _16_wpf_menu_command
{
    public static class SajatParancsok
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand(
            "Kilépés",
            "Exit",
            typeof(SajatParancsok),
            new InputGestureCollection() {new KeyGesture(Key.Q,ModifierKeys.Control) }
            );


    }
}
