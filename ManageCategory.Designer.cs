namespace TEST
{
    partial class ManageCategory
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
            this.update = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.minimize = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // update
            // 
            this.update.BackColor = System.Drawing.SystemColors.ControlLight;
            this.update.FlatAppearance.BorderSize = 0;
            this.update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.update.Location = new System.Drawing.Point(491, 354);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(95, 39);
            this.update.TabIndex = 6;
            this.update.Text = "update";
            this.update.UseVisualStyleBackColor = false;
            this.update.Click += new System.EventHandler(this.update_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(343, 163);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(390, 171);
            this.dataGridView1.TabIndex = 5;
            // 
            // minimize
            // 
            this.minimize.AutoSize = true;
            this.minimize.BackColor = System.Drawing.Color.Transparent;
            this.minimize.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimize.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.minimize.Location = new System.Drawing.Point(711, -6);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(22, 29);
            this.minimize.TabIndex = 31;
            this.minimize.Text = "-";
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            // 
            // Exit
            // 
            this.Exit.AutoSize = true;
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Exit.Location = new System.Drawing.Point(739, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(24, 21);
            this.Exit.TabIndex = 30;
            this.Exit.Text = "X";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(381, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Categories";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(671, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 39);
            this.button1.TabIndex = 9;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::TEST.Properties.Resources.gyugu1;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(12, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 207);
            this.panel2.TabIndex = 68;
            // 
            // ManageCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 450);
            this.Controls.Add(this.minimize);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.update);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageCategory";
            this.Text = "Form7";
            this.Load += new System.EventHandler(this.ManageCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label minimize;
        private System.Windows.Forms.Label Exit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
    }
}