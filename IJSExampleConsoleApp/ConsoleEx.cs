using System;
using System.Collections.Generic;
using System.Text;

namespace IJSExampleConsoleApp
{
    public static class ConsoleEx
    {
        public static void WriteLine(string value) => WriteLine(value, ConsoleColor.Gray);
        public static void WriteLine(object value) => WriteLine(value.ToString());
        public static void WriteLine(string value, ConsoleColor color) {
            Console.ForegroundColor = color;
            var printValue = value;
            var maxlenght = Console.BufferWidth - 3;

            var divideresult = (double)value.Length / maxlenght;
            var rowCount = Math.Ceiling(divideresult);

            for (var i = 0; i < rowCount; i++) {
                var substringLenght = printValue.Length > maxlenght ? maxlenght : printValue.Length;

                var line = printValue.Substring(0, substringLenght);

                printValue = printValue.Remove(0, substringLenght);
                Console.WriteLine($"| {line}");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        public static string ReadLine(string value) => Console.ReadLine();

        public static void WriteSeperatorLine() => Console.WriteLine(CreateSeperator());

        public static void WriteEmptyLine() => Console.WriteLine();

        public static void Write(string value, ConsoleColor color = ConsoleColor.Gray) {
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static string CreateSeperator() {
            var seperator = "|";
            for (var i = 0; i < (Console.BufferWidth - 3); i++) {
                seperator += "=";
            }
            seperator += "|";

            return seperator;
        }

        internal static void WriteLineStarter() => Console.Write("| ");
    }
}
