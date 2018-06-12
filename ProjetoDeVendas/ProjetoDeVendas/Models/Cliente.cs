using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeVendas.Models
{
    class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }


        public override string ToString()
        {
            return "\nNome: " + Nome + "\nCPF: " + Cpf;
        }

        //MODO JAVA
        //private string nome;
        //private string cpf;
        //public string getNome()
        //{
        //    return this.nome;
        //}

        //public void setNome(string nome)
        //{
        //    this.nome = nome;
        //}
    }


}
