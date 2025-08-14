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
    }
}
