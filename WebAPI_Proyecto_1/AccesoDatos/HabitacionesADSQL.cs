using AccesoDatos.Interfaces;
using Entidades.SQLServer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccesoDatos
{
    public class HabitacionesADSQL : IHabitacionesADSQL
    {
        public bool AgregarHabitacion(Habitaciones pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                bool resultado = false;
                try
                {
                    contexto.Habitaciones.Add(pEntidad);
                    contexto.SaveChanges();
                    resultado = true;
                    return resultado;
                }
                catch (Exception ex)
                {
                    return resultado;
                }
            }
        }

        public List<Habitaciones> ConsultarHabitacion(Habitaciones pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                List<Habitaciones> lista = new List<Habitaciones>();
                try
                {
                    if (Convert.ToString(pEntidad.CodHabitacion) == "0")
                    {
                        var consulta = (from x in contexto.Habitaciones
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
                        var consulta = (from x in contexto.Habitaciones
                                        where x.CodHabitacion.Equals(pEntidad.CodHabitacion)
                                        select x).ToList();

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

        public bool EliminarHabitacion(Habitaciones pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                bool resultado = false;
                try
                {
                    var consulta = (from x in contexto.Habitaciones
                                    where x.CodHabitacion.Equals(pEntidad.CodHabitacion)
                                    select x).FirstOrDefault();

                    if (consulta != null)
                    {
                        contexto.Habitaciones.Remove(consulta);
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

        public bool ModificarHabitacion(Habitaciones pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                bool resultado = false;
                try
                {
                    var consulta = (from x in contexto.Habitaciones
                                    where x.CodHabitacion.Equals(pEntidad.CodHabitacion)
                                    select x).FirstOrDefault();

                    if (consulta != null)
                    {
                        consulta.CodHabitacion = pEntidad.CodHabitacion;
                        consulta.TipoHabitacion = pEntidad.TipoHabitacion;
                        consulta.CapacidadHabitacion = pEntidad.CapacidadHabitacion;
                        consulta.EstadoHabitacion = pEntidad.EstadoHabitacion;
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