using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UNOMAS1.Controladores;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNOMAS1.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PantallaMenuMaster : ContentPage
    {
       
        public PantallaMenuMaster()
        {
            InitializeComponent();

            BindingContext = new ControladorPrincipal(this);
           
        }

      
    }
}