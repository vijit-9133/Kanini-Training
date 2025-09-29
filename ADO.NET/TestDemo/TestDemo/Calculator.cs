using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    public class Calculator
    {
        private readonly ILogger _logger;

        public Calculator(ILogger logger)
        {
            _logger = logger;
        }

        public int Add(int a, int b)
        {
            _logger.Log($"Adding {a} and {b}");
            return a + b;
        }
    }
}
