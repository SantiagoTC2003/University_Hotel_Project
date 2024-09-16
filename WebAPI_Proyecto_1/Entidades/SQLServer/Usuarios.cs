using System;
using System.Collections.Generic;

namespace Entidades.SQLServer
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Tipo { get; set; }
    }
}