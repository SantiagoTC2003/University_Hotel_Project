using System;
using System.Collections.Generic;

namespace Entidades.SQLServer
{
    public partial class Reservaciones
    {
        public short IdReserva { get; set; }
        public string CodReserva { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public short CantidadAdultos { get; set; }
        public short CantidadNinos { get; set; }
        public string CedulaCliente { get; set; }
        public short CodHabitacion { get; set; }
        public decimal PrecioHabitacion { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Clientes CedulaClienteNavigation { get; set; }
        public virtual Habitaciones CodHabitacionNavigation { get; set; }
    }
}
