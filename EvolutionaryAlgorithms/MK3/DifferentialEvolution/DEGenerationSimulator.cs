using MK3.Evolution;
using System.Diagnostics;

namespace MK3.DifferentialEvolution
{
    internal class DEGenerationSimulator<TSynth> : IGenerationSimulator<TSynth>
        where TSynth : class, ISynth, IDESynth, new()
    {
        public DEParams DEParams { get; set; } = new();
        public async Task<double> SimulateGeneration(World<TSynth> world)
        {
            List<FitnessRecord<TSynth>> nextGen = new();

            bool firstRunFlag = true;
            double maxFitness = 0;
            for(int i = 0; i < world.Population.Count; i++)
            {
                var parent = world.Population[i];
                var threeRandomSynths = GetDistinctSynths(parent.Synth, world);
                var child = (TSynth)parent.Synth.DifferentialCrossover(threeRandomSynths[0], threeRandomSynths[1], threeRandomSynths[2], world.RNG, DEParams);
                var childFitness = await world.Fitness(child);

                double thisGenerationFitnenss = 0;
                if(childFitness > parent.Fitness)
                {
                    thisGenerationFitnenss = childFitness;
                    nextGen.Add(new(childFitness, child));
                }
                else
                {
                    thisGenerationFitnenss = parent.Fitness;
                    nextGen.Add(parent);
                }
                if (firstRunFlag)
                {
                    firstRunFlag = false;
                    maxFitness = thisGenerationFitnenss;
                }
                else
                {
                    maxFitness = Math.Max(maxFitness, thisGenerationFitnenss);
                }
            }

            world.Population = nextGen;
            return maxFitness;
        }
        public List<TSynth> GetDistinctSynths(TSynth notThisOne, World<TSynth> world, int count = 3)
        {
            List<TSynth> selected = new();
            while(selected.Count < count)
            {
                var candidate = world.Population[world.RNG.Next(world.Population.Count)].Synth;
                if(candidate != notThisOne && !selected.Contains(candidate))
                {
                    selected.Add(candidate);
                }
            }
            return selected;
        }
    }
}
