namespace SimLib.JADE
{
    internal class SimulationReport
    {
        public bool WasSuccess { get; set; } = false;
        public double SuccessValue { get; set; } = 0;
    }
    internal static class SimulationReportOperations
    {
        public static double SuccessfulAverage(this SimulationReport[] reports)
        {
            double count = reports.Count(report => report.WasSuccess);
            double sum = reports.Sum(report => report.WasSuccess ? report.SuccessValue : 0);
            return sum / count;
        }
        public static bool AnySuccess(this SimulationReport[] reports)
        {
            return reports.Any(report => report.WasSuccess);
        }
    }
}
