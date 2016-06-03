using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloFornecedores
    {
        private int for_IDFornecedor;
        private String for_Nome;
        private String for_Desricao;
        private String for_Endereco;

        public ModeloFornecedores()
        {
            this.for_IDFornecedor = 0;
            this.for_Nome = "";
            this.for_Desricao = "";
            this.for_Endereco = "";
        }

        public ModeloFornecedores(int identificador, String nomeFornecedor, String descricao, String endereco)
        {
            this.for_IDFornecedor = identificador;
            this.for_Nome = nomeFornecedor;
            this.for_Desricao = descricao;
            this.for_Endereco = endereco;
        }

        public int For_IDFornecedor
        {
            get { return this.for_IDFornecedor; }
            set { this.for_IDFornecedor = value; }
        }

        public String For_Nome
        {
            get { return this.for_Nome; }
            set { this.for_Nome = value; }
        }

        public String For_Descricao
        {
            get { return this.for_Desricao; }
            set { this.for_Desricao = value; }
        }

        public String For_Endereco
        {
            get { return this.for_Endereco; }
            set { this.for_Endereco = value; }
        }
    }
}
