namespace PatientRegistrationService
{
    partial class DebugForm
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
            this.uxMessages = new System.Windows.Forms.TextBox();
            this.uxStop = new System.Windows.Forms.Button();
            this.uxStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxMessages
            // 
            this.uxMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxMessages.Location = new System.Drawing.Point(72, 77);
            this.uxMessages.Margin = new System.Windows.Forms.Padding(4);
            this.uxMessages.Multiline = true;
            this.uxMessages.Name = "uxMessages";
            this.uxMessages.ReadOnly = true;
            this.uxMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uxMessages.Size = new System.Drawing.Size(612, 440);
            this.uxMessages.TabIndex = 5;
            // 
            // uxStop
            // 
            this.uxStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxStop.Location = new System.Drawing.Point(72, 41);
            this.uxStop.Margin = new System.Windows.Forms.Padding(4);
            this.uxStop.Name = "uxStop";
            this.uxStop.Size = new System.Drawing.Size(613, 28);
            this.uxStop.TabIndex = 4;
            this.uxStop.Text = "Stop";
            this.uxStop.UseVisualStyleBackColor = true;
            // 
            // uxStart
            // 
            this.uxStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxStart.Location = new System.Drawing.Point(72, 6);
            this.uxStart.Margin = new System.Windows.Forms.Padding(4);
            this.uxStart.Name = "uxStart";
            this.uxStart.Size = new System.Drawing.Size(613, 28);
            this.uxStart.TabIndex = 3;
            this.uxStart.Text = "Start";
            this.uxStart.UseVisualStyleBackColor = true;
            this.uxStart.Click += new System.EventHandler(this.uxStart_Click);
            // 
            // debugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 530);
            this.Controls.Add(this.uxMessages);
            this.Controls.Add(this.uxStop);
            this.Controls.Add(this.uxStart);
            this.Name = "debugForm";
            this.Text = "debugForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxMessages;
        private System.Windows.Forms.Button uxStop;
        private System.Windows.Forms.Button uxStart;
    }
}