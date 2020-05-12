using Bacchus.MVC.DAO;
using Bacchus.MVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.MVC.View.MainView
{
    /// <summary>
    /// The view of importing the data from a csv file.
    /// </summary>
    public partial class FormImport : Form
    {
        public string FilePath = string.Empty;

        /// <summary>
        /// The constructor of FormImport.
        /// </summary>
        public FormImport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Select a csv file to import.
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
                    label_FichierImporte.Text = "FileName: " + System.IO.Path.GetFileName(FilePath);
                }
            }
        }

        /// <summary>
        /// Import the data with mode erasement.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ModeEcrasement_Click(object sender, EventArgs e)
        {
            this.progressBar.Visible = true;
            Util.CsvImport.ReadFile(true, FilePath, this);
            ((FormMain)Owner).LoadListView();
            this.Close();
        }

        /// <summary>
        /// Import with mode ajout.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ModeAjout_Click(object sender, EventArgs e)
        {
            this.progressBar.Visible = true;
            Util.CsvImport.ReadFile(false, FilePath, this);
            ((FormMain)Owner).LoadListView();
            this.Close();
        }

    }
}
