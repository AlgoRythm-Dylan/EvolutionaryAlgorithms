namespace MK2
{
    internal interface ISynth
    {
        public string ID { get; set; }
        public List<Chromosome> Chromosomes { get; set; }
        public void Initialize();
    }
}
