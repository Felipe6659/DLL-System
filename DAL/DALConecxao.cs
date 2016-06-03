using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALConecxao
    {
        private String _stringConecxao;
        private SqlConnection _conecxao;

        public DALConecxao(String dadosConecxao)
        {
            this._conecxao = new SqlConnection();
            this._stringConecxao = dadosConecxao;
            this._conecxao.ConnectionString = dadosConecxao;
        }

        public String  StringConnecxao
        {
            get { return this._stringConecxao; }
            set { this._stringConecxao = value; }
        }

        public SqlConnection ObjetoConecxao
        {
            get { return this._conecxao; }
            set { this._conecxao = value; }
        }

        public void Conectar()
        {
            this._conecxao.Open();
        }

        public void Desconectar()
        {
            this._conecxao.Close();
        }
    }
}
