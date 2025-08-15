using System.Runtime.CompilerServices;

namespace MK2
{
    internal class Chromosome
    {
        public List<Gene> Genes { get; set; } = new();
        protected static void ValidateCrossovers(params List<Chromosome> chromosomes)
        {
            if (chromosomes.Count == 0)
            {
                throw new InvalidDataException("At least one chromosome required");
            }
            int geneCount = chromosomes[0].Genes.Count;
            for(int i = 1; i < chromosomes.Count; i++)
            {
                if (chromosomes[i].Genes.Count != geneCount)
                {
                    throw new InvalidDataException("All chromosomes must have the same number of genes");
                }
            }
        }
        public Chromosome Clone()
        {
            Chromosome clone = new();
            foreach (var gene in Genes)
            {
                clone.Genes.Add(gene.Clone());
            }
            return clone;
        }
        public static Chromosome Crossover(params List<Chromosome> chromosomes)
        {
            ValidateCrossovers(chromosomes);

            int geneCount = chromosomes[0].Genes.Count;
            Chromosome result = new();
            var random = new Random();
            for(int i = 0; i < geneCount; i++)
            {
                result.Genes.Add(chromosomes[random.Next(chromosomes.Count - 1)].Genes[i].Clone());
            }
            return result;
        }
    }
}
