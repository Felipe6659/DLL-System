using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class ModeloClientes
    {
        private int codigo;
        private string nome;
        private string cpfourg;
        private int telefone;
        private string cep;
        private string bairro;
        private string municipio;
        private string rua;
        private int numero;
        private string email;

        public ModeloClientes()
        {
            this.codigo = 0;
            this.nome = "";
            this.cpfourg = "";
            this.telefone = 0;
            this.cep = "";
            this.bairro = "";
            this.municipio = "";
            this.rua = "";
            this.numero = 0;
            this.email = "";


        }

        public ModeloClientes(int identificador, String nomeCliente, String cpfourgCliente,
                              int telefoneCliente, String cepCliente, String BairroCliente, String municipioCliente,
                              String ruaCliente, int numeroCliente, String emailCliente)
        {
            this.codigo = identificador;
            this.nome = nomeCliente;
            this.cpfourg = cpfourgCliente;
            this.telefone = telefoneCliente;
            this.cep = cepCliente;
            this.bairro = BairroCliente;
            this.municipio = municipioCliente;
            this.rua = ruaCliente;
            this.numero = numeroCliente;
            this.email = emailCliente;


        }





        private string nomeCliente;
        public string Nome
        {
            get { return this.nomeCliente; }
            set { this.nomeCliente = value; }

        }

        private string cpfourgCliente;
        public string RGCPF
        {
            get { return this.cpfourgCliente; }
            set { this.cpfourgCliente = value; }
        }

        private string cepCliente;
        public string CEP
        {
            get { return this.cepCliente; }
            set { this.cepCliente = value; }
        }

        private string BairroCliente;
        public string Bairro
        {
            get { return this.BairroCliente; }
            set { this.BairroCliente = value; }
        }

        private string municipioCliente;
        public string Municipio
        {
            get { return this.municipioCliente; }
            set { this.municipioCliente = value; }

        }

        private string ruaCliente;
        public string Rua
        {
            get { return this.ruaCliente; }
            set { this.ruaCliente = value; }

        }

        private string numeroCliente;
        public string Numero
         {
            get { return this.numeroCliente; }
            set { this.numeroCliente = value; }

         }

        private string telefoneCliente;
        public string Telefone
        {
            get { return this.telefoneCliente; }
            set { this.telefoneCliente = value; }
        }




    }
        }
