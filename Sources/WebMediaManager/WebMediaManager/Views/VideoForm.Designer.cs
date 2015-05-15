namespace WebMediaManager.Views
{
    partial class VideoForm
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.cmbb = new System.Windows.Forms.ComboBox();
            this.lblView = new System.Windows.Forms.Label();
            this.pnlDescription = new System.Windows.Forms.Panel();
            this.btnAddContainers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(3, 2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(707, 530);
            this.webBrowser1.TabIndex = 0;
            // 
            // pnlChat
            // 
            this.pnlChat.Location = new System.Drawing.Point(716, 2);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(231, 707);
            this.pnlChat.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 535);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(698, 48);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "label1";
            // 
            // btn
            // 
            this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn.Location = new System.Drawing.Point(16, 587);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 23);
            this.btn.TabIndex = 3;
            this.btn.Text = "S\'abonner";
            this.btn.UseVisualStyleBackColor = true;
            // 
            // cmbb
            // 
            this.cmbb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbb.FormattingEnabled = true;
            this.cmbb.Location = new System.Drawing.Point(113, 587);
            this.cmbb.Name = "cmbb";
            this.cmbb.Size = new System.Drawing.Size(121, 21);
            this.cmbb.TabIndex = 4;
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblView.Location = new System.Drawing.Point(645, 583);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(65, 22);
            this.lblView.TabIndex = 5;
            this.lblView.Text = "label1";
            // 
            // pnlDescription
            // 
            this.pnlDescription.Location = new System.Drawing.Point(12, 616);
            this.pnlDescription.Name = "pnlDescription";
            this.pnlDescription.Size = new System.Drawing.Size(694, 93);
            this.pnlDescription.TabIndex = 6;
            // 
            // btnAddContainers
            // 
            this.btnAddContainers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddContainers.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddContainers.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddContainers.Location = new System.Drawing.Point(240, 585);
            this.btnAddContainers.Name = "btnAddContainers";
            this.btnAddContainers.Size = new System.Drawing.Size(51, 23);
            this.btnAddContainers.TabIndex = 7;
            this.btnAddContainers.Text = "Add";
            this.btnAddContainers.UseVisualStyleBackColor = true;
            // 
            // VideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(949, 710);
            this.Controls.Add(this.btnAddContainers);
            this.Controls.Add(this.pnlDescription);
            this.Controls.Add(this.lblView);
            this.Controls.Add(this.cmbb);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.webBrowser1);
            this.Name = "VideoForm";
            this.Text = "VideoForm";
            this.Load += new System.EventHandler(this.VideoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.ComboBox cmbb;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.Panel pnlDescription;
        private System.Windows.Forms.Button btnAddContainers;
    }
}