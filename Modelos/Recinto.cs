using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Recinto
    {
        public int NumeroRecinto { get; set; }
        public float Tarifa { get; set; }
        public string Ubicacion { get; set; }
        public bool Habilitado { get; set; }
        public Tipo_De_Recinto TipoRecinto { get; set; }

        public override string ToString()
        {
            return "n° " + NumeroRecinto + " - " + TipoRecinto.nombre_tipo_recinto;
        }
    }
}
