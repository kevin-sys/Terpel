using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using DAL;
using Oracle.ManagedDataAccess.Client;
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
    }
}
