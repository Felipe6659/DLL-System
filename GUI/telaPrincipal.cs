using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class telaPrincipal : Form
    {
        public telaPrincipal()
        {
            InitializeComponent();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroFornecedores f = new frmCadastroFornecedores();
            f.ShowDialog();
            f.Dispose();
        }

        private void fornecedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaFornecedores f = new frmConsultaFornecedores();
            f.ShowDialog();
            f.Dispose();
        }

        private void telefoneFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroTelefoneFornecedor f = new frmCadastroTelefoneFornecedor();
            f.ShowDialog();
            f.Dispose();
        }

        private void telefoneFornecedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaTelefoneFornecedor f = new frmConsultaTelefoneFornecedor();
            f.ShowDialog();
            f.Dispose();
        }

       /* private void adicionarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                this.Hide();
                CadastroClientes f = new CadastroClientes();
                f.ShowDialog();
                f.Dispose();


            }*/

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TelaInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;

            }
        }

        private void TelaInicial_DoubleClick(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }



        private void funcionarioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmCadastroFuncionarios f = new frmCadastroFuncionarios();
            f.ShowDialog();
            f.Dispose();
        }
    }
    }
