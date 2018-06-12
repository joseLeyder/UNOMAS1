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
   public class ControladorPrincipal
    {
        private string msgError = "";
        public string User { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public SolicitudLogin Usuario { get; set; }
        public ObservableCollection<PantallaMenuMenuItem> Menu { get; set; }
        NavigationService navigationService;
        Page page;
        ApiService apiService;
        DialogService dialogService;
       

        public ControladorPrincipal(Page pagina)
        {
            this.page = pagina;
            apiService = new ApiService();
            dialogService = new DialogService();
            navigationService = new NavigationService();
            if(this.page.Title=="Login")
            {
                ingresar();
            }
            else
            {
                Nombre = DatosGlobales.nombre;
                if(DatosGlobales.admin)
                {
                    Tipo = "Administrador";
                }
                else
                {
                    Tipo = "Entrenador";
                }
                LoadMenu(DatosGlobales.admin);

            }



        }
        #region LOGIN
        private void ingresar()
        {
            try
            {
               
               
                if (CheckInternetConnection())
                {
                    Device.BeginInvokeOnMainThread(()=> page.DisplayAlert("Bienvenido al sistema de Uno+", "Ingrese por favor", "Aceptar"));
                }
                else
                {
                    Device.BeginInvokeOnMainThread(()=>page.DisplayAlert("No se pudo conectar al sistema de Uno+", "Revise servicio de datos", "Aceptar"));
                }
                

            }
            catch (Exception)
            {

                throw;
            }
        }

      

        public ICommand SaveCommand
        {
            get { return new RelayCommand(Acceder); }
        }
        private bool CheckInternetConnection()
        {
            try
            {
                if (!CrossConnectivity.IsSupported)
                    return true;

                return CrossConnectivity.Current.IsConnected;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private async void Acceder()
        {
            try
            {
                if(CheckInternetConnection())
                {
                    if (ValidarCampos())

                    {

                        var resultado = await apiService.Login(new SolicitudLogin
                        {

                            usuario = this.User,
                            password = this.Password

                        });
                        DatosGlobales.admin = resultado.admin;
                        DatosGlobales.nombre = resultado.nombre;


                        navigationService.SetMainPage("MasterPage");
                        await page.DisplayAlert("Exito", "Ingreso Correcto", "Aceptar");

                    }

                    else

                        await page.DisplayAlert("Campos vacios", msgError, "Aceptar");
                }
                else
                {
                    await page.DisplayAlert("Conexion Fallida", "Revise su servicio de datos, Intente más tarde", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await page.DisplayAlert("Error", "Ingreso fallido", "Aceptar");
            }
        }

        private bool ValidarCampos()
        {
            try
            {
                ValidacionExpRegulares validator = new ValidacionExpRegulares();
                if (User == null)
                {
                    msgError = "Escriba un correo electrónico";
                    return false;
                }
                if (Password == null)
                {
                    msgError = "Escriba su contraseña";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Menu
        private void LoadMenu(bool user)
        {
            Menu = new ObservableCollection<PantallaMenuMenuItem>();
            if (user)
            {
                Menu.Add(new PantallaMenuMenuItem()
                {
                    Icon = "adduser.png",
                    Title = "Registrar",
                    PageName = "Registrar",
                    admin=user
                });

                Menu.Add(new PantallaMenuMenuItem()
                {
                    Icon = "informacion.png",
                    Title = "Clases",
                    PageName = "Progresos",
                    admin = user
                });

                Menu.Add(new PantallaMenuMenuItem()
                {
                    Icon = "misdatos.png",
                    Title = "Informes",
                    PageName = "Informes",
                    admin = user
                });
            }
            else
            {
                Menu.Add(new PantallaMenuMenuItem()
                {
                    Icon = "adduser.png",
                    Title = "Clases",
                    PageName = "Clases",
                    admin = user
                });                
            }
           
        }


        #endregion
    }
}
