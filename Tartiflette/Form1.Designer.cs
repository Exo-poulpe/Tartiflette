namespace Tartiflette
{
    partial class Form1
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
            this.wbrView = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbrView
            // 
            this.wbrView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbrView.Location = new System.Drawing.Point(0, 0);
            this.wbrView.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrView.Name = "wbrView";
            this.wbrView.Size = new System.Drawing.Size(1069, 613);
            this.wbrView.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 613);
            this.Controls.Add(this.wbrView);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbrView;
    }
}