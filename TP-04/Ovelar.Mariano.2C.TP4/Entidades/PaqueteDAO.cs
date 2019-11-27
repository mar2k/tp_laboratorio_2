using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand _comando;
        private static SqlConnection _conexion;

        #region Constructor

        static PaqueteDAO()
        {
            PaqueteDAO._conexion = new SqlConnection(Properties.Settings.Default.Conexion);
        }
        #endregion

        #region Metodos

        public static bool Insertar(Paquete p)
        {
            bool retorno = true;
            try
            {
                PaqueteDAO._conexion.Open();
                PaqueteDAO._comando = new SqlCommand("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES(' " + p.DireccionEntrega + "','" + p.TrackingID + "','Ovelar Mariano')", PaqueteDAO._conexion);
                PaqueteDAO._comando.ExecuteNonQuery();
                PaqueteDAO._conexion.Close();
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                retorno = false;
                throw e;
            }
            finally
            {
                if (PaqueteDAO._conexion.State == ConnectionState.Open)
                {
                    PaqueteDAO._conexion.Close();
                }
                    
            }
            return retorno;
        }
#endregion

    }
}
