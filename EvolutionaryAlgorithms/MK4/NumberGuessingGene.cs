using MK4.Evolution;

namespace MK4
{
    internal class NumberGuessingGene : IGene
    {
        public double Number { get; set; }

        public void Randomize()
        {
            Number = (new Random().NextDouble() * 50) - 25;
        }
        public static NumberGuessingGene DifferentialCrossover(NumberGuessingGene a,
                                                               NumberGuessingGene b,
                                                               NumberGuessingGene c,
                                                               double scalingFactor)
        {
            return new() { Number = a.Number + scalingFactor * (b.Number - c.Number) };
        }
        public static NumberGuessingGene JADECrossover(NumberGuessingGene parent, 
                                                       NumberGuessingGene top,
                                                       NumberGuessingGene a,
                                                       NumberGuessingGene b,
                                                       double scalingFactor)
        {
            return new()
            {
                Number = parent.Number + scalingFactor * (top.Number - parent.Number) + scalingFactor * (a.Number - b.Number)
            };
        }
        public IGene Clone()
        {
            return new NumberGuessingGene() { Number = Number };
        }
    }
}
