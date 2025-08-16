namespace SimLib.JADE
{
    public class JADEGenerationSimulator<TSynth> : IGenerationSimulator<TSynth>
        where TSynth : class, ISynth, IJADESynth, new()
    {
        public JADEParams JADEParams { get; set; } = new();
        public double CurrentCrossoverProbability { get; set; } = 0;
        public double CurrentDifferentialWeight { get; set; } = 0;
        private bool FirstRunFlag = true;
        private List<TSynth> Archive { get; set; } = new();
        public async Task<double> SimulateGeneration(World<TSynth> world)
        {
            if (FirstRunFlag)
            {
                FirstRunFlag = false;
                CurrentCrossoverProbability = JADEParams.CrossoverProbability;
                CurrentDifferentialWeight = JADEParams.DifferentialWeight;
            }
            else
            {
                world.Population = world.Population.OrderBy(synth => synth.Fitness).ToList();
            }
            List<FitnessRecord<TSynth>> nextGen = new();

            bool firstLoopFlag = true;
            double bestFitness = 0;
            double successCRSum = 0;
            int successCRCount = 0;
            double successWeightSum = 0;
            int successWeightCount = 0;

            for (int i = 0; i < world.Population.Count; i++)
            {
                var parent = world.Population[i];
                var twoRandomSynths = JADEParams.UseArchive ? GetDistinctSynthsPlusArchive(parent.Synth, world) : GetDistinctSynths(parent.Synth, world);
                var topPerformer = GetRandomTopSynth(world, JADEParams.TopPercentageSynth);
                double thisCR = NextCR(world.RNG, CurrentCrossoverProbability);
                double thisWeight = NextCauchy(world.RNG, CurrentDifferentialWeight);
                var child = (TSynth)parent.Synth.JADECrossover(parent.Synth, topPerformer, twoRandomSynths[0], twoRandomSynths[1], world.RNG, CurrentCrossoverProbability, CurrentDifferentialWeight);
                var childFitness = await world.Fitness(child);

                double thisGenerationFitness = 0;
                if (childFitness < parent.Fitness)
                {
                    thisGenerationFitness = childFitness;
                    nextGen.Add(new(childFitness, child));
                    successCRSum += thisCR;
                    successCRCount++;
                    successWeightSum += 0;
                    successWeightCount++;
                    AddToArchive(parent.Synth, world.Population.Count);
                }
                else
                {
                    thisGenerationFitness = parent.Fitness;
                    nextGen.Add(parent);
                }
                if (firstLoopFlag)
                {
                    firstLoopFlag = false;
                    bestFitness = thisGenerationFitness;
                }
                else
                {
                    bestFitness = Math.Min(bestFitness, thisGenerationFitness);
                }

            }

            if(successCRCount > 0)
            {
                CurrentCrossoverProbability = successCRSum / successCRCount;
            }
            world.Population = nextGen;
            return bestFitness;
        }

        private List<TSynth> GetDistinctSynths(TSynth notThisOne, World<TSynth> world, int count = 2)
        {
            List<TSynth> selected = new();
            while (selected.Count < count)
            {
                var candidate = world.Population[world.RNG.Next(world.Population.Count)].Synth;
                if (candidate != notThisOne && !selected.Contains(candidate))
                {
                    selected.Add(candidate);
                }
            }
            return selected;
        }

        private List<TSynth> GetDistinctSynthsPlusArchive(TSynth notThisOne, World<TSynth> world)
        {
            TSynth fromPopulation, fromPopulationPlusArchive;
            do
            {
                fromPopulation = world.Population[world.RNG.Next(world.Population.Count)].Synth;
            } while(fromPopulation == notThisOne);
            do
            {
                int index = world.RNG.Next(world.Population.Count + Archive.Count);
                if(index < world.Population.Count)
                {
                    fromPopulationPlusArchive = world.Population[index].Synth;
                }
                else
                {
                    fromPopulationPlusArchive = Archive[index - world.Population.Count];
                }
            } while (fromPopulationPlusArchive == notThisOne || fromPopulationPlusArchive != fromPopulation);
            return [ fromPopulation, fromPopulationPlusArchive ];
        }

        private TSynth GetRandomTopSynth(World<TSynth> world, double topPercentage = 0.05)
        {
            int max = (int)(world.Population.Count * topPercentage);
            return world.Population[world.RNG.Next(max)].Synth;
        }

        private double NextCR(Random random, double meanCR, double stdDev = 0.1)
        {
            double cr;
            do
            {
                cr = random.NextNormal(meanCR, stdDev);
            } while (cr < 0 || cr > 1);
            return cr;
        }

        private double NextCauchy(Random random, double x0 = 0.5, double gamma = 0.1)
        {
            double u;
            do
            {
                u = random.NextDouble() - 0.5;
            } while (u == 0); // avoid division by zero

            double value = x0 + gamma * Math.Tan(Math.PI * u);

            // clamp to [0,1]
            value = Math.Min(1.0, Math.Max(0.0, value));

            return value;
        }
        private void AddToArchive(TSynth synth, int maxPopulation)
        {
            Random rand = new();
            if(Archive.Count >= maxPopulation)
            {
                Archive[rand.Next(Archive.Count)] = synth;
            }
            else
            {
                Archive.Add(synth);
            }
        }

    }
}
