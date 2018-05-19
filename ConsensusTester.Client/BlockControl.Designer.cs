namespace ConsensusTester.Client
{
    partial class BlockControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HashLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.MinerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HashLabel
            // 
            this.HashLabel.Location = new System.Drawing.Point(14, 26);
            this.HashLabel.Name = "HashLabel";
            this.HashLabel.Size = new System.Drawing.Size(188, 23);
            this.HashLabel.TabIndex = 0;
            this.HashLabel.Text = "Hash";
            this.HashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DateLabel
            // 
            this.DateLabel.Location = new System.Drawing.Point(14, 61);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(188, 23);
            this.DateLabel.TabIndex = 1;
            this.DateLabel.Text = "Hash";
            this.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MinerLabel
            // 
            this.MinerLabel.Location = new System.Drawing.Point(14, 94);
            this.MinerLabel.Name = "MinerLabel";
            this.MinerLabel.Size = new System.Drawing.Size(188, 23);
            this.MinerLabel.TabIndex = 2;
            this.MinerLabel.Text = "Hash";
            this.MinerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BlockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.MinerLabel);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.HashLabel);
            this.Name = "BlockControl";
            this.Size = new System.Drawing.Size(223, 151);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label HashLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label MinerLabel;
    }
}
