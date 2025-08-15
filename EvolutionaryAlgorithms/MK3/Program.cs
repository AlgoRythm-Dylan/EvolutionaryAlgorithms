/*
 * MK3 will implement Differential Evolution:
 * 
 * https://en.wikipedia.org/wiki/Differential_evolution
 * 
 * Step one: initialize population randomly
 * Step two: iterate over each synth. For each, do:
 *      1.) Find three other synths: a, b, c
 *      2.) For each gene, generate a random number
 *          between 0 and 1. If this number is
 *          greater than (alternatively, less than)
 *          the CR (CrossoverProbability), do this:
 *              - Mutate the gene by applying the
 *                formula:
 *                new = a.chromosome[i] + F * (b.chromosome[i] - c.chromosome[i])
 *                where: F = scaling factor (DifferentialWeight)
 *          - Pick one random gene and ensure that it
 *            undergoes this process (in other words,
 *            guarantee at least one gene mutates in this way)
 *      3.) After each gene has been modified (or not),
 *          evaluate the child's fitness. If it is more fit
 *          than the parent, add the child to the next
 *          generation. Otherwise, copy the parent to
 *          the next generation.
 * 
 */


using MK3.DifferentialEvolution;
using MK3.Evolution;

namespace MK3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            World<ParabolaGuessingSynth>.FitnessDelegate fitness = async synth =>
            {
                return -Math.Pow(synth.SumNumberGenes() / 10, 2);
            };
            var simulator = new DEGenerationSimulator<ParabolaGuessingSynth>();

            var world = new World<ParabolaGuessingSynth>(fitness, simulator);
            var startingFitness = await world.InitializePopulation();
            Console.WriteLine($"Starting fitness: {startingFitness}");
            for(int i = 0; i < 100; i++)
            {
                var thisGenerationFitness = await world.Simulate();
                Console.WriteLine($"Fitness after generation {world.Generation}: {thisGenerationFitness}");
            }
        }
    }
}
