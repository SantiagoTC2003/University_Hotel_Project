using AccesoDatos.Interfaces;
using Entidades.SQLServer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccesoDatos
{
    public class ReservacionesADSQL : IReservacionesADSQL
    {
        public bool AgregarReserva(Reservaciones pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                bool resultado = false;
                try
                {
                    contexto.Reservaciones.Add(pEntidad);
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

        public List<Reservaciones> ConsultarReserva(Reservaciones pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                List<Reservaciones> lista = new List<Reservaciones>();
                try
                {
                    if (Convert.ToString(pEntidad.IdReserva) == "0")
                    {
                        var consulta = (from x in contexto.Reservaciones
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
                        var consulta = (from x in contexto.Reservaciones
                                        where x.IdReserva.Equals(pEntidad.IdReserva)
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

        public bool EliminarReserva(Reservaciones pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                bool resultado = false;
                try
                {
                    var consulta = (from x in contexto.Reservaciones
                                    where x.IdReserva.Equals(pEntidad.IdReserva)
                                    select x).FirstOrDefault();

                    if (consulta != null)
                    {
                        contexto.Reservaciones.Remove(consulta);
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

        public bool ModificarReserva(Reservaciones pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                bool resultado = false;
                try
                {
                    var consulta = (from x in contexto.Reservaciones
                                    where x.IdReserva.Equals(pEntidad.IdReserva)
                                    select x).FirstOrDefault();

                    if (consulta != null)
                    {
                        consulta.CodReserva = pEntidad.CodReserva;
                        consulta.FechaEntrada = pEntidad.FechaEntrada;
                        consulta.FechaSalida = pEntidad.FechaSalida;
                        consulta.CantidadAdultos = pEntidad.CantidadAdultos;
                        consulta.CantidadNinos = pEntidad.CantidadNinos;
                        consulta.CedulaCliente = pEntidad.CedulaCliente;
                        consulta.CodHabitacion = pEntidad.CodHabitacion;
                        consulta.PrecioHabitacion = pEntidad.PrecioHabitacion;
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
