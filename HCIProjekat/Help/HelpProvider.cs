using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace HCIProjekat.Help
{
    static class HelpProvider

    {
        static HelpProvider()

        {

            CommandManager.RegisterClassCommandBinding(

                typeof(FrameworkElement),

                new CommandBinding(

                    ApplicationCommands.Help,

                    new ExecutedRoutedEventHandler(Executed),

                    new CanExecuteRoutedEventHandler(CanExecute)));

        }



        static private void CanExecute(object sender, CanExecuteRoutedEventArgs e)

        {



            FrameworkElement senderElement = sender as FrameworkElement;



            if (HelpProvider.GetHelpString(senderElement) != null)

                e.CanExecute = true;

        }



        static private void Executed(object sender, ExecutedRoutedEventArgs e)

        {
            System.Windows.Forms.Help.ShowHelp(null, @"Pomoc.chm", System.Windows.Forms.HelpNavigator.KeywordIndex, HelpProvider.GetHelpString(sender as FrameworkElement));


        }


        public static string GetHelpString(DependencyObject obj)

        {

            return (string)obj.GetValue(HelpStringProperty);

        }



        public static void SetHelpString(DependencyObject obj, string value)

        {

            obj.SetValue(HelpStringProperty, value);

        }



        public static readonly DependencyProperty HelpStringProperty = DependencyProperty.RegisterAttached("HelpString", typeof(string), typeof(HelpProvider));

    }
}
