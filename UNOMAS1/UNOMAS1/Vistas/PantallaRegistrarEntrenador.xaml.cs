
using UNOMAS1.Controladores;
using UNOMAS1.Servicios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UNOMAS1.Modelos;
using UNOMAS1.Comportamientos;
namespace UNOMAS1.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PantallaRegistrarEntrenador : ContentPage
	{
        string filePath = "", msgError = "", msgIMC = "";
        NavigationService nav;
        public PantallaRegistrarEntrenador ()
		{
			InitializeComponent ();
           // BindingContext = new ControladorRegistro(this);
		}
        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
               CallService();
            }
            catch (Exception ex)
            {
                msgError = ex.Message.ToString();
            }
        }
        
        public void CallService()
        {
            msgError = "";
            nav = new NavigationService();
            Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("", MaskType.Black));
            Task.Run(async () =>
            {
                await GuardarDatos();
            }).ContinueWith(result => Device.BeginInvokeOnMainThread(async () =>
            {
                if (msgError != string.Empty || msgError != "")
                    await DisplayAlert("Campo Vacio o Error", msgError, "Aceptar");
                else
                {
                    await DisplayAlert("Mensaje", "Registro Guardado Satisfactoriamente", "Aceptar");

                    nav.Navigate("MainPage", true);

                }
                await Task.Delay(1500).ContinueWith(t => CerrarformAsync(Tarea));
            }));
        }

        private async Task GuardarDatos()
        {
            msgError = "";
            try
            {
                if (ValidarCampos())
                {
                    ApiService dataServices = new ApiService();
                    SolicitudEntrenador solicitudEntrenador = ObtenerDatos();
                    try
                    {
                        var result = await dataServices.AbcEntrenador(solicitudEntrenador);
                        if (result != null)
                        {
                          /*  if (App.CroppedImage != null)
                            {
                                if (Device.RuntimePlatform.Equals("Android") || Device.RuntimePlatform.Equals("iOS"))
                                {
                                    await DependencyService.Get<IFtpWebRequest>().Upload(DatosGlobales.id_cliente + ".png", DatosGlobales.servidorFTP, filePath, DatosGlobales.usuarioFTP, DatosGlobales.passwordFTP, "/ScriptAppUnoMasCliente/Images/Perfil");
                                }
                            }
                            ActualizarDatos(solicitudCliente);*/
                        }
                        else
                        {
                            msgError = "Lo sentimos, hubo un error al guardar sus datos.";
                        }
                    }
                    catch (Exception ex)
                    {
                        msgError = ex.Message.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private SolicitudEntrenador ObtenerDatos()
        {
            try
            {
                SolicitudEntrenador datos = new SolicitudEntrenador();
                datos.nombre = txtNombre.Text;
                datos.opcion = "1";
                datos.usuario = DatosGlobales.nombre;
                datos.experiencia = txtExperiencia.Text.Trim();
                datos.domicilio = txtDomicilio.Text;
                datos.fecha_nac = dtpFecNac.Date.ToShortDateString();
                datos.password = txtPass1.Text;
                datos.correo = txtCorreo.Text;
                datos.id_entrenador = "";

                return datos;

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
private bool ValidarCampos()
{
    ValidacionExpRegulares validator = new ValidacionExpRegulares();
    msgError = "";
    try
    {
        if (txtNombre.Text == null || txtNombre.Text == string.Empty || txtNombre.Text == "")
        {
            msgError = "Escriba su nombre";
            return false;
        }
        if (txtCorreo.Text == null || txtCorreo.Text == string.Empty || txtCorreo.Text == "")
        {
            msgError = "Escriba su correo electrónico";
            return false;
        }
        if (!validator.IsValidEmail(txtCorreo.Text.Trim()))
        {
            msgError = "Escriba un correo electrónico válido";
            return false;
        }
        if (dtpFecNac.Date.Date >= DateTime.Now.Date)
        {
            msgError = "Eliga una fecha de nacimiento válida";
            return false;
        }
             int var= Convert.ToInt32(txtExperiencia.Text);
        if (var==0)
                {
                    msgError = "Ingrese los anños de experiencia en numero";
                    return false;
                }
        if (txtUsuario.Text == null || txtUsuario.Text == string.Empty || txtUsuario.Text == "")
        {
            msgError = "Escriba su usuario";
            return false;
        }
        /*
        if (await ValidarUsuario())
        {
            msgError = "El nombre de usuario ya se encuentra en uso.";
            return false;
        }*/
        if (txtPass1.Text != null && txtPass2.Text != null)
        {
            if (txtPass2.Text.Trim() != txtPass1.Text.Trim())
            {
                msgError = "Las Contraseñas no coinciden.";
                return false;
            }
        }
        return true;
    }
    catch (Exception ex)
    {
        msgError = ex.Message.ToString();
        return false;
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