using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStatExplorer.Pll
{
    public class MainWindowViewModel : ViewModelBase
    {
        public event EventHandler<CancelEventArgs> CloseApplicationRequested;

    }
}
