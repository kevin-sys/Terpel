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
            //  string CadenaConexion = "TNS_ADMIN=C://Users//pc//Oracle//network//admin;USER ID=ADMIN;WALLET_LOCATION=C://Users//pc//Oracle//network//admin;DATA SOURCE=DESKTOP-BED3FNE";


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

            catch (Exception e)
            {
                Connection.Close();

                return null;
            }
            finally
            {
                Connection.Close();
            }




        }
    }
}
