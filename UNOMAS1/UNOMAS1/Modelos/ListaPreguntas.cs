using System;
using System.Collections.Generic;
using System.Text;

namespace UNOMAS1.Modelos
{
    public class ListaPreguntas
    {
        public List<PreguntaJson> Pregunta { get; set; }
    }

    public class PreguntaJson
    {
        public string id_pregunta { get; set; }
        public string id_tipoPregunta { get; set; }
        public string pregunta { get; set; }
        public string requerida { get; set; }
        public List<Respuesta> ListaRespuestas { get; set; }
    }

    public class Respuesta
    {
        public string id_respuesta { get; set; }
        public string respuesta { get; set; }
    }
}
