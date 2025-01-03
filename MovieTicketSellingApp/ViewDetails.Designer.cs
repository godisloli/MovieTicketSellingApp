namespace MovieTicketSellingApp
{
    partial class ViewDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nextBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.roomTxt = new System.Windows.Forms.TextBox();
            this.endTimeTxt = new System.Windows.Forms.TextBox();
            this.startTimeTxt = new System.Windows.Forms.TextBox();
            this.titleTxt = new System.Windows.Forms.TextBox();
            this.returnBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "End Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Room";
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(77, 250);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 5;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.roomTxt);
            this.groupBox1.Controls.Add(this.endTimeTxt);
            this.groupBox1.Controls.Add(this.startTimeTxt);
            this.groupBox1.Controls.Add(this.titleTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 222);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // roomTxt
            // 
            this.roomTxt.Location = new System.Drawing.Point(67, 158);
            this.roomTxt.Name = "roomTxt";
            this.roomTxt.ReadOnly = true;
            this.roomTxt.Size = new System.Drawing.Size(263, 20);
            this.roomTxt.TabIndex = 8;
            // 
            // endTimeTxt
            // 
            this.endTimeTxt.Location = new System.Drawing.Point(67, 109);
            this.endTimeTxt.Name = "endTimeTxt";
            this.endTimeTxt.ReadOnly = true;
            this.endTimeTxt.Size = new System.Drawing.Size(263, 20);
            this.endTimeTxt.TabIndex = 7;
            // 
            // startTimeTxt
            // 
            this.startTimeTxt.Location = new System.Drawing.Point(67, 63);
            this.startTimeTxt.Name = "startTimeTxt";
            this.startTimeTxt.ReadOnly = true;
            this.startTimeTxt.Size = new System.Drawing.Size(263, 20);
            this.startTimeTxt.TabIndex = 6;
            // 
            // titleTxt
            // 
            this.titleTxt.Location = new System.Drawing.Point(67, 20);
            this.titleTxt.Name = "titleTxt";
            this.titleTxt.ReadOnly = true;
            this.titleTxt.Size = new System.Drawing.Size(263, 20);
            this.titleTxt.TabIndex = 5;
            // 
            // returnBtn
            // 
            this.returnBtn.Location = new System.Drawing.Point(238, 250);
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.Size = new System.Drawing.Size(75, 23);
            this.returnBtn.TabIndex = 10;
            this.returnBtn.Text = "Return";
            this.returnBtn.UseVisualStyleBackColor = true;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // ViewDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 291);
            this.Controls.Add(this.returnBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nextBtn);
            this.Name = "ViewDetails";
            this.Text = "ViewDetails";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox roomTxt;
        private System.Windows.Forms.TextBox endTimeTxt;
        private System.Windows.Forms.TextBox startTimeTxt;
        private System.Windows.Forms.TextBox titleTxt;
        private System.Windows.Forms.Button returnBtn;
    }
}