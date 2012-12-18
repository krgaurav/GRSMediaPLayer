namespace GRSPlayer
{
    partial class PlayList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayList));
            this.PlayListBox = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_PlaylistAdd = new System.Windows.Forms.Button();
            this.btn_PlaylistRemove = new System.Windows.Forms.Button();
            this.btn_PlaylistSave = new System.Windows.Forms.Button();
            this.btn_PlaylistShuffle = new System.Windows.Forms.Button();
            this.btn_PlaylistRepeat = new System.Windows.Forms.Button();
            this.PlayListName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayListBox
            // 
            this.PlayListBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PlayListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlayListBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayListBox.ForeColor = System.Drawing.Color.White;
            this.PlayListBox.FormattingEnabled = true;
            this.PlayListBox.HorizontalScrollbar = true;
            this.PlayListBox.Location = new System.Drawing.Point(2, 41);
            this.PlayListBox.Name = "PlayListBox";
            this.PlayListBox.ScrollAlwaysVisible = true;
            this.PlayListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PlayListBox.Size = new System.Drawing.Size(231, 403);
            this.PlayListBox.Sorted = true;
            this.PlayListBox.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.btn_PlaylistAdd);
            this.flowLayoutPanel1.Controls.Add(this.btn_PlaylistRemove);
            this.flowLayoutPanel1.Controls.Add(this.btn_PlaylistSave);
            this.flowLayoutPanel1.Controls.Add(this.btn_PlaylistShuffle);
            this.flowLayoutPanel1.Controls.Add(this.btn_PlaylistRepeat);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(238, 34);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // btn_PlaylistAdd
            // 
            this.btn_PlaylistAdd.AutoSize = true;
            this.btn_PlaylistAdd.BackgroundImage = global::GRSPlayer.Properties.Resources.add;
            this.btn_PlaylistAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_PlaylistAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_PlaylistAdd.Location = new System.Drawing.Point(3, 3);
            this.btn_PlaylistAdd.Name = "btn_PlaylistAdd";
            this.btn_PlaylistAdd.Size = new System.Drawing.Size(30, 30);
            this.btn_PlaylistAdd.TabIndex = 5;
            this.btn_PlaylistAdd.UseVisualStyleBackColor = true;
            this.btn_PlaylistAdd.Click += new System.EventHandler(this.btn_PlaylistAdd_Click);
            // 
            // btn_PlaylistRemove
            // 
            this.btn_PlaylistRemove.AutoSize = true;
            this.btn_PlaylistRemove.BackgroundImage = global::GRSPlayer.Properties.Resources.remove;
            this.btn_PlaylistRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_PlaylistRemove.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_PlaylistRemove.Location = new System.Drawing.Point(39, 3);
            this.btn_PlaylistRemove.Name = "btn_PlaylistRemove";
            this.btn_PlaylistRemove.Size = new System.Drawing.Size(30, 30);
            this.btn_PlaylistRemove.TabIndex = 8;
            this.btn_PlaylistRemove.UseVisualStyleBackColor = true;
            this.btn_PlaylistRemove.Click += new System.EventHandler(this.btn_PlaylistRemove_Click);
            // 
            // btn_PlaylistSave
            // 
            this.btn_PlaylistSave.AutoSize = true;
            this.btn_PlaylistSave.BackgroundImage = global::GRSPlayer.Properties.Resources.save;
            this.btn_PlaylistSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_PlaylistSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_PlaylistSave.Location = new System.Drawing.Point(75, 3);
            this.btn_PlaylistSave.Name = "btn_PlaylistSave";
            this.btn_PlaylistSave.Size = new System.Drawing.Size(30, 30);
            this.btn_PlaylistSave.TabIndex = 9;
            this.btn_PlaylistSave.UseVisualStyleBackColor = true;
            this.btn_PlaylistSave.Click += new System.EventHandler(this.btn_PlaylistSave_Click);
            // 
            // btn_PlaylistShuffle
            // 
            this.btn_PlaylistShuffle.AutoSize = true;
            this.btn_PlaylistShuffle.BackgroundImage = global::GRSPlayer.Properties.Resources.media_shuffle;
            this.btn_PlaylistShuffle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_PlaylistShuffle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_PlaylistShuffle.Location = new System.Drawing.Point(111, 3);
            this.btn_PlaylistShuffle.Name = "btn_PlaylistShuffle";
            this.btn_PlaylistShuffle.Size = new System.Drawing.Size(30, 30);
            this.btn_PlaylistShuffle.TabIndex = 7;
            this.btn_PlaylistShuffle.UseVisualStyleBackColor = true;
            // 
            // btn_PlaylistRepeat
            // 
            this.btn_PlaylistRepeat.AutoSize = true;
            this.btn_PlaylistRepeat.BackgroundImage = global::GRSPlayer.Properties.Resources.media_repeat;
            this.btn_PlaylistRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_PlaylistRepeat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_PlaylistRepeat.Location = new System.Drawing.Point(147, 3);
            this.btn_PlaylistRepeat.Name = "btn_PlaylistRepeat";
            this.btn_PlaylistRepeat.Size = new System.Drawing.Size(30, 30);
            this.btn_PlaylistRepeat.TabIndex = 6;
            this.btn_PlaylistRepeat.UseVisualStyleBackColor = true;
            // 
            // PlayListName
            // 
            this.PlayListName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PlayListName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayListName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.PlayListName.Location = new System.Drawing.Point(2, 450);
            this.PlayListName.Name = "PlayListName";
            this.PlayListName.Size = new System.Drawing.Size(139, 20);
            this.PlayListName.TabIndex = 10;
            this.PlayListName.Text = "Untitled";
            this.PlayListName.Click += new System.EventHandler(this.Enabled_Save);
            // 
            // PlayList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(238, 474);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.PlayListBox);
            this.Controls.Add(this.PlayListName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(400, 500);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PlayList";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_PlaylistAdd;
        private System.Windows.Forms.Button btn_PlaylistRepeat;
        private System.Windows.Forms.Button btn_PlaylistShuffle;
        private System.Windows.Forms.Button btn_PlaylistRemove;
        private System.Windows.Forms.Button btn_PlaylistSave;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.ListBox PlayListBox;
        private System.Windows.Forms.TextBox PlayListName;
    }
}