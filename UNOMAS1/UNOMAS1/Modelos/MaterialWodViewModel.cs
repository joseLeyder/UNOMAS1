using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace UNOMAS1.Modelos
{
     public class MaterialWodViewModel : INotifyPropertyChanged
    {
        private string _material;
        public string material
        {
            get
            {
                return _material;
            }
            set
            {
                if (_material != value)
                {
                    _material = value;
                    OnPropertyChanged("material");
                }
            }
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
