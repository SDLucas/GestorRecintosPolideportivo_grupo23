using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Recinto
    {
        public int nro_recinto { get; set; }
        public float tarifa_recinto { get; set; }
        public string ubicacion_recinto { get; set; }
        public bool habilitado { get; set; }
        public Tipo_De_Recinto tipo_recinto { get; set; }

        public override string ToString()
        {
            return "n° " + nro_recinto + " - " + tipo_recinto.nombre_tipo_recinto;
        }
    }
}
