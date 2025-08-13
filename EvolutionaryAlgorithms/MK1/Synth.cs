namespace MK1
{
    internal class Synth
    {
        public int Generation { get; set; }
        public List<Synth> Ancestors { get; set; } = new();
        public World? World { get; set; } = null;
    }
}
