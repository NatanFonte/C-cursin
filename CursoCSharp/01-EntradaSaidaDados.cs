using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharp
{
    public static class EntradaSaidaDados
    {
        public static void LerArmazenar()
        {
            string? nome;
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine($"O nome é: {nome}");
        }
    }
}
