namespace Syncoski.App.Controls
{
    partial class DataManagerControl
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
            this.lblOrigin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxServerPath = new System.Windows.Forms.TextBox();
            this.textBoxLocalPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblOrigin
            // 
            this.lblOrigin.AutoSize = true;
            this.lblOrigin.Location = new System.Drawing.Point(16, 13);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(44, 13);
            this.lblOrigin.TabIndex = 0;
            this.lblOrigin.Text = "lblOrigin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "lblOrigin";
            // 
            // textBoxServerPath
            // 
            this.textBoxServerPath.Location = new System.Drawing.Point(95, 10);
            this.textBoxServerPath.Name = "textBoxServerPath";
            this.textBoxServerPath.Size = new System.Drawing.Size(289, 20);
            this.textBoxServerPath.TabIndex = 4;
            // 
            // textBoxLocalPath
            // 
            this.textBoxLocalPath.Location = new System.Drawing.Point(95, 52);
            this.textBoxLocalPath.Name = "textBoxLocalPath";
            this.textBoxLocalPath.Size = new System.Drawing.Size(289, 20);
            this.textBoxLocalPath.TabIndex = 4;
            // 
            // DataManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxLocalPath);
            this.Controls.Add(this.textBoxServerPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOrigin);
            this.Name = "DataManagerControl";
            this.Size = new System.Drawing.Size(408, 94);
            this.Load += new System.EventHandler(this.DataManagerControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrigin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxServerPath;
        private System.Windows.Forms.TextBox textBoxLocalPath;
    }
}
