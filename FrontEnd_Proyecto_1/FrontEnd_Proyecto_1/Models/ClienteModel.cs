using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.Models
{
    public class ClienteModel
    {
        public string CedulaCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Apellido1Cliente { get; set; }
        public string Apellido2Cliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string CorreoCliente { get; set; }

        public ClienteModel()
        {
            this.CedulaCliente = string.Empty;
            this.NombreCliente = string.Empty;
            this.Apellido1Cliente = string.Empty;
            this.CedulaCliente = string.Empty;
            this.Apellido2Cliente = string.Empty;
            this.TelefonoCliente = string.Empty;
            this.CorreoCliente = string.Empty;
        }
    }
}
