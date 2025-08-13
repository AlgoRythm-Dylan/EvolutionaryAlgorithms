namespace MK1
{
    internal class ParabolaGuesser : Synth
    {
        public NumberGuessingGene A = new(), B = new(), C = new();
        public override void InitializeGenes()
        {
            Genes.Add("number_1", A);
            Genes.Add("number_2", B);
            Genes.Add("number_3", C);
        }
        public ParabolaGuesser Crossover(ParabolaGuesser other)
        {
            var child = new ParabolaGuesser();
            child.A.Number = (A.Number + other.A.Number) / 2;
            child.B.Number = (B.Number + other.B.Number) / 2;
            child.C.Number = (C.Number + other.C.Number) / 2;
            child.InitializeGenes();
            child.Source = "Offspring";
            return child;
        }
    }
}
