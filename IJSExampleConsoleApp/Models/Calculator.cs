using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

namespace IJSExampleConsoleApp.Models
{
    public class Calculator
    {
        public static int GCD(params int[] numbers) {
            if (numbers.Count() == 0) return 0;
            if (numbers.Count() == 1) return numbers.First();

            return numbers.Aggregate(GCD);
        }

        public static int GCD(int a, int b) {

            var rest = b == 0 ? 0 : (a % b);
            var divided = b == 0 ? 0 : a / b;
            ConsoleEx.WriteLine($"{b == 0} || {a}, {b} --> {rest} ({divided}x)");

            return b == 0 ? a : GCD(b, a % b);
        }

        public static double Calculate(string input, bool calcparenthesis = true) {
            var sum = input.Replace(" ", "").Trim();

            if (calcparenthesis) {
                sum = CalcParenthesis(sum);
            }

            sum = CalcModuloAndPowerSegments(sum, !calcparenthesis);
            sum = CalcMulitplyAndDivideSegments(sum, !calcparenthesis);
            sum = CalcAddAndSubtractSegments(sum, !calcparenthesis);

            var returnVal = double.Parse(sum);
            return returnVal;
        }


        private static string CalcParenthesis(string input) {
            var regex = @"[(]([\-]{0,1}\d{1,}([.,][\d]{1,}){0,1}[\-*+/\^%][\-]{0,1}([\d]([.,][\d]){0,1}){0,}){1,}[)]";
            var segment = Regex.Match(input, regex);

            while (segment.Success) {
                var inp = segment.ToString();

                var inpCleaned = Regex.Replace(inp, @"[()]", "");
                var res = Calculate(inpCleaned, false);

                var splitVal = inp.ToCharArray().Select(s => "[" + new string(s,1) + "]").Aggregate((a, b) => a + b);

                var tempvals = Regex.Split(input, splitVal).ToList();
                input = input.Replace(inp, res.ToString());

                ConsoleEx.WriteLineStarter();
                for (var i = 0; i < (tempvals.Count -1); i++) {
                    ConsoleEx.Write(tempvals[i]);
                    ConsoleEx.Write($"{res}", ConsoleColor.Green);
                }
                ConsoleEx.Write(tempvals.LastOrDefault());

                ConsoleEx.WriteEmptyLine();

                segment = Regex.Match(input, regex);
            }
            
            return input;
        }

        private static string CalcModuloAndPowerSegments(string input, bool isSubCalc = false) {
            var regex = @"[\-]{0,1}[\d]{1,}([.,][\d]{1,}){0,1}[%\^][\-]{0,1}[\d]{1,}([.,][\d]{1,}){0,1}";
            var segment = Regex.Match(input, regex);

            while (segment.Success) {
                var inp = segment.ToString();

                if (inp.StartsWith("-")) {
                    var rg = $@"{inp}";
                    rg = rg.Replace("/", "[/]");
                    rg = rg.Replace("*", "[*]");
                    rg = rg.Replace("+", "[+]");
                    rg = rg.Replace("-", "[-]");
                    rg = rg.Replace("^", @"[\^]");
                    rg = rg.Replace("%", "[%]");
                    rg = $"[0-9]{rg}";
                    //[0-9]
                    var match = Regex.Match(input, rg);
                    if (match.Success) {
                        inp = inp.Remove(0, 1);
                    }
                }

                var res = CalcSegment(inp);

                var splitVal = inp.ToCharArray().Select(s => "[" + new string(s, 1) + "]").Aggregate((a, b) => a + b);
                splitVal = splitVal.Replace("^", @"\^");
                var tempvals = Regex.Split(input, splitVal).ToList();

                input = input.Replace(inp, $"{res}");

                var spacer = isSubCalc ? $"--> {inp} = " : "";

                ConsoleEx.WriteLineStarter();
                ConsoleEx.Write(spacer);
                for (var i = 0; i < (tempvals.Count - 1); i++) {
                    ConsoleEx.Write(tempvals[i]);
                    ConsoleEx.Write($"{res}", ConsoleColor.Green);
                }
                ConsoleEx.Write(tempvals.LastOrDefault());
                ConsoleEx.WriteEmptyLine();

                //ConsoleEx.WriteLine($"{spacer}{input}");

                segment = Regex.Match(input, regex);
            }

            return input;
        }

