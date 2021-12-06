﻿using ENTITY;
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
            cliente.Cedula = Convert.ToString(reader["Cedula"]);
            cliente.Primernombre = Convert.ToString(reader["PrimerNombre"]);
            cliente.Segundonombre = Convert.ToString(reader["SegundoNombre"]);
            cliente.Primerapellido = Convert.ToString(reader["PrimerApellido"]);
            cliente.Segundoapellido = Convert.ToString(reader["SegundoApellido"]);
            cliente.Telefono = Convert.ToString(reader["Telefono"]);
            cliente.Email = Convert.ToString(reader["Email"]);
            cliente.Direccion = Convert.ToString(reader["Direccion"]);

            cliente.Edad = Convert.ToInt32(reader["Edad"]);


            cliente.Ciudad = Convert.ToString(reader["Ciudad"]);
            cliente.Comuna = Convert.ToString(reader["Comuna"]);
            cliente.Barrio = Convert.ToString(reader["Barrio"]);
            cliente.Nacionalidad = Convert.ToString(reader["Nacionalidad"]);
            return cliente;
        }

        public IList<Cliente> Consultar()
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "PKG_CONSULTAR.CONSULTAR_CLIENTE";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("CURSORMEMORIA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                using (var reader = command.ExecuteReader())
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
            using (var command = Connection.CreateCommand())
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


        //public void Eliminar(string identificacion)
        //{
        //    using (var command = Connection.CreateCommand())

        //    {
        //        command.CommandText = "DELETE_CLIENTE";
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add(":C_CEDULA", OracleDbType.Varchar2).Value = identificacion;
        //        command.ExecuteNonQuery();

        //    }
        //}

        public string Eliminar(string identificacion)
        {
            string result = string.Empty;
            try
            {

                using (var command = Connection.CreateCommand())
                {
                    command.CommandText = "DELETE_CLIENTE";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(":C_CEDULA", OracleDbType.Varchar2).Value = identificacion;
                    command.Parameters.Add(new OracleParameter("P_RESULT", OracleDbType.Varchar2, 50)).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                }

            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public Cliente Buscar(string identificacion)
        {


            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "SELECT_CLIENTE_ID";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(":C_CEDULA", OracleDbType.Varchar2).Value = identificacion;
                command.Parameters.Add("C_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                using (var reader = command.ExecuteReader())
                {

                    reader.Read();
                    return Mapear(reader);

                }
            }
        }


    }
}
