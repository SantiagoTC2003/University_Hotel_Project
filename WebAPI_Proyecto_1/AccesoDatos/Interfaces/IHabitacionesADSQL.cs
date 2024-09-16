using Entidades.SQLServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Interfaces
{
    public interface IHabitacionesADSQL
    {
        /// <summary>Agregar habitación</summary>
        /// <remarks>Realiza la inserción de la habitación a la base de datos</remarks>
        /// <returns>Retorna un true o false para indicar el estado de la acción</returns>
        /// <param name="pEntidad">El objeto con la información de la habitación</param>
        bool AgregarHabitacion(Habitaciones pEntidad);

        /// <summary>Modificar habitación</summary>
        /// <remarks>Realiza la modificación de la habitación</remarks>
        /// <returns>Retorna un true o false para indicar el estado de la acción</returns>
        /// <param name="pEntidad">El objeto con la información de la habitación</param>
        bool ModificarHabitacion(Habitaciones pEntidad);

        /// <summary>Eliminar habitación</summary>
        /// <remarks>Realiza la eliminación de la habitación</remarks>
        /// <returns>Retorna un true o false para indicar el estado de la acción</returns>
        /// <param name="pEntidad">El objeto con la información de la habitación</param>
        bool EliminarHabitacion(Habitaciones pEntidad);

        /// <summary>Consultar habitación</summary>
        /// <remarks>Realiza la consulta de la información de la habitación</remarks>
        /// <returns>Retorna la información de la habitación</returns>
        /// <param name="pEntidad">El objeto con la información de la habitación</param>
        List<Habitaciones> ConsultarHabitacion(Habitaciones pEntidad);
    }
}
