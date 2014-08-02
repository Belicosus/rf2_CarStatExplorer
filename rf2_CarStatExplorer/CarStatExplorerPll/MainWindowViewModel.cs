using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStatExplorer.Common.BaseClasses;

namespace CarStatExplorer.Pll
{
    public class MainWindowViewModel : ViewModelBase
    {
        

        public MainWindowViewModel()
        {
            SomeText = "Dette er en tekst";
            _EngineGraphViewModel = new EngineGraphViewModel();   

        }


        #region " Events "

        public event EventHandler<CancelEventArgs> CloseApplicationRequested;

        #endregion

        #region " ViewModel Properties "
        private String _SomeText;

        public String SomeText
        {
            get { return _SomeText; }
            set { this.SetPropertyValue(ref _SomeText, value); }
        }

        private EngineGraphViewModel _EngineGraphViewModel;
        public EngineGraphViewModel EngineGraphViewModel
        {
            get { return _EngineGraphViewModel; }
            set
            {
                this.SetPropertyValue(ref _EngineGraphViewModel, value);
                //_EngineGraphViewModel = value;
            }
        }

        #endregion

    }
}
