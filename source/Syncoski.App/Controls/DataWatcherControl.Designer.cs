namespace Syncoski.App.Controls
{
    partial class DataWatcherControl
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
            this.textBoxSelectedPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.actionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSelectedPath
            // 
            this.textBoxSelectedPath.Location = new System.Drawing.Point(70, 25);
            this.textBoxSelectedPath.Name = "textBoxSelectedPath";
            this.textBoxSelectedPath.Size = new System.Drawing.Size(249, 20);
            this.textBoxSelectedPath.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Path:";
            // 
            // actionButton
            // 
            this.actionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.actionButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.actionButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.actionButton.Location = new System.Drawing.Point(325, 17);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(55, 35);
            this.actionButton.TabIndex = 4;
            this.actionButton.Text = "button1";
            this.actionButton.UseVisualStyleBackColor = false;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);
            // 
            // DataWatcherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxSelectedPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.actionButton);
            this.Name = "DataWatcherControl";
            this.Size = new System.Drawing.Size(400, 69);
            this.Load += new System.EventHandler(this.DataWatcherControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSelectedPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button actionButton;
    }
}
