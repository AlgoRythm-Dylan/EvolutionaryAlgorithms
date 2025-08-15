namespace MK3
{
    internal class World<TSynth>
        where TSynth : class, ISynth, new()
    {
        public List<TSynth> Population { get; set; } = new();
        public DifferentialEvolutionParams DEParams { get; set; } = new();
    }
}
