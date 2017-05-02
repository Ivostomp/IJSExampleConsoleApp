using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IJSExampleConsoleApp.Models
{
    public class PrimeNumber {
        private int _value;

        public int Value => _value;

        public string[] Options { get; set; }

        public PrimeNumber(int value) {
            _value = value;
        }

        public bool IsPrimenumber {
            get {
                var options = new List<double>();
                for (int i = _value; i > 0; i--) {
                    var divideResult = (double)_value / i;

                    if (divideResult % 1 == 0) {
                        options.Add(divideResult);
                    }
                }

                Options = options.Select(s => s.ToString()).ToArray();

                return (options.Count <= 2);
            }
        }
    }
}
