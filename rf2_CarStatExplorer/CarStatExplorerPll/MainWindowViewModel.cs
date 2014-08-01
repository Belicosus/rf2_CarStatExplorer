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

        private EngineGraphViewModel _EngineGraphViewModel;
        public EngineGraphViewModel EngineGraphViewModel
        {
            get { return _EngineGraphViewModel; }
            set
            {
                SetPropertyValue(ref _EngineGraphViewModel, value);
                _EngineGraphViewModel = value;
            }
        }

        public MainWindowViewModel()
        {
            _EngineGraphViewModel = new EngineGraphViewModel();   

        }

    }
}
