using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNOMAS1.Servicios;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
namespace UNOMAS1.Vistas
{

    public class PantallaMenuMenuItem
    {
        NavigationService navigationService;
        public PantallaMenuMenuItem()
        {
            navigationService = new NavigationService();
        }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        public bool admin { get; set; }
        public ICommand NavigateCommand
        {
            get { return new RelayCommand(() => navigationService.Navigate(PageName,admin)); }
        }
    }
}