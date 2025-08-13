namespace MK1
{
    internal class World
    {
        public int Generation { get; set; } = 0;
        public List<ParabolaGuesser> Population { get; set; } = new();
        public PopulationDistribution PopulationDistribution { get; set; } = new();

        public void MaterializeInitialPopulation(PopulationDistribution popDist)
        {
            PopulationDistribution = popDist;
            AddRandoms(PopulationDistribution.Random);
        }
        protected double GetFitness(ParabolaGuesser synth)
        {
            double synthScore = (synth.Genes["number_1"] as NumberGuessingGene).Number +
                (synth.Genes["number_2"] as NumberGuessingGene).Number +
                (synth.Genes["number_3"] as NumberGuessingGene).Number;
            // Score = position on a parabola, from [0, 2] where the correct answer is 1
            return -Math.Pow(synthScore - 1, 2) + 1;
        }
        private void AddRandoms(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var newRandomSynth = new ParabolaGuesser();
                newRandomSynth.InitializeGenes();
                newRandomSynth.MutateAllGenes();
                Population.Add(newRandomSynth);
            }
        }
        public double RunGeneration()
        {
            List<FitnessRecord<ParabolaGuesser>> records = new();
            foreach(var synth in Population)
            {
                records.Add(new()
                {
                    Synth = synth,
                    Fitness = GetFitness(synth)
                });
            }
            var sorted = records.OrderByDescending(r => r.Fitness).ToList();
            Console.WriteLine($"Generation {Generation + 1} best fitness: {Math.Round(sorted[0].Fitness, 3)}, source: {sorted[0].Synth.Source}, genes: {sorted[0].Synth.EnumerateGenes()}");
            Population = [ sorted[0].Synth, sorted[1].Synth, sorted[0].Synth.Crossover(sorted[1].Synth) ];
            AddRandoms(PopulationDistribution.Random - 3);
            Generation++;
            return sorted[0].Fitness;
        }
    }
}
