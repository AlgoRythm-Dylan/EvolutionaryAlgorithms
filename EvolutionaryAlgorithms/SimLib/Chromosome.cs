namespace SimLib
{
    public class Chromosome<TGene>
        where TGene : class, IGene, new()
    {
        public List<TGene> Genes { get; set; } = new();
    }
}
