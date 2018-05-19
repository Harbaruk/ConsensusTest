namespace ConsensusTester.Client
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CreateTransaction = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Mining = new ConsensusTester.Client.BlockControl();
            this.LastVerifiedBlock = new ConsensusTester.Client.BlockControl();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(33, 312);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(242, 110);
            this.textBox1.TabIndex = 0;
            // 
            // CreateTransaction
            // 
            this.CreateTransaction.Location = new System.Drawing.Point(304, 377);
            this.CreateTransaction.Name = "CreateTransaction";
            this.CreateTransaction.Size = new System.Drawing.Size(112, 45);
            this.CreateTransaction.TabIndex = 1;
            this.CreateTransaction.Text = "Create";
            this.CreateTransaction.UseVisualStyleBackColor = true;
            this.CreateTransaction.Click += new System.EventHandler(this.CreateTransaction_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(652, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "Mining";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Transaction description";
            // 
            // Mining
            // 
            this.Mining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Mining.Location = new System.Drawing.Point(365, 21);
            this.Mining.Name = "Mining";
            this.Mining.Size = new System.Drawing.Size(223, 151);
            this.Mining.TabIndex = 4;
            this.Mining.TabStop = false;
            // 
            // LastVerifiedBlock
            // 
            this.LastVerifiedBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastVerifiedBlock.Location = new System.Drawing.Point(33, 21);
            this.LastVerifiedBlock.Name = "LastVerifiedBlock";
            this.LastVerifiedBlock.Size = new System.Drawing.Size(223, 151);
            this.LastVerifiedBlock.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 475);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Mining);
            this.Controls.Add(this.LastVerifiedBlock);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CreateTransaction);
            this.Controls.Add(this.textBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CreateTransaction;
        private System.Windows.Forms.Button button2;
        private BlockControl LastVerifiedBlock;
        private BlockControl Mining;
        private System.Windows.Forms.Label label1;
    }
}

