namespace SimLib
{
    public interface ISynth
    {
        public void InitializeRandomly(Random RNG);
        public ISynth Clone();
    }
}
