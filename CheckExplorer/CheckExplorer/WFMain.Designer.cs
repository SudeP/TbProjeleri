namespace CheckExplorer
{
    partial class WFMain
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
            this.TbxLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TbxLog
            // 
            this.TbxLog.BackColor = System.Drawing.Color.Black;
            this.TbxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbxLog.Font = new System.Drawing.Font("Consolas", 10F);
            this.TbxLog.ForeColor = System.Drawing.Color.White;
            this.TbxLog.Location = new System.Drawing.Point(0, 0);
            this.TbxLog.Multiline = true;
            this.TbxLog.Name = "TbxLog";
            this.TbxLog.ReadOnly = true;
            this.TbxLog.Size = new System.Drawing.Size(107, 16);
            this.TbxLog.TabIndex = 0;
            // 
            // WFMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(107, 16);
            this.Controls.Add(this.TbxLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WFMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Path Controller";
            this.Load += new System.EventHandler(this.WFMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbxLog;
    }
}