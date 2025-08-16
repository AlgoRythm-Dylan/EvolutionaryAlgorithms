namespace SimLib.JADE
{
    public interface IJADESynth
    {
        public ISynth JADECrossover(ISynth parent, ISynth topCandidate, ISynth a, ISynth b, Random RNG, double crossoverProbability, double differentialWeight);
    }
}
