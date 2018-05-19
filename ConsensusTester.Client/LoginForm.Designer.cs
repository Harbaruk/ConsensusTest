namespace ConsensusTester.Client
{
    partial class LoginForm
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
            this.PublicKeyBox = new System.Windows.Forms.TextBox();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.Label();
            this.PrivateKeyBox = new System.Windows.Forms.TextBox();
            this.PublicKey = new System.Windows.Forms.Label();
            this.PrivateKey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PublicKeyBox
            // 
            this.PublicKeyBox.Location = new System.Drawing.Point(145, 153);
            this.PublicKeyBox.Name = "PublicKeyBox";
            this.PublicKeyBox.Size = new System.Drawing.Size(143, 20);
            this.PublicKeyBox.TabIndex = 2;
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(145, 101);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(143, 20);
            this.UsernameBox.TabIndex = 1;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(176, 264);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Enter";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(64, 101);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(75, 20);
            this.Username.TabIndex = 3;
            this.Username.Text = "Username";
            this.Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrivateKeyBox
            // 
            this.PrivateKeyBox.Location = new System.Drawing.Point(145, 202);
            this.PrivateKeyBox.Name = "PrivateKeyBox";
            this.PrivateKeyBox.Size = new System.Drawing.Size(143, 20);
            this.PrivateKeyBox.TabIndex = 3;
            // 
            // PublicKey
            // 
            this.PublicKey.Location = new System.Drawing.Point(64, 153);
            this.PublicKey.Name = "PublicKey";
            this.PublicKey.Size = new System.Drawing.Size(75, 20);
            this.PublicKey.TabIndex = 5;
            this.PublicKey.Text = "PublicKey";
            this.PublicKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrivateKey
            // 
            this.PrivateKey.Location = new System.Drawing.Point(64, 202);
            this.PrivateKey.Name = "PrivateKey";
            this.PrivateKey.Size = new System.Drawing.Size(75, 20);
            this.PrivateKey.TabIndex = 6;
            this.PrivateKey.Text = "PrivateKey";
            this.PrivateKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 329);
            this.Controls.Add(this.PrivateKey);
            this.Controls.Add(this.PublicKey);
            this.Controls.Add(this.PrivateKeyBox);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.PublicKeyBox);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PublicKeyBox;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.TextBox PrivateKeyBox;
        private System.Windows.Forms.Label PublicKey;
        private System.Windows.Forms.Label PrivateKey;
    }
}