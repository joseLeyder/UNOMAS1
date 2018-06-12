using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNOMAS1.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PantallaMenu : MasterDetailPage
    {
        public PantallaMenu()
        {
            InitializeComponent();
          
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Master = this;
            App.Navigator = this.Navigator;
        }
       
    }
}