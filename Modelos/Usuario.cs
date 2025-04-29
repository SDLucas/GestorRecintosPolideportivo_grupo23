using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario
    {
        public int id_Usuario { get; set; }
        public int DNI_Usuario { get; set; }
        public byte[] foto_usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Apellido_Usuario { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string pass { get; set; }
        public string telefono { get; set; }
        public int Id_Tipo { get; set; }
        public string Sexo_Usuario { get; set; }
    }
}
