namespace MK2
{
    internal class NumberGuessingGene : Gene
    {
        public double Number { get; set; }

        public override void Randomize()
        {
            Number = (new Random().NextDouble() * 2000) - 1000;
        }
    }
}
