using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALFornecedores
    {
        private DALConecxao conecxao;

        public DALFornecedores (DALConecxao cx)
        {
            this.conecxao = cx;
        }

        public void Incluir(ModeloFornecedores modelo)
        {
            

            SqlCommand comando = new SqlCommand();
            comando.Connection = conecxao.ObjetoConecxao;
            comando.CommandText = "insert into Fornecedores(Nome, Descricao, Endereco) values (@nome, @descricao, @endereco); select @@IDENTITY;";
            comando.Parameters.AddWithValue("@nome", modelo.For_Nome);
            comando.Parameters.AddWithValue("@descricao", modelo.For_Descricao);
            comando.Parameters.AddWithValue("@endereco", modelo.For_Endereco);

            conecxao.Conectar();
            modelo.For_IDFornecedor = Convert.ToInt32(comando.ExecuteScalar());
            conecxao.Desconectar();
        }

        public void Alterar(ModeloFornecedores modelo)
        {

            SqlCommand comando = new SqlCommand();
            comando.Connection = conecxao.ObjetoConecxao;
            comando.CommandText = "update dbo.Fornecedores set Nome = @nome, Descricao = @descricao, Endereco = @endereco where IDFornecedor = @identificador;";
            comando.Parameters.AddWithValue("@nome", modelo.For_Nome);
            comando.Parameters.AddWithValue("@descricao", modelo.For_Descricao);
            comando.Parameters.AddWithValue("@endereco", modelo.For_Endereco);
            comando.Parameters.AddWithValue("@identificador", modelo.For_IDFornecedor);

            

            conecxao.Conectar();
            comando.ExecuteNonQuery();
            conecxao.Desconectar();
        }

        public void Excluir(int identificador)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conecxao.ObjetoConecxao;
            comando.CommandText = "delete from dbo.Fornecedores where IDFornecedor = @identificador;";
            comando.Parameters.AddWithValue("@identificador", identificador);

           

            conecxao.Conectar();
            comando.ExecuteNonQuery();
            conecxao.Desconectar();
        }

        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Fornecedores where Nome like '%" + 
                valor + "%'", conecxao.StringConnecxao);
            da.Fill(tabela);
            return tabela;
        }

        public ModeloFornecedores CarregaModeloFornecedores(int identificador)
        {
            ModeloFornecedores modelo = new ModeloFornecedores();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conecxao.ObjetoConecxao;
            comando.CommandText = "select * from Fornecedores where IDFornecedor = @identificador;";
            comando.Parameters.AddWithValue("@identificador", identificador);

            conecxao.Conectar();
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.For_IDFornecedor = Convert.ToInt32(registro["IDFornecedor"]);
                modelo.For_Nome = Convert.ToString(registro["Nome"]);
                modelo.For_Descricao = Convert.ToString(registro["Descricao"]);
                modelo.For_Endereco = Convert.ToString(registro["Endereco"]);

            }
            conecxao.Desconectar();
            return modelo;
        }

    }
}
