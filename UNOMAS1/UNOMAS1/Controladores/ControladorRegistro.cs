using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using UNOMAS1.Servicios;
using UNOMAS1.Modelos;
using UNOMAS1.Vistas;
using UNOMAS1;
using Plugin.Connectivity;
using Xamarin.Forms;
using System.ComponentModel;
using UNOMAS1.Comportamientos;
using Acr.UserDialogs;
using System.Collections.ObjectModel;

namespace UNOMAS1.Controladores
{
    
    public class ControladorRegistro
    {
        public string nombre { get; set; }
        public string domicilio { get; set; }
        public string experiencia { get; set; }
        public string correo { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string confirmar { get; set; }
        string msgError;
        Page page;
        NavigationService navigationService;
        public ControladorRegistro(Page pagina)
        {
            this.page = pagina;
            navigationService = new NavigationService();
        }
        public ICommand EntrenadorCommand
        {
            get { return new RelayCommand(Entrenador); }
        }

        private void Entrenador()
        {
            try
            {
                navigationService.Navigate("Entrenador",true);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public ICommand ClienteCommand
        {
            get { return new RelayCommand(Cliente); }
        }

        private void Cliente()
        {
            try
            {
                navigationService.Navigate("Cliente", true);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ICommand RegistrarCommand
        {
            get { return new RelayCommand(registro); }
        }
        private void registro()
        {
            try
            {
                if (ValidarCampos())
                {
                    page.DisplayAlert("Exito", "Datos Guardados Correctamente", "Aceptar");
                    navigationService.Navigate("MainPage", true);
                }
                else
                {
                    page.DisplayAlert("Error!!", msgError, "Aceptar");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        private bool ValidarCampos()
        {
            try
            {
               
                if (nombre == null)
                {
                    msgError = "Escriba el nombre del entrenador";
                    return false;
                }
                if (domicilio == null)
                {
                    msgError = "Escriba su domicilio";
                    return false;
                }
                if (usuario == null)
                {
                    msgError = "Escriba su usuario";
                    return false;
                }
                if (contraseña == null)
                {
                    msgError = "Escriba su contraseña";
                    return false;
                }
                if (confirmar == null)
                {
                    msgError = "Escriba la confirmacion de la contraseña";
                    return false;
                }
                if (experiencia == null)
                {
                    msgError = "Escriba la experiencia";
                    return false;
                }
                if (correo == null)
                {
                    msgError = "Escriba el correo";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
