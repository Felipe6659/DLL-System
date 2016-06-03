using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;

namespace GUI
{
    public partial class frmCadastroFuncionarios : Form
    {
        public frmCadastroFuncionarios()
        {
            InitializeComponent();
        }
        public void Cpferrado()
        {
            MessageBox.Show("O Cpf é invalido");
        }

        private void verificacamposembranco()
        {
            if ((txtCPF.Text == "") | (txtNome.Text == "") | (txtRG.Text == "") | (txtTelefone.Text == ""))
            {
                MessageBox.Show("Campo em branco");
            }
        }
        private void verificacampos()
        {
            if ((txtTelefone.TextLength > 10) | (txtTelefone.TextLength < 10))
            {
                MessageBox.Show("Numero de telefone invalido");
            }
        }
        private void limpacampos()
        {
            txtCPF.Clear();
            txtNome.Clear();
            txtRG.Clear();
            txtTelefone.Clear();

        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            verificacamposembranco();
            verificacampos();
            ModeloFuncionario func = new ModeloFuncionario();
            func.Nome = txtNome.Text;
            func.Telefone = txtTelefone.Text;
            func.RG = txtRG.Text;
            func.CPF = txtCPF.Text;
            if ((txtCPF.TextLength > 11) | (txtCPF.TextLength < 11))
            {
                Cpferrado();
                txtCPF.Clear();
            }
            if ((txtCPF.Text == "11111111111") | (txtCPF.Text == "22222222222") | (txtCPF.Text == "33333333333") | (txtCPF.Text == "44444444444") | (txtCPF.Text == "55555555555") | (txtCPF.Text == "66666666666") || (txtCPF.Text == "77777777777") | (txtCPF.Text == "88888888888") | (txtCPF.Text == "999999999") | (txtCPF.Text == "00000000000"))
            {
                Cpferrado();
                txtCPF.Clear();
            }
        }

    }
}
