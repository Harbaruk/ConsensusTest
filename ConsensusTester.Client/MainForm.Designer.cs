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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CreateTransaction = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.LastVerifiedBlock = new ConsensusTester.Client.BlockControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PublicKeyLabel = new System.Windows.Forms.Label();
            this.PrivateKeyLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
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
            // SpeedLabel
            // 
            this.SpeedLabel.Location = new System.Drawing.Point(652, 425);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(98, 23);
            this.SpeedLabel.TabIndex = 6;
            this.SpeedLabel.Text = "Speed : ";
            this.SpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TimeLabel
            // 
            this.TimeLabel.Location = new System.Drawing.Point(652, 448);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(98, 23);
            this.TimeLabel.TabIndex = 7;
            this.TimeLabel.Text = "Time : ";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LastVerifiedBlock
            // 
            this.LastVerifiedBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastVerifiedBlock.Location = new System.Drawing.Point(33, 76);
            this.LastVerifiedBlock.Name = "LastVerifiedBlock";
            this.LastVerifiedBlock.Size = new System.Drawing.Size(223, 151);
            this.LastVerifiedBlock.TabIndex = 3;
            this.LastVerifiedBlock.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PrivateKeyLabel);
            this.groupBox1.Controls.Add(this.PublicKeyLabel);
            this.groupBox1.Controls.Add(this.UsernameLabel);
            this.groupBox1.Location = new System.Drawing.Point(576, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 170);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User information";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Location = new System.Drawing.Point(73, 37);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(100, 23);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "label2";
            // 
            // PublicKeyLabel
            // 
            this.PublicKeyLabel.Location = new System.Drawing.Point(73, 83);
            this.PublicKeyLabel.Name = "PublicKeyLabel";
            this.PublicKeyLabel.Size = new System.Drawing.Size(100, 23);
            this.PublicKeyLabel.TabIndex = 1;
            this.PublicKeyLabel.Text = "label3";
            // 
            // PrivateKeyLabel
            // 
            this.PrivateKeyLabel.Location = new System.Drawing.Point(73, 130);
            this.PrivateKeyLabel.Name = "PrivateKeyLabel";
            this.PrivateKeyLabel.Size = new System.Drawing.Size(100, 23);
            this.PrivateKeyLabel.TabIndex = 2;
            this.PrivateKeyLabel.Text = "label4";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 475);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LastVerifiedBlock);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CreateTransaction);
            this.Controls.Add(this.textBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CreateTransaction;
        private System.Windows.Forms.Button button2;
        private BlockControl LastVerifiedBlock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label PrivateKeyLabel;
        private System.Windows.Forms.Label PublicKeyLabel;
        private System.Windows.Forms.Label UsernameLabel;
    }
}

