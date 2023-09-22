using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aulaDataGridViewComValidacoes
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void txtUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void limpar()
        {
            txtProduto.Clear();
            txtUnitario.Clear();
            txtQuant.Clear();
            txtProduto.Focus();
        }

        private void calculaTotal()
        {
            double total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total += Convert.ToDouble(row.Cells["Totaltoto"].Value);
            }

            txtTotal.Text = Convert.ToDouble(total).ToString("C");
        }

        private bool verificaCampos()
        {
            if (txtProduto.Text == "" || txtQuant.Text == "" || txtUnitario.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double vUnit, vTotal;
            int qtd;
            string nome;
            bool x = verificaCampos();

            if (x == true)
            {
                nome = txtProduto.Text;
                qtd = Convert.ToInt32 (txtQuant.Text);
                vUnit = Convert.ToDouble (txtUnitario.Text);
                vTotal = qtd * vUnit;
                dataGridView1.Rows.Add(nome, vUnit, qtd, vTotal);
                calculaTotal();
                limpar();
            }
            else
            {
                MessageBox.Show ("Campos em Branco!");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {

                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                calculaTotal();
            }
            else
            {
                MessageBox.Show("Vazio", "Vazio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
    }
}
