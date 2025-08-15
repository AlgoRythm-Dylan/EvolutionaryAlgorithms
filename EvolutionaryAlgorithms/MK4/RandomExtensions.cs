namespace MK4
{
    internal static class RandomExtensions
    {
        public static double NextGaussian(this Random random)
        {
            double u1 = 1.0 - random.NextDouble();
            double u2 = 1.0 - random.NextDouble();
            return Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
        }
        public static double NextNormal(this Random random, double mean, double stdDev)
        {
            return mean + stdDev * random.NextGaussian();
        }
    }
}
