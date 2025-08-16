namespace SimLib.DifferentialEvolution
{
    public interface IDESynth
    {
        public ISynth DifferentialCrossover(ISynth a, ISynth b, ISynth c, Random RNG, DEParams deParams);
    }
}
