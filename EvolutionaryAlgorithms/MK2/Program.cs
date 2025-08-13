/*
 * MK2 expands on MK1, using the same parabolic
 * scoring system, but the parabola has been re-centered,
 * and widened to be more useful
 * 
 * y = -(x / 10)^2 + 1
 * 
 * To increase the pressure for evolution, the random
 * number effectiveness has been significantly decreased
 * by increasing the range of possible random values from
 * 2 units to 2000.
 * 
 * This implementation plays around with some options
 * for generic simulations instead of fixed synth and
 * gene types.
 * 
 * This implementation continues to explore options for
 * initializing and simulating synths.
 * 
 * Grouped genes into Chromosomes. The biological analogy
 * might not be perfect in this case. Chromosomes just
 * contain related groups of genes so you can isolate one
 * chromosome and only alter that specific chromosome
 * (and its effects) if needed.
 * 
 * Interface is now async-first. This just makes sense.
 */

namespace MK2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var world = new World<ParabolaGuessingSynth>(async synth =>
            {
                return -Math.Pow(synth.SumNumberGenes() / 10, 2) + 1;
            });

        }
    }
}
