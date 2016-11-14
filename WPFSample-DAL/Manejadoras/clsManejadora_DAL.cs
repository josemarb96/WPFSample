using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSample;
using WPFSample_Ent;

namespace WPFSample_DAL.Manejadoras
{
    public class clsManejadora_DAL
    {
        private clsMyConnection miConexion;

        public clsManejadora_DAL()
        {
            miConexion = new clsMyConnection();
        }

        /// <summary>
        /// Función que permite añadir una persona a la tabla
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int insertarPersonaDAL (clsPersona persona)
        {
            int resultado = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            //Añadimos los datos al comando
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.DateTime).Value = persona.FechaNac;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;

            try
            {
                //Realizamos la conexión e insertamos los datos
                conexion = miConexion.getConnection();
                miComando.CommandText = "INSERT INTO personas(nombre, apellidos, fechaNac, direccion, telefono) VALUES (@nombre, @apellidos, @fechaNac, @direccion, @telefono)";
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
                return resultado;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
                miConexion.closeConnection(ref conexion);
            }
        } //Fin insertarPersonaDAL

    } //Fin class
}
