namespace Bacchus.MVC.View.FamillesView
{
    partial class ModifyFamille
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
            this.textBox_NewFamilleName = new System.Windows.Forms.TextBox();
            this.label_NewFamilleName = new System.Windows.Forms.Label();
            this.button_Modify = new System.Windows.Forms.Button();
            this.label_ModifyFamille = new System.Windows.Forms.Label();
            this.label_FamilleName = new System.Windows.Forms.Label();
            this.label_Famille_Name = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_Famille_Name);
            this.panel1.Controls.Add(this.button_Cancle);
            this.panel1.Controls.Add(this.textBox_NewFamilleName);
            this.panel1.Controls.Add(this.label_NewFamilleName);
            this.panel1.Controls.Add(this.button_Modify);
            this.panel1.Controls.Add(this.label_ModifyFamille);
            this.panel1.Controls.Add(this.label_FamilleName);
            this.panel1.Location = new System.Drawing.Point(35, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 244);
            this.panel1.TabIndex = 16;
            // 
            // button_Cancle
            // 
            this.button_Cancle.Location = new System.Drawing.Point(256, 182);
            this.button_Cancle.Name = "button_Cancle";
            this.button_Cancle.Size = new System.Drawing.Size(103, 34);
            this.button_Cancle.TabIndex = 17;
            this.button_Cancle.Text = "Cancle";
            this.button_Cancle.UseVisualStyleBackColor = true;
            this.button_Cancle.Click += new System.EventHandler(this.button_Cancle_Click);
            // 
            // textBox_NewFamilleName
            // 
            this.textBox_NewFamilleName.Location = new System.Drawing.Point(178, 132);
            this.textBox_NewFamilleName.Name = "textBox_NewFamilleName";
            this.textBox_NewFamilleName.Size = new System.Drawing.Size(244, 26);
            this.textBox_NewFamilleName.TabIndex = 16;
            // 
            // label_NewFamilleName
            // 
            this.label_NewFamilleName.AutoSize = true;
            this.label_NewFamilleName.Location = new System.Drawing.Point(15, 135);
            this.label_NewFamilleName.Name = "label_NewFamilleName";
            this.label_NewFamilleName.Size = new System.Drawing.Size(136, 20);
            this.label_NewFamilleName.TabIndex = 15;
            this.label_NewFamilleName.Text = "New FamilleName";
            // 
            // button_Modify
            // 
            this.button_Modify.Location = new System.Drawing.Point(89, 182);
            this.button_Modify.Name = "button_Modify";
            this.button_Modify.Size = new System.Drawing.Size(103, 34);
            this.button_Modify.TabIndex = 2;
            this.button_Modify.Text = "Modify";
            this.button_Modify.UseVisualStyleBackColor = true;
            this.button_Modify.Click += new System.EventHandler(this.button_Modify_Click);
            // 
            // label_ModifyFamille
            // 
            this.label_ModifyFamille.AutoSize = true;
            this.label_ModifyFamille.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ModifyFamille.Location = new System.Drawing.Point(14, 10);
            this.label_ModifyFamille.Name = "label_ModifyFamille";
            this.label_ModifyFamille.Size = new System.Drawing.Size(145, 25);
            this.label_ModifyFamille.TabIndex = 14;
            this.label_ModifyFamille.Text = "ModifyFamille";
            // 
            // label_FamilleName
            // 
            this.label_FamilleName.AutoSize = true;
            this.label_FamilleName.Location = new System.Drawing.Point(44, 68);
            this.label_FamilleName.Name = "label_FamilleName";
            this.label_FamilleName.Size = new System.Drawing.Size(101, 20);
            this.label_FamilleName.TabIndex = 0;
            this.label_FamilleName.Text = "FamilleName";
            // 
            // label_Famille_Name
            // 
            this.label_Famille_Name.AutoSize = true;
            this.label_Famille_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_Famille_Name.Location = new System.Drawing.Point(174, 68);
            this.label_Famille_Name.Name = "label_Famille_Name";
            this.label_Famille_Name.Size = new System.Drawing.Size(162, 22);
            this.label_Famille_Name.TabIndex = 18;
            this.label_Famille_Name.Text = "label_FamilleName";
            // 
            // ModifyFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 274);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModifyFamille";
            this.Text = "ModifyFamille";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Modify;
        private System.Windows.Forms.Label label_ModifyFamille;
        private System.Windows.Forms.Label label_FamilleName;
        internal System.Windows.Forms.TextBox textBox_NewFamilleName;
        private System.Windows.Forms.Label label_NewFamilleName;
        private System.Windows.Forms.Button button_Cancle;
        private System.Windows.Forms.Label label_Famille_Name;
    }
}