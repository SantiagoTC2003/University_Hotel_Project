using System;
using System.Collections.Generic;

namespace Entidades.SQLServer
{
    public partial class Habitaciones
    {
        public Habitaciones()
        {
            Reservaciones = new HashSet<Reservaciones>();
        }

        public short CodHabitacion { get; set; }
        public string TipoHabitacion { get; set; }
        public short CapacidadHabitacion { get; set; }
        public string EstadoHabitacion { get; set; }

        public virtual ICollection<Reservaciones> Reservaciones { get; set; }
    }
}
