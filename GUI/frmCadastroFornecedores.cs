using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelo;
using DAL;
using BLL;

namespace GUI
{
    public partial class frmCadastroFornecedores : GUI.frmModeloDeCadastro
    {
        public frmCadastroFornecedores()
        {
            InitializeComponent();
        }

        public void limpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtEndereco.Clear();
        }

        private void frmCadastroFornecedores_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            limpaTela(); //limpar a tela
            this.alteraBotoes(1);
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura dos dados na tela 
                ModeloFornecedores modelo = new ModeloFornecedores();
                modelo.For_Nome = txtNome.Text;
                modelo.For_Descricao = txtDescricao.Text;
                modelo.For_Endereco = txtEndereco.Text;

                
                //cria uma conecxao
                DALConecxao cx = new DALConecxao(DadosDaConecxao.StringDeConecxao);
                BLLFornecedores bll = new BLLFornecedores(cx);

                //obj para gravar os dados no banco
                if (operacao == "inserir")
                {
                    //Adicionar um fornecedor
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado, Fornecedor: " + modelo.For_IDFornecedor.ToString());

                }

                else
                {
                    //Alterar um fornecedor
                    modelo.For_IDFornecedor = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado");
                }
                this.limpaTela();
                this.alteraBotoes(1);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            this.alteraBotoes(2);
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    //cria uma conecxao
                    DALConecxao cx = new DALConecxao(DadosDaConecxao.StringDeConecxao);
                    BLLFornecedores bll = new BLLFornecedores(cx);

                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.limpaTela();
                    this.alteraBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Impossivel excluir o registro. \n O registro está sendo utilizado em outro local.");
                this.alteraBotoes(3);

            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaFornecedores f = new frmConsultaFornecedores();
            f.ShowDialog();
            if (f.identificador != -1)
            {
                //cria uma conecxao
                DALConecxao cx = new DALConecxao(DadosDaConecxao.StringDeConecxao);
                BLLFornecedores bll = new BLLFornecedores(cx);
               
                ModeloFornecedores modelo = bll.CarregaModeloFornecedores(f.identificador);
                txtCodigo.Text = modelo.For_IDFornecedor.ToString();
                txtNome.Text = modelo.For_Nome;
                txtDescricao.Text = modelo.For_Descricao;
                txtEndereco.Text = modelo.For_Endereco;

                BLLTelefoneFornecedor bllTelefone = new BLLTelefoneFornecedor(cx);
                ModeloFornecedores modeloTelefone = bll.CarregaModeloFornecedores(f.identificador);
                
                this.alteraBotoes(3);

            }
            else
            {
                this.limpaTela();
                this.alteraBotoes(1);
            }

            f.Dispose();
        }
    }
}
