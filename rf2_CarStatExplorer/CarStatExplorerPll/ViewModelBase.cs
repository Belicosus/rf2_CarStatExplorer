using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarStatExplorer.Pll
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        //}

        //Using the new CallerMemberName (.NET 4.5)
        protected void SetPropertyValue<T>(ref T CurrentValue, T NewValue, [CallerMemberName] string PropertyName = "")
        {

            if (!EqualityComparer<T>.Default.Equals(CurrentValue, NewValue))
            {
                CurrentValue = NewValue;
                OnPropertyChanged(PropertyName);
            }
        }

        //[NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged(string strPropertyName)
        {
            this.VerifyPropertyName(strPropertyName);

            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(strPropertyName));
            }

            if (this.IsTrackingChanges == true)
            {
                this.HasChanges = true;

                lock (((ICollection)this.PropertiesChanged).SyncRoot)
                {
                    if (this.PropertiesChanged.Contains(strPropertyName) == false)
                    {
                        this.PropertiesChanged.Add(strPropertyName);
                    }
                }
            }
        }

        public void VerifyPropertyName(string propertyName)
        {

            TypeDescriptor.GetProperties(propertyName);
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                {
                    throw new Exception(msg);
                }
                else
                {
                    //Debug.Fail(msg);
                }
            }
        }


        private bool privateThrowOnInvalidPropertyName;

        protected virtual bool ThrowOnInvalidPropertyName
        {
            get
            {
                return privateThrowOnInvalidPropertyName;
            }
            set
            {
                privateThrowOnInvalidPropertyName = value;
            }
        }

        protected bool IsValueDifferent<T>(T CurrentValue, T NewValue)
        {
            bool blnIsDifferent = true;

            if (CurrentValue == null && NewValue == null)
            {
                blnIsDifferent = false;

            }
            else if (CurrentValue != null && NewValue != null && CurrentValue.Equals(NewValue))
            {
                blnIsDifferent = false;

            }

            return blnIsDifferent;
        }


        #region " Change Tracking on Object Properties "

        private bool IsTrackingChanges = false;
        private List<string> PropertiesChanged = new List<string>();

        private bool _HasChanges = false;
        public bool HasChanges
        {
            get { return _HasChanges; }
            set { this.SetPropertyValue(ref _HasChanges, value); }
        }

        public bool HasPropertyChanged(string PropertyName)
        {
            lock (((ICollection)this.PropertiesChanged).SyncRoot)
            {
                return this.PropertiesChanged.Contains(PropertyName);
            }
        }

        public void StartChangeTracking()
        {
            this.HasChanges = false;
            this.IsTrackingChanges = true;

            lock (((ICollection)this.PropertiesChanged).SyncRoot)
            {
                this.PropertiesChanged.Clear();
            }
        }

        #endregion



        #region

        public void Dispose()
        {
            this.OnDispose();
        }

        private void OnDispose()
        {

        }

        #endregion
    }
}
