using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UNOMAS1.Modelos;
using UNOMAS1.Servicios;

namespace UNOMAS1.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PantallaProgresos : ContentPage
	{
        NavigationService navigationService;
        string msgError = "", resultado = "";
        ListaEntrenador listaEntrenador;
        public List<string> Entrenadores { get; set; }
        ListaClases listaClases;
        ClaseVM clase = new ClaseVM();
        public PantallaProgresos ()
		{
			InitializeComponent ();
            Entrenadores = new List<string>();
            CallService();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private void CallService()
        {
            Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("", MaskType.Black));
            Task.Run(async () =>
            {
                await LlenarListaEntrenadores();
            }).ContinueWith(result => Device.BeginInvokeOnMainThread(async () =>
            {
                if (msgError != "")
                    await DisplayAlert("Ocurrió un error", msgError, "Aceptar");
                else
                    PintarDatos();
                await Task.Delay(1500).ContinueWith(t => CerrarformAsync(Tarea));
            }));
        }
        private void Tarea()
        {
            this.IsBusy = false;
            UserDialogs.Instance.HideLoading();
        }

        private Task CerrarformAsync(Action action)
        {
            TaskCompletionSource<object> finishSource = new TaskCompletionSource<object>();
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    action();
                    finishSource.SetResult(null);
                }
                catch (Exception ex)
                {
                    finishSource.SetResult(ex);
                }
            });
            return finishSource.Task;
        }
        private async Task LlenarListaEntrenadores()
        {
            msgError = "";
            try
            {
                ApiService dataServices = new ApiService();
                try
                {
                    listaEntrenador = await dataServices.getEntrenadores();
                }
                catch (Exception ex)
                {
                    listaEntrenador = null;
                    msgError = ex.Message.ToString();
                }
                if (Entrenadores.Count > 0)
                    Entrenadores = new List<string>();
                if (listaEntrenador != null && listaEntrenador.Entrenador.Count > 0)
                {
                    for (int i = 0; i < listaEntrenador.Entrenador.Count; i++)
                    {
                        Entrenadores.Add(listaEntrenador.Entrenador[i].nombre);
                    }
                }
                else
                {
                    msgError = "Lo sentimos, no hay Entrenadores activos este momento";
                }
            }
            catch (Exception ex)
            {
                msgError = ex.Message.ToString();
            }
        }
        private void PintarDatos()
        {
            try
            {
                if (Entrenadores.Count > 0)
                {
                    pckEntrenador.ItemsSource = Entrenadores;
                    pckEntrenador.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ValidarCampos()
        {
            msgError = "";
            try
            {
                if (pckEntrenador.SelectedIndex == -1)
                {
                    msgError = "Seleccione un Entrenador";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            try
            {
                    CallBusqueda();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CallBusqueda()
        {
            Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("", MaskType.Black));
            Task.Run(async () =>
            {
                await BusquedaClases();
            }).ContinueWith(result => Device.BeginInvokeOnMainThread(async () =>
            {
                if (resultado != "")
                    await DisplayAlert("Ocurrió un error", resultado, "Aceptar");
                else
                    CargarClases();
                await Task.Delay(1500).ContinueWith(t => CerrarformAsync(Tarea));
            }));
        }
        private async Task BusquedaClases()
        {
            resultado = "";
            try
            {
                if (ValidarCampos())
                {
                    SolicitudClase solicitudClase = ObtenerDatos();
                    ApiService dataServices = new ApiService();
                    listaClases = new ListaClases();
                    
                    try
                    {
                        var result = await dataServices.GetClasesProgreso(solicitudClase);
                        if (result != null)
                        {
                            clase = result;
                        }
                    }
                    catch (Exception ex)
                    {
                        resultado = ex.Message.ToString();
                    }
                }
                else
                {
                    await DisplayAlert("Advertencia", msgError, "Aceptar");
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message.ToString();
            }
        }
        private SolicitudClase ObtenerDatos()
        {
            try
            {
                SolicitudClase solicitudClase = new SolicitudClase
                {
                    id_entrenador = listaEntrenador.Entrenador[pckEntrenador.SelectedIndex].id_entrenador
                   // Fecha = dtpFecha.Date.ToString("yyyy-MM-dd")
                };
                return solicitudClase;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarClases()
        {
            try
            {

                CouchListView.ItemsSource = listaClases.Clases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async void CouchListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var item = e.Item as ClaseVM;
                if (item == null)
                    return;

                navigationService.Navigate("ClaseDet", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}