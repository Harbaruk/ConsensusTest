using System;
using System.Windows.Forms;

namespace ConsensusTester.Client.Services.Helpers
{
    public static class ThreadHelperClass
    {
        private delegate void SetTextCallback(Form f, Control ctrl, string text);

        private delegate void SetTextBlockCallback(Form f, Control ctrl, string text1, string text2, string text3);

        /// <summary>
        /// Set text property of various controls
        /// </summary>
        /// <param name="form">The calling form</param>
        /// <param name="ctrl"></param>
        /// <param name="text"></param>
        public static void SetText(Form form, Control ctrl, string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                try
                {
                    form.Invoke(d, new object[] { form, ctrl, text });
                }
                catch
                { }
            }
            else
            {
                try
                {
                    if (ctrl.GetType() == typeof(Label))
                    {
                        ctrl.Text = text;
                    }
                    else { ((TextBox)ctrl).AppendText(text + Environment.NewLine); }
                }
                catch { }
            }
        }

        public static void SetTextBlock(Form form, Control ctrl, string text1, string text2, string text3)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (ctrl.InvokeRequired)
            {
                SetTextBlockCallback d = new SetTextBlockCallback(SetTextBlock);
                try
                {
                    form.Invoke(d, new object[] { form, ctrl, text1, text2, text3 });
                }
                catch
                { }
            }
            else
            {
                try
                {
                    ((BlockControl)ctrl).HashLabelProp.Text = text1;
                    ((BlockControl)ctrl).DateLabelProp.Text = text2;
                    ((BlockControl)ctrl).MinerLabelProp.Text = text3;
                }
                catch { }
            }
        }

        public static void AddSpeed(Form form, Control ctrl, int value)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (ctrl.InvokeRequired)
            {
                SetTextBlockCallback d = new SetTextBlockCallback(SetTextBlock);
                try
                {
                    form.Invoke(d, new object[] { form, ctrl, value });
                }
                catch
                { }
            }
            else
            {
                try
                {
                    ((ChartForm)ctrl).AddSeries(value);
                }
                catch { }
            }
        }
    }
}