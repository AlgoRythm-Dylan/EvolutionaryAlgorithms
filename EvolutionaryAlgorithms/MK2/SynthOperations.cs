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
    }
}
