using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCIProjekat.Komande
{
    public static class RoutedCommands
    {
        public static readonly RoutedUICommand FormaSpomenik = new RoutedUICommand(
            "Forma Spomenik",
            "FormaSpomenik",
            typeof(RoutedUICommand),
            new InputGestureCollection() {

                new KeyGesture(Key.S, ModifierKeys.Control)

            }
        );

        public static readonly RoutedUICommand FormaEtiketa = new RoutedUICommand(
            "Forma Etiketa",
            "FormaEtiketa",
            typeof(RoutedUICommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Control)
            }

        );

        public static readonly RoutedUICommand FormaTip = new RoutedUICommand(
            "Forma Tip",
            "FormaTip",
            typeof(RoutedUICommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand TabelaSpomenici = new RoutedUICommand(
            "Tabela spomenici",
            "TabelaSpomenici",
            typeof(RoutedUICommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S, ModifierKeys.Alt)
            }
        );

        public static readonly RoutedUICommand TabelaEtikete = new RoutedUICommand(
            "Tabela etikete",
            "TabelaEtikete",
            typeof(RoutedUICommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Alt)
            }
        );

        public static readonly RoutedUICommand TabelaTipovi = new RoutedUICommand(
            "Tabela tipovi",
            "TabelaTipovi",
            typeof(RoutedUICommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T, ModifierKeys.Alt)
            }
        );
    }
}
