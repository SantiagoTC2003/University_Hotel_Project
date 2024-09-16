using AccesoDatos.Interfaces;
using Entidades.SQLServer;
using Negocio.Interfaces.SQLServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Metodos.SQLServer
{
    public class HabitacionNSQL : IHabitacionNSQL
    {

        private readonly IHabitacionesADSQL _IHabitacionAD;

        public HabitacionNSQL(IHabitacionesADSQL iAccesoSQL)
        {
            _IHabitacionAD = iAccesoSQL;
        }

        public bool AgregarHabitacion(Habitaciones pEntidad)
        {
            return _IHabitacionAD.AgregarHabitacion(pEntidad);
        }

        public List<Habitaciones> ConsultarHabitacion(Habitaciones pEntidad)
        {
            return _IHabitacionAD.ConsultarHabitacion(pEntidad);
        }

        public bool EliminarHabitacion(Habitaciones pEntidad)
        {
            return _IHabitacionAD.EliminarHabitacion(pEntidad);
        }

        public bool ModificarHabitacion(Habitaciones pEntidad)
        {
            return _IHabitacionAD.ModificarHabitacion(pEntidad);
        }
    }
}
