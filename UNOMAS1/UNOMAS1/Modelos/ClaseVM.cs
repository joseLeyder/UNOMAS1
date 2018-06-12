using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace UNOMAS1.Modelos
{
    public class ListaClases
    {
      public List<ClaseVM> Clases { get; set; }
    }
    public class ClaseVM : INotifyPropertyChanged
    {
        public string id_clase { get; set; }
        
        public string _descripcion;
        public string descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                if (_descripcion != value)
                {
                    _descripcion = value;
                    OnPropertyChanged("descripcion");
                }
            }
        }
        private string _hora;
        public string hora
        {
            get
            {
                return _hora;
            }
            set
            {
                if (_hora != value)
                {
                    _hora = value;
                    OnPropertyChanged("hora");
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
