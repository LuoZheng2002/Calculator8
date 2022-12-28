using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator8
{
    internal class Model
    {
        public int Adder1 { get; set; }
        public int Adder2 { get; set; }
        public int Sum { get; set; }
        public event Action SumChanged;
        public void Add()
        {
            Sum = Adder1 + Adder2;
            Console.WriteLine("Added!");
            SumChanged?.Invoke();
        }
    }
}
