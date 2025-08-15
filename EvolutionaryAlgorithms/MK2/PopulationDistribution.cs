namespace MK2
{
    internal class PopulationDistribution
    {
        /// <summary>
        /// Kept as-is, no mutations
        /// </summary>
        public int TopPerformers { get; set; } = 20;
        /// <summary>
        /// Using the top n*2 performers, n offspring are generated
        /// </summary>
        public int Crossovers { get; set; } = 20;
        /// <summary>
        /// Using the top n performers, n offspring are cloned (with mutations)
        /// </summary>
        public int Clones { get; set; } = 20;
        /// <summary>
        /// Any of the rest of the population are randomized
        /// </summary>
        public int TotalPopulationSize { get; set; } = 100;
        /// <summary>
        /// Any synth performing under this bar will not continue to the next
        /// generation, even if a top performer. This filtering is done BEFORE
        /// the other options, and if there aren't enough synths, those
        /// categories will not have any synths and the population will be filled
        /// with randoms.
        /// </summary>
        public double? MinimumFitness { get; set; } = null;
    }
}
