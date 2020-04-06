namespace Agricola
{
    partial class SetupForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.nPlayersButton1 = new System.Windows.Forms.RadioButton();
            this.nPlayersButton2 = new System.Windows.Forms.RadioButton();
            this.nPlayersButton3 = new System.Windows.Forms.RadioButton();
            this.nPlayersButton4 = new System.Windows.Forms.RadioButton();
            this.nPlayersButton5 = new System.Windows.Forms.RadioButton();
            this.continueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "How many players will participate?";
            // 
            // nPlayersButton1
            // 
            this.nPlayersButton1.AutoSize = true;
            this.nPlayersButton1.Location = new System.Drawing.Point(34, 34);
            this.nPlayersButton1.Name = "nPlayersButton1";
            this.nPlayersButton1.Size = new System.Drawing.Size(31, 17);
            this.nPlayersButton1.TabIndex = 1;
            this.nPlayersButton1.TabStop = true;
            this.nPlayersButton1.Text = "1";
            this.nPlayersButton1.UseVisualStyleBackColor = true;
            this.nPlayersButton1.CheckedChanged += new System.EventHandler(this.nPlayersButton1_CheckedChanged);
            // 
            // nPlayersButton2
            // 
            this.nPlayersButton2.AutoSize = true;
            this.nPlayersButton2.Location = new System.Drawing.Point(71, 34);
            this.nPlayersButton2.Name = "nPlayersButton2";
            this.nPlayersButton2.Size = new System.Drawing.Size(31, 17);
            this.nPlayersButton2.TabIndex = 2;
            this.nPlayersButton2.TabStop = true;
            this.nPlayersButton2.Text = "2";
            this.nPlayersButton2.UseVisualStyleBackColor = true;
            this.nPlayersButton2.CheckedChanged += new System.EventHandler(this.nPlayersButton2_CheckedChanged);
            // 
            // nPlayersButton3
            // 
            this.nPlayersButton3.AutoSize = true;
            this.nPlayersButton3.Location = new System.Drawing.Point(108, 34);
            this.nPlayersButton3.Name = "nPlayersButton3";
            this.nPlayersButton3.Size = new System.Drawing.Size(31, 17);
            this.nPlayersButton3.TabIndex = 3;
            this.nPlayersButton3.TabStop = true;
            this.nPlayersButton3.Text = "3";
            this.nPlayersButton3.UseVisualStyleBackColor = true;
            this.nPlayersButton3.CheckedChanged += new System.EventHandler(this.nPlayersButton3_CheckedChanged);
            // 
            // nPlayersButton4
            // 
            this.nPlayersButton4.AutoSize = true;
            this.nPlayersButton4.Location = new System.Drawing.Point(145, 34);
            this.nPlayersButton4.Name = "nPlayersButton4";
            this.nPlayersButton4.Size = new System.Drawing.Size(31, 17);
            this.nPlayersButton4.TabIndex = 4;
            this.nPlayersButton4.TabStop = true;
            this.nPlayersButton4.Text = "4";
            this.nPlayersButton4.UseVisualStyleBackColor = true;
            this.nPlayersButton4.CheckedChanged += new System.EventHandler(this.nPlayersButton4_CheckedChanged);
            // 
            // nPlayersButton5
            // 
            this.nPlayersButton5.AutoSize = true;
            this.nPlayersButton5.Location = new System.Drawing.Point(182, 34);
            this.nPlayersButton5.Name = "nPlayersButton5";
            this.nPlayersButton5.Size = new System.Drawing.Size(31, 17);
            this.nPlayersButton5.TabIndex = 5;
            this.nPlayersButton5.TabStop = true;
            this.nPlayersButton5.Text = "5";
            this.nPlayersButton5.UseVisualStyleBackColor = true;
            this.nPlayersButton5.CheckedChanged += new System.EventHandler(this.nPlayersButton5_CheckedChanged);
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(219, 31);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(83, 22);
            this.continueButton.TabIndex = 6;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 64);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.nPlayersButton5);
            this.Controls.Add(this.nPlayersButton4);
            this.Controls.Add(this.nPlayersButton3);
            this.Controls.Add(this.nPlayersButton2);
            this.Controls.Add(this.nPlayersButton1);
            this.Controls.Add(this.label1);
            this.Name = "SetupForm";
            this.Text = "Agricola Setup Phase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton nPlayersButton1;
        private System.Windows.Forms.RadioButton nPlayersButton2;
        private System.Windows.Forms.RadioButton nPlayersButton3;
        private System.Windows.Forms.RadioButton nPlayersButton4;
        private System.Windows.Forms.RadioButton nPlayersButton5;
        private System.Windows.Forms.Button continueButton;
    }
}