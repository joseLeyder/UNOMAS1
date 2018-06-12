using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using UNOMAS1.Servicios;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UNOMAS1.Modelos;
using UNOMAS1.Comportamientos;
namespace UNOMAS1.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PantallaEncuesta : ContentPage
	{
        ListaPreguntas listaPreguntas;
        Picker[] pickers;
        Editor[] editors;
        string[] msgError;
        string msgError1 = "";
        SolicitudEncuesta solicitudEncuesta;
        public PantallaEncuesta ()
		{
			InitializeComponent ();
		}
        public void CallService()
        {
            Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("", MaskType.Black));
            Task.Run(async () =>
            {
                await CargarPreguntas();
            }).ContinueWith(result => Device.BeginInvokeOnMainThread(async () =>
            {

                if (msgError1 != "")
                    await DisplayAlert("Ocurrió un error", msgError1, "Aceptar");
                else
                    PintarPreguntas();
                await Task.Delay(1500).ContinueWith(t => CerrarformAsync(Tarea));
            }));
        }
        private async Task CargarPreguntas()
        {
            try
            {
                SolicitudPregunta solicitudPregunta = new SolicitudPregunta { id_encuesta = "poner la id de pregunta" };
                ApiService dataServices = new ApiService();
                try
                {
                    var result = await dataServices.GetPreguntas(solicitudPregunta);
                    if (result != null && result.Pregunta.Count > 0)
                    {
                        listaPreguntas = result;
                    }
                }
                catch (Exception ex)
                {
                    msgError1 = ex.Message.ToString();
                }
            }
            catch (Exception ex)
            {
                msgError1 = ex.Message.ToString();
            }
        }
        public void PintarPreguntas()
        {
            Title = "Encuesta Clientes Nuevos";
            List<string> respuestas = new List<string>();
            int i = 0, j = 0, p = 0, k = 1;
            p = listaPreguntas.Pregunta.Count;
            Label[] labels = new Label[p];
            foreach (PreguntaJson item in listaPreguntas.Pregunta)
            {
                if (Convert.ToInt32(item.id_tipoPregunta) == 1)
                    i++;
                else
                    j++;
            }
            pickers = new Picker[i];
            editors = new Editor[j];

            i = 0; j = 0; p = 0;
            foreach (PreguntaJson item in listaPreguntas.Pregunta)
            {
                labels[p] = new Label();
                labels[p].Text = k + ".- " + item.pregunta;
                labels[p].TextColor = Color.FromHex("#174188");
                labels[p].FontSize = 16;
                labels[p].FontAttributes = FontAttributes.Bold;
                Contenido.Children.Add(labels[p]);
                if (Convert.ToInt32(item.id_tipoPregunta) == 1)
                {
                    pickers[i] = new Picker();
                    pickers[i].TextColor = Color.FromHex("#174188");
                    respuestas = new List<string>();
                    foreach (Respuesta item2 in item.ListaRespuestas)
                    {
                        respuestas.Add(item2.respuesta);
                    }
                    pickers[i].ItemsSource = respuestas;
                    Contenido.Children.Add(pickers[i]);
                    i++;
                }
                else
                {
                    editors[j] = new Editor();
                    editors[j].HeightRequest = 100;
                    editors[j].TextColor = Color.FromHex("#174188");
                    editors[j].Behaviors.Add(new MaxLengthValidatorEditor { MaxLength = 500 });
                    Contenido.Children.Add(editors[j]);
                    j++;
                }
                p++;
                k++;
            }
        }
        public void Tarea()
        {
            this.IsBusy = false;
            UserDialogs.Instance.HideLoading();
        }

        public Task CerrarformAsync(Action action)
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