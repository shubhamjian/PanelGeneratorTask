using System;
using System.ComponentModel;

namespace PanelMaker.UI.ViewModels
{
    /// <summary>
    /// Base class for ViewModels. Inherites from INotifyPropertyChanged 
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static implicit operator ViewModelBase(MainViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
