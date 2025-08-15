namespace MK3.Evolution
{
    internal class Chromosome<TGene>
        where TGene : class, IGene, new()
    {
        public List<TGene> Genes { get; set; } = new();
    }
}
