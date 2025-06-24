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
        public float tarifa_hora { get; set; }
        public string ubicacion_recinto { get; set; }
        public bool habilitado { get; set; }
        public Tipo_De_Recinto tipo_recinto { get; set; }
        

        //sobreescritura del método ToString para correcta visualización en los combobox
        public override string ToString()
        {
            return "n° " + nro_recinto + " - " + tipo_recinto.nombre_tipo_recinto;
        }
        // Para compatibilidad con la grilla
        public int NumeroRecinto => nro_recinto;
        public float Tarifa => tarifa_hora;
        public string Ubicacion => ubicacion_recinto;
        public string NombreTipoRecinto
        {
            get
            {
                return tipo_recinto != null ? tipo_recinto.nombre_tipo_recinto : "";
            }
        }
    }
}
