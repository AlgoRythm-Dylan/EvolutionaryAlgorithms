namespace MK2
{
    internal class FitnessRecord<SynthT> where SynthT : class, ISynth
    {
        public double Fitness { get; set; }
        public SynthT Synth { get; set; }
    }
}
