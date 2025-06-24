using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public int dni_usuario { get; set; }
        public byte[] foto_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string apellido_usuario { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string pass { get; set; }
        public string telefono { get; set; }
        public int id_tipo { get; set; }
        public string sexo_usuario { get; set; }
    }
}
