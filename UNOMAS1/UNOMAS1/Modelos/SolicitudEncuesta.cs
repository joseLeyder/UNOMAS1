using System;
using System.Collections.Generic;
using System.Text;

namespace UNOMAS1.Modelos
{
    public class SolicitudEncuesta
    {
        public string id_encuesta { get; set; }
        public string id_cliente { get; set; }
        public string id_notificacion { get; set; }
        public List<ContestarEncuesta> tblEncuesta { get; set; }
    }

    public class ContestarEncuesta
    {
        public string id_pregunta { get; set; }
        public bool opcionMultiple { get; set; }
        public string id_respuesta { get; set; }
        public string respuesta { get; set; }
    }
}
