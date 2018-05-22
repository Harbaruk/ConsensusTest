using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Forms;

namespace ConsensusTester.Client
{
    public partial class ChartForm : Form
    {
        public SeriesCollection _Series { get; set; }

        public ChartForm()
        {
            InitializeComponent();
            _Series = new SeriesCollection
            {
                new LineSeries
                {
                     Values = new ChartValues<int>()
                }
            };
            cartesianChart1.Series = _Series;
        }
    }
}