using MK3.Evolution;

namespace MK3
{
    internal class NumberGuessingGene : IGene
    {
        public double Number { get; set; }

        public void Randomize()
        {
            Number = (new Random().NextDouble() * 10) - 5;
        }
        public static NumberGuessingGene DifferentialCrossover(NumberGuessingGene a,
                                                               NumberGuessingGene b,
                                                               NumberGuessingGene c,
                                                               double scalingFactor)
        {
            return new() { Number = a.Number + scalingFactor * (b.Number - c.Number) };
        }
        public IGene Clone()
        {
            return new NumberGuessingGene() { Number = Number };
        }
    }
}
