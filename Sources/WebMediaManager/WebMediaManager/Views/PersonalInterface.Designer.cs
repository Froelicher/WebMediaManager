namespace WebMediaManager
{
    partial class PersonalInterface
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlVideos = new System.Windows.Forms.Panel();
            this.pnlStreams = new System.Windows.Forms.Panel();
            this.pnlSite = new System.Windows.Forms.Panel();
            this.pnlContainers = new System.Windows.Forms.Panel();
            this.pnlLeft.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlContainers);
            this.pnlLeft.Controls.Add(this.pnlSite);
            this.pnlLeft.Location = new System.Drawing.Point(12, 12);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(191, 701);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnSearch);
            this.pnlHeader.Controls.Add(this.tbxSearch);
            this.pnlHeader.Location = new System.Drawing.Point(209, 12);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(828, 43);
            this.pnlHeader.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(497, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // tbxSearch
            // 
            this.tbxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSearch.Location = new System.Drawing.Point(204, 8);
            this.tbxSearch.Multiline = true;
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(287, 27);
            this.tbxSearch.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.label2);
            this.pnlContent.Controls.Add(this.label1);
            this.pnlContent.Controls.Add(this.pnlVideos);
            this.pnlContent.Controls.Add(this.pnlStreams);
            this.pnlContent.Location = new System.Drawing.Point(209, 61);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(828, 652);
            this.pnlContent.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last videos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Online streams";
            // 
            // pnlVideos
            // 
            this.pnlVideos.Location = new System.Drawing.Point(16, 287);
            this.pnlVideos.Name = "pnlVideos";
            this.pnlVideos.Size = new System.Drawing.Size(796, 349);
            this.pnlVideos.TabIndex = 1;
            // 
            // pnlStreams
            // 
            this.pnlStreams.Location = new System.Drawing.Point(16, 49);
            this.pnlStreams.Name = "pnlStreams";
            this.pnlStreams.Size = new System.Drawing.Size(796, 195);
            this.pnlStreams.TabIndex = 0;
            // 
            // pnlSite
            // 
            this.pnlSite.Location = new System.Drawing.Point(3, 3);
            this.pnlSite.Name = "pnlSite";
            this.pnlSite.Size = new System.Drawing.Size(185, 92);
            this.pnlSite.TabIndex = 0;
            // 
            // pnlContainers
            // 
            this.pnlContainers.Location = new System.Drawing.Point(3, 98);
            this.pnlContainers.Name = "pnlContainers";
            this.pnlContainers.Size = new System.Drawing.Size(185, 92);
            this.pnlContainers.TabIndex = 1;
            // 
            // PersonalInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1045, 725);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PersonalInterface";
            this.Text = "Form1";
            this.pnlLeft.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlVideos;
        private System.Windows.Forms.Panel pnlStreams;
        private System.Windows.Forms.Panel pnlContainers;
        private System.Windows.Forms.Panel pnlSite;
    }
}

