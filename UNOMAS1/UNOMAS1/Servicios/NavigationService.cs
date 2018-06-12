using System;
using System.Collections.Generic;
using System.Text;
using UNOMAS1.Vistas;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace UNOMAS1.Servicios
{
    class NavigationService
    {
        public async void Navigate(string pageName,bool user)
        {
            App.Master.IsPresented = false;
            if (user)
            {
                switch (pageName)
                {
                    case "Encuesta":
                        await Navigate(new PantallaEncuesta());
                        break;
                    case "ClaseDet":
                        await Navigate(new PantallaClaseDetalle());
                        break;
                    case "Cliente":
                        await Navigate(new PantallaRegistrarCliente());
                        break;
                    case "Entrenador":
                        await Navigate(new PantallaRegistrarEntrenador());
                        break;
                    case "Registrar":
                        await Navigate(new PantallaRegistrar());
                        break;
                    case "Progresos":
                        await Navigate(new PantallaProgresos());
                        break;
                    case "Informes":
                        await Navigate(new PantallaInformes());
                        break;
                    case "MainPage":
                        await App.Navigator.PopToRootAsync();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (pageName)
                {
                    
                    case "Clases":
                        await Navigate(new PantallaClases());
                        break;
                    case "MainPage":
                        await App.Navigator.PopToRootAsync();
                        break;
                    default:
                        break;
                }
            }
            
        }

        private static async Task Navigate<T>(T page) where T : Page
        {
            NavigationPage.SetHasBackButton(page, true);
            NavigationPage.SetBackButtonTitle(page, "Atrás"); //iOS

            await App.Navigator.PushAsync(page);
        }

        internal void SetMainPage(string pageName)
        {
            switch (pageName)
            {
                case "MasterPage":
                    App.Current.MainPage = new PantallaMenu();
                    break;
                default:
                    break;
            }
        }
    }
}
