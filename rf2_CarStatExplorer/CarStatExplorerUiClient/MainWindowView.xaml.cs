using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using CarStatExplorer;
using CarStatExplorer.Pll;

namespace CarStatExplorer.Ui.Client
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();

            MainWindowViewModel objMainWindowView = new MainWindowViewModel();
            objMainWindowView.CloseApplicationRequested += MainWindow_CloseApplicationRequested;
            this.Closing += MainWindow_Closing;
            this.DataContext = objMainWindowView;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            ((MainWindowViewModel) this.DataContext).Dispose();
        }

        private void MainWindow_CloseApplicationRequested(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(this.Close ));
        }
    }
}
