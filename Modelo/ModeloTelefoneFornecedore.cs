using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloTelefoneFornecedor
    {
        private int tel_IDTelefoneFornecedor;
        private String tel_Telefone;
        private int tel_IDFornecedor;

        public ModeloTelefoneFornecedor()
        {
            this.tel_IDTelefoneFornecedor = 0;
            this.tel_Telefone = "";
            this.tel_IDFornecedor = 0;
        }

        public ModeloTelefoneFornecedor(int identificador, String telefone, int identificadorFornecedor)
        {
            this.tel_IDTelefoneFornecedor = identificador;
            this.tel_Telefone = telefone;
            this.tel_IDFornecedor = identificadorFornecedor;
        }

        public int Tel_IDTelefoneFornecedor
        {
            get { return this.tel_IDTelefoneFornecedor; }
            set { this.tel_IDTelefoneFornecedor = value; }
        }

        public String Tel_Telefone
        {
            get { return this.tel_Telefone; }
            set { this.tel_Telefone = value; }
        }

        public int Tel_IDFornecedor
        {
            get { return this.tel_IDFornecedor; }
            set { this.tel_IDFornecedor = value; }
        }
    }
}
