using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.Models
{
    public class HabitacionModel
    {
        #region Propiedades
        public short CodHabitacion { get; set; }
        public string TipoHabitacion { get; set; }
        public short CapacidadHabitacion { get; set; }
        public string EstadoHabitacion { get; set; }

        #endregion

        #region Constructor

        public HabitacionModel()
        {
            CodHabitacion = short.MinValue;
            TipoHabitacion = string.Empty;
            CapacidadHabitacion = short.MinValue;
            EstadoHabitacion = string.Empty;
        }
        #endregion
    }
}
