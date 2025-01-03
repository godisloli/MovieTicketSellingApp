namespace MovieTicketSellingApp
{
    partial class Menu
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
            this.logoutBtn = new System.Windows.Forms.Button();
            this.viewDetailsBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.movieListView = new System.Windows.Forms.ListView();
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.startTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searcherTxt = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(894, 533);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(55, 25);
            this.logoutBtn.TabIndex = 0;
            this.logoutBtn.Text = "Log Out";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // viewDetailsBtn
            // 
            this.viewDetailsBtn.Location = new System.Drawing.Point(18, 533);
            this.viewDetailsBtn.Name = "viewDetailsBtn";
            this.viewDetailsBtn.Size = new System.Drawing.Size(108, 25);
            this.viewDetailsBtn.TabIndex = 5;
            this.viewDetailsBtn.Text = "View Details";
            this.viewDetailsBtn.UseVisualStyleBackColor = true;
            this.viewDetailsBtn.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.vScrollBar1);
            this.groupBox1.Controls.Add(this.movieListView);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(943, 485);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(920, 19);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 460);
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // movieListView
            // 
            this.movieListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.title,
            this.startTime,
            this.endTime,
            this.tags,
            this.status});
            this.movieListView.HideSelection = false;
            this.movieListView.Location = new System.Drawing.Point(6, 19);
            this.movieListView.Name = "movieListView";
            this.movieListView.Size = new System.Drawing.Size(931, 460);
            this.movieListView.TabIndex = 0;
            this.movieListView.UseCompatibleStateImageBehavior = false;
            // 
            // title
            // 
            this.title.Text = "Title";
            // 
            // startTime
            // 
            this.startTime.Text = "Start Time";
            // 
            // endTime
            // 
            this.endTime.Text = "End Time";
            // 
            // tags
            // 
            this.tags.Text = "Tags";
            // 
            // status
            // 
            this.status.Text = "Status";
            // 
            // searcherTxt
            // 
            this.searcherTxt.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.searcherTxt.Location = new System.Drawing.Point(18, 16);
            this.searcherTxt.Name = "searcherTxt";
            this.searcherTxt.Size = new System.Drawing.Size(931, 20);
            this.searcherTxt.TabIndex = 7;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 584);
            this.Controls.Add(this.searcherTxt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.viewDetailsBtn);
            this.Controls.Add(this.logoutBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Text = "Menu";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button viewDetailsBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ListView movieListView;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.ColumnHeader startTime;
        private System.Windows.Forms.ColumnHeader endTime;
        private System.Windows.Forms.ColumnHeader tags;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.TextBox searcherTxt;
    }
}