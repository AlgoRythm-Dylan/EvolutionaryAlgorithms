namespace MK2
{
    internal class Chromosome
    {
        public List<Gene> Genes { get; set; } = new();
        protected static void ValidateCrossovers(params Chromosome[] chromosomes)
        {
            if (chromosomes.Length == 0)
            {
                throw new InvalidDataException("At least one chromosome required");
            }
            int geneCount = chromosomes[0].Genes.Count;
            for(int i = 1; i < chromosomes.Length; i++)
            {
                if (chromosomes[i].Genes.Count != geneCount)
                {
                    throw new InvalidDataException("All chromosomes must have the same number of genes");
                }
            }
        }
        public static Chromosome Crossover(params Chromosome[] chromosomes)
        {
            ValidateCrossovers(chromosomes);

            int geneCount = chromosomes[0].Genes.Count;
            Chromosome result = new();
            var random = new Random();
            for(int i = 0; i < geneCount; i++)
            {
                result.Genes[i] = chromosomes[random.Next(chromosomes.Length - 1)].Genes[i];
            }
            return result;
        }
    }
}
