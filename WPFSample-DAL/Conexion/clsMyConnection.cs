﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

// Esta clase contiene los métodos necesarios para trabajar con el acceso a una base de datos SQL Server
//PROPIEDADES
//  _host: cadena
//   _database: cadena, básica. Consultable/modificable.
//   _user: cadena, básica. Consultable/modificable.
//   _pass: cadena, básica. Consultable/modificable.

// MÉTODOS
//   Function getConnection() As SqlConnection
//       Este método abre una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//   
//   Sub closeConnection(ByRef connection As SqlConnection)
//       Este método cierra una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//


namespace WPFSample
{
    public class clsMyConnection
    {
        //Atributos
        //public String host { get; set; }
        public String server { get; set; }
        public String dataBase { get; set; }
        public String user { get; set; }
        public String pass { get; set; }

        //Constructores

        public clsMyConnection()
        {
            /* BASE DE DATOS LOCAL
            this.host = "192.168.0.161"; //IP de Fernando (también puedes poner el equipo -> 107-01)
            this.dataBase = "WPFSample";
            //El primer usuario es de de la base de datos del instituto, el segundo la de casa
            this.user = "prueba";
            //this.user = "pruebaResident";
            this.pass = "123";*/

            //AZURE
            this.server = "iesnervion.database.windows.net";
            this.dataBase = "WPFSample";
            this.user = "prueba";
            this.pass = "iesnervion123.";
        }
        //Con parámetros por si quisiera cambiar las conexiones
        /*public clsMyConnection(String host,String database, String user, String pass)
        {
            this.host = host;
            this.dataBase = database;
            this.user = user;
            this.pass = pass;
        }*/

        public clsMyConnection(String server, String database, String user, String pass)
        {
            this.server = server;
            this.dataBase = database;
            this.user = user;
            this.pass = pass;
        }


        //METODOS



            /// <summary>
            /// Método que abre una conexión con la base de datos
            /// </summary>
            /// <pre>Nada.</pre>
            /// <returns>Una conexión con la base de datso</returns>
        public SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                //connection.ConnectionString = "Data Source=" & My.Computer.Name & "Initial Catalog=" & _database & ";uid=" & _user & ";pwd=" & _user & ";"
                //connection.ConnectionString = "server=(local);database=" + dataBase + ";uid=" + user + ";pwd=" + pass + ";";

                //Muy cómoda esta forma de escribir la cadena conStringFormat, metiendo los parametros entre llaves y asignandoselo tras la coma
                //connection.ConnectionString = string.Format("server=(local);database={0};uid={1};pwd={2};", dataBase, user, pass);
                //Base de datos local
                //connection.ConnectionString = string.Format("server={0};database={1};uid={2};pwd={3};", host, dataBase, user, pass);

                //Azure
                connection.ConnectionString = "Server=tcp:iesnervion.database.windows.net,1433;Initial Catalog=WPFSample;Persist Security Info=False;User ID=prueba;Password=iesnervion123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                connection.Open();
            }
            catch (SqlException)
            {
                throw;
            }

            return connection;

        }




        /// <summary>
        /// Este metodo cierra una conexión con la Base de datos
        /// </summary>
        /// <post>The connection is closed.</post>
        /// <param name="connection">La entrada es la conexión a cerrar
        /// </param>
        public void closeConnection(ref SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw; 
            }
            catch (Exception)
            {
            throw;
            }
        }


    }

}
