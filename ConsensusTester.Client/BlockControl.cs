using System;
using System.Windows.Forms;

namespace ConsensusTester.Client
{
    public partial class BlockControl : UserControl
    {
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