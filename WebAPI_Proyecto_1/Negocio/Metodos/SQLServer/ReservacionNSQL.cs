using AccesoDatos.Interfaces;
using Entidades.SQLServer;
using Negocio.Interfaces.SQLServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Metodos.SQLServer
{
    public class ReservacionNSQL : IReservacionNSQL
    {

        private readonly IReservacionesADSQL _IReservacionAD;

        public ReservacionNSQL(IReservacionesADSQL iAccesoSQL)
        {
            _IReservacionAD = iAccesoSQL;
        }

        public bool AgregarReserva(Reservaciones pEntidad)
        {
            return _IReservacionAD.AgregarReserva(pEntidad);
        }

        public List<Reservaciones> ConsultarReserva(Reservaciones pEntidad)
        {
            return _IReservacionAD.ConsultarReserva(pEntidad);
        }

        public bool EliminarReserva(Reservaciones pEntidad)
        {
            return _IReservacionAD.EliminarReserva(pEntidad);
        }

        public bool ModificarReserva(Reservaciones pEntidad)
        {
            return _IReservacionAD.ModificarReserva(pEntidad);
        }
    }
}
