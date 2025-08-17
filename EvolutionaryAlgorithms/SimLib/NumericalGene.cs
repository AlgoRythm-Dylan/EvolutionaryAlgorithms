namespace SimLib
{
    public class NumericalGene : IGene
    {
        private double Backend = 0;
        public double MininumValue { get; set; } = 0;
        public double MaximumValue { get; set; } = 1;
        public double Number
        {
            get
            {
                return Backend;
            }
            set
            {
                Backend = Math.Min(Math.Max(value, MininumValue), MaximumValue);
            }
        }

        public IGene Clone()
        {
            return new NumericalGene()
            {
                MininumValue = MininumValue,
                MaximumValue = MaximumValue,
                Number = Number
            };
        }

        public void Randomize(Random RNG)
        {
            double difference = MaximumValue - MininumValue;
            Number = MininumValue + (difference * RNG.NextDouble());
        }

        public static NumericalGene DifferentialCrossover(NumericalGene a,
                                                          NumericalGene b,
                                                          NumericalGene c,
                                                          double scalingFactor)
        {
            var clone = (NumericalGene)a.Clone();
            clone.Number = a.Number + scalingFactor * (b.Number - c.Number);
            return clone;
        }
        public static NumericalGene JADECrossover(NumericalGene parent,
                                                  NumericalGene top,
                                                  NumericalGene a,
                                                  NumericalGene b,
                                                  double scalingFactor)
        {
            var clone = (NumericalGene)parent.Clone();
            clone.Number = parent.Number + scalingFactor * (top.Number - parent.Number) + scalingFactor * (a.Number - b.Number);
            return clone;
        }
    }
}
