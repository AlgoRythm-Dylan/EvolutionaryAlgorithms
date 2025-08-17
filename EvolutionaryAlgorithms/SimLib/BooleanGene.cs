namespace SimLib
{
    public class BooleanGene : IGene
    {
        private NumericalGene Backend { get; set; } = new();

        public IGene Clone()
        {
            return new BooleanGene()
            {
                Backend = (NumericalGene)Backend.Clone()
            };
        }

        public void Randomize(Random RNG)
        {
            Backend.Randomize(RNG);
        }

        public bool GetValue()
        {
            return Backend.Number > 0.5;
        }

        public double GetWeight()
        {
            return Backend.Number;
        }

        public void SetWeight(double value)
        {
            Backend.Number = value;
        }
    }
}
