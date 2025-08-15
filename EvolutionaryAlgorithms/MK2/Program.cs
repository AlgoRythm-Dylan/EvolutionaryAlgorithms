/*
 * MK2 expands on MK1, using the same parabolic
 * scoring system, but the parabola has been re-centered,
 * and widened to be more useful
 * 
 * y = -(x / 10)^2
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
 * 
 * The selection is done by trying to keep well-performing
 * synths around and crossing them over and cloning them
 * plus a few mutations. This system ultimately works, but
 * cannot beat it's comparison: generating 6 random numbers.
 * 
 * This is partially because my selection process is bad,
 * but also because 0 is the goal and 6 randomly generated
 * numbers will likely sum to 0, so the random population is
 * unnaturally skilled at this task. MK3 will hope to address
 * both of these issues.
 */

namespace MK2
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            await RunTheNumbers();
        }
        private static async Task RunTheNumbers()
        {
            List<double> nullSelectorResults = new();
            List<double> naturalSelectorResults = new();
            for (int i = 0; i < 50; i++)
            {
                nullSelectorResults.Add(await Simulate(true));
                naturalSelectorResults.Add(await Simulate());
            }
            Console.WriteLine("Results after 50 simulations of each:");
            Console.WriteLine($"Null selector average score: {nullSelectorResults.Average()}");
            Console.WriteLine($"Natural selector average score: {naturalSelectorResults.Average()}");

            Console.WriteLine($"Null selector best score: {nullSelectorResults.Max()}");
            Console.WriteLine($"Natural selector best score: {naturalSelectorResults.Max()}");

            Console.WriteLine($"Null selector worst score: {nullSelectorResults.Min()}");
            Console.WriteLine($"Natural selector worst score: {naturalSelectorResults.Min()}");
        }
        private static async Task<double> Simulate(bool nullSelector = false, double? mininumFitness = null)
        {
            var world = new World<ParabolaGuessingSynth>(async synth =>
            {
                return -Math.Pow(synth.SumNumberGenes() / 10, 2);
            });
            if (nullSelector)
            {
                world.PopulationSelector = new NullPopulationSelector<ParabolaGuessingSynth>();
            }
            world.PopulationDistribution.MinimumFitness = mininumFitness;
            world.InitializePopulation();

            bool firstFlag = true;
            double bestScore = 0;
            int count = 0;
            while (count < 10)
            {
                if (firstFlag)
                {
                    firstFlag = false;
                    bestScore = await world.Step();
                }
                else
                {
                    bestScore = Math.Max(bestScore, await world.Step());
                }
                count++;
            }
            return bestScore;
        }
    }
}
