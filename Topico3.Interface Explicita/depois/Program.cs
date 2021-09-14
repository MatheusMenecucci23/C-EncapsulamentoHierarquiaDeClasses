using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topico3
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <image url="$(ProjectDir)\Cracha.png" />
            /// <image url="$(ProjectDir)\Cracha2.png" />
            Funcionario funcionario = new Funcionario(1500);
            funcionario.CPF = "123.456.789-00";
            funcionario.Nome = "josé da silva";
            funcionario.DataNascimento = new DateTime(2000, 1, 1);

            //convertendo explicitamente a propriedade funcionario para as interfaces
            //é necessário usar essa técnica quando tem se duas interfaces com o mesmo método, mas com implementações diferentes
            ((IFuncionario)funcionario).CargaHorariaMensal = 168;
            ((IPlantonista)funcionario).CargaHorariaMensal = 32;
            funcionario.EfeturarPagamento();
            funcionario.CrachaGerado += (s, e) =>
            {
                Console.WriteLine("Crachá gerado");
            };
            ((IFuncionario)funcionario).GerarCracha();
            ((IPlantonista)funcionario).GerarCracha();
        }
    }

    interface IFuncionario
    {
        string CPF { get; set; }
        string Nome { get; set; }
        DateTime DataNascimento { get; set; }

        event EventHandler CrachaGerado;

        void GerarCracha();

        decimal Salario { get; }
        int CargaHorariaMensal { get; set; }

        void EfeturarPagamento();
    }

    interface IPlantonista
    {
        int CargaHorariaMensal { get; set; }
        void GerarCracha();
    }

    class Funcionario : IFuncionario, IPlantonista
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public event EventHandler CrachaGerado;

        //faz-se necessário essa técnica de conversão, pois dois métodos tem o mesmo nome, porém são destinados a interfaces diferentes
        //método gerarCracha da interface Ifuncionario
        void IFuncionario.GerarCracha()
        {
            if (CrachaGerado != null)
            {
                CrachaGerado(this, new EventArgs());
            }
        }

        //método GerarCrachá da classe Iplantonista
        void IPlantonista.GerarCracha()
        {
            if (CrachaGerado != null)
            {
                CrachaGerado(this, new EventArgs());
            }
        }

        public decimal Salario { get; }

        //interface explicita
        int IFuncionario.CargaHorariaMensal { get; set; }

        //interface explicita
        int IPlantonista.CargaHorariaMensal { get; set; }

        public Funcionario(decimal salario)
        {
            Salario = salario;
        }

        public void EfeturarPagamento()
        {
            Console.WriteLine("Pagamento Efetuado");
        }
    }
}
