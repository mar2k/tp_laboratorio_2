using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #region Propiedades

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        #endregion


        #region Constructor

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        #endregion


        #region Metodos

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string retorno = "";
            Paquete p = (Paquete)elemento;
            retorno = String.Format("{0} para {1}", p.TrackingID, p.DireccionEntrega);
            return retorno;
        }


        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado += 1;
                this.InformaEstado(this, new EventArgs());
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                MessageBox.Show("Se produjo el siguiente error al conectar a la base de datos: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Sobrecargas de Operadores

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if (p1.TrackingID == p2.TrackingID)
                retorno = true;
            return retorno;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        #endregion

        #region Otros

        //Delegado
        public delegate void DelegadoEstado(object sender, EventArgs e);

        //Evento
        public event DelegadoEstado InformaEstado;

        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

    }
}
