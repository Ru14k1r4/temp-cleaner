namespace temp_cleaner
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnClean;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnClean = new Button();
            this.lblTitle = new Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Text = "Temp 資料夾清理工具";

            // btnClean
            this.btnClean.Text = "一鍵清理 %temp%";
            this.btnClean.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Bold);
            this.btnClean.Location = new Point(20, 55);
            this.btnClean.Size = new Size(300, 45);
            this.btnClean.BackColor = Color.FromArgb(0, 120, 215);
            this.btnClean.ForeColor = Color.White;
            this.btnClean.FlatStyle = FlatStyle.Flat;
            this.btnClean.Cursor = Cursors.Hand;
            this.btnClean.Click += new EventHandler(this.btnClean_Click);

            // Form1
            this.ClientSize = new Size(340, 120);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClean);
            this.Text = "Temp Cleaner";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}