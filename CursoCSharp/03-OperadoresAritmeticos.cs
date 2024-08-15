using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 1.
         public static void EntradaSaida()
        {
            string? nome;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();
            string? sobrenome;
            Console.WriteLine("Digite o seu sobre nome: ");
            sobrenome = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} {sobrenome}");
        }



2.
        public static void EntradaSaida()
        {
            string? nome;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();
            int? idade;
            Console.WriteLine("Digite a sua idade: ");
            idade = Convert.ToInt32( Console.ReadLine());

            Console.WriteLine($"O nome é: {nome} {idade}");
        }

3.
        public static void EntradaSaida()
        {
            string? nome;
            string? cidade;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();
 
            Console.WriteLine("Digite a sua cidade: ");
            cidade = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} e a sua cidade é {cidade}");
        }

4.
    public static class ExerciciosTiposPrimitivos
    {
        public static void EntradaSaida()
        {
            string? nome;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine().ToUpper();

            Console.WriteLine($"seu nome é: {nome}");
        }

5.
    public static class ExerciciosTiposPrimitivos
    {
        public static void EntradaSaida()
        {
            string? nome;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine().ToLower();

            Console.WriteLine($"seu nome é: {nome}");
        }

6.
    public static class ExerciciosTiposPrimitivos
    {
        public static void EntradaSaida()
        {
            string? nome;
            int? idade;
            Console.Write("Digite o seu nome: ");
            nome = Console.ReadLine();
            Console.Write("Digite sua idade: ");
            idade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"seu nome é: {nome} e a sua idade é {idade}");
        }
    }

7.
        public static void EntradaSaida()
        {
            string? nome;
            string? cidade;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite a sua cidade de nascimento: ");
            cidade = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} e a sua cidade de nascimento é {cidade}");
        }

8.
        public static void EntradaSaida()
        {
            string? nome;
            string? prof;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite a sua profissão: ");
            prof = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} e a sua cidade de nascimento é {prof}");
        }

9.
        public static void EntradaSaida()
        {
            string? nome;
            string? prof;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite o seu país de origem: ");
            prof = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} e a seu país de origem é {prof}");
        }

10.
        public static void EntradaSaida()
        {
            string? nome;
            int? num;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite o seu número favorito: ");
            num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"O nome é: {nome} e o seu número favorito é {num}");
        }

11.
        public static void EntradaSaida()
        {
            string? nome;
            string? hob;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite o seu hobby favorito: ");
            hob = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} e o seu hobby favorito é {hob}");
        }

12.
        public static void EntradaSaida()
        {
            string? nome;
            string? hob;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite a sua cor favorita: ");
            hob = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} e a sua cor favorita é {hob}");
        }
13.
        public static void EntradaSaida()
        {
            string? nome;
            string? hob;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite o seu filme favorito: ");
            hob = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} e o seu filme favorito {hob}");
        }

14.
        public static void EntradaSaida()
        {
            string? nome;
            string? hob;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite o seu gênero musical favorito: ");
            hob = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} e o seu gênero musical favorito é {hob}");
        }
15.
        public static void EntradaSaida()
        {
            string? nome;
            string? hob;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite o seu animal favorito: ");
            hob = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} e o seu animal favorito é {hob}");
        }
16.
        public static void EntradaSaida()
        {
            string? nome;
            string? hob;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite o seu esporte favorito: ");
            hob = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} e o seu esporte favorito é {hob}");
        }
17.
        public static void EntradaSaida()
        {
            string? nome;
            string? hob;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite a sua comida favorita: ");
            hob = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} e a sua comida favorita é {hob}");
        }
18.
        public static void EntradaSaida()
        {
            string? nome;
            string? hob;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite a sua banda favorita: ");
            hob = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} e a sua banda favorita é {hob}");
        }
19.
        public static void EntradaSaida()
        {
            string? nome;
            string? hob;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite o seu livro favorito: ");
            hob = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} e o seu livro favorito é {hob}");
        }
20.
        public static void EntradaSaida()
        {
            string? nome;
            string? hob;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite um lema de vida: ");
            hob = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome} e o seu lema de vida é {hob}");
        }



 */

namespace CursoCSharp
{
    public static class _03_OperadoresAritmeticos
    {
        public static void EntradaSaida()
        {
            int horas, minutos;

            Console.WriteLine("Digite a quantidade de horas: ");
            horas = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a quantidade de minutos: ");
            minutos = Convert.ToInt32(Console.ReadLine());

            int totalMinutos = (horas * 60) + minutos;
            Console.WriteLine($"O total de {horas} horas e {minutos} minutos é: {totalMinutos} minutos.");
        }
    }
}
