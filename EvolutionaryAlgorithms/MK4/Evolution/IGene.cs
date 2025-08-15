namespace MK4.Evolution
{
    internal interface IGene
    {
        public void Randomize();
        public IGene Clone();
    }
}
