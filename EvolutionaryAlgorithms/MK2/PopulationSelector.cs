namespace MK2
{
    internal class PopulationSelector<SynthT> where SynthT : class, ISynth, new()
    {
        public virtual List<SynthT> Select(List<FitnessRecord<SynthT>> generation,
                                           PopulationDistribution distribution,
                                           MutationConfiguration mutationConfig)
        {
            List<FitnessRecord<SynthT>> workingPopulation;
            if(distribution.MinimumFitness is not null)
            {
                workingPopulation = generation
                    .Where(synth => synth.Fitness >= distribution.MinimumFitness).ToList()
                    .OrderBy(synth => synth.Fitness)
                    .ToList();
            }
            else
            {
                workingPopulation = generation.OrderBy(synth => synth.Fitness).ToList();
            }
            List<SynthT> nextGeneration = new(distribution.TotalPopulationSize);
            for(int i = 0; i < distribution.TopPerformers && i < workingPopulation.Count; i++)
            {
                nextGeneration.Add(workingPopulation[i].Synth);
            }
            for(int i = 0; i < distribution.Crossovers && i + 1 < workingPopulation.Count; i+=2)
            {
                var child = workingPopulation[i].Synth.Crossover(workingPopulation[i + 1].Synth);
                child.MutateGenes(mutationConfig);
                nextGeneration.Add(child);
            }
            for(int i = 0; i < distribution.Clones && i < workingPopulation.Count; i++)
            {
                var clone = workingPopulation[i].Synth.CloneChromosomes<SynthT>();
                clone.MutateGenes(mutationConfig);
                nextGeneration.Add(clone);
            }
            while(nextGeneration.Count < distribution.TotalPopulationSize)
            {
                var synth = new SynthT();
                synth.Initialize();
                synth.RandomizeAllGenes();
                nextGeneration.Add(synth);
            }
            return nextGeneration;
        }
    }
}
