/*
 * MK5 will finally solidify the API
 * by moving everything into SimLib
 * 
 * Additionally, SimLib will run multi-threaded
 * 
 */

using SimLib;
using SimLib.JADE;

namespace MK5
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            World<TwoDimensionalSynth>.FitnessDelegate fitness = async synth =>
            {
                return BenchmarkFunctions.Ackley2D(synth.NumberGuessingChromosome.Genes[0].Number, synth.NumberGuessingChromosome.Genes[1].Number, 5.7, 10.9);
            };
            var simulator = new JADEGenerationSimulator<TwoDimensionalSynth>();

            var world = new World<TwoDimensionalSynth>(fitness, simulator);
            var startingFitness = await world.InitializePopulation();
            Console.WriteLine($"Starting fitness: {startingFitness}");
            for (int i = 0; i < 100; i++)
            {
                var thisGenerationFitness = await world.Simulate();
                Console.WriteLine($"Fitness after generation {world.Generation}: {thisGenerationFitness}");
            }
            var bestFit = world.Population.OrderBy(synth => synth.Fitness).First();
            Console.WriteLine($"Coordinates of best fit: ({bestFit.Synth.NumberGuessingChromosome.Genes[0].Number}, {bestFit.Synth.NumberGuessingChromosome.Genes[1].Number})");
        }
    }
}
