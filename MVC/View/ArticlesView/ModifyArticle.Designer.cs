namespace Bacchus.MVC.View.ArticlesView
{
    partial class ModifyArticle
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
            this.label_ModifyArticle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_ReferenceArticle = new System.Windows.Forms.Label();
            this.comboBox_Famille = new System.Windows.Forms.ComboBox();
            this.label_NewFamille = new System.Windows.Forms.Label();
            this.comboBox_SousFamille = new System.Windows.Forms.ComboBox();
            this.comboBox_Marque = new System.Windows.Forms.ComboBox();
            this.button_Cancle = new System.Windows.Forms.Button();
            this.button_Modify = new System.Windows.Forms.Button();
            this.label_NewSousFamille = new System.Windows.Forms.Label();
            this.label_NewMarque = new System.Windows.Forms.Label();
            this.textBox_Quantite = new System.Windows.Forms.TextBox();
            this.label_NewQuantite = new System.Windows.Forms.Label();
            this.textBox_PrixHT = new System.Windows.Forms.TextBox();
            this.label_NewPrixHT = new System.Windows.Forms.Label();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.label_NewDescription = new System.Windows.Forms.Label();
            this.label_RefArticle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_ModifyArticle
            // 
            this.label_ModifyArticle.AutoSize = true;
            this.label_ModifyArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ModifyArticle.Location = new System.Drawing.Point(14, 11);
            this.label_ModifyArticle.Name = "label_ModifyArticle";
            this.label_ModifyArticle.Size = new System.Drawing.Size(137, 25);
            this.label_ModifyArticle.TabIndex = 14;
            this.label_ModifyArticle.Text = "ModifyArticle";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_ReferenceArticle);
            this.panel1.Controls.Add(this.comboBox_Famille);
            this.panel1.Controls.Add(this.label_NewFamille);
            this.panel1.Controls.Add(this.comboBox_SousFamille);
            this.panel1.Controls.Add(this.comboBox_Marque);
            this.panel1.Controls.Add(this.button_Cancle);
            this.panel1.Controls.Add(this.label_ModifyArticle);
            this.panel1.Controls.Add(this.button_Modify);
            this.panel1.Controls.Add(this.label_NewSousFamille);
            this.panel1.Controls.Add(this.label_NewMarque);
            this.panel1.Controls.Add(this.textBox_Quantite);
            this.panel1.Controls.Add(this.label_NewQuantite);
            this.panel1.Controls.Add(this.textBox_PrixHT);
            this.panel1.Controls.Add(this.label_NewPrixHT);
            this.panel1.Controls.Add(this.textBox_Description);
            this.panel1.Controls.Add(this.label_NewDescription);
            this.panel1.Controls.Add(this.label_RefArticle);
            this.panel1.Location = new System.Drawing.Point(29, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 466);
            this.panel1.TabIndex = 13;
            // 
            // label_ReferenceArticle
            // 
            this.label_ReferenceArticle.AutoSize = true;
            this.label_ReferenceArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_ReferenceArticle.Location = new System.Drawing.Point(165, 54);
            this.label_ReferenceArticle.Name = "label_ReferenceArticle";
            this.label_ReferenceArticle.Size = new System.Drawing.Size(136, 22);
            this.label_ReferenceArticle.TabIndex = 20;
            this.label_ReferenceArticle.Text = "label_RefArticle";
            // 
            // comboBox_Famille
            // 
            this.comboBox_Famille.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Famille.FormattingEnabled = true;
            this.comboBox_Famille.Location = new System.Drawing.Point(165, 335);
            this.comboBox_Famille.Name = "comboBox_Famille";
            this.comboBox_Famille.Size = new System.Drawing.Size(281, 28);
            this.comboBox_Famille.TabIndex = 19;
            this.comboBox_Famille.SelectedIndexChanged += new System.EventHandler(this.comboBox_Famille_SelectedIndexChanged);
            // 
            // label_NewFamille
            // 
            this.label_NewFamille.AutoSize = true;
            this.label_NewFamille.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_NewFamille.Location = new System.Drawing.Point(56, 336);
            this.label_NewFamille.Name = "label_NewFamille";
            this.label_NewFamille.Size = new System.Drawing.Size(103, 22);
            this.label_NewFamille.TabIndex = 18;
            this.label_NewFamille.Text = "NewFamille";
            // 
            // comboBox_SousFamille
            // 
            this.comboBox_SousFamille.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SousFamille.FormattingEnabled = true;
            this.comboBox_SousFamille.Location = new System.Drawing.Point(165, 382);
            this.comboBox_SousFamille.Name = "comboBox_SousFamille";
            this.comboBox_SousFamille.Size = new System.Drawing.Size(281, 28);
            this.comboBox_SousFamille.TabIndex = 17;
            // 
            // comboBox_Marque
            // 
            this.comboBox_Marque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Marque.FormattingEnabled = true;
            this.comboBox_Marque.Location = new System.Drawing.Point(165, 282);
            this.comboBox_Marque.Name = "comboBox_Marque";
            this.comboBox_Marque.Size = new System.Drawing.Size(281, 28);
            this.comboBox_Marque.TabIndex = 16;
            // 
            // button_Cancle
            // 
            this.button_Cancle.Location = new System.Drawing.Point(271, 433);
            this.button_Cancle.Name = "button_Cancle";
            this.button_Cancle.Size = new System.Drawing.Size(87, 30);
            this.button_Cancle.TabIndex = 15;
            this.button_Cancle.Text = "Cancle";
            this.button_Cancle.UseVisualStyleBackColor = true;
            this.button_Cancle.Click += new System.EventHandler(this.button_Cancle_Click);
            // 
            // button_Modify
            // 
            this.button_Modify.Location = new System.Drawing.Point(113, 433);
            this.button_Modify.Name = "button_Modify";
            this.button_Modify.Size = new System.Drawing.Size(87, 30);
            this.button_Modify.TabIndex = 12;
            this.button_Modify.Text = "Modify";
            this.button_Modify.UseVisualStyleBackColor = true;
            this.button_Modify.Click += new System.EventHandler(this.button_Modify_Click);
            // 
            // label_NewSousFamille
            // 
            this.label_NewSousFamille.AutoSize = true;
            this.label_NewSousFamille.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_NewSousFamille.Location = new System.Drawing.Point(15, 383);
            this.label_NewSousFamille.Name = "label_NewSousFamille";
            this.label_NewSousFamille.Size = new System.Drawing.Size(144, 22);
            this.label_NewSousFamille.TabIndex = 10;
            this.label_NewSousFamille.Text = "NewSousFamille";
            // 
            // label_NewMarque
            // 
            this.label_NewMarque.AutoSize = true;
            this.label_NewMarque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_NewMarque.Location = new System.Drawing.Point(53, 283);
            this.label_NewMarque.Name = "label_NewMarque";
            this.label_NewMarque.Size = new System.Drawing.Size(106, 22);
            this.label_NewMarque.TabIndex = 8;
            this.label_NewMarque.Text = "NewMarque";
            // 
            // textBox_Quantite
            // 
            this.textBox_Quantite.Location = new System.Drawing.Point(165, 226);
            this.textBox_Quantite.Name = "textBox_Quantite";
            this.textBox_Quantite.Size = new System.Drawing.Size(281, 26);
            this.textBox_Quantite.TabIndex = 7;
            // 
            // label_NewQuantite
            // 
            this.label_NewQuantite.AutoSize = true;
            this.label_NewQuantite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_NewQuantite.Location = new System.Drawing.Point(45, 227);
            this.label_NewQuantite.Name = "label_NewQuantite";
            this.label_NewQuantite.Size = new System.Drawing.Size(114, 22);
            this.label_NewQuantite.TabIndex = 6;
            this.label_NewQuantite.Text = "NewQuantite";
            // 
            // textBox_PrixHT
            // 
            this.textBox_PrixHT.Location = new System.Drawing.Point(165, 164);
            this.textBox_PrixHT.Name = "textBox_PrixHT";
            this.textBox_PrixHT.Size = new System.Drawing.Size(281, 26);
            this.textBox_PrixHT.TabIndex = 5;
            // 
            // label_NewPrixHT
            // 
            this.label_NewPrixHT.AutoSize = true;
            this.label_NewPrixHT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_NewPrixHT.Location = new System.Drawing.Point(57, 164);
            this.label_NewPrixHT.Name = "label_NewPrixHT";
            this.label_NewPrixHT.Size = new System.Drawing.Size(102, 22);
            this.label_NewPrixHT.TabIndex = 4;
            this.label_NewPrixHT.Text = "NewPrixHT";
            // 
            // textBox_Description
            // 
            this.textBox_Description.Location = new System.Drawing.Point(165, 107);
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(281, 26);
            this.textBox_Description.TabIndex = 3;
            // 
            // label_NewDescription
            // 
            this.label_NewDescription.AutoSize = true;
            this.label_NewDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_NewDescription.Location = new System.Drawing.Point(23, 107);
            this.label_NewDescription.Name = "label_NewDescription";
            this.label_NewDescription.Size = new System.Drawing.Size(136, 22);
            this.label_NewDescription.TabIndex = 2;
            this.label_NewDescription.Text = "NewDescription";
            // 
            // label_RefArticle
            // 
            this.label_RefArticle.AutoSize = true;
            this.label_RefArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_RefArticle.Location = new System.Drawing.Point(71, 54);
            this.label_RefArticle.Name = "label_RefArticle";
            this.label_RefArticle.Size = new System.Drawing.Size(88, 22);
            this.label_RefArticle.TabIndex = 0;
            this.label_RefArticle.Text = "RefArticle";
            // 
            // ModifyArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 494);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModifyArticle";
            this.Text = "ModifyArticle";
            this.Load += new System.EventHandler(this.ModifyArticle_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_ModifyArticle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Modify;
        private System.Windows.Forms.Label label_NewSousFamille;
        private System.Windows.Forms.Label label_NewMarque;
        private System.Windows.Forms.TextBox textBox_Quantite;
        private System.Windows.Forms.Label label_NewQuantite;
        private System.Windows.Forms.TextBox textBox_PrixHT;
        private System.Windows.Forms.Label label_NewPrixHT;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.Label label_NewDescription;
        private System.Windows.Forms.Label label_RefArticle;
        private System.Windows.Forms.Button button_Cancle;
        private System.Windows.Forms.ComboBox comboBox_SousFamille;
        private System.Windows.Forms.ComboBox comboBox_Marque;
        private System.Windows.Forms.ComboBox comboBox_Famille;
        private System.Windows.Forms.Label label_NewFamille;
        private System.Windows.Forms.Label label_ReferenceArticle;
    }
}