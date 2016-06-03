using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloFuncionario
    {
        private string nome;
        private string cpf;
        private string Numero_Telefone;
        private string rg;
        
        public string RG
        {
            get { return this.rg; }
            set { this.rg = value; }
        }
        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }

        }
        public string CPF
        {
            get { return this.cpf; }
            set { this.cpf = value; }
        }
        public string Telefone
        {
            get { return this.Numero_Telefone; }
            set { this.Numero_Telefone = value; }
        }
        

    }
}
