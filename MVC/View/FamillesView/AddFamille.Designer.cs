namespace Bacchus.MVC.View.FamillesView
{
    partial class AddFamille
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
            this.label_NewFamille = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Cancle = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.textBox_FamilleName = new System.Windows.Forms.TextBox();
            this.label_FamilleName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_NewFamille
            // 
            this.label_NewFamille.AutoSize = true;
            this.label_NewFamille.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NewFamille.Location = new System.Drawing.Point(14, 10);
            this.label_NewFamille.Name = "label_NewFamille";
            this.label_NewFamille.Size = new System.Drawing.Size(123, 25);
            this.label_NewFamille.TabIndex = 14;
            this.label_NewFamille.Text = "NewFamille";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Cancle);
            this.panel1.Controls.Add(this.button_Add);
            this.panel1.Controls.Add(this.label_NewFamille);
            this.panel1.Controls.Add(this.textBox_FamilleName);
            this.panel1.Controls.Add(this.label_FamilleName);
            this.panel1.Location = new System.Drawing.Point(46, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 192);
            this.panel1.TabIndex = 15;
            // 
            // button_Cancle
            // 
            this.button_Cancle.Location = new System.Drawing.Point(242, 125);
            this.button_Cancle.Name = "button_Cancle";
            this.button_Cancle.Size = new System.Drawing.Size(103, 34);
            this.button_Cancle.TabIndex = 15;
            this.button_Cancle.Text = "Cancle";
            this.button_Cancle.UseVisualStyleBackColor = true;
            this.button_Cancle.Click += new System.EventHandler(this.button_Cancle_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(84, 125);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(103, 34);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // textBox_FamilleName
            // 
            this.textBox_FamilleName.Location = new System.Drawing.Point(162, 62);
            this.textBox_FamilleName.Name = "textBox_FamilleName";
            this.textBox_FamilleName.Size = new System.Drawing.Size(244, 26);
            this.textBox_FamilleName.TabIndex = 1;
            // 
            // label_FamilleName
            // 
            this.label_FamilleName.AutoSize = true;
            this.label_FamilleName.Location = new System.Drawing.Point(36, 62);
            this.label_FamilleName.Name = "label_FamilleName";
            this.label_FamilleName.Size = new System.Drawing.Size(101, 20);
            this.label_FamilleName.TabIndex = 0;
            this.label_FamilleName.Text = "FamilleName";
            // 
            // AddFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 274);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddFamille";
            this.Text = "AddFamille";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_NewFamille;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Add;
        internal System.Windows.Forms.TextBox textBox_FamilleName;
        private System.Windows.Forms.Label label_FamilleName;
        private System.Windows.Forms.Button button_Cancle;
    }
}