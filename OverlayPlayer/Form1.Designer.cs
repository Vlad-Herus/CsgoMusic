namespace OverlayPlayer
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.mVlume_bar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.mMenu_lbl = new System.Windows.Forms.Label();
            this.mMenu_txt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mVlume_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(18, 326);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1381, 544);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // mVlume_bar
            // 
            this.mVlume_bar.Location = new System.Drawing.Point(198, 0);
            this.mVlume_bar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mVlume_bar.Maximum = 100;
            this.mVlume_bar.Name = "mVlume_bar";
            this.mVlume_bar.Size = new System.Drawing.Size(537, 69);
            this.mVlume_bar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Volume";
            // 
            // mMenu_lbl
            // 
            this.mMenu_lbl.AutoSize = true;
            this.mMenu_lbl.Location = new System.Drawing.Point(78, 88);
            this.mMenu_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mMenu_lbl.Name = "mMenu_lbl";
            this.mMenu_lbl.Size = new System.Drawing.Size(135, 20);
            this.mMenu_lbl.TabIndex = 4;
            this.mMenu_lbl.Text = "Menu Folder Path";
            // 
            // mMenu_txt
            // 
            this.mMenu_txt.Location = new System.Drawing.Point(244, 83);
            this.mMenu_txt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mMenu_txt.Name = "mMenu_txt";
            this.mMenu_txt.Size = new System.Drawing.Size(488, 26);
            this.mMenu_txt.TabIndex = 6;
            this.mMenu_txt.TextChanged += new System.EventHandler(this.mMenu_txt_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 891);
            this.Controls.Add(this.mMenu_txt);
            this.Controls.Add(this.mMenu_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mVlume_bar);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mVlume_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TrackBar mVlume_bar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label mMenu_lbl;
        private System.Windows.Forms.TextBox mMenu_txt;
    }
}

