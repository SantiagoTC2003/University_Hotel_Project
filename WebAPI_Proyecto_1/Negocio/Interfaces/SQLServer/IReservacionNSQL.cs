using Entidades.SQLServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Interfaces.SQLServer
{
    public interface IReservacionNSQL
    {
        /// <summary>Agregar reservación</summary>
        /// <remarks>Realiza la inserción de la reservación a la base de datos</remarks>
        /// <returns>Retorna un true o false para indicar el estado de la acción</returns>
        /// <param name="pEntidad">El objeto con la información de la reservación</param>
        bool AgregarReserva(Reservaciones pEntidad);

        /// <summary>Modificar reservación</summary>
        /// <remarks>Realiza la modificación de la reservación</remarks>
        /// <returns>Retorna un true o false para indicar el estado de la acción</returns>
        /// <param name="pEntidad">El objeto con la información de la reservación</param>
        bool ModificarReserva(Reservaciones pEntidad);

        /// <summary>Eliminar reservación</summary>
        /// <remarks>Realiza la eliminación de la reservación</remarks>
        /// <returns>Retorna un true o false para indicar el estado de la acción</returns>
        /// <param name="pEntidad">El objeto con la información de la reservación</param>
        bool EliminarReserva(Reservaciones pEntidad);

        /// <summary>Consultar reservación</summary>
        /// <remarks>Realiza la consulta de la información de la reservación</remarks>
        /// <returns>Retorna la información de la habitación</returns>
        /// <param name="pEntidad">El objeto con la información de la reservación</param>
        List<Reservaciones> ConsultarReserva(Reservaciones pEntidad);
    }
}