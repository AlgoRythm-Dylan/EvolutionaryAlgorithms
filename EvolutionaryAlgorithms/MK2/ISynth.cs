namespace MK2
{
    internal interface ISynth
    {
        public List<Chromosome> Chromosomes { get; set; }
        public void Initialize();
    }
}
