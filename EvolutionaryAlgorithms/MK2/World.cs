namespace MK2
{
    internal class World<SynthT> where SynthT : class, ISynth, new()
    {
        public int Generation { get; set; } = 0;
        public List<SynthT> Population { get; set; } = new();
        public delegate Task<double> FitnessDelegate(SynthT synth);
        public FitnessDelegate Fitness { get; set; }
        public PopulationSelector<SynthT> PopulationSelector { get; set; } = new();
        public PopulationDistribution PopulationDistribution { get; set; } = new();
        public MutationConfiguration MutationConfiguration { get; set; } = new();

        public World(FitnessDelegate fitnessDelegate)
        {
            Fitness = fitnessDelegate;
            InitializePopulation();
        }
        public void InitializePopulation()
        {
            Population.Clear();
            for(int i = 0; i < PopulationDistribution.TotalPopulationSize; i++)
            {
                var newSynth = new SynthT();
                newSynth.Initialize();
                newSynth.RandomizeAllGenes();
                Population.Add(newSynth);
            }
        }
        public async Task<double> Step()
        {
            Generation++;
            List<FitnessRecord<SynthT>> performances = new();
            bool firstFlag = true;
            double bestScore = 0;
            foreach(var synth in Population)
            {
                var performance = new FitnessRecord<SynthT>()
                {
                    Synth = synth,
                    Fitness = await Fitness(synth)
                };
                if(firstFlag)
                {
                    firstFlag = false;
                    bestScore = performance.Fitness;
                }
                else
                {
                    bestScore = Math.Max(bestScore, performance.Fitness);
                }
                performances.Add(performance);
            }
            Population = PopulationSelector.Select(performances, PopulationDistribution, MutationConfiguration);
            return bestScore;
        }
    }
}
