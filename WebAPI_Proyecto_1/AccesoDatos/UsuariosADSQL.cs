using AccesoDatos.Interfaces;
using Entidades.SQLServer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace AccesoDatos
{
    public class UsuariosADSQL : IUsuariosADSQL
    {
        public bool AgregarUsuario(Usuarios pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                try
                {
                    contexto.Usuarios.Add(pEntidad);
                    contexto.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool AgregarUsuarioSP(Usuarios pEntidad)
        {
            using (HotelProyectoContext contexto = new HotelProyectoContext())
            {
                try
                {
                    contexto.Database.ExecuteSqlRaw("EXEC [SCH_RESERVACIONES].[SP_AGREGARUSUARIO] @IDUsuario, @Email, @Pass, @Nombre, @Apellidos, @Tipo",
                                                        new SqlParameter("@IDUsuario", pEntidad.IdUsuario),
                                                        new SqlParameter("@Email", pEntidad.Email),
                                                        new SqlParameter("@Pass", pEntidad.Pass),
                                                        new SqlParameter("@Nombre", pEntidad.Nombre),
                                                        new SqlParameter("@Apellidos", pEntidad.Apellidos),
                                                        new SqlParameter("@Tipo", pEntidad.Tipo)
                                                        );

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public List<Usuarios> ComprobarLogin(Usuarios pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                List<Usuarios> lista = new List<Usuarios>();
                try
                {
                    var consulta = (from usuario in contexto.Usuarios //clientes
                                    where usuario.Email.Equals(pEntidad.Email) && usuario.Pass.Equals(pEntidad.Pass)
                                    select usuario).ToList();

                    if (consulta != null)
                    {
                        return consulta;
                    } else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<Usuarios> ConsultarUsuarios(Usuarios pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                List<Usuarios> lista = new List<Usuarios>();
                try
                {
                    if (pEntidad.Email == null)
                    {
                        var consulta = (from x in contexto.Usuarios
                                        select x).ToList();

                        if (consulta != null)
                        {
                            consulta.ForEach(x =>
                            {
                                lista.Add(x);
                            });
                        }
                    }
                    else
                    {
                        var consulta = (from usuario in contexto.Usuarios //clientes
                                        where usuario.Email.Equals(pEntidad.Email)
                                        select usuario).ToList();

                        if (consulta != null)
                        {
                            consulta.ForEach(x =>
                            {
                                lista.Add(x);
                            });
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    return lista;
                }
            }
        }

        public bool EliminarUsuario(Usuarios pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                bool resultado = false;
                try
                {
                    var consulta = (from x in contexto.Usuarios
                                    where x.IdUsuario.Equals(pEntidad.IdUsuario)
                                    select x).FirstOrDefault();

                    if (consulta != null)
                    {
                        contexto.Usuarios.Remove(consulta);
                        contexto.SaveChanges();
                        resultado = true;
                    }
                    return resultado;
                }
                catch (Exception ex)
                {
                    return resultado;
                }
            }
        }

        public bool ModificarUsuario(Usuarios pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                bool resultado = false;
                try
                {
                    var consulta = (from x in contexto.Usuarios
                                    where x.IdUsuario.Equals(pEntidad.IdUsuario)
                                    select x).FirstOrDefault();

                    if (consulta != null)
                    {
                        consulta.Email = pEntidad.Email;
                        consulta.Pass = pEntidad.Pass;
                        consulta.Nombre = pEntidad.Nombre;
                        consulta.Apellidos = pEntidad.Apellidos;
                        consulta.Tipo = pEntidad.Tipo;
                        contexto.SaveChanges();
                        resultado = true;
                    }
                    return resultado;
                }
                catch (Exception ex)
                {
                    return resultado;
                }
            }
        }
    }
}