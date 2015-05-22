namespace WebMediaManager.Views
{
    partial class VidForm
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
            this.pnlChat = new System.Windows.Forms.Panel();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.tbxSendMsg = new System.Windows.Forms.TextBox();
            this.tbxChat = new System.Windows.Forms.TextBox();
            this.wbbPlayer = new System.Windows.Forms.WebBrowser();
            this.pnlDescription = new System.Windows.Forms.Panel();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.btnSubscribes = new System.Windows.Forms.Button();
            this.wbbDescription = new System.Windows.Forms.WebBrowser();
            this.lblViews = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAddPlaylist = new System.Windows.Forms.Button();
            this.cbxPlaylist = new System.Windows.Forms.ComboBox();
            this.pnlChat.SuspendLayout();
            this.pnlDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChat
            // 
            this.pnlChat.Controls.Add(this.btnSendMsg);
            this.pnlChat.Controls.Add(this.tbxSendMsg);
            this.pnlChat.Controls.Add(this.tbxChat);
            this.pnlChat.Location = new System.Drawing.Point(726, 0);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(239, 789);
            this.pnlChat.TabIndex = 0;
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMsg.Location = new System.Drawing.Point(211, 740);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(25, 38);
            this.btnSendMsg.TabIndex = 2;
            this.btnSendMsg.Text = ">>";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // tbxSendMsg
            // 
            this.tbxSendMsg.Location = new System.Drawing.Point(4, 740);
            this.tbxSendMsg.Multiline = true;
            this.tbxSendMsg.Name = "tbxSendMsg";
            this.tbxSendMsg.Size = new System.Drawing.Size(202, 38);
            this.tbxSendMsg.TabIndex = 1;
            // 
            // tbxChat
            // 
            this.tbxChat.BackColor = System.Drawing.Color.White;
            this.tbxChat.Location = new System.Drawing.Point(0, 0);
            this.tbxChat.Multiline = true;
            this.tbxChat.Name = "tbxChat";
            this.tbxChat.ReadOnly = true;
            this.tbxChat.Size = new System.Drawing.Size(236, 734);
            this.tbxChat.TabIndex = 0;
            // 
            // wbbPlayer
            // 
            this.wbbPlayer.Location = new System.Drawing.Point(0, 0);
            this.wbbPlayer.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbbPlayer.Name = "wbbPlayer";
            this.wbbPlayer.ScrollBarsEnabled = false;
            this.wbbPlayer.Size = new System.Drawing.Size(724, 486);
            this.wbbPlayer.TabIndex = 1;
            // 
            // pnlDescription
            // 
            this.pnlDescription.Controls.Add(this.btnAddPlaylist);
            this.pnlDescription.Controls.Add(this.cbxPlaylist);
            this.pnlDescription.Controls.Add(this.btnAddCategory);
            this.pnlDescription.Controls.Add(this.cbxCategory);
            this.pnlDescription.Controls.Add(this.btnSubscribes);
            this.pnlDescription.Controls.Add(this.wbbDescription);
            this.pnlDescription.Controls.Add(this.lblViews);
            this.pnlDescription.Controls.Add(this.lblTitle);
            this.pnlDescription.Location = new System.Drawing.Point(0, 492);
            this.pnlDescription.Name = "pnlDescription";
            this.pnlDescription.Size = new System.Drawing.Size(724, 297);
            this.pnlDescription.TabIndex = 2;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCategory.Location = new System.Drawing.Point(282, 59);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(28, 23);
            this.btnAddCategory.TabIndex = 5;
            this.btnAddCategory.Text = "+";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // cbxCategory
            // 
            this.cbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(146, 60);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(131, 21);
            this.cbxCategory.TabIndex = 4;
            // 
            // btnSubscribes
            // 
            this.btnSubscribes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubscribes.Location = new System.Drawing.Point(12, 59);
            this.btnSubscribes.Name = "btnSubscribes";
            this.btnSubscribes.Size = new System.Drawing.Size(128, 23);
            this.btnSubscribes.TabIndex = 3;
            this.btnSubscribes.Text = "S\'abonner";
            this.btnSubscribes.UseVisualStyleBackColor = true;
            this.btnSubscribes.Click += new System.EventHandler(this.btnSubscribes_Click);
            // 
            // wbbDescription
            // 
            this.wbbDescription.Location = new System.Drawing.Point(12, 86);
            this.wbbDescription.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbbDescription.Name = "wbbDescription";
            this.wbbDescription.Size = new System.Drawing.Size(708, 208);
            this.wbbDescription.TabIndex = 2;
            // 
            // lblViews
            // 
            this.lblViews.AutoSize = true;
            this.lblViews.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViews.Location = new System.Drawing.Point(650, 59);
            this.lblViews.Name = "lblViews";
            this.lblViews.Size = new System.Drawing.Size(54, 19);
            this.lblViews.TabIndex = 1;
            this.lblViews.Text = "label1";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(9, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(711, 53);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            // 
            // btnAddPlaylist
            // 
            this.btnAddPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPlaylist.Location = new System.Drawing.Point(452, 61);
            this.btnAddPlaylist.Name = "btnAddPlaylist";
            this.btnAddPlaylist.Size = new System.Drawing.Size(28, 23);
            this.btnAddPlaylist.TabIndex = 7;
            this.btnAddPlaylist.Text = "+";
            this.btnAddPlaylist.UseVisualStyleBackColor = true;
            this.btnAddPlaylist.Click += new System.EventHandler(this.btnAddPlaylist_Click);
            // 
            // cbxPlaylist
            // 
            this.cbxPlaylist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPlaylist.FormattingEnabled = true;
            this.cbxPlaylist.Location = new System.Drawing.Point(316, 62);
            this.cbxPlaylist.Name = "cbxPlaylist";
            this.cbxPlaylist.Size = new System.Drawing.Size(131, 21);
            this.cbxPlaylist.TabIndex = 6;
            // 
            // VidForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(965, 790);
            this.Controls.Add(this.pnlDescription);
            this.Controls.Add(this.wbbPlayer);
            this.Controls.Add(this.pnlChat);
            this.Name = "VidForm";
            this.Text = "VidForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VidForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VidForm_FormClosed);
            this.pnlChat.ResumeLayout(false);
            this.pnlChat.PerformLayout();
            this.pnlDescription.ResumeLayout(false);
            this.pnlDescription.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.WebBrowser wbbPlayer;
        private System.Windows.Forms.Panel pnlDescription;
        private System.Windows.Forms.Label lblViews;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.Button btnSubscribes;
        private System.Windows.Forms.WebBrowser wbbDescription;
        private System.Windows.Forms.TextBox tbxChat;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox tbxSendMsg;
        private System.Windows.Forms.Button btnAddPlaylist;
        private System.Windows.Forms.ComboBox cbxPlaylist;
    }
}