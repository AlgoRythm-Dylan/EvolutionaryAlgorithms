namespace MK2
{
    internal class NumberGuessingGene : Gene
    {
        public double Number { get; set; }

        public override void Randomize()
        {
            Number = (new Random().NextDouble() * 200_000) - 100_000;
        }
        public override Gene Clone()
        {
            var clone = new NumberGuessingGene();
            clone.Number = Number;
            return clone;
        }
        public override void Mutate(MutationConfiguration config)
        {
            var rand = new Random();
            if(rand.NextDouble() >= config.MutationRate)
            {
                double mutationValue = (rand.NextDouble() - 0.5) * config.MutationStrength;
                Number += Number * mutationValue;
            }
        }
    }
}
