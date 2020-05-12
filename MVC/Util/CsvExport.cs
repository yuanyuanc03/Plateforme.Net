using Bacchus.MVC.Controller;
using Bacchus.MVC.DAO;
using Bacchus.MVC.Model;
using Bacchus.MVC.View.MainView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.MVC.Util
{
    /// <summary>
    /// Export all the data from the application to a csv file.
    /// </summary>
    class CsvExport
    {
        public static FamillesController FamilleController = new FamillesController();
        public static ModelList ModelList = new ModelList();

        /// <summary>
        /// Write all the data to a csv file.
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="FormExport"></param>
        public static void WriteFile(string FilePath, FormExport FormExport)
        {
            try
            {
                ModelList ModelList = new ModelList();
                string HeaderCsv = null;

                if (FilePath == "")
                {
                    if (MessageBox.Show("Please choose a file!", "ERROR") == DialogResult.OK)
                    {
                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.Filter = "csv files (*.csv)|*.csv";
                            openFileDialog.RestoreDirectory = true;

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                FilePath = openFileDialog.FileName;
                                FormExport.label_FichierExporte.Text = "FileName: " + System.IO.Path.GetFileName(FilePath);
                            }
                        }
                    }
                }

                using (var StreamReader = new StreamReader(FilePath, Encoding.Default))
                {
                    HeaderCsv = StreamReader.ReadLine();
                    StreamReader.Close();
                }

                using (var FileStream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    FileStream.SetLength(0);
                    using (var StreamWriter = new StreamWriter(FileStream, Encoding.Default))
                    {
                        FormExport.progressBar.Maximum = ModelList.Articles.Count + 1;
                        FormExport.progressBar.Value = 1;

                        StreamWriter.WriteLine(HeaderCsv);
                        foreach (var Article in ModelList.Articles)
                        {
                            StreamWriter.WriteLine(Article.Description + ";" + Article.RefArticle + ";" + Article.Marque.MarqueName
                                + ";" + FamilleController.FindFamillesByRefFamille(Article.SousFamille.RefFamille).FamilleName + ";" + Article.SousFamille.SousFamilleName + ";" + Article.PrixHT);
                            FormExport.progressBar.Value++;
                        }
                    }
                }

                string Message = ModelList.Articles.Count + " articles have been added!";

                MessageBox.Show(" Export success!\n" + Message, System.IO.Path.GetFileName(FilePath));
            }
            catch
            {
                MessageBox.Show("Please close the selected file!");
            }
            
        }
    }
}
