using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Reserva
    {
        public int id_reserva { get; set; }
        public DateTime fecha_reserva { get; set; }
        public int hora_reserva { get; set; }
        public bool pagado { get; set; }
        public bool estado { get; set; }

        //propiedades calculadas para visualización correcta en los datagridview
        public string EstadoTexto
        {
            get { if (estado == true) {
                    return "Activa";
                } else {
                    return "Cancelada";
                }
            }
        }
        public float monto_reserva { get; set; }

        public int id_cliente { get; set; }
        public int id_usuario { get; set; }
        public int nro_recinto { get; set; }

        // datos visuales (nombres)
        public string nombre_cliente { get; set; }
        public string apellido_cliente { get; set; }

        public string nombre_usuario { get; set; }
        public string apellido_usuario { get; set; }

        // para utilizar el formateo automatico en los datagridview
        public string PagadoTexto => pagado ? "Sí" : "No";
    }
}
