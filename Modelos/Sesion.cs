using System;

namespace Modelos
{
    //Clase estatica para llevar registro del usuario que inicio sesion
    public static class Sesion
    {
        public static Usuario UsuarioActual { get; set; }
    }
}
