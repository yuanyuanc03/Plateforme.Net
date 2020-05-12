using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.MVC.View.MainView
{
    /// <summary>
    /// The view of exporting the data.
    /// </summary>
    public partial class FormExport : Form
    {
        public String FilePath = string.Empty;

        /// <summary>
        /// The constructor of FormExport.
        /// </summary>
        public FormExport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Select a csv file to export.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ChoisirUnFichier_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = openFileDialog.FileName;
                    label_FichierExporte.Text = "FileName: " + System.IO.Path.GetFileName(FilePath);
                }
            }
        }

        /// <summary>
        /// Export to the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ExportToFichier_Click(object sender, EventArgs e)
        {
            this.progressBar.Visible = true;
            Util.CsvExport.WriteFile(FilePath, this);
            this.Close();
        }
    }
}
