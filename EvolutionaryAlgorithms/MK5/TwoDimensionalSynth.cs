using SimLib;
using SimLib.DifferentialEvolution;
using SimLib.JADE;

namespace MK5
{
    internal class TwoDimensionalSynth : ISynth, IDESynth, IJADESynth
    {
        public Chromosome<NumericalGene> NumberGuessingChromosome { get; set; } = new();
        public TwoDimensionalSynth()
        {
            NumberGuessingChromosome.Genes = [
                    new NumericalGene(){ MaximumValue = 25, MininumValue = -25 },
                    new NumericalGene(){ MaximumValue = 25, MininumValue =-25 }
                ];
        }
        public void InitializeRandomly(Random RNG)
        {
            foreach(var gene in NumberGuessingChromosome.Genes)
            {
                gene.Randomize(RNG);
            }
        }

        public ISynth Clone()
        {
            var clone = new TwoDimensionalSynth();
            clone.NumberGuessingChromosome.Genes.Clear();
            foreach(var gene in NumberGuessingChromosome.Genes)
            {
                clone.NumberGuessingChromosome.Genes.Add((NumericalGene)gene.Clone());
            }
            return clone;
        }

        public ISynth DifferentialCrossover(ISynth a, ISynth b, ISynth c, Random RNG, DEParams deParams)
        {
            var synthA = a as TwoDimensionalSynth;
            var synthB = a as TwoDimensionalSynth;
            var synthC = a as TwoDimensionalSynth;
            if(synthA is null || synthB is null || synthC is null)
            {
                throw new InvalidCastException("Cannot cast provided ISynth");
            }
            var child = (TwoDimensionalSynth)Clone();
            int guaranteedMutation = RNG.Next(synthA.NumberGuessingChromosome.Genes.Count);
            for(int i = 0; i < synthA.NumberGuessingChromosome.Genes.Count; i++)
            {
                if(RNG.NextDouble() > deParams.CrossoverProbability || i == guaranteedMutation)
                {
                    var geneA = synthA.NumberGuessingChromosome.Genes[i];
                    var geneB = synthB.NumberGuessingChromosome.Genes[i];
                    var geneC = synthC.NumberGuessingChromosome.Genes[i];
                    child.NumberGuessingChromosome.Genes[i] = NumericalGene.DifferentialCrossover(geneA, geneB, geneC, deParams.DifferentialWeight);
                }
            }
            return child;
        }

        public ISynth JADECrossover(ISynth parent, ISynth topCandidate, ISynth a, ISynth b, Random RNG, double crossoverProbability, double differentialWeight)
        {
            var synthParent = parent as TwoDimensionalSynth;
            var synthTop = topCandidate as TwoDimensionalSynth;
            var synthA = a as TwoDimensionalSynth;
            var synthB = b as TwoDimensionalSynth;
            if (synthA is null || synthB is null || synthParent is null || synthTop is null)
            {
                throw new InvalidCastException("Cannot cast provided ISynth");
            }
            var child = (TwoDimensionalSynth)Clone();
            int guaranteedMutation = RNG.Next(synthA.NumberGuessingChromosome.Genes.Count);
            for (int i = 0; i < synthA.NumberGuessingChromosome.Genes.Count; i++)
            {
                if (RNG.NextDouble() > crossoverProbability || i == guaranteedMutation)
                {
                    var geneParent = synthParent.NumberGuessingChromosome.Genes[i];
                    var geneTop = synthTop.NumberGuessingChromosome.Genes[i];
                    var geneA = synthA.NumberGuessingChromosome.Genes[i];
                    var geneB = synthB.NumberGuessingChromosome.Genes[i];
                    child.NumberGuessingChromosome.Genes[i] = NumericalGene.JADECrossover(geneParent, geneTop, geneA, geneB, differentialWeight);
                }
            }
            return child;
        }
    }
}
