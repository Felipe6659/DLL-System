using BLL;
using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCadastroTelefoneFornecedor : GUI.frmModeloDeCadastro
    {
        public frmCadastroTelefoneFornecedor()
        {
            InitializeComponent();
        }

        public void limpaTela()
        {
            txtCodigoTelefoneFornecedor.Clear();
            txtTelefone.Clear();
        }

        private void frmCadastroTelefoneFornecedor_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
            
            //cria uma conecxao
            DALConecxao cx = new DALConecxao(DadosDaConecxao.StringDeConecxao);
            BLLFornecedores bll = new BLLFornecedores(cx);
            cbIDFornecedor.DataSource = bll.Localizar(""); //Retorna os dados
            cbIDFornecedor.DisplayMember = "Nome";
            cbIDFornecedor.ValueMember = "IDFornecedor";

        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.alteraBotoes(2);
            this.operacao = "inserir";
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
            limpaTela();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.alteraBotoes(2);
            this.operacao = "alterar";
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura dos dados na tela 
                ModeloTelefoneFornecedor modelo = new ModeloTelefoneFornecedor();
                modelo.Tel_Telefone = txtTelefone.Text;
                modelo.Tel_IDFornecedor = Convert.ToInt32(cbIDFornecedor.SelectedValue);


                //cria uma conecxao
                DALConecxao cx = new DALConecxao(DadosDaConecxao.StringDeConecxao);
                BLLTelefoneFornecedor bll = new BLLTelefoneFornecedor(cx);

                //obj para gravar os dados no banco
                if (operacao == "inserir")
                {
                    //Adicionar telefone de um fornecedor
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado");

                }

                else
                {
                    //Alterar um fornecedor
                    modelo.Tel_IDTelefoneFornecedor = Convert.ToInt32(txtCodigoTelefoneFornecedor.Text);
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

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    //cria uma conecxao
                    DALConecxao cx = new DALConecxao(DadosDaConecxao.StringDeConecxao);
                    BLLTelefoneFornecedor bll = new BLLTelefoneFornecedor(cx);

                    bll.Excluir(Convert.ToInt32(txtCodigoTelefoneFornecedor.Text));
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

            frmConsultaTelefoneFornecedor f = new frmConsultaTelefoneFornecedor();
            f.ShowDialog();
            if (f.identificador != -1)
            {
                //cria uma conecxao
                DALConecxao cx = new DALConecxao(DadosDaConecxao.StringDeConecxao);
                BLLTelefoneFornecedor bll = new BLLTelefoneFornecedor(cx);

                ModeloTelefoneFornecedor modelo = bll.CarregaModeloTelefoneFornecedor(f.identificador);
                txtCodigoTelefoneFornecedor.Text = modelo.Tel_IDTelefoneFornecedor.ToString();
                txtTelefone.Text = modelo.Tel_Telefone;
                
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
