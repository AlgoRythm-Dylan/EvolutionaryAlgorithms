using SimLib.DifferentialEvolution;

namespace SimLib.JADE
{
    public class JADEParams : DEParams
    {
        public double LearningRate { get; set; } = 0.15;
        public double TopPercentageSynth { get; set; } = 0.05;
        public bool UseArchive { get; set; } = true;
    }
}
