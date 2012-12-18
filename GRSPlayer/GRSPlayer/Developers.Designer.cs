namespace GRSPlayer
{
    partial class Developers
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
            this.DeveloperContent = new System.Windows.Forms.RichTextBox();
            this.btn_sadik = new System.Windows.Forms.Button();
            this.btn_gaurav = new System.Windows.Forms.Button();
            this.btn_rakhi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeveloperContent
            // 
            this.DeveloperContent.BackColor = System.Drawing.Color.White;
            this.DeveloperContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DeveloperContent.CausesValidation = false;
            this.DeveloperContent.Location = new System.Drawing.Point(12, 43);
            this.DeveloperContent.Multiline = false;
            this.DeveloperContent.Name = "DeveloperContent";
            this.DeveloperContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.DeveloperContent.ShortcutsEnabled = false;
            this.DeveloperContent.Size = new System.Drawing.Size(368, 294);
            this.DeveloperContent.TabIndex = 0;
            this.DeveloperContent.Text = "";
            this.DeveloperContent.TextChanged += new System.EventHandler(this.DeveloperContent_TextChanged);
            // 
            // btn_sadik
            // 
            this.btn_sadik.BackColor = System.Drawing.SystemColors.Control;
            this.btn_sadik.FlatAppearance.BorderSize = 0;
            this.btn_sadik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sadik.Location = new System.Drawing.Point(12, 20);
            this.btn_sadik.Name = "btn_sadik";
            this.btn_sadik.Size = new System.Drawing.Size(75, 23);
            this.btn_sadik.TabIndex = 1;
            this.btn_sadik.Text = "Sadik";
            this.btn_sadik.UseVisualStyleBackColor = false;
            this.btn_sadik.Click += new System.EventHandler(this.btn_sadik_Click);
            // 
            // btn_gaurav
            // 
            this.btn_gaurav.FlatAppearance.BorderSize = 0;
            this.btn_gaurav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_gaurav.Location = new System.Drawing.Point(93, 20);
            this.btn_gaurav.Name = "btn_gaurav";
            this.btn_gaurav.Size = new System.Drawing.Size(75, 23);
            this.btn_gaurav.TabIndex = 2;
            this.btn_gaurav.Text = "Gaurav";
            this.btn_gaurav.UseVisualStyleBackColor = false;
            this.btn_gaurav.Click += new System.EventHandler(this.btn_gaurav_Click);
            // 
            // btn_rakhi
            // 
            this.btn_rakhi.FlatAppearance.BorderSize = 0;
            this.btn_rakhi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rakhi.Location = new System.Drawing.Point(174, 20);
            this.btn_rakhi.Name = "btn_rakhi";
            this.btn_rakhi.Size = new System.Drawing.Size(75, 23);
            this.btn_rakhi.TabIndex = 3;
            this.btn_rakhi.Text = "Rakhi";
            this.btn_rakhi.UseVisualStyleBackColor = false;
            this.btn_rakhi.Click += new System.EventHandler(this.btn_rakhi_Click);
            // 
            // Developers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(392, 348);
            this.Controls.Add(this.btn_rakhi);
            this.Controls.Add(this.btn_gaurav);
            this.Controls.Add(this.btn_sadik);
            this.Controls.Add(this.DeveloperContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Developers";
            this.ShowIcon = false;
            this.Text = "Developers";
            this.Load += new System.EventHandler(this.Developers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_sadik;
        private System.Windows.Forms.Button btn_gaurav;
        private System.Windows.Forms.Button btn_rakhi;
        public System.Windows.Forms.RichTextBox DeveloperContent;
    }
}