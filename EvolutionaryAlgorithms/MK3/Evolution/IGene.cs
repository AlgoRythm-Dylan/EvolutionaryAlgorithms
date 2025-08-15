namespace MK3.Evolution
{
    internal interface IGene
    {
        public void Randomize();
        public IGene Clone();
    }
}
