using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class ClienteRepositoryOracle
    {
        private OracleConnection Connection;
        IList<Cliente> clientes = new List<Cliente>();
        public ClienteRepositoryOracle(OracleConnection connection)
        {
            Connection = connection;
        }
        
        public Cliente Mapear(OracleDataReader reader)
        {
            var cliente = new Cliente();
            cliente.Cedula = (string)reader["Cedula"];
            cliente.Primernombre = (string)reader["PrimerNombre"];
            cliente.Segundonombre = (string)reader["SegundoNombre"];
            cliente.Primerapellido = (string)reader["PrimerApellido"];
            cliente.Segundoapellido = (string)reader["SegundoApellido"];
            cliente.Telefono = (string)reader["Telefono"];
            cliente.Email = (string)reader["Email"];
            cliente.Marca = (string)reader["Marca"];
            cliente.Modelo = (string)reader["Modelo"];
            cliente.Tipodeaceite = (string)reader["TipoAceite"];
            cliente.Referenciaaceite = (string)reader["ReferenciaAceite"];
            cliente.Tipofiltro = (string)reader["TipoFiltro"];
            cliente.Referenciafiltro = (string)reader["ReferenciaFiltro"];
            return cliente;
        }

        public void Guardar(Cliente cliente)
        {
            using (var command=Connection.CreateCommand())
            {
                command.CommandText = "PKG_INSERTAR.INSERTAR_CLIENTE";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(":Cedula", OracleDbType.Varchar2).Value = cliente.Cedula;
                command.Parameters.Add(":PrimerNombre", OracleDbType.Varchar2).Value = cliente.Primernombre;
                command.Parameters.Add(":SegundoNombre", OracleDbType.Varchar2).Value = cliente.Segundonombre;
                command.Parameters.Add(":PrimerApellido", OracleDbType.Varchar2).Value = cliente.Primerapellido;
                command.Parameters.Add(":SegundoApellido", OracleDbType.Varchar2).Value = cliente.Segundoapellido;
                command.Parameters.Add(":Telefono", OracleDbType.Varchar2).Value = cliente.Telefono;
                command.Parameters.Add(":Email", OracleDbType.Varchar2).Value = cliente.Email;
                command.Parameters.Add(":Marca", OracleDbType.Varchar2).Value = cliente.Marca;
                command.Parameters.Add(":Modelo", OracleDbType.Varchar2).Value = cliente.Modelo;
                command.Parameters.Add(":TipoAceite", OracleDbType.Varchar2).Value = cliente.Tipodeaceite;
                command.Parameters.Add(":ReferenciaAceite", OracleDbType.Varchar2).Value = cliente.Referenciaaceite;
                command.Parameters.Add(":TipoFiltro", OracleDbType.Varchar2).Value = cliente.Tipofiltro;
                command.Parameters.Add(":ReferenciaFiltro", OracleDbType.Varchar2).Value = cliente.Referenciafiltro;
                command.ExecuteNonQuery();
            }
        }

    }
}
