using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {

        private List<Thread> _mockPaquetes;

        private List<Paquete> _paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return _paquetes;
            }
            set
            {
                this._paquetes = value;
            }
        }
      

        #region Constructor

        public Correo()
        {
            this._mockPaquetes = new List<Thread>();
            this.Paquetes = new List<Paquete>();
        }

        #endregion

        #region Metodos

        public void FinEntregas()
        {
            foreach (Thread t in this._mockPaquetes)
                if (t.IsAlive)
                {
                    t.Abort();
                }

        }


        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIDRepetidoException("El paquete ya se encuentra cargado en la base de datos");
                }
            }
            try
            {
                c.Paquetes.Add(p);
                Thread hilo = new Thread(p.MockCicloDeVida);
                hilo.Start();
                c._mockPaquetes.Add(hilo);
            }
            catch (Exception e)
            {
                throw e;
            }
            return c;
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string retorno = "";
            List<Paquete> listPaq = ((Correo)elemento).Paquetes;
            foreach (Paquete item in listPaq)
            {
                retorno += string.Format("{0} para {1} ({2})\n", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
            }
            return retorno;
        }

        #endregion

    }
}
