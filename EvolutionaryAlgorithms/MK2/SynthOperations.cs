namespace MK2
{
    internal static class SynthOperations
    {
        public static void RandomizeAllGenes(this ISynth synth)
        {
            foreach(var chromosome in synth.Chromosomes)
            {
                foreach(var gene in chromosome.Genes)
                {
                    gene.Randomize();
                }
            }
        }
        public static SynthT Crossover<SynthT>(this SynthT parent1, SynthT parent2)
            where SynthT : class, ISynth, new()
        {
            var child = new SynthT();
            for(int i = 0; i < parent1.Chromosomes.Count; i++)
            {
                child.Chromosomes.Add(Chromosome.Crossover(parent1.Chromosomes[i], parent2.Chromosomes[i]));
            }
            return child;
        }
    }
}
