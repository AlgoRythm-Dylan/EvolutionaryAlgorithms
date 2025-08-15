namespace MK2
{
    internal class MutationConfiguration
    {
        /*
         * Mutations occur about 15% of the time and can mutate
         * a gene by as much as 10%
         */
        public double MutationRate { get; set; } = 0.15;
        public double MutationStrength { get; set; } = 0.01;
    }
}
