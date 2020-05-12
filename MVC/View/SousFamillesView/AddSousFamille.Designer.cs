namespace Bacchus.MVC.View.SousFamillesView
{
    partial class AddSousFamille
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
            this.label_Famille_Name = new System.Windows.Forms.Label();
            this.button_Cancle = new System.Windows.Forms.Button();
            this.textBox_SousFamilleName = new System.Windows.Forms.TextBox();
            this.label_SousFamilleName = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.label_NewSousFamille = new System.Windows.Forms.Label();
            this.label_FamilleName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_Famille_Name);
            this.panel1.Controls.Add(this.button_Cancle);
            this.panel1.Controls.Add(this.textBox_SousFamilleName);
            this.panel1.Controls.Add(this.label_SousFamilleName);
            this.panel1.Controls.Add(this.button_Add);
            this.panel1.Controls.Add(this.label_NewSousFamille);
            this.panel1.Controls.Add(this.label_FamilleName);
            this.panel1.Location = new System.Drawing.Point(36, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 234);
            this.panel1.TabIndex = 16;
            // 
            // label_Famille_Name
            // 
            this.label_Famille_Name.AutoSize = true;
            this.label_Famille_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_Famille_Name.Location = new System.Drawing.Point(176, 62);
            this.label_Famille_Name.Name = "label_Famille_Name";
            this.label_Famille_Name.Size = new System.Drawing.Size(162, 22);
            this.label_Famille_Name.TabIndex = 18;
            this.label_Famille_Name.Text = "label_FamilleName";
            // 
            // button_Cancle
            // 
            this.button_Cancle.Location = new System.Drawing.Point(254, 179);
            this.button_Cancle.Name = "button_Cancle";
            this.button_Cancle.Size = new System.Drawing.Size(103, 34);
            this.button_Cancle.TabIndex = 17;
            this.button_Cancle.Text = "Cancle";
            this.button_Cancle.UseVisualStyleBackColor = true;
            this.button_Cancle.Click += new System.EventHandler(this.button_Cancle_Click);
            // 
            // textBox_SousFamilleName
            // 
            this.textBox_SousFamilleName.Location = new System.Drawing.Point(180, 116);
            this.textBox_SousFamilleName.Name = "textBox_SousFamilleName";
            this.textBox_SousFamilleName.Size = new System.Drawing.Size(244, 26);
            this.textBox_SousFamilleName.TabIndex = 16;
            // 
            // label_SousFamilleName
            // 
            this.label_SousFamilleName.AutoSize = true;
            this.label_SousFamilleName.Location = new System.Drawing.Point(15, 116);
            this.label_SousFamilleName.Name = "label_SousFamilleName";
            this.label_SousFamilleName.Size = new System.Drawing.Size(138, 20);
            this.label_SousFamilleName.TabIndex = 15;
            this.label_SousFamilleName.Text = "SousFamilleName";
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(99, 179);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(103, 34);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // label_NewSousFamille
            // 
            this.label_NewSousFamille.AutoSize = true;
            this.label_NewSousFamille.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NewSousFamille.Location = new System.Drawing.Point(14, 10);
            this.label_NewSousFamille.Name = "label_NewSousFamille";
            this.label_NewSousFamille.Size = new System.Drawing.Size(173, 25);
            this.label_NewSousFamille.TabIndex = 14;
            this.label_NewSousFamille.Text = "NewSousFamille";
            // 
            // label_FamilleName
            // 
            this.label_FamilleName.AutoSize = true;
            this.label_FamilleName.Location = new System.Drawing.Point(52, 62);
            this.label_FamilleName.Name = "label_FamilleName";
            this.label_FamilleName.Size = new System.Drawing.Size(101, 20);
            this.label_FamilleName.TabIndex = 0;
            this.label_FamilleName.Text = "FamilleName";
            // 
            // AddSousFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 274);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddSousFamille";
            this.Text = "AddSousFamille";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label_NewSousFamille;
        private System.Windows.Forms.Label label_FamilleName;
        internal System.Windows.Forms.TextBox textBox_SousFamilleName;
        private System.Windows.Forms.Label label_SousFamilleName;
        private System.Windows.Forms.Button button_Cancle;
        internal System.Windows.Forms.Label label_Famille_Name;
    }
}