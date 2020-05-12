namespace Bacchus.MVC.View.MainView
{
    partial class FormImport
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
            this.button_ChoisirUnFichier = new System.Windows.Forms.Button();
            this.button_ModeEcrasement = new System.Windows.Forms.Button();
            this.button_ModeAjout = new System.Windows.Forms.Button();
            this.label_ImportCSV = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label_Progress = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_FichierImporte = new System.Windows.Forms.Label();
            this.label_NomDuFichier = new System.Windows.Forms.Label();
            this.label_Lancer = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ChoisirUnFichier
            // 
            this.button_ChoisirUnFichier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_ChoisirUnFichier.Location = new System.Drawing.Point(172, 71);
            this.button_ChoisirUnFichier.Name = "button_ChoisirUnFichier";
            this.button_ChoisirUnFichier.Size = new System.Drawing.Size(184, 38);
            this.button_ChoisirUnFichier.TabIndex = 0;
            this.button_ChoisirUnFichier.Text = "Choisir un fichier";
            this.button_ChoisirUnFichier.UseVisualStyleBackColor = true;
            this.button_ChoisirUnFichier.Click += new System.EventHandler(this.button_ChoisirUnFichier_Click);
            // 
            // button_ModeEcrasement
            // 
            this.button_ModeEcrasement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_ModeEcrasement.Location = new System.Drawing.Point(172, 163);
            this.button_ModeEcrasement.Name = "button_ModeEcrasement";
            this.button_ModeEcrasement.Size = new System.Drawing.Size(184, 36);
            this.button_ModeEcrasement.TabIndex = 1;
            this.button_ModeEcrasement.Text = "Mode écrasement";
            this.button_ModeEcrasement.UseVisualStyleBackColor = true;
            this.button_ModeEcrasement.Click += new System.EventHandler(this.button_ModeEcrasement_Click);
            // 
            // button_ModeAjout
            // 
            this.button_ModeAjout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_ModeAjout.Location = new System.Drawing.Point(386, 163);
            this.button_ModeAjout.Name = "button_ModeAjout";
            this.button_ModeAjout.Size = new System.Drawing.Size(182, 36);
            this.button_ModeAjout.TabIndex = 3;
            this.button_ModeAjout.Text = "Mode ajout";
            this.button_ModeAjout.UseVisualStyleBackColor = true;
            this.button_ModeAjout.Click += new System.EventHandler(this.button_ModeAjout_Click);
            // 
            // label_ImportCSV
            // 
            this.label_ImportCSV.AutoSize = true;
            this.label_ImportCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ImportCSV.Location = new System.Drawing.Point(26, 12);
            this.label_ImportCSV.Name = "label_ImportCSV";
            this.label_ImportCSV.Size = new System.Drawing.Size(147, 25);
            this.label_ImportCSV.TabIndex = 8;
            this.label_ImportCSV.Text = "IMPORT CSV";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(172, 236);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(396, 32);
            this.progressBar.TabIndex = 9;
            // 
            // label_Progress
            // 
            this.label_Progress.AutoSize = true;
            this.label_Progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_Progress.Location = new System.Drawing.Point(70, 236);
            this.label_Progress.Name = "label_Progress";
            this.label_Progress.Size = new System.Drawing.Size(82, 22);
            this.label_Progress.TabIndex = 13;
            this.label_Progress.Text = "Progress";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label_FichierImporte);
            this.panel1.Controls.Add(this.label_ImportCSV);
            this.panel1.Controls.Add(this.label_NomDuFichier);
            this.panel1.Controls.Add(this.label_Lancer);
            this.panel1.Controls.Add(this.button_ModeAjout);
            this.panel1.Controls.Add(this.button_ModeEcrasement);
            this.panel1.Controls.Add(this.button_ChoisirUnFichier);
            this.panel1.Controls.Add(this.label_Progress);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Location = new System.Drawing.Point(101, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 303);
            this.panel1.TabIndex = 14;
            // 
            // label_FichierImporte
            // 
            this.label_FichierImporte.AutoSize = true;
            this.label_FichierImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_FichierImporte.Location = new System.Drawing.Point(177, 127);
            this.label_FichierImporte.Name = "label_FichierImporte";
            this.label_FichierImporte.Size = new System.Drawing.Size(210, 22);
            this.label_FichierImporte.TabIndex = 17;
            this.label_FichierImporte.Text = "Aucun fichier a été choisi";
            // 
            // label_NomDuFichier
            // 
            this.label_NomDuFichier.AutoSize = true;
            this.label_NomDuFichier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_NomDuFichier.Location = new System.Drawing.Point(27, 79);
            this.label_NomDuFichier.Name = "label_NomDuFichier";
            this.label_NomDuFichier.Size = new System.Drawing.Size(125, 22);
            this.label_NomDuFichier.TabIndex = 16;
            this.label_NomDuFichier.Text = "Nom du fichier";
            // 
            // label_Lancer
            // 
            this.label_Lancer.AutoSize = true;
            this.label_Lancer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_Lancer.Location = new System.Drawing.Point(87, 170);
            this.label_Lancer.Name = "label_Lancer";
            this.label_Lancer.Size = new System.Drawing.Size(65, 22);
            this.label_Lancer.TabIndex = 15;
            this.label_Lancer.Text = "Lancer";
            // 
            // FormImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 494);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormImport";
            this.Text = "FormImport";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ChoisirUnFichier;
        private System.Windows.Forms.Button button_ModeEcrasement;
        private System.Windows.Forms.Button button_ModeAjout;
        private System.Windows.Forms.Label label_ImportCSV;
        internal System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label_Progress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Lancer;
        internal System.Windows.Forms.Label label_FichierImporte;
        private System.Windows.Forms.Label label_NomDuFichier;
    }
}