using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
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
            cliente.Direccion = (string)reader["Direccion"];
          
            cliente.Edad = Convert.ToInt32(reader["Edad"]);

          //  dto.TELEFONO = Convert.ToInt32(dr["TELEFONO"]);
            cliente.Ciudad = (string)reader["Ciudad"];
            cliente.Comuna = (string)reader["Comuna"];
            cliente.Barrio = (string)reader["Barrio"];
            cliente.Nacionalidad = (string)reader["Nacionalidad"];
            return cliente;
        }

        public IList<Cliente> Consultar()
        {
            using (var command=Connection.CreateCommand())
            {
                command.CommandText = "PKG_CONSULTAR.CONSULTAR_CLIENTE";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("CURSORMEMORIA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                using (var reader=command.ExecuteReader())
                {
                    clientes.Clear();
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente = Mapear(reader);
                        clientes.Add(cliente);
                    }
                }
            }
            return clientes;
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

                command.Parameters.Add(":Direccion", OracleDbType.Varchar2).Value = cliente.Direccion;
                command.Parameters.Add(":Edad", OracleDbType.Int16).Value = cliente.Edad;
                command.Parameters.Add(":Ciudad", OracleDbType.Varchar2).Value = cliente.Ciudad;
                command.Parameters.Add(":Comuna", OracleDbType.Varchar2).Value = cliente.Comuna;
                command.Parameters.Add(":Barrio", OracleDbType.Varchar2).Value = cliente.Barrio;
                command.Parameters.Add(":Nacionalidad", OracleDbType.Varchar2).Value = cliente.Nacionalidad;
                command.ExecuteNonQuery();
            }
        }

    }
}
