namespace MK2
{
    internal class NullPopulationSelector<SynthT> : PopulationSelector<SynthT>
        where SynthT : class, ISynth, new()
    {
        public override List<SynthT> Select(List<FitnessRecord<SynthT>> generation, PopulationDistribution distribution)
        {
            // Just return new synths
            List<SynthT> nextGeneration = new();
            for(int i = 0; i < generation.Count; i++)
            {
                var newSynth = new SynthT();
                newSynth.Initialize();
                newSynth.RandomizeAllGenes();
                nextGeneration.Add(newSynth);
            }
            return nextGeneration;
        }
    }
}
