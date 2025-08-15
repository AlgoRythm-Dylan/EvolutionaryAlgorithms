namespace MK4
{
    internal static class BenchmarkFunctions
    {
        public static double Ackley2D(double x, double y, double xOffset = 0.0, double yOffset = 0.0)
        {
            double a = 20.0;
            double b = 0.2;
            double c = 2 * Math.PI;

            // Shift the input coordinates by the offsets
            double xs = x - xOffset;
            double ys = y - yOffset;

            double sumSquares = xs * xs + ys * ys;
            double cosSum = Math.Cos(c * xs) + Math.Cos(c * ys);

            double term1 = -a * Math.Exp(-b * Math.Sqrt(0.5 * sumSquares));
            double term2 = -Math.Exp(0.5 * cosSum);

            return term1 + term2 + a + Math.E;
        }
    }
}
