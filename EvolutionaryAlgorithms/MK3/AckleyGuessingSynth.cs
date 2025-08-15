using MK3.DifferentialEvolution;
using MK3.Evolution;
using System.Diagnostics;

namespace MK3
{
    internal class AckleyGuessingSynth : ISynth, IDESynth
    {
        public Chromosome<NumberGuessingGene> NumberGuessingChromosome { get; set; } = new();
        public AckleyGuessingSynth()
        {
            NumberGuessingChromosome.Genes = [
                    new NumberGuessingGene(),
                    new NumberGuessingGene()
                ];
        }
        public void InitializeRandomly()
        {
            foreach(var gene in NumberGuessingChromosome.Genes)
            {
                gene.Randomize();
            }
        }

        public ISynth Clone()
        {
            var clone = new AckleyGuessingSynth();
            clone.NumberGuessingChromosome.Genes.Clear();
            foreach(var gene in NumberGuessingChromosome.Genes)
            {
                clone.NumberGuessingChromosome.Genes.Add((NumberGuessingGene)gene.Clone());
            }
            return clone;
        }

        public ISynth DifferentialCrossover(ISynth a, ISynth b, ISynth c, Random RNG, DEParams deParams)
        {
            var synthA = a as AckleyGuessingSynth;
            var synthB = a as AckleyGuessingSynth;
            var synthC = a as AckleyGuessingSynth;
            if(a is null || b is null || c is null)
            {
                throw new InvalidCastException("Cannot cast provided ISynth to ParabolaGuessingSynth");
            }
            var child = (AckleyGuessingSynth)Clone();
            int guaranteedMutation = RNG.Next(synthA.NumberGuessingChromosome.Genes.Count);
            for(int i = 0; i < synthA.NumberGuessingChromosome.Genes.Count; i++)
            {
                if(RNG.NextDouble() > deParams.CrossoverProbability || i == guaranteedMutation)
                {
                    var geneA = synthA.NumberGuessingChromosome.Genes[i];
                    var geneB = synthB.NumberGuessingChromosome.Genes[i];
                    var geneC = synthC.NumberGuessingChromosome.Genes[i];
                    child.NumberGuessingChromosome.Genes[i] = NumberGuessingGene.DifferentialCrossover(geneA, geneB, geneC, deParams.DifferentialWeight);
                }
            }
            return child;
        }
    }
}
