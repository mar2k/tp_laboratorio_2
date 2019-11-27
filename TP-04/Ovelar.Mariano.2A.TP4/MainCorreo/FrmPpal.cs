using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            switch (MessageBox.Show(this, "¿Desea salir?", "Cerrando", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    this.correo.FinEntregas();
                    break;
            }
        }


        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }


        private void ActualizarEstados()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();

            foreach (Paquete p in this.correo.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(p);
                        break;
                }
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxTrackingID.Text);
            EventArgs info = new EventArgs();
            paquete.InformaEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);
            try
            {
                this.correo += paquete;
            }
            catch (TrackingIDRepetidoException error)
            {
                MessageBox.Show(error.Message, "ID repetido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ep)
            {
                MessageBox.Show("Se produjo el siguiente error al intentar agregar un paquete: " + ep.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.ActualizarEstados();
        }




        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!Equals(elemento, null))
            {
                string texto;
                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory)+"//salida.txt";
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                texto = this.rtbMostrar.Text;
                try
                {
                    texto.Guardar(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        
    }
}
