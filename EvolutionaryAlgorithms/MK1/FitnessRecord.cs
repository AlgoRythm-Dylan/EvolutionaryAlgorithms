namespace MK1
{
    internal class FitnessRecord<T> where T: class
    {
        public double Fitness { get; set; }
        public T Synth { get; set; }
    }
}
