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
    public partial class LaCalculadora : Form
    {
        Numero num1=new Numero();
        Numero num2=new Numero();
        
        public LaCalculadora()
        {
            InitializeComponent();
            this.comOperador.SelectedIndex = 0;
            this.comOperador.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ComvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }

        private void ComvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
        }

        private void Operar_Click(object sender, EventArgs e)
        {
            double resultado;

            num1.SetNumero = txtNumero1.Text;
            num2.SetNumero = txtNumero2.Text;
            
            resultado = Calculadora.Operar(num1,num2,comOperador.Text);

            lblResultado.Text = resultado.ToString();

        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "0";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        private void comOperador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
