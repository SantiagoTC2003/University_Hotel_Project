using AccesoDatos.Interfaces;
using Entidades.SQLServer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccesoDatos
{
    public class ClientesADSQL : IClientesADSQL
    {
        public bool AgregarCliente(Clientes pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                try
                {
                    contexto.Clientes.Add(pEntidad);
                    contexto.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public List<Clientes> ConsultarCliente(Clientes pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                List<Clientes> lista = new List<Clientes>();
                try
                {
                    if (pEntidad.CedulaCliente == null)
                    {
                        var consulta = (from x in contexto.Clientes
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
                        var consulta = (from cliente in contexto.Clientes //clientes
                                        where cliente.CedulaCliente.Equals(pEntidad.CedulaCliente)
                                        select cliente).ToList();

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

        public bool EliminarCliente(Clientes pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                bool resultado = false;
                try
                {
                    var consulta = (from x in contexto.Clientes
                                    where x.CedulaCliente.Equals(pEntidad.CedulaCliente)
                                    select x).FirstOrDefault();

                    if (consulta != null)
                    {
                        contexto.Clientes.Remove(consulta);
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

        public bool ModificarCliente(Clientes pEntidad)
        {
            using (var contexto = new HotelProyectoContext())
            {
                bool resultado = false;
                try
                {
                    var consulta = (from x in contexto.Clientes
                                    where x.CedulaCliente.Equals(pEntidad.CedulaCliente)
                                    select x).FirstOrDefault();

                    if (consulta != null)
                    {
                        consulta.CedulaCliente = pEntidad.CedulaCliente;
                        consulta.NombreCliente = pEntidad.NombreCliente;
                        consulta.Apellido1Cliente = pEntidad.Apellido1Cliente;
                        consulta.Apellido2Cliente = pEntidad.Apellido2Cliente;
                        consulta.TelefonoCliente = pEntidad.TelefonoCliente;
                        consulta.CorreoCliente = pEntidad.CorreoCliente;
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