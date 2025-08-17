namespace SimLib
{
    public interface IGene
    {
        public void Randomize(Random RNG);
        public IGene Clone();
    }
}
