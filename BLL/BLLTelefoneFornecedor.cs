using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLTelefoneFornecedor
    {
        private DALConecxao conecxao;

        public BLLTelefoneFornecedor(DALConecxao cx)
        {
            this.conecxao = cx;
        }

        public void Incluir(ModeloTelefoneFornecedor modelo)
        {

            if (modelo.Tel_Telefone.Trim().Length == 0)
            {
                throw new Exception("O telefone do fornecedor é obrigatório");
            }
            else
            {
                if (modelo.Tel_IDFornecedor <= 0)
                {
                    throw new Exception("O identficador do fornecedor é obrigatório");
                }
            }


            //modelo.For_Nome = modelo.For_Nome.ToUpper();

            DALTelefoneFornecedor DALobj = new DALTelefoneFornecedor(conecxao);
            DALobj.Incluir(modelo);
        }

        public void Alterar(ModeloTelefoneFornecedor modelo)
        {


            if (modelo.Tel_IDTelefoneFornecedor <= 0)  //Caso o identificador do fornecedor for menor que zero
            {
                throw new Exception("O identificador do telefone do fornecedor é obrigatório");
            }
            else
            {
                if (modelo.Tel_Telefone.Trim().Length == 0)
                {
                    throw new Exception("O telefone do fornecedor é obrigatório");
                }
                else
                {
                    if (modelo.Tel_IDFornecedor <= 0)
                    {
                        throw new Exception("O identficador do fornecedor é obrigatório");
                    }
                }
            }

            //modelo.For_Nome = modelo.For_Nome.ToUpper();

            DALTelefoneFornecedor DALobj = new DALTelefoneFornecedor(conecxao);
            DALobj.Alterar(modelo);
        }


        public void Excluir(int identificador)
        {
            DALTelefoneFornecedor DALobj = new DALTelefoneFornecedor(conecxao);
            DALobj.Excluir(identificador);
        }


        public DataTable Localizar(String valor)
        {
            DALTelefoneFornecedor DALobj = new DALTelefoneFornecedor(conecxao);
            return DALobj.Localizar(valor);
        }


        public ModeloTelefoneFornecedor CarregaModeloTelefoneFornecedor(int identificador)
        {
            DALTelefoneFornecedor DALobj = new DALTelefoneFornecedor(conecxao);
            return DALobj.CarregaModeloTelefoneFornecedor(identificador);
        }
    }
}
