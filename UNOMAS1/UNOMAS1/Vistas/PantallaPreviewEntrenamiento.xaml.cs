using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNOMAS1.Servicios;
using UNOMAS1.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNOMAS1.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PantallaPreviewEntrenamiento : ContentPage
	{
        string id,msgError="";
        EntrenamientoVM wodPreviewViewModel;
        SolicitudEntrenamiento solicitudWodPreview;
        public PantallaPreviewEntrenamiento (string id)
		{
            this.id = id;
			InitializeComponent ();
		}
        private void CallService()
        {
            try
            {
                Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("", MaskType.Black));
                Task.Run(async () =>
                {
                    await CargarEntrenamiento();
                }).ContinueWith(result => Device.BeginInvokeOnMainThread(async () =>
                {
                    if (msgError != "")
                        await DisplayAlert("Ocurrió un error", msgError, "Aceptar");
                    else
                        PintarDatos();
                    await Task.Delay(1500).ContinueWith(t => CerrarformAsync(Tarea));
                }));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private async Task CargarEntrenamiento()
        {
            try
            {
                ApiService dataServices = new ApiService();
                
                if (id != null && id!="")
                    solicitudWodPreview = new SolicitudEntrenamiento { id_wod = id };
               
                try
                {
                    var result = await dataServices.GetWodPreview(solicitudWodPreview);
                    if (result != null)
                    {
                        wodPreviewViewModel = result;
                    }
                }
                catch (Exception ex)
                {
                    msgError = ex.Message.ToString();
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
                if (wodPreviewViewModel.id_wod != null && wodPreviewViewModel.id_wod != "")
                {
                    wodPreviewViewModel.icon = "heartpulse.png";
                    if (wodPreviewViewModel.espacio == "")
                        lblEspacio.IsVisible = false;
                    else
                        wodPreviewViewModel.espacio = "Se recomienda realizar esta actividad en: " + wodPreviewViewModel.espacio;
                    if (wodPreviewViewModel.ListaMaterial.Count > 0)
                    {
                        MaterialListView.IsVisible = true;
                        MaterialListView.ItemsSource = wodPreviewViewModel.ListaMaterial;
                        MaterialListView.HorizontalOptions = LayoutOptions.CenterAndExpand;
                        MaterialListView.VerticalOptions = LayoutOptions.CenterAndExpand;
                    }
                    if (wodPreviewViewModel.ListaEjercicio.Count > 0)
                    {
                        EjercicioListView.IsVisible = true;
                        EjercicioListView.ItemsSource = wodPreviewViewModel.ListaEjercicio;
                        EjercicioListView.HorizontalOptions = LayoutOptions.CenterAndExpand;
                        EjercicioListView.VerticalOptions = LayoutOptions.CenterAndExpand;
                    }
                }
                BindingContext = wodPreviewViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
    }
}