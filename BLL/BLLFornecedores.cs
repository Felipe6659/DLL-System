using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLFornecedores
    {
        private DALConecxao conecxao;

        public BLLFornecedores(DALConecxao cx)
        {
            this.conecxao = cx;
        }

        public void Incluir(ModeloFornecedores modelo)
        {

            if (modelo.For_Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do fornecedor é obrigatório");
            }
            else
            {
                if (modelo.For_Descricao.Trim().Length == 0)
                {
                    throw new Exception("A descrição do fornecedor é obrigatório");
                }
                else
                {
                    if (modelo.For_Endereco.Trim().Length == 0)
                    {
                        throw new Exception("O Endereço do fornecedor é obrigatório");
                    }
                }
            }
            
            
            //modelo.For_Nome = modelo.For_Nome.ToUpper();

            DALFornecedores DALobj = new DALFornecedores(conecxao);
            DALobj.Incluir(modelo);
        }

        public void Alterar(ModeloFornecedores modelo)
        {
           

            if (modelo.For_IDFornecedor <= 0)  //Caso o identificador do fornecedor for menor que zero
            {
                throw new Exception("O identificador do fornecedor é obrigatório");
            }
            else
            {
                if (modelo.For_Nome.Trim().Length == 0)
                {
                    throw new Exception("O nome do fornecedor é obrigatório");
                }
                else
                {
                    if (modelo.For_Descricao.Trim().Length == 0)
                    {
                        throw new Exception("A descrição do fornecedor é obrigatório");
                    }
                    else
                    {
                        if (modelo.For_Endereco.Trim().Length == 0)
                        {
                            throw new Exception("O Endereço do fornecedor é obrigatório");
                        }
                    }
                }
            }

            //modelo.For_Nome = modelo.For_Nome.ToUpper();

            DALFornecedores DALobj = new DALFornecedores(conecxao);
            DALobj.Alterar(modelo);
        }


        public void Excluir(int identificador)
        {
            DALFornecedores DALobj = new DALFornecedores(conecxao);
            DALobj.Excluir(identificador);
        }


        public DataTable Localizar(String valor)
        {
            DALFornecedores DALobj = new DALFornecedores(conecxao);
            return DALobj.Localizar(valor);
        }


        public ModeloFornecedores CarregaModeloFornecedores(int identificador)
        {
            DALFornecedores DALobj = new DALFornecedores(conecxao);
            return DALobj.CarregaModeloFornecedores(identificador);
        }

    }
}
