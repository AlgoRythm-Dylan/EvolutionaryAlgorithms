using MK4.Evolution;

namespace MK4.JADE
{
    internal interface IJADESynth
    {
        public ISynth JADECrossover(ISynth parent, ISynth topCandidate, ISynth a, ISynth b, Random RNG, double crossoverProbability, double differentialWeight);
    }
}
