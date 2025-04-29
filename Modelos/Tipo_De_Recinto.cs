using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Tipo_De_Recinto
    {
        public int id_tipo_recinto { get; set; }
        public string nombre_tipo_recinto { get; set; }

        public override string ToString()
        {
            return this.nombre_tipo_recinto;
        }
    }
}