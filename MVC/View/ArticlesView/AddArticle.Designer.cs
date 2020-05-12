namespace Bacchus.MVC.View.ArticlesView
{
    partial class AddArticle
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
            this.label_RefArticle = new System.Windows.Forms.Label();
            this.textBox_RefArticle = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.comboBox_SousFamille = new System.Windows.Forms.ComboBox();
            this.button_Cancle = new System.Windows.Forms.Button();
            this.comboBox_Marque = new System.Windows.Forms.ComboBox();
            this.label_NewArticle = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.label_SousFamille = new System.Windows.Forms.Label();
            this.label_Marque = new System.Windows.Forms.Label();
            this.textBox_Quantite = new System.Windows.Forms.TextBox();
            this.label_Quantite = new System.Windows.Forms.Label();
            this.textBox_PrixHT = new System.Windows.Forms.TextBox();
            this.label_PrixHT = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label_Description = new System.Windows.Forms.Label();
            this.label_Famille = new System.Windows.Forms.Label();
            this.comboBox_Famille = new System.Windows.Forms.ComboBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_RefArticle
            // 
            this.label_RefArticle.AutoSize = true;
            this.label_RefArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_RefArticle.Location = new System.Drawing.Point(47, 48);
            this.label_RefArticle.Name = "label_RefArticle";
            this.label_RefArticle.Size = new System.Drawing.Size(88, 22);
            this.label_RefArticle.TabIndex = 0;
            this.label_RefArticle.Text = "RefArticle";
            // 
            // textBox_RefArticle
            // 
            this.textBox_RefArticle.Location = new System.Drawing.Point(155, 48);
            this.textBox_RefArticle.Name = "textBox_RefArticle";
            this.textBox_RefArticle.Size = new System.Drawing.Size(281, 26);
            this.textBox_RefArticle.TabIndex = 1;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.comboBox_Famille);
            this.panel.Controls.Add(this.label_Famille);
            this.panel.Controls.Add(this.comboBox_SousFamille);
            this.panel.Controls.Add(this.button_Cancle);
            this.panel.Controls.Add(this.comboBox_Marque);
            this.panel.Controls.Add(this.label_NewArticle);
            this.panel.Controls.Add(this.button_Add);
            this.panel.Controls.Add(this.label_SousFamille);
            this.panel.Controls.Add(this.label_Marque);
            this.panel.Controls.Add(this.textBox_Quantite);
            this.panel.Controls.Add(this.label_Quantite);
            this.panel.Controls.Add(this.textBox_PrixHT);
            this.panel.Controls.Add(this.label_PrixHT);
            this.panel.Controls.Add(this.textBoxDescription);
            this.panel.Controls.Add(this.label_Description);
            this.panel.Controls.Add(this.label_RefArticle);
            this.panel.Controls.Add(this.textBox_RefArticle);
            this.panel.Location = new System.Drawing.Point(27, 22);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(470, 460);
            this.panel.TabIndex = 2;
            // 
            // comboBox_SousFamille
            // 
            this.comboBox_SousFamille.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SousFamille.FormattingEnabled = true;
            this.comboBox_SousFamille.Location = new System.Drawing.Point(155, 378);
            this.comboBox_SousFamille.Name = "comboBox_SousFamille";
            this.comboBox_SousFamille.Size = new System.Drawing.Size(281, 28);
            this.comboBox_SousFamille.TabIndex = 14;
            // 
            // button_Cancle
            // 
            this.button_Cancle.Location = new System.Drawing.Point(261, 427);
            this.button_Cancle.Name = "button_Cancle";
            this.button_Cancle.Size = new System.Drawing.Size(94, 30);
            this.button_Cancle.TabIndex = 13;
            this.button_Cancle.Text = "Cancle";
            this.button_Cancle.UseVisualStyleBackColor = true;
            this.button_Cancle.Click += new System.EventHandler(this.button_Cancle_Click);
            // 
            // comboBox_Marque
            // 
            this.comboBox_Marque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Marque.FormattingEnabled = true;
            this.comboBox_Marque.Location = new System.Drawing.Point(155, 275);
            this.comboBox_Marque.Name = "comboBox_Marque";
            this.comboBox_Marque.Size = new System.Drawing.Size(281, 28);
            this.comboBox_Marque.TabIndex = 3;
            // 
            // label_NewArticle
            // 
            this.label_NewArticle.AutoSize = true;
            this.label_NewArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NewArticle.Location = new System.Drawing.Point(3, 10);
            this.label_NewArticle.Name = "label_NewArticle";
            this.label_NewArticle.Size = new System.Drawing.Size(115, 25);
            this.label_NewArticle.TabIndex = 12;
            this.label_NewArticle.Text = "NewArticle";
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(119, 427);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(94, 30);
            this.button_Add.TabIndex = 12;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // label_SousFamille
            // 
            this.label_SousFamille.AutoSize = true;
            this.label_SousFamille.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_SousFamille.Location = new System.Drawing.Point(27, 379);
            this.label_SousFamille.Name = "label_SousFamille";
            this.label_SousFamille.Size = new System.Drawing.Size(108, 22);
            this.label_SousFamille.TabIndex = 10;
            this.label_SousFamille.Text = "SousFamille";
            // 
            // label_Marque
            // 
            this.label_Marque.AutoSize = true;
            this.label_Marque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_Marque.Location = new System.Drawing.Point(65, 275);
            this.label_Marque.Name = "label_Marque";
            this.label_Marque.Size = new System.Drawing.Size(70, 22);
            this.label_Marque.TabIndex = 8;
            this.label_Marque.Text = "Marque";
            // 
            // textBox_Quantite
            // 
            this.textBox_Quantite.Location = new System.Drawing.Point(155, 220);
            this.textBox_Quantite.Name = "textBox_Quantite";
            this.textBox_Quantite.Size = new System.Drawing.Size(281, 26);
            this.textBox_Quantite.TabIndex = 7;
            // 
            // label_Quantite
            // 
            this.label_Quantite.AutoSize = true;
            this.label_Quantite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_Quantite.Location = new System.Drawing.Point(57, 221);
            this.label_Quantite.Name = "label_Quantite";
            this.label_Quantite.Size = new System.Drawing.Size(78, 22);
            this.label_Quantite.TabIndex = 6;
            this.label_Quantite.Text = "Quantite";
            // 
            // textBox_PrixHT
            // 
            this.textBox_PrixHT.Location = new System.Drawing.Point(155, 159);
            this.textBox_PrixHT.Name = "textBox_PrixHT";
            this.textBox_PrixHT.Size = new System.Drawing.Size(281, 26);
            this.textBox_PrixHT.TabIndex = 5;
            // 
            // label_PrixHT
            // 
            this.label_PrixHT.AutoSize = true;
            this.label_PrixHT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_PrixHT.Location = new System.Drawing.Point(69, 159);
            this.label_PrixHT.Name = "label_PrixHT";
            this.label_PrixHT.Size = new System.Drawing.Size(66, 22);
            this.label_PrixHT.TabIndex = 4;
            this.label_PrixHT.Text = "PrixHT";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(155, 102);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(281, 26);
            this.textBoxDescription.TabIndex = 3;
            // 
            // label_Description
            // 
            this.label_Description.AutoSize = true;
            this.label_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_Description.Location = new System.Drawing.Point(35, 102);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(100, 22);
            this.label_Description.TabIndex = 2;
            this.label_Description.Text = "Description";
            // 
            // label_Famille
            // 
            this.label_Famille.AutoSize = true;
            this.label_Famille.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_Famille.Location = new System.Drawing.Point(65, 332);
            this.label_Famille.Name = "label_Famille";
            this.label_Famille.Size = new System.Drawing.Size(67, 22);
            this.label_Famille.TabIndex = 15;
            this.label_Famille.Text = "Famille";
            // 
            // comboBox_Famille
            // 
            this.comboBox_Famille.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Famille.FormattingEnabled = true;
            this.comboBox_Famille.Location = new System.Drawing.Point(155, 326);
            this.comboBox_Famille.Name = "comboBox_Famille";
            this.comboBox_Famille.Size = new System.Drawing.Size(281, 28);
            this.comboBox_Famille.TabIndex = 16;
            this.comboBox_Famille.SelectedIndexChanged += new System.EventHandler(this.comboBox_Famille_SelectedIndexChanged);
            // 
            // AddArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 494);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddArticle";
            this.Text = "AddArticle";
            this.Load += new System.EventHandler(this.AddArticle_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_RefArticle;
        private System.Windows.Forms.TextBox textBox_RefArticle;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label_SousFamille;
        private System.Windows.Forms.Label label_Marque;
        private System.Windows.Forms.TextBox textBox_Quantite;
        private System.Windows.Forms.Label label_Quantite;
        private System.Windows.Forms.TextBox textBox_PrixHT;
        private System.Windows.Forms.Label label_PrixHT;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label_NewArticle;
        private System.Windows.Forms.Button button_Cancle;
        private System.Windows.Forms.ComboBox comboBox_Marque;
        private System.Windows.Forms.ComboBox comboBox_SousFamille;
        private System.Windows.Forms.ComboBox comboBox_Famille;
        private System.Windows.Forms.Label label_Famille;
    }
}