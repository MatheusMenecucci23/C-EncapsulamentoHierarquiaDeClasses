using System;
using System.Collections.Generic;

namespace Topico5
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno aluno1 = new Aluno
            {
                Nome = "José da Silva",
                DataNascimento = new DateTime(1990, 1, 1)
            };

            Aluno aluno2 = new Aluno
            {
                Nome = "José da Silva",
                DataNascimento = new DateTime(1995, 1, 1)
            };

            Aluno aluno3 = new Aluno
            {
                Nome = "josé da silva",
                DataNascimento = new DateTime(1990, 1, 1)
            };



            //comparando o aluno 1 com o aluno 2
            Console.WriteLine(aluno1.Equals(aluno2));
            //comparando o aluno1 com o aluno3
            Console.WriteLine(aluno1.Equals(aluno3));



            Aluno aluno4 = new Aluno
            {
                Nome = "ANDRÉ DOS SANTOS",
                DataNascimento = new DateTime(1970, 1, 1)
            };

            Aluno aluno5 = new Aluno
            {
                Nome = "Ana de Souza",
                DataNascimento = new DateTime(1990, 1, 1)
            };


            //criando uma lista com os alunos já criados
            List<Aluno> alunos = new List<Aluno>
            {
                aluno1,
                aluno2,
                aluno3,
                aluno4,
                aluno5
            };

            //
            alunos.Sort();


            //imprimindo no console os alunos
            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }
        }
    }

    class Aluno : IComparable
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}, Data nascimento: {DataNascimento:dd/MM/yyyy}";
        }

        //subrescrevendo o framework equals com o override
        public override bool Equals(object obj)
        {
            Aluno outro = obj as Aluno;
            //veficando se o parametro passado é nulo
            if (outro == null)
            {
                return false;
            }
            //retorna se tudo isso for verdadeiro
            //StringComparison.CurrentCultureIgnoreCase faz com que o método ignore o maiúsculo e minúsculo 
            //comparando o nome e data de nascimento
            return this.Nome.Equals(outro.Nome, StringComparison.CurrentCultureIgnoreCase)
                && this.DataNascimento.Equals(outro.DataNascimento);
        }

        //essa classe vem para não cairmos o desempenho
        public override int GetHashCode()
        {
            var hashCode = -1523756618;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + DataNascimento.GetHashCode();
            return hashCode;
        }


        //esse método faz parte da interface IComparable
        public int CompareTo(object obj)
        {
            //se o método retornar 0 => objetos são iguais
            //se o método retornar > 0 => objeto atual vem depois
            //se o método retornar < 0 => objeto atual vem antes

            if (obj == null)
            {
                return 1;
            }

            Aluno outro = obj as Aluno;
            //se o o parametro recebido não for convertido para o tipo Aluno, então lance um erro
            if (outro == null)
            {
                //lançando uma exceção 
                throw new ArgumentException("Objeto não é um Aluno");
            }

            //após comparar a data de nascimento, o retorno é jogado na variável resultado
            int resultado = this.DataNascimento.CompareTo(outro.DataNascimento);
            //se o resultado for 0, quer dizer que as datas de nascimentos são iguais, assim precisaremos comparar outra propriedade
            if (resultado == 0)
            {
                //comparando a propriedade nome dos alunos e armazenando a variável dentro da variável resultado
                resultado = this.Nome.CompareTo(outro.Nome);
            }
            return resultado;
        }
    }
}