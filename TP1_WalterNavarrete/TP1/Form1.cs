using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_WalterNavarrete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblResultado.Text = "";
            this.Text = "TP1_Calculadora";
        }

        private void btnOperar_Click_1(object sender, EventArgs e)
        {
            double resultado;
            Numero num1 = new Numero(this.txtNumero1.Text);
            Numero num2 = new Numero(this.txtNumero2.Text);

            string operador = Calculadora.validarOperador(this.cmbOperacion.Text);

            resultado = Calculadora.operar(num1, num2, operador);

            this.lblResultado.Text = resultado.ToString();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            this.lblResultado.Text = "";
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
        }

       

           
    }
}
