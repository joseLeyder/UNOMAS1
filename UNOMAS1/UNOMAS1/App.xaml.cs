using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UNOMAS1.Vistas;
using Xamarin.Forms;
using UNOMAS1;

namespace UNOMAS1
{
	public partial class App : Application
	{
        public static NavigationPage Navigator { get; internal set; }
        public static PantallaMenu Master { get; internal set; }
        public App ()
		{
			InitializeComponent();
            EstablecerVariales();
            MainPage = new PantallaPrincipal();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
        private void EstablecerVariales()
        {
            DatosGlobales.id_usuario = string.Empty;
            DatosGlobales.nombre = string.Empty;
            DatosGlobales.fecha_nac = DateTime.Now;
            DatosGlobales.password = string.Empty;
            DatosGlobales.domicilio = string.Empty;
            DatosGlobales.correo = string.Empty;
            DatosGlobales.admin = false;
            DatosGlobales.experiencia = 0;

        }
	}
}
