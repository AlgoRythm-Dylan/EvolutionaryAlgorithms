namespace SimLib
{
    internal class ListGene<TEntity> : IGene
    {
        private NumericalGene Backend { get; set; } = new();

        public List<TEntity> List { get; set; } = new();

        public void Randomize(Random RNG)
        {
            Backend.Randomize(RNG);
        }

        public IGene Clone()
        {
            return new ListGene<TEntity>()
            {
                Backend = (NumericalGene)Backend.Clone(),
                List = List
            };
        }

        public TEntity GetValue()
        {
            return List[(int)Math.Floor(Backend.Number * List.Count)];
        }

        public double GetWeight()
        {
            return Backend.Number;
        }

        public void SetWeight(double value)
        {
            Backend.Number = value;
        }
    }
}
