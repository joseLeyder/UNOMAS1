using System;
using System.Collections.Generic;
using System.Text;

namespace UNOMAS1.Modelos
{
    public class SolicitudLogin
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public string id_usuario { get; set; }
        public string nombre { get; set; }
        public int experiencia { get; set; }
        public string domicilio { get; set; }
        public DateTime fecha_nac { get; set; }
        public bool admin { get; set; }
        public string correo { get; set; }
    }
}
