namespace Runner
{
    partial class TextConsole
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
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // consoleBox
            // 
            this.consoleBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.consoleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleBox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.consoleBox.Location = new System.Drawing.Point(0, 0);
            this.consoleBox.MaxLength = 1000000;
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleBox.Size = new System.Drawing.Size(635, 673);
            this.consoleBox.TabIndex = 0;
            // 
            // Console
            // 
            this.ClientSize = new System.Drawing.Size(635, 673);
            this.Controls.Add(this.consoleBox);
            this.Name = "Console";
            this.Text = "Console";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox consoleBox;
    }
}