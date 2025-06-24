using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    namespace Modelos
    {
        public class Pago
        {
            public int id_pago { get; set; }
            public int id_reserva { get; set; }
            public int id_medio { get; set; }
            public string nombre_medio { get; set; }
            public string nombre_usuario { get; set; }
            public string apellido_usuario { get; set; }
            public float monto_pago { get; set; }
            public DateTime fecha_pago { get; set; }

            public string nombre_cliente { get; set; }
            public string apellido_cliente { get; set; }

            public string ClienteCompleto
            {
                get { return $"{nombre_cliente} {apellido_cliente}"; }
            }
            public string UsuarioCompleto => $"{nombre_usuario} {apellido_usuario}";
        }
    }

}
