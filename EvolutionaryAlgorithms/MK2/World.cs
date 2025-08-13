namespace MK2
{
    internal class World<SynthT> where SynthT : class, ISynth, new()
    {
        public List<SynthT> Population { get; set; } = new();
        public delegate Task<double> FitnessDelegate(SynthT synth);
        public FitnessDelegate Fitness { get; set; }
        public PopulationSelector<SynthT> PopulationSelector { get; set; } = new();

        public World(FitnessDelegate fitnessDelegate)
        {
            Fitness = fitnessDelegate;
            InitializePopulation();
        }
        public void InitializePopulation()
        {
            Population.Clear();
            for(int i = 0; i < 100; i++)
            {
                var newSynth = new SynthT();
                newSynth.Initialize();
                newSynth.RandomizeAllGenes();
            }
        }
        public async Task Step()
        {
            List<FitnessRecord<SynthT>> performances = new();
            foreach(var synth in Population)
            {
                performances.Add(new()
                {
                    Synth = synth,
                    Fitness = await Fitness(synth)
                });
            }
            Population = PopulationSelector.Select(performances);
        }
    }
}
