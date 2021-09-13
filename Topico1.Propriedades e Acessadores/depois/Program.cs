using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topico1
{
    class Program
    {
        static void Main(string[] args)
        {
            Funcionario funcionario = new Funcionario(1000);
            //funcionario.salario = 1000;
            //Console.WriteLine(funcionario.salario);

            //funcionario.salario = -1200;
            //Console.WriteLine(funcionario.salario);

            //funcionario.Salario = -1200;
            //funcionario.Salario = 1200;
            Console.WriteLine(funcionario.Salario);
            //funcionario.Salario = 2000;
            //funcionario.Salario = 800;
        }
    }

    class Funcionario
    {
        //constructor para a classe Funcionário conseguir receber parametros diretamente
        public Funcionario(decimal salario)
        {
            //regra de validação do salário
            if (salario < 0)
            {
                throw new ArgumentOutOfRangeException("salário não pode ser negativo");
            }
            this.salario = salario;
        }




        //sem o public ninguém consegue alterar a variável salário
        decimal salario;

        //3 maneiras de fazer o encapsulamento do campo salario
        public decimal Salario 
        {
            //acessador get, permite ler o valor da variável salário
            get
            {
                return salario;
            }
            //acessador set, permite gravar/atribuir um novo valor para a propriedade salário
            //set
            //{
            //    se o salário for negativo não gravar  
            //    if (value < 0)
            //    {
            //        Lançando uma excessão de argumento fora da faixa aceitável
            //        throw new ArgumentOutOfRangeException("salário não pode ser negativo");
            //    }
            //    gravando um novo valor
            //    salario = value;
            //}
        }

        //propfull + tab + tab
        //campo privado
        //private decimal salario;
        //propriedade publica
        //public decimal Salario
        //{
        //    get { return salario; }
        //    set { salario = value; }
        //}

        //propriedade autoimplementada
        //public decimal Salario { get; set; }
    }

    public class Banco
    {
        public Banco()
        {
            Conta conta = new Conta();
            conta.Saldo = 1000;
            Console.WriteLine(conta.Saldo);
        }
    }

    public class Conta
    {
        //constructor
        public Conta()
        {
            this.Saldo = 1000;
            Console.WriteLine(this.Saldo);
        }
        //método sacar
        void Sacar(decimal saque)
        {
            Saldo = Saldo - saque;
        }

        public decimal Saldo { get; set; }
    }

    public class ContaCorrente : Conta
    {
        public ContaCorrente()
        {
            this.Saldo = 1000;
            Console.WriteLine(this.Saldo);
        }
    }
}
