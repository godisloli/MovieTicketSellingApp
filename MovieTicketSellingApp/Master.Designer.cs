namespace MovieTicketSellingApp
{
    partial class Master
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
            this.addMoviesBtn = new System.Windows.Forms.Button();
            this.statusUpdateBtn = new System.Windows.Forms.Button();
            this.dataGenerateBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.runBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addMoviesBtn
            // 
            this.addMoviesBtn.Location = new System.Drawing.Point(12, 101);
            this.addMoviesBtn.Name = "addMoviesBtn";
            this.addMoviesBtn.Size = new System.Drawing.Size(346, 44);
            this.addMoviesBtn.TabIndex = 0;
            this.addMoviesBtn.Text = "Add Movie";
            this.addMoviesBtn.UseVisualStyleBackColor = true;
            this.addMoviesBtn.Click += new System.EventHandler(this.moviesBtn_Click);
            // 
            // statusUpdateBtn
            // 
            this.statusUpdateBtn.Location = new System.Drawing.Point(12, 151);
            this.statusUpdateBtn.Name = "statusUpdateBtn";
            this.statusUpdateBtn.Size = new System.Drawing.Size(346, 44);
            this.statusUpdateBtn.TabIndex = 1;
            this.statusUpdateBtn.Text = "Update Status";
            this.statusUpdateBtn.UseVisualStyleBackColor = true;
            this.statusUpdateBtn.Click += new System.EventHandler(this.statusUpdateBtn_Click);
            // 
            // dataGenerateBtn
            // 
            this.dataGenerateBtn.Location = new System.Drawing.Point(12, 201);
            this.dataGenerateBtn.Name = "dataGenerateBtn";
            this.dataGenerateBtn.Size = new System.Drawing.Size(346, 44);
            this.dataGenerateBtn.TabIndex = 2;
            this.dataGenerateBtn.Text = "Data Generate";
            this.dataGenerateBtn.UseVisualStyleBackColor = true;
            this.dataGenerateBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(12, 251);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(346, 44);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(75, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Master Controller";
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(12, 51);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(346, 44);
            this.runBtn.TabIndex = 5;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 305);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.dataGenerateBtn);
            this.Controls.Add(this.statusUpdateBtn);
            this.Controls.Add(this.addMoviesBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Master";
            this.Text = "Master";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addMoviesBtn;
        private System.Windows.Forms.Button statusUpdateBtn;
        private System.Windows.Forms.Button dataGenerateBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button runBtn;
    }
}