        private static string CalcMulitplyAndDivideSegments(string input, bool isSubCalc = false) {
            var regex = @"[\-]{0,1}[\d]{1,}([.,][\d]{1,}){0,1}[*/][\-]{0,1}[\d]{1,}([.,][\d]{1,}){0,1}";
            var segment = Regex.Match(input, regex);

            while (segment.Success) { 
                var inp = segment.ToString();

                if (inp.StartsWith("-")) {
                    var rg = $@"{inp}";
                    rg = rg.Replace("/", "[/]");
                    rg = rg.Replace("*", "[*]");
                    rg = rg.Replace("+", "[+]");
                    rg = rg.Replace("-", "[-]");
                    rg = rg.Replace("^", @"[\^]");
                    rg = rg.Replace("%", "[%]");
                    rg = $"[0-9]{rg}";
                    //[0-9]
                    var match = Regex.Match(input, rg);
                    if (match.Success) {
                        inp = inp.Remove(0, 1);
                    }
                }

                var res = CalcSegment(inp);

                var splitVal = inp.ToCharArray().Select(s => "[" + new string(s, 1) + "]").Aggregate((a, b) => a + b);
                var tempvals = Regex.Split(input, splitVal).ToList();

                input = input.Replace(inp, $"{res}");

                var spacer = isSubCalc ? $"--> {inp} = " : "";

                ConsoleEx.WriteLineStarter();
                ConsoleEx.Write(spacer);
                for (var i = 0; i < (tempvals.Count - 1); i++) {
                    ConsoleEx.Write(tempvals[i]);
                    ConsoleEx.Write($"{res}", ConsoleColor.Green);
                }
                ConsoleEx.Write(tempvals.LastOrDefault());
                ConsoleEx.WriteEmptyLine();

                //ConsoleEx.WriteLine($"{spacer}{input}");

                segment = Regex.Match(input, regex);
            }

            return input;
        }

        private static string CalcAddAndSubtractSegments(string input, bool isSubCalc = false) {
            var regex = @"[\-]{0,1}[\d]{1,}([.,][\d]{1,}){0,1}[\-+][\-]{0,1}[\d]{1,}([.,][\d]{1,}){0,1}";
            var segment = Regex.Match(input, regex);

            while (segment.Success) {
                var inp = segment.ToString();

                if (inp.StartsWith("-")) {
                    var rg = $@"{inp}";
                    rg = rg.Replace("/", "[/]");
                    rg = rg.Replace("*", "[*]");
                    rg = rg.Replace("+", "[+]");
                    rg = rg.Replace("-", "[-]");
                    rg = rg.Replace("^", @"[\^]");
                    rg = rg.Replace("%", "[%]");
                    rg = $"[0-9]{rg}";
                    //[0-9]
                    var match = Regex.Match(input, rg);
                    if (match.Success) {
                        inp = inp.Remove(0, 1);
                    }
                }

                var res = CalcSegment(inp);

                var splitVal = inp.ToCharArray().Select(s => "[" + new string(s, 1) + "]").Aggregate((a, b) => a + b);
                var tempvals = Regex.Split(input, splitVal).ToList();

                input = input.Replace(inp, $"{res}");

                var spacer = isSubCalc ? $"--> {inp} = " : "";

                ConsoleEx.WriteLineStarter();
                ConsoleEx.Write(spacer);
                for (var i = 0; i < (tempvals.Count - 1); i++) {
                    ConsoleEx.Write(tempvals[i]);
                    ConsoleEx.Write($"{res}", ConsoleColor.Green);
                }
                ConsoleEx.Write(tempvals.LastOrDefault());
                ConsoleEx.WriteEmptyLine();

                //ConsoleEx.WriteLine($"{spacer}{input}");

                segment = Regex.Match(input, regex);
            }

            return input;
        }

        private static double CalcSegment(string input) {
            var res = 0.0;
            //var op = Regex.Match(input, @"[/*\-+]").ToString();
            var op = GetOperator(input);

            switch (op) {
                case "+":
                    res = Add(input);
                    break;
                case "-":
                    res = Subtract(input);
                    break;
                case "*":
                    res = Multiply(input);
                    break;
                case "/":
                    res = Divide(input);
                    break;
                case "%":
                    res = Modulo(input);
                    break;
                case "^":
                    res = Power(input);
                    break;
                default:
                    ConsoleEx.WriteLine($"Operator not found ('{op}')", ConsoleColor.Red);
                    break;
            }

            res = Math.Round(res, 5);

            return res;
        }

