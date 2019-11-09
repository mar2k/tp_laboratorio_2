using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cmbOperador.SelectedIndex = 0;
            
        }

        private void btnComvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }

        private void btnComvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 =new Numero(txtNumero2.Text);
            lblResultado.Text = Calculadora.Operar(numero1,numero2, cmbOperador.Text).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
        }

        private void Limpiar()
        {
            lblResultado.Text = "0";
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
        }

        
    }
}
