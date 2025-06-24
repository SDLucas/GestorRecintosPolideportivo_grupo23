namespace Modelos
{
    public class Cliente
    {
        public int id_cliente { get; set; }
        public int dni_cliente { get; set; }
        public string nombre_cliente { get; set; }
        public string apellido_cliente { get; set; }
        public string telefono_cliente { get; set; }

        public bool estado_cliente { get; set; }

        //sobreescritura del método ToString para correcta visualización en los combobox
        public override string ToString()
        {
            return nombre_cliente+" "+apellido_cliente+", DNI:"+dni_cliente;
        }
    }
}
