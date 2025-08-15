namespace MK2
{
    internal abstract class Gene
    {
        public abstract void Randomize();
        public abstract Gene Clone();
        public abstract void Mutate(MutationConfiguration config);
    }
}
