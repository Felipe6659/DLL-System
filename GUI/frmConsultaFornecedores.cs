using BLL;
using DAL;
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
    public partial class frmConsultaFornecedores : Form
    {
        public int identificador = 0;

        public frmConsultaFornecedores()
        {
            InitializeComponent();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            DALConecxao cx = new DALConecxao(DadosDaConecxao.StringDeConecxao);
            BLLFornecedores bll = new BLLFornecedores(cx);
            dgvDados.DataSource = bll.Localizar(txtValor.Text);  //DataSource == Fonte dos dados que seram exibidos na tela

        }

        private void frmConsultaFornecedores_Load(object sender, EventArgs e)
        {
            btLocalizar_Click(sender, e);

            //Trocar os nomes das colunas na consulta
            //Tamanho da tela de localização - 756; 439
            dgvDados.Columns[0].HeaderText = "Identificador";
            dgvDados.Columns[0].Width = 100;
            dgvDados.Columns[1].HeaderText = "Nome";
            dgvDados.Columns[1].Width = 100;
            dgvDados.Columns[2].HeaderText = "Descrição";
            dgvDados.Columns[2].Width = 336;
            dgvDados.Columns[3].HeaderText = "Endereço";
            dgvDados.Columns[3].Width = 220;
        }

        private void dgvDados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.identificador = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }
    }
}
