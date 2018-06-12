using System;
using System.Collections.Generic;
using System.Text;

namespace UNOMAS1.Modelos
{
    public class ListaEntrenador
    {
        public List<Entrenador> Entrenador { get; set; }
    }
    public class Entrenador
    {
        public string id_entrenador { get; set; }
        public string nombre { get; set; }
    }
}
