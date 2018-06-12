using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace UNOMAS1.Modelos
{
    public class EjercicioWodViewModel:INotifyPropertyChanged
    {
        private string _id_round;
        public string id_round
        {
            get
            {
                return _id_round;
            }
            set
            {
                if (_id_round != value)
                {
                    _id_round = value;
                    OnPropertyChanged("id_round");
                }
            }
        }
        private string _id_ejercicio;
        public string id_ejercicio
        {
            get { return _id_ejercicio; }
            set { _id_ejercicio = value; }
        }
        private bool _EsDescanso;
        public bool EsDescanso
        {
            get { return _EsDescanso; }
            set { _EsDescanso = value; }
        }
        private string _ejercicio;
        public string ejercicio
        {
            get
            {
                return _ejercicio;
            }
            set
            {
                if (_ejercicio != value)
                {
                    _ejercicio = value;
                    OnPropertyChanged("ejercicio");
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
