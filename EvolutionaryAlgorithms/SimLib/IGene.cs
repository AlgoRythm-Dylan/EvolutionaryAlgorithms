namespace SimLib
{
    public interface IGene
    {
        public void Randomize();
        public IGene Clone();
    }
}
