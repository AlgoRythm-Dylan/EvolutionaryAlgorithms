namespace SimLib
{
    public class World<TSynth>
        where TSynth : class, ISynth, new()
    {
        public delegate Task<double> FitnessDelegate(TSynth synth);

        public int Generation { get; set; } = 0;
        public List<FitnessRecord<TSynth>> Population { get; set; } = new();
        public int TargetPopulationSize { get; set; } = 100;
        public FitnessDelegate Fitness { get; set; }
        public IGenerationSimulator<TSynth> Simulator { get; set; }

        private ThreadLocal<Random> ThreadLocalRandom = new ThreadLocal<Random>(
            () => {
                // Use a thread-safe seed source
                return new Random(Guid.NewGuid().GetHashCode());
            }
        );
        public Random RNG
        {
            get => ThreadLocalRandom.Value;
        }

        public World(FitnessDelegate fitness, IGenerationSimulator<TSynth> simulator)
        {
            Fitness = fitness;
            Simulator = simulator;
        }

        public async Task<double> InitializePopulation()
        {
            bool firstRunFlag = true;
            double bestFitness = 0;
            for (int i = 0; i < TargetPopulationSize; i++)
            {
                var synth = new TSynth();
                synth.InitializeRandomly(RNG);
                double fitness = await Fitness(synth);

                if (firstRunFlag)
                {
                    firstRunFlag = false;
                    bestFitness = fitness;
                }
                else
                {
                    bestFitness = Math.Min(bestFitness, fitness);
                }

                Population.Add(new(fitness, synth));
            }
            return bestFitness;
        }

        public async Task<double> Simulate()
        {
            Generation++;
            return await Simulator.SimulateGeneration(this);
        }
    }
}
