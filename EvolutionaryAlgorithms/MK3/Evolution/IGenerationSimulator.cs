namespace MK3.Evolution
{
    internal interface IGenerationSimulator<TSynth>
        where TSynth : class, ISynth, new()
    {
        public Task<double> SimulateGeneration(World<TSynth> world);
    }
}
