using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharp
{
    public static class TiposPrimitivos
    {
        public static void ImprimirTipos()
        {
            sbyte SByte = -128; // Valores variam de -128 a 127
            Console.WriteLine($"sbyte: {SByte}");

            byte variavelByte = 255; // Valores variam de 0 a 255
            Console.WriteLine($"byte: {variavelByte}");

            short variavelShort = -32768; // Valores variam de -32768 a 3767
            Console.WriteLine($"short: {variavelShort}");

            ushort variavelUShort = 65535; // Valores variam de 0 a 6535
            Console.WriteLine($"ushort: {variavelUShort}");

            int variavelInt = -2147483648; // Valores variam de -2147483648 a 2147483647
            Console.WriteLine($"int: {variavelInt}");

            uint variavelUInt = 4294967295; // Valores variam de 0 a 4294967295
            Console.WriteLine($"uint: {variavelUInt}");

            long variavelLong = -9223372036854775808; // Valores variam de -9223372036854775808 a 4294967295
            Console.WriteLine($"long: {variavelLong}");

            ulong variavelULong = 18446744073709551615; // Valores variam de 0 a 18446744073709551615
            Console.WriteLine($"ulong: {variavelULong}");

            float variavelFloat = 3.14f ; 
            Console.WriteLine($"float: {variavelFloat}");

            double variavelDouble = 3.141592653589793;
            Console.WriteLine($"double: {variavelDouble}");

            decimal variavelDecimal = 79228162514264337593543950335M;
            Console.WriteLine($"decimal: {variavelDecimal}");

            char variavelChar = 'A';
            Console.WriteLine($"char: {variavelChar}");

            bool variavelBool = true;
            Console.WriteLine($"bool: {variavelBool}");

            object variavelObject = null;
            Console.WriteLine($"object: {variavelObject}");

            string variavelString = "Olá, Mundo!";
            Console.WriteLine($"string: {variavelString}");

        }
    }
}
