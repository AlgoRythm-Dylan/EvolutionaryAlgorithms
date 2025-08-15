using MK4.Evolution;

namespace MK4.DifferentialEvolution
{
    internal interface IDESynth
    {
        public ISynth DifferentialCrossover(ISynth a, ISynth b, ISynth c, Random RNG, DEParams deParams);
    }
}
