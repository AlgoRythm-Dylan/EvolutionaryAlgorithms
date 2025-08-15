namespace MK3
{
    internal static class BenchmarkFunctions
    {
        public static double Ackley2D(double x, double y)
        {
            double a = 20.0;
            double b = 0.2;
            double c = 2 * Math.PI;

            double sumSquares = x * x + y * y;
            double cosSum = Math.Cos(c * x) + Math.Cos(c * y);

            double term1 = -a * Math.Exp(-b * Math.Sqrt(0.5 * sumSquares));
            double term2 = -Math.Exp(0.5 * cosSum);

            return term1 + term2 + a + Math.E;
        }
    }
}
