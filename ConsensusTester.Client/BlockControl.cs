using System;
using System.Windows.Forms;

namespace ConsensusTester.Client
{
    public partial class BlockControl : UserControl
    {
        public Label HashLabelProp { get { return HashLabel; } set { HashLabel = value; } }

        public Label DateLabelProp { get { return DateLabel; } set { DateLabel = value; } }

        public Label MinerLabelProp { get { return MinerLabel; } set { MinerLabel = value; } }

        public BlockControl(string blockHash, DateTimeOffset date, string miner)
        {
            InitializeComponent();
            HashLabel.Text = blockHash;
            DateLabel.Text = date.ToLocalTime().ToString();
            MinerLabel.Text = miner;
        }

        public BlockControl()
        {
            InitializeComponent();
        }
    }
}