using DAL;
using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
namespace BLL
{
    public class ClienteServiceOracle
    {
        ClienteRepositoryOracle repositoryOracle;
        OracleConnection Connection;
        public ClienteServiceOracle()
        {
            string CadenaConexion = "Data Source = DESKTOP-BED3FNE; User ID = admin;Password=admin";


            Connection = new OracleConnection(CadenaConexion);
            repositoryOracle = new ClienteRepositoryOracle(Connection);
        }

        public class Respuesta
        {
            public IList<Cliente> clientes { get; set; }
            public string Message { get; set; }
            public bool IsError { get; set; }
        }

        public Respuesta Guardar(Cliente cliente)
        {
            var respuesta = new Respuesta();
            respuesta.IsError = false;
            try
            {
                Connection.Open();
                repositoryOracle.Guardar(cliente);
                respuesta.Message = $"SE GUARDO CORRECTAMENTE EL CLIENTE";
                return respuesta;
            }
            catch (Exception e)
            {
                Connection.Close();
                respuesta.IsError = true;
                respuesta.Message = "Error de Base de Datos:" + e.Message.ToString();
                return respuesta;
            }
            finally
            {
                Connection.Close();
            }
        }

        public IList<Cliente> ConsultarTodos()
        {

            try
            {

                Connection.Open();
                return repositoryOracle.Consultar();
            }

            catch (Exception)
            {
                Connection.Close();

                return null;
            }
            finally
            {
                Connection.Close();
            }




        }

        //public string Eliminar(string identificacion)
        //{
        //    try
        //    {
        //       // Cliente cliente = new Cliente(); 
        //        Connection.Open();

        //        repositoryOracle.Eliminar(identificacion);
        //        Connection.Close();
        //        return ($"El registro se ha eliminado satisfactoriamente.");


        //    }
        //    catch (Exception)
        //    {

        //        return ($"No existe un cliente con esa cedula");
        //    }
        //    finally { Connection.Close(); }

        //}

        public string Eliminar(string identificacion)
        {
           
            Connection.Open();
            string mensaje=repositoryOracle.Eliminar(identificacion);

            Connection.Close();
            return mensaje;
        }

        
      
        public Cliente BuscarID(string identificacion)
        {
            Cliente persona = new Cliente();
            try
            {
                Connection.Open();
                return repositoryOracle.Buscar(identificacion);
            }
            catch (Exception e)
            {
                string mensaje = " ERROR EN LA BASE DE DATOS " + e.Message;
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }



    }
}
