using UNOMAS1.Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UNOMAS1.Infraestructura
{
    public class InstanceLocator
    {
        public ControladorPrincipal Principal { get; set; }
        public InstanceLocator()
        {
          //  Principal = new ControladorPrincipal();
        }
    }
}
