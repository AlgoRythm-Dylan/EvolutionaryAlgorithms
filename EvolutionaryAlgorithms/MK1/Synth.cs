using System.Text;

namespace MK1
{
    internal abstract class Synth
    {
        public int Generation { get; set; }
        public List<Synth> Ancestors { get; set; } = new();
        public World? World { get; set; } = null;
        public Dictionary<string, IGene> Genes { get; set; } = new();
        public string Source { get; set; } = "Generated";
        public abstract void InitializeGenes();
        public void MutateAllGenes()
        {
            foreach(var gene in Genes.Values)
            {
                gene.Mutate();
            }
        }
        public string EnumerateGenes()
        {
            StringBuilder sb = new();
            foreach(var gene in Genes)
            {
                sb.Append($"[{gene.Key}={gene.Value.GetValueString()}]");
            }
            return sb.ToString();
        }
    }
}
