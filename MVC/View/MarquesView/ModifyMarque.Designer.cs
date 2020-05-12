namespace Bacchus.MVC.View.MarquesView
{
    partial class ModifyMarque
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Cancle = new System.Windows.Forms.Button();
            this.textBox_NewMarqueName = new System.Windows.Forms.TextBox();
            this.label_NewMarqueName = new System.Windows.Forms.Label();
            this.button_Modify = new System.Windows.Forms.Button();
            this.label_ModifyMarque = new System.Windows.Forms.Label();
            this.label_MarqueName = new System.Windows.Forms.Label();
            this.label_Marque_Name = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_Marque_Name);
            this.panel1.Controls.Add(this.button_Cancle);
            this.panel1.Controls.Add(this.textBox_NewMarqueName);
            this.panel1.Controls.Add(this.label_NewMarqueName);
            this.panel1.Controls.Add(this.button_Modify);
            this.panel1.Controls.Add(this.label_ModifyMarque);
            this.panel1.Controls.Add(this.label_MarqueName);
            this.panel1.Location = new System.Drawing.Point(36, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 244);
            this.panel1.TabIndex = 17;
            // 
            // button_Cancle
            // 
            this.button_Cancle.Location = new System.Drawing.Point(263, 182);
            this.button_Cancle.Name = "button_Cancle";
            this.button_Cancle.Size = new System.Drawing.Size(103, 34);
            this.button_Cancle.TabIndex = 17;
            this.button_Cancle.Text = "Cancle";
            this.button_Cancle.UseVisualStyleBackColor = true;
            this.button_Cancle.Click += new System.EventHandler(this.button_Cancle_Click);
            // 
            // textBox_NewMarqueName
            // 
            this.textBox_NewMarqueName.Location = new System.Drawing.Point(178, 132);
            this.textBox_NewMarqueName.Name = "textBox_NewMarqueName";
            this.textBox_NewMarqueName.Size = new System.Drawing.Size(244, 26);
            this.textBox_NewMarqueName.TabIndex = 16;
            // 
            // label_NewMarqueName
            // 
            this.label_NewMarqueName.AutoSize = true;
            this.label_NewMarqueName.Location = new System.Drawing.Point(9, 135);
            this.label_NewMarqueName.Name = "label_NewMarqueName";
            this.label_NewMarqueName.Size = new System.Drawing.Size(140, 20);
            this.label_NewMarqueName.TabIndex = 15;
            this.label_NewMarqueName.Text = "New MarqueName";
            // 
            // button_Modify
            // 
            this.button_Modify.Location = new System.Drawing.Point(87, 182);
            this.button_Modify.Name = "button_Modify";
            this.button_Modify.Size = new System.Drawing.Size(103, 34);
            this.button_Modify.TabIndex = 2;
            this.button_Modify.Text = "Modify";
            this.button_Modify.UseVisualStyleBackColor = true;
            this.button_Modify.Click += new System.EventHandler(this.button_Modify_Click);
            // 
            // label_ModifyMarque
            // 
            this.label_ModifyMarque.AutoSize = true;
            this.label_ModifyMarque.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ModifyMarque.Location = new System.Drawing.Point(14, 10);
            this.label_ModifyMarque.Name = "label_ModifyMarque";
            this.label_ModifyMarque.Size = new System.Drawing.Size(149, 25);
            this.label_ModifyMarque.TabIndex = 14;
            this.label_ModifyMarque.Text = "ModifyMarque";
            // 
            // label_MarqueName
            // 
            this.label_MarqueName.AutoSize = true;
            this.label_MarqueName.Location = new System.Drawing.Point(44, 68);
            this.label_MarqueName.Name = "label_MarqueName";
            this.label_MarqueName.Size = new System.Drawing.Size(105, 20);
            this.label_MarqueName.TabIndex = 0;
            this.label_MarqueName.Text = "MarqueName";
            // 
            // label_Marque_Name
            // 
            this.label_Marque_Name.AutoSize = true;
            this.label_Marque_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_Marque_Name.Location = new System.Drawing.Point(174, 68);
            this.label_Marque_Name.Name = "label_Marque_Name";
            this.label_Marque_Name.Size = new System.Drawing.Size(165, 22);
            this.label_Marque_Name.TabIndex = 18;
            this.label_Marque_Name.Text = "label_MarqueName";
            // 
            // ModifyMarque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 274);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModifyMarque";
            this.Text = "DeleteMarque";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.TextBox textBox_NewMarqueName;
        private System.Windows.Forms.Label label_NewMarqueName;
        private System.Windows.Forms.Button button_Modify;
        private System.Windows.Forms.Label label_ModifyMarque;
        private System.Windows.Forms.Label label_MarqueName;
        private System.Windows.Forms.Button button_Cancle;
        private System.Windows.Forms.Label label_Marque_Name;
    }
}