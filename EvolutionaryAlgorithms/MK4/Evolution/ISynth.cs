namespace MK4.Evolution
{
    internal interface ISynth
    {
        public void InitializeRandomly();
        public ISynth Clone();
    }
}
