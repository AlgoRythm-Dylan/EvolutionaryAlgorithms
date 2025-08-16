namespace SimLib
{
    public interface IGenerationSimulator<TSynth>
        where TSynth : class, ISynth, new()
    {
        public Task<double> SimulateGeneration(World<TSynth> world);
    }
}
