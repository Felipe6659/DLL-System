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
    public class DALTelefoneFornecedor
    {
        private DALConecxao conecxao;

        public DALTelefoneFornecedor(DALConecxao cx)
        {
            this.conecxao = cx;
        }

        public void Incluir(ModeloTelefoneFornecedor modelo)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conecxao.ObjetoConecxao;
                comando.CommandText = "insert into TelefoneFornecedor(Telefone, IDFornecedor) values (@telefone, @IDFornecedor); select @@IDENTITY;";
                comando.Parameters.AddWithValue("@telefone", modelo.Tel_Telefone);
                comando.Parameters.AddWithValue("@IDFornecedor", modelo.Tel_IDFornecedor);

                conecxao.Conectar();
                modelo.Tel_IDTelefoneFornecedor = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conecxao.Desconectar();
            }
            
        }

        public void Alterar(ModeloTelefoneFornecedor modelo)
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conecxao.ObjetoConecxao;
                comando.CommandText = "update TelefoneFornecedor set Telefone = @telefone, IDFornecedor = @IDFornecedor where IDTelefoneFornecedor = @identificador;";
                comando.Parameters.AddWithValue("@telefone", modelo.Tel_Telefone);
                comando.Parameters.AddWithValue("@IDFornecedor", modelo.Tel_IDFornecedor);
                comando.Parameters.AddWithValue("@identificador", modelo.Tel_IDTelefoneFornecedor);

                conecxao.Conectar();
                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conecxao.Desconectar();
            }
        }

        public void Excluir(int identificador)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conecxao.ObjetoConecxao;
                comando.CommandText = "delete from TelefoneFornecedor where IDTelefoneFornecedor = @identificador;";
                comando.Parameters.AddWithValue("@identificador", identificador);

                conecxao.Conectar();
                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conecxao.Desconectar();
            }
        }

        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TelefoneFornecedor where IDTelefoneFornecedor like '%" +
                valor + "%'", conecxao.StringConnecxao);
            da.Fill(tabela);
            return tabela;
        }
        
        public ModeloTelefoneFornecedor CarregaModeloTelefoneFornecedor(int identificador)
        {
            ModeloTelefoneFornecedor modelo = new ModeloTelefoneFornecedor();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conecxao.ObjetoConecxao;
            comando.CommandText = "select * from TelefoneFornecedor where IDTelefoneFornecedor = @identificador;";
            comando.Parameters.AddWithValue("@identificador", identificador);

            conecxao.Conectar();
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.Tel_IDTelefoneFornecedor = Convert.ToInt32(registro["IDTelefoneFornecedor"]);
                modelo.Tel_Telefone = Convert.ToString(registro["Telefone"]);
                modelo.Tel_IDFornecedor = Convert.ToInt32(registro["IDFornecedor"]);

            }
            conecxao.Desconectar();
            return modelo;
        }
    }
}
