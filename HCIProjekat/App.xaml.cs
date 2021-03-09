using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    /*
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        EventManager.RegisterClassHandler(typeof(Window), Window.KeyDownEvent, new RoutedEventHandler(Window_KeyDown));
        EventManager.RegisterClassHandler(typeof(Window), Window.MouseDoubleClickEvent, new RoutedEventHandler(Window_MouseDoubleClick));
    } */

    /*
    private void Window_MouseDoubleClick(object sender, RoutedEventArgs e)
    {
        if (Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().demoMod.tajmer.Enabled == true)
        {


            Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().demoMod.ugasiDemo();


            /*
             Window prozor = Application.Current.Windows.OfType<Window>().Last();
             if (prozor != Application.Current.Windows.OfType<MainWindow>().FirstOrDefault())
             {
                 prozor.Close();
             }*/
    /*
   System.Windows.MessageBox.Show("Demo je ugasen!", "Demo");


}

}


private void Window_KeyDown(object sender, RoutedEventArgs e)
{
if (Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().demoMod.tajmer.Enabled == true)
{

   Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().demoMod.ugasiDemo();

   /*

    if (Application.Current.Windows.OfType<Window>().Last() != Application.Current.Windows.OfType<MainWindow>().FirstOrDefault() )
    {
        Application.Current.Windows.OfType<Window>().Last().Close();
    }
    */
    /*
   System.Windows.MessageBox.Show("Demo je ugasen!", "Demo");

}

} */


}

