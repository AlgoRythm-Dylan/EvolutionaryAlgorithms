namespace MK1
{
    internal class World
    {
        public int Generation { get; set; } = 0;
        public List<Synth> Population { get; set; } = new();

        public void MaterializeInitialPopulation()
        {

        }
    }
}
