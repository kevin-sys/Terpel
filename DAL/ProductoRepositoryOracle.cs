using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class ProductoRepositoryOracle
    {
        private OracleConnection Connection;
        IList<Producto> productos = new List<Producto>();
        public ProductoRepositoryOracle(OracleConnection connection)
        {

            Connection = connection;
        }

        public void Guardar(Producto producto)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "PKG_INSERTARPRODUCTO.INSERTAR_PRODUCTO";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(":Id", OracleDbType.Varchar2).Value = producto.Id;
                command.Parameters.Add(":Nombre", OracleDbType.Varchar2).Value = producto.Nombre;
                command.Parameters.Add(":Cantidad", OracleDbType.Decimal).Value = producto.Cantidad;
                command.Parameters.Add(":PrecioCompra", OracleDbType.Decimal).Value = producto.PrecioCompra;
                command.Parameters.Add(":PrecioVenta", OracleDbType.Decimal).Value = producto.PrecioVenta;
                command.Parameters.Add(":Descripcion", OracleDbType.Varchar2).Value = producto.Descripcion;
                command.Parameters.Add(":Ganancia", OracleDbType.Decimal).Value = producto.Ganancia;
                command.ExecuteNonQuery();
            }
        }
    }
}
