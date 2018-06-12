using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UNOMAS1.Modelos
{
    public class EntrenamientoVM:INotifyPropertyChanged
    {
        public string id_wod { get; set; }
        private string _fecha;
        public string fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                if (_fecha != value)
                {
                    _fecha = value;
                    OnPropertyChanged("fecha");
                }
            }
        }
        private string _nombre;
        public string nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged("nombre");
                }
            }
        }
        private string _dificultad;
        public string dificultad
        {
            get
            {
                return _dificultad;
            }
            set
            {
                if (_dificultad != value)
                {
                    _dificultad = value;
                    OnPropertyChanged("dificultad");
                }
            }
        }
        private string _totalRounds;
        public string totalRounds
        {
            get
            {
                return _totalRounds;
            }
            set
            {
                if (_totalRounds != value)
                {
                    _totalRounds = value;
                    OnPropertyChanged("totalRounds");
                }
            }
        }
        private string _tiempoSegundos;
        public string tiempoSegundos
        {
            get
            {
                return _tiempoSegundos;
            }
            set
            {
                if (_tiempoSegundos != value)
                {
                    _tiempoSegundos = value;
                    OnPropertyChanged("tiempoSegundos");
                }
            }
        }
        private string _espacio;
        public string espacio
        {
            get
            {
                return _espacio;
            }
            set
            {
                if (_espacio != value)
                {
                    _espacio = value;
                    OnPropertyChanged("espacio");
                }
            }
        }
        private string _icon;
        public string icon
        {
            get
            {
                return _icon;
            }
            set
            {
                if (_icon != value)
                {
                    _icon = value;
                    OnPropertyChanged("icon");
                }
            }
        }
        private List<EjercicioWodViewModel> _ListaEjercicio;
        public List<EjercicioWodViewModel> ListaEjercicio
        {
            get
            {
                return _ListaEjercicio;
            }
            set
            {
                if (_ListaEjercicio != value)
                {
                    _ListaEjercicio = value;
                    OnPropertyChanged("ListaEjercicio");
                }
            }
        }
        private List<MaterialWodViewModel> _ListaMaterial;
        public List<MaterialWodViewModel> ListaMaterial
        {
            get
            {
                return _ListaMaterial;
            }
            set
            {
                if (_ListaMaterial != value)
                {
                    _ListaMaterial = value;
                    OnPropertyChanged("ListaMaterial");
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
