using System;
using System.Collections.Generic;

namespace Entidades.SQLServer
{
    public partial class Clientes
    {
        public Clientes()
        {
            Reservaciones = new HashSet<Reservaciones>();
        }

        public string CedulaCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Apellido1Cliente { get; set; }
        public string Apellido2Cliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string CorreoCliente { get; set; }

        public virtual ICollection<Reservaciones> Reservaciones { get; set; }
    }
}