        private static string _reg = @"[\-]{0,1}[\d]{1,}([.,][\d]{1,}){0,1}";
        private static double Add(string input) {
            var newInput = Regex.Replace(input, _reg, "");
            var matches = Regex.Matches(input, _reg);

            var matchStrings = matches.Cast<Match>().Select(m => m.Value).ToArray();

            var val1 = double.Parse(matchStrings.First(), CultureInfo.InvariantCulture);
            var val2 = double.Parse(matchStrings.Last(), CultureInfo.InvariantCulture);
            if (newInput == "") {
                var lastVal = matchStrings.Last().Replace("-", "");
                val2 = double.Parse(lastVal, CultureInfo.InvariantCulture);
            }

            return val1 + val2;
        }

        private static double Subtract(string input) {
            var newInput = Regex.Replace(input, _reg, "");
            var matches = Regex.Matches(input, _reg);

            var matchStrings = matches.Cast<Match>().Select(m => m.Value).ToArray();

            var val1 = double.Parse(matchStrings.First(), CultureInfo.InvariantCulture);
            var val2 = double.Parse(matchStrings.Last(), CultureInfo.InvariantCulture);
            if (newInput == "") {
                var lastVal = matchStrings.Last().Replace("-", "");
                val2 = double.Parse(lastVal, CultureInfo.InvariantCulture);
            }

            return val1 - val2;
        }

        private static double Multiply(string input) {
            var newInput = Regex.Replace(input, _reg, "");
            var matches = Regex.Matches(input, _reg);

            var matchStrings = matches.Cast<Match>().Select(m => m.Value).ToArray();

            var val1 = double.Parse(matchStrings.First(), CultureInfo.InvariantCulture);
            var val2 = double.Parse(matchStrings.Last(), CultureInfo.InvariantCulture);
            if (newInput == "") {
                var lastVal = matchStrings.Last().Replace("-", "");
                val2 = double.Parse(lastVal, CultureInfo.InvariantCulture);
            }


            return val1 * val2;
        }

        private static double Divide(string input) {
            var newInput = Regex.Replace(input, _reg, "");
            var matches = Regex.Matches(input, _reg);

            var matchStrings = matches.Cast<Match>().Select(m => m.Value).ToArray();

            var val1 = double.Parse(matchStrings.First(), CultureInfo.InvariantCulture);
            var val2 = double.Parse(matchStrings.Last(), CultureInfo.InvariantCulture);
            if (newInput == "") {
                var lastVal = matchStrings.Last().Replace("-", "");
                val2 = double.Parse(lastVal, CultureInfo.InvariantCulture);
            }

            return val1 / val2;
        }

        private static double Modulo(string input) {
            var newInput = Regex.Replace(input, _reg, "");
            var matches = Regex.Matches(input, _reg);

            var matchStrings = matches.Cast<Match>().Select(m => m.Value).ToArray();

            var val1 = double.Parse(matchStrings.First(), CultureInfo.InvariantCulture);
            var val2 = double.Parse(matchStrings.Last(), CultureInfo.InvariantCulture);
            if (newInput == "") {
                var lastVal = matchStrings.Last().Replace("-", "");
                val2 = double.Parse(lastVal, CultureInfo.InvariantCulture);
            }

            return val1 % val2;
        }

        private static double Power(string input) {
            var newInput = Regex.Replace(input, _reg, "");
            var matches = Regex.Matches(input, _reg);

            var matchStrings = matches.Cast<Match>().Select(m => m.Value).ToArray();

            var val1 = double.Parse(matchStrings.First(), CultureInfo.InvariantCulture);
            var val2 = double.Parse(matchStrings.Last(), CultureInfo.InvariantCulture);
            if (newInput == "") {
                var lastVal = matchStrings.Last().Replace("-", "");
                val2 = double.Parse(lastVal, CultureInfo.InvariantCulture);
            }

            return Math.Pow(val1, val2);
        }

        private static string GetOperator(string input) {
            var operators = Regex.Replace(input, @"[\-]{0,1}[\d]{1,}([.,][\d]{1,}){0,1}", "");
            if (operators == "") return "-";
            return operators;
        }
    }
}
