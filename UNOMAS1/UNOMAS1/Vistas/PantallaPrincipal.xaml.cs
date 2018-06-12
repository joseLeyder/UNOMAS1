﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNOMAS1.Controladores;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNOMAS1.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PantallaPrincipal : ContentPage
	{
       
		public PantallaPrincipal ()
		{
			InitializeComponent ();
          BindingContext= new ControladorPrincipal(this);
		}
	}
}