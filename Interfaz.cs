using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENEform
{
    public partial class Interfaz : Form
    {
        public Interfaz()
        {
            InitializeComponent();
        }
        private void Calcular(object sender, EventArgs e)
        {

            // Lógica para el botón "CALCULAR".
            int horasTrabajadas = int.Parse(txtBoxHrTrab.Text);
            int horasExtras = int.Parse(txtBoxHrExt.Text);
            string afpSeleccionada = comboBox1.SelectedItem.ToString();
            string saludSeleccionada = comboBox2.SelectedItem.ToString();
            // Calcula el sueldo bruto y el descuento AFP.

            int valorHora = 5000;
            int valorHoraExtra = 7000;
            int sueldoBruto = (horasTrabajadas * valorHora) + (horasExtras * valorHoraExtra);


            int descuentoAFP = CalculaDescuentoAFP(sueldoBruto, afpSeleccionada);
            int descuentoSalud = CalculaDescuentoSalud(sueldoBruto, saludSeleccionada);
            int sueldoLiquido = (sueldoBruto - descuentoAFP - descuentoSalud);
            // Muestra los resultados en los TextBox correspondientes.
            txtBoxSldBruto.Text = sueldoBruto.ToString();
            txtBoxSldLqi.Text = sueldoLiquido.ToString();
            // Para mostrar el descuento AFP, puedes necesitar un nuevo TextBox.
            // textBoxX.Text = descuentoAFP.ToString();
        }
        private int CalculaDescuentoSalud(int sueldoBruto, string salud)
        {
            double tasaDescuento = 0;

            switch (salud)
            {
                case "FONASA":
                    tasaDescuento = 0.12;
                    break;
                case "CONSALUD":
                    tasaDescuento = 0.13;
                    break;
                case "MASVIDA":
                    tasaDescuento = 0.14;
                    break;
                case "BANMEDICA":
                    tasaDescuento = 0.15;
                    break;
                default:
                    MessageBox.Show("Sistema de Salud no reconocido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            return (int)(sueldoBruto * tasaDescuento);
        }
        private int CalculaDescuentoAFP(int sueldoBruto, string afp)
        {
            double tasaDescuento = 0;

            switch (afp)
            {
                case "CAPITAL":
                    tasaDescuento = 0.12;
                    break;
                case "CUPRUM":
                    tasaDescuento = 0.07;
                    break;
                case "MODELO":
                    tasaDescuento = 0.09;
                    break;
                case "PROVIDA":
                    tasaDescuento = 0.13;
                    break;
                default:
                    MessageBox.Show("AFP no reconocida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            return (int)(sueldoBruto * tasaDescuento);
        }
    }
}
