namespace MK2
{
    internal class ParabolaGuessingSynth : ISynth
    {
        private const int NUMBER_GUESS_CHROMOSOME_INDEX = 0;
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public List<Chromosome> Chromosomes { get; set; } = new();

        public void Initialize()
        {
            Chromosomes.Clear();
            // Add the number guessing chromosome and all of its genes
            Chromosomes.Add(new Chromosome()
            {
                Genes = new()
                {
                    new NumberGuessingGene(),
                    new NumberGuessingGene(),
                    new NumberGuessingGene(),
                    new NumberGuessingGene(),
                    new NumberGuessingGene(),
                    new NumberGuessingGene(),
                    new NumberGuessingGene(),
                    new NumberGuessingGene()
                }
            });
        }
        public double SumNumberGenes()
        {
            return NumberGuessingChromosome.Genes.Sum(gene => (gene as NumberGuessingGene).Number);
        }
        public Chromosome NumberGuessingChromosome
        {
            get
            {
                return Chromosomes[NUMBER_GUESS_CHROMOSOME_INDEX];
            }
        }
    }
}
