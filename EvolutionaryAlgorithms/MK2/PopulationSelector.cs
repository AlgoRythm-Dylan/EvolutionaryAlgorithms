namespace MK2
{
    internal class PopulationSelector<SynthT> where SynthT : class, ISynth, new()
    {
        public virtual List<SynthT> Select(List<FitnessRecord<SynthT>> generation)
        {
            // TODO
            return new();
        }
    }
}
