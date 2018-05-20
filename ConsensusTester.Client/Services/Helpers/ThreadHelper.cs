using System;
using System.Windows.Forms;

namespace ConsensusTester.Client.Services.Helpers
{
    public static class ThreadHelperClass
    {
        private delegate void SetTextCallback(Form f, Control ctrl, string text);

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
                    ((TextBox)ctrl).AppendText(text + Environment.NewLine);
                }
                catch { }
            }
        }
    }
}