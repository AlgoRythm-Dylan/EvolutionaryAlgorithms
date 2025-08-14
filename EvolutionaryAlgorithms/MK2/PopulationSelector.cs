namespace MK2
{
    internal class PopulationSelector<SynthT> where SynthT : class, ISynth, new()
    {
        public virtual List<SynthT> Select(List<FitnessRecord<SynthT>> generation, PopulationDistribution distribution)
        {
            List<SynthT> nextGeneration = new(distribution.TotalPopulationSize);
            for(int i = 0; i < distribution.TopPerformers; i++)
            {
                nextGeneration.Add(generation[i].Synth);
            }
            for(int i = 0; i < distribution.Crossovers; i+=2)
            {
                nextGeneration.Add(generation[i].Synth.Crossover(generation[i + 1].Synth));
            }
            // TODO: clones
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
