using MK3.Evolution;

namespace MK3.DifferentialEvolution
{
    internal interface IDESynth
    {
        public ISynth DifferentialCrossover(ISynth a, ISynth b, ISynth c, Random RNG, DEParams deParams);
    }
}
