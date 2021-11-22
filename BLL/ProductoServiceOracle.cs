using DAL;
using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ProductoServiceOracle
    {
        ProductoRepositoryOracle repositoryOracle;
        OracleConnection Connection;
        public ProductoServiceOracle()
        {
            string CadenaConexion = "Data Source = DESKTOP-BED3FNE; User ID = admin;Password=admin";
            Connection = new OracleConnection(CadenaConexion);
            repositoryOracle = new ProductoRepositoryOracle(Connection);
        }
        public class Respuesta
        {
            public IList<Producto> productos { get; set; }
            public string Message { get; set; }
            public bool IsError { get; set; }
        }


        public Respuesta Guardar(Producto producto)
        {
            var respuesta = new Respuesta();
            respuesta.IsError = false;
            try
            {
                Connection.Open();
                repositoryOracle.Guardar(producto);
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
