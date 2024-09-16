using Entidades.SQLServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Interfaces.SQLServer
{
    public interface IUsuarioNSQL
    {
        /// <summary>Agregar cliente</summary>
        /// <remarks>Realiza la inserción del cliente a la base de datos</remarks>
        /// <returns>Retorna un true o false para indicar el estado de la acción</returns>
        /// <param name="pEntidad">El objeto con la información del cliente</param>
        bool AgregarUsuario(Usuarios pEntidad);

        bool AgregarUsuarioSP(Usuarios pEntidad);

        /// <summary>Modificar cliente</summary>
        /// <remarks>Realiza la modificación del cliente</remarks>
        /// <returns>Retorna un true o false para indicar el estado de la acción</returns>
        /// <param name="pEntidad">El objeto con la información del cliente</param>
        bool ModificarUsuario(Usuarios pEntidad);

        /// <summary>Eliminar cliente</summary>
        /// <remarks>Realiza la eliminación del cliente</remarks>
        /// <returns>Retorna un true o false para indicar el estado de la acción</returns>
        /// <param name="pEntidad">El objeto con la información del cliente</param>
        bool EliminarUsuario(Usuarios pEntidad);

        /// <summary>Consultar cliente</summary>
        /// <remarks>Realiza la consulta de la información del cliente</remarks>
        /// <returns>Retorna la informacion del cliente</returns>
        /// <param name="pEntidad">El objeto con la información del cliente</param>
        List<Usuarios> ConsultarUsuarios(Usuarios pEntidad);

        List<Usuarios> ComprobarLogin(Usuarios pEntidad);
    }
}
