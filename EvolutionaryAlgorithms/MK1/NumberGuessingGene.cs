using System.Security.Cryptography;

namespace MK1
{
    internal class NumberGuessingGene : IGene
    {
        public double Number { get; set; } = 0;
        public void Mutate()
        {
            Number = new Random().NextDouble() * 2;
        }
        public string GetValueString()
        {
            return Math.Round(Number, 3).ToString();
        }
    }
}
