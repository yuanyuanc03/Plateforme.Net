namespace Bacchus.MVC.View.MainView
{
    partial class FormExport
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
            this.label_FichierExporte = new System.Windows.Forms.Label();
            this.label_ExportCSV = new System.Windows.Forms.Label();
            this.label_NomDuFichier = new System.Windows.Forms.Label();
            this.label_Export = new System.Windows.Forms.Label();
            this.button_ExportToFichier = new System.Windows.Forms.Button();
            this.button_ChoisirUnFichier = new System.Windows.Forms.Button();
            this.label_Progress = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label_FichierExporte);
            this.panel1.Controls.Add(this.label_ExportCSV);
            this.panel1.Controls.Add(this.label_NomDuFichier);
            this.panel1.Controls.Add(this.label_Export);
            this.panel1.Controls.Add(this.button_ExportToFichier);
            this.panel1.Controls.Add(this.button_ChoisirUnFichier);
            this.panel1.Controls.Add(this.label_Progress);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Location = new System.Drawing.Point(98, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 303);
            this.panel1.TabIndex = 15;
            // 
            // label_FichierExporte
            // 
            this.label_FichierExporte.AutoSize = true;
            this.label_FichierExporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_FichierExporte.Location = new System.Drawing.Point(178, 128);
            this.label_FichierExporte.Name = "label_FichierExporte";
            this.label_FichierExporte.Size = new System.Drawing.Size(210, 22);
            this.label_FichierExporte.TabIndex = 17;
            this.label_FichierExporte.Text = "Aucun fichier a été choisi";
            // 
            // label_ExportCSV
            // 
            this.label_ExportCSV.AutoSize = true;
            this.label_ExportCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ExportCSV.Location = new System.Drawing.Point(26, 12);
            this.label_ExportCSV.Name = "label_ExportCSV";
            this.label_ExportCSV.Size = new System.Drawing.Size(152, 25);
            this.label_ExportCSV.TabIndex = 8;
            this.label_ExportCSV.Text = "EXPORT CSV";
            // 
            // label_NomDuFichier
            // 
            this.label_NomDuFichier.AutoSize = true;
            this.label_NomDuFichier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_NomDuFichier.Location = new System.Drawing.Point(27, 80);
            this.label_NomDuFichier.Name = "label_NomDuFichier";
            this.label_NomDuFichier.Size = new System.Drawing.Size(125, 22);
            this.label_NomDuFichier.TabIndex = 16;
            this.label_NomDuFichier.Text = "Nom du fichier";
            // 
            // label_Export
            // 
            this.label_Export.AutoSize = true;
            this.label_Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_Export.Location = new System.Drawing.Point(87, 170);
            this.label_Export.Name = "label_Export";
            this.label_Export.Size = new System.Drawing.Size(62, 22);
            this.label_Export.TabIndex = 15;
            this.label_Export.Text = "Export";
            // 
            // button_ExportToFichier
            // 
            this.button_ExportToFichier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_ExportToFichier.Location = new System.Drawing.Point(172, 163);
            this.button_ExportToFichier.Name = "button_ExportToFichier";
            this.button_ExportToFichier.Size = new System.Drawing.Size(184, 36);
            this.button_ExportToFichier.TabIndex = 1;
            this.button_ExportToFichier.Text = "Export to Fichier";
            this.button_ExportToFichier.UseVisualStyleBackColor = true;
            this.button_ExportToFichier.Click += new System.EventHandler(this.button_ExportToFichier_Click);
            // 
            // button_ChoisirUnFichier
            // 
            this.button_ChoisirUnFichier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_ChoisirUnFichier.Location = new System.Drawing.Point(172, 72);
            this.button_ChoisirUnFichier.Name = "button_ChoisirUnFichier";
            this.button_ChoisirUnFichier.Size = new System.Drawing.Size(184, 38);
            this.button_ChoisirUnFichier.TabIndex = 0;
            this.button_ChoisirUnFichier.Text = "Choisir un fichier";
            this.button_ChoisirUnFichier.UseVisualStyleBackColor = true;
            this.button_ChoisirUnFichier.Click += new System.EventHandler(this.button_ChoisirUnFichier_Click);
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
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(172, 236);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(396, 32);
            this.progressBar.TabIndex = 9;
            // 
            // FormExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 494);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormExport";
            this.Text = "FormExport";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label_FichierExporte;
        private System.Windows.Forms.Label label_ExportCSV;
        private System.Windows.Forms.Label label_NomDuFichier;
        private System.Windows.Forms.Label label_Export;
        private System.Windows.Forms.Button button_ExportToFichier;
        private System.Windows.Forms.Button button_ChoisirUnFichier;
        private System.Windows.Forms.Label label_Progress;
        internal System.Windows.Forms.ProgressBar progressBar;
    }
}