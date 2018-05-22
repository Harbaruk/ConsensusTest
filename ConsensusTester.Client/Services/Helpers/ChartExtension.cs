using System.Linq;

namespace ConsensusTester.Client.Services.Helpers
{
    public static class ChartExtension
    {
        public static void AddSeries(this ChartForm form, int speed)
        {
            form._Series.First().Values.Add(speed);
        }
    }
}