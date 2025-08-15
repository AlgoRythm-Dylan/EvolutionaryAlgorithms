namespace MK3.Evolution
{
    internal class FitnessRecord<TSynth>
    {
        public double Fitness { get; set; }
        public TSynth Synth { get; set; }
        public FitnessRecord(double fitness, TSynth synth)
        {
            Fitness = fitness;
            Synth = synth;
        }
    }
}
