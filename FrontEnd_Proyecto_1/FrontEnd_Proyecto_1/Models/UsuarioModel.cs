using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Tipo { get; set; }

        public UsuarioModel()
        {
            this.IdUsuario = 0;
            this.Email = string.Empty;
            this.Pass = string.Empty;
            this.Nombre = string.Empty;
            this.Apellidos = string.Empty;
            this.Tipo = string.Empty;
        }
    }
}
