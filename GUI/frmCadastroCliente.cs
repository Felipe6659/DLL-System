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
    public partial class frmCadastroCliente : Form
    {
        public frmCadastroCliente()
        {
            InitializeComponent();
        }

        /*        private void FullScreen()
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Maximized;
                    this.TopMost = true;

                } */

        public string operacao = "";

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        public void AlteraBotoes(int op)
        {
            pDados.Enabled = false;
            btInserir.Enabled = false;
            btAlterar.Enabled = false;
            btExcluir.Enabled = false;
            btLocalizar.Enabled = false;
            btSalvar.Enabled = false;
            btCancelar.Enabled = false;

            if (op == 1)
            {
                pDados.Enabled = true;
                btInserir.Enabled = true;
                btLocalizar.Enabled = true;

            }

            if (op == 2)
            {
                pDados.Enabled = true;
                btSalvar.Enabled = true;
                btCancelar.Enabled = true;

            }

            if (op == 3)
            {

                btExcluir.Enabled = true;
                btAlterar.Enabled = true;
                btCancelar.Enabled = true;

            }

        }

        public void LimparCampos()
        {
            txtBairro.Clear();
            txtEmail.Clear();
            txtNomeCliente.Clear();
            txtNumero.Clear();
            txtCpfRg.Clear();
            txtRua.Clear();
            txtTelefone.Clear();
            txtCep.Clear();
            txtMunicipio.Clear();

        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "Inserir";
            this.AlteraBotoes(2);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.AlteraBotoes(1);
            this.LimparCampos();
        }

        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {
            this.AlteraBotoes(1);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;

        }

        private void frmCadastroCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void frmCadastroCliente_DoubleClick(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
        }
    }
}