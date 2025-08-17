namespace SimLib
{
    public class NumericalGene : IGene
    {
        private double Backend = 0;
        public double MininumValue { get; set; } = 0;
        public double MaxinumValue { get; set; } = 1;
        public double Number
        {
            get
            {
                return Backend;
            }
            set
            {
                Backend = Math.Min(Math.Max(value, MininumValue), MaxinumValue);
            }
        }

        public IGene Clone()
        {
            return new NumericalGene()
            {
                MininumValue = MininumValue,
                MaxinumValue = MaxinumValue,
                Number = Number
            };
        }

        public void Randomize()
        {
            double difference = MaxinumValue - MininumValue;
            Number = MininumValue + (difference * new Random().NextDouble());
        }
    }
}
