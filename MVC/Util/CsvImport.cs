using Bacchus.MVC.DAO;
using Bacchus.MVC.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bacchus.MVC.Model;
using Bacchus.MVC.View.MainView;
using System.Globalization;

namespace Bacchus.MVC.Util
{
    /// <summary>
    /// Import the csv file and display in the application.
    /// </summary>
    class CsvImport
    {
        public static ArticlesDao ArticleDao = new ArticlesDao();
        public static FamillesDao FamilleDao = new FamillesDao();
        public static MarquesDao MarqueDao = new MarquesDao();
        public static SousFamillesDao SousFamilleDao = new SousFamillesDao();
        public static ArticlesController ArticleController = new ArticlesController();
        public static FamillesController FamilleController = new FamillesController();
        public static MarquesController MarqueController = new MarquesController();
        public static SousFamillesController SousFamilleController = new SousFamillesController();
        public static ModelList ModelList = new ModelList();
        public static Articles Article;
        public static Familles Famille;
        public static Marques Marque;
        public static SousFamilles SousFamille;
        public static string FileDirectory;
        public static FileSystemWatcher FileWatch = new FileSystemWatcher();

        /// <summary>
        /// Read the csv file in two modes, mode erasement et mode ajout.
        /// </summary>
        /// <param name="Flag"></param>
        /// <param name="FilePath"></param>
        /// <param name="FormImport"></param>
        public static void ReadFile(bool Flag, string FilePath, FormImport FormImport)
        {
            try 
            {
                int AddedArticles = 0;
                int ExistingArticles = 0;

                if (Flag == true)
                {
                    ModelList.Articles.Clear();
                    ModelList.Familles.Clear();
                    ModelList.Marques.Clear();
                    ModelList.SousFamilles.Clear();

                    ArticleDao.EmptyArticles();
                    SousFamilleDao.EmptySousFamilles();
                    MarqueDao.EmptyMarques();
                    FamilleDao.EmptyFamilles();
                }

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
                                FormImport.label_FichierImporte.Text = "FileName: " + System.IO.Path.GetFileName(FilePath);
                            }
                        }
                    }
                }

                using (var StreamReader = new StreamReader(FilePath, Encoding.Default))
                {
                    var NbLines = File.ReadAllLines(FilePath).Length;

                    FormImport.progressBar.Maximum = NbLines;
                    FormImport.progressBar.Value = 1;

                    StreamReader.ReadLine();

                    string Line;
                    while ((Line = StreamReader.ReadLine()) != null)
                    {
                        var Values = Line.Split(';');
                        var Description = Values[0].Trim();
                        var RefArticle = Values[1].Trim();
                        var MarqueName = Values[2].Trim();
                        var FamilleName = Values[3].Trim();
                        var SousFamilleName = Values[4].Trim();
                        //var Prix = Values[5].Trim();
                        /*
                        if (Prix.IndexOf("\"") >= 0)
                            Prix = Prix.Replace("\"", "");

                        if (Prix.EndsWith(","))
                            Prix = Prix.Remove(Prix.Length - 1, 1);

                        if (Prix.IndexOf(",") != -1)
                        {
                            int StartIndex = 0;
                            int Count = 0;
                            while (true)
                            {
                                int Index = Prix.IndexOf(",", StartIndex);
                                if (Index != -1)
                                {
                                    Count++;
                                    StartIndex = Index + 1;
                                }
                                else
                                    break;
                            }

                            StartIndex = 0;
                            for (int i = 0; i < Count - 1; i++)
                            {
                                int Index = Prix.IndexOf(",", StartIndex);
                                StartIndex = Index + 1;
                                Prix = Prix.Remove(Index, Index);
                            }
                               
                            Prix = Prix.Replace(",", ".");
                        }
                        
                        var PrixHT = float.Parse(Prix, CultureInfo.InvariantCulture.NumberFormat);
                        */
                        var PrixHT = float.Parse(Values[5].Trim().Replace(",", "."), CultureInfo.InvariantCulture.NumberFormat);
                        if (ArticleController.FindArticleByRefArticle(RefArticle))
                        {
                            ExistingArticles += 1;
                            if (Flag == false)
                            {
                                Article = ArticleController.FindArticlesByRefArticle(RefArticle);
                                if (Article.Description != Description)
                                    Article.Description = Description;
                                if (Article.PrixHT != PrixHT)
                                    Article.PrixHT = PrixHT;
                                if (Article.Quantite != 1)
                                    Article.Quantite = 1;
                                if (!MarqueController.FindMarqueByMarqueName(MarqueName))
                                {
                                    Marque = new Marques(MarqueName);
                                    ModelList.Marques.Add(Marque);
                                    MarqueDao.AddMarque(Marque);
                                    Article.Marque = Marque;
                                }
                                if (!SousFamilleController.FindSousFamilleBySousFamilleName(SousFamilleName))
                                {
                                    SousFamille = new SousFamilles(SousFamilleName);
                                    ModelList.SousFamilles.Add(SousFamille);
                                    SousFamilleDao.AddSousFamille(SousFamille, Famille);
                                    Article.SousFamille = SousFamille;
                                }
                            }
                            continue;
                        }
                        else
                        {
                            AddedArticles += 1;
                        }

                        if (!MarqueController.FindMarqueByMarqueName(MarqueName))
                        {
                            Marque = new Marques(MarqueName);
                            ModelList.Marques.Add(Marque);
                            MarqueDao.AddMarque(Marque);
                        }

                        if (!ArticleController.FindArticleByFamilleName(FamilleName))
                        {
                            Famille = new Familles(FamilleName);
                            ModelList.Familles.Add(Famille);
                            FamilleDao.AddFamille(Famille);
                        }

                        if (!SousFamilleController.FindSousFamilleBySousFamilleName(SousFamilleName))
                        {
                            SousFamille = new SousFamilles(SousFamilleName);
                            ModelList.SousFamilles.Add(SousFamille);
                            SousFamilleDao.AddSousFamille(SousFamille, Famille);
                        }

                        Article = new Articles(RefArticle, Description, FamilleController.FindFamillesByRefSousFamille(SousFamille.RefSousFamille), SousFamille, Marque, PrixHT, 1);
                        ModelList.Articles.Add(Article);
                        ArticleDao.AddArticle(Article);

                        FormImport.progressBar.Value++;
                    }
                    StreamReader.Close();
                }

                string Message = "Nombre d'articles ajoutés " + AddedArticles + "\n" +
                                 "Nombre d'articles anomalies " + ExistingArticles;

                MessageBox.Show(" Import success!\n" + Message, System.IO.Path.GetFileName(FilePath));

                FileDirectory = Path.GetDirectoryName(FilePath);
                if (FileDirectory != null)
                    FormMain_FileSystemWatcher();
            }
            catch(System.IO.IOException)
            {
                MessageBox.Show("Please close the selected file!");
            }
        }

        /// <summary>
        /// Settings of the watcher of the filesystem.
        /// </summary>
        private static void FormMain_FileSystemWatcher()
        {
            FileWatch.Path = FileDirectory;
            FileWatch.NotifyFilter = NotifyFilters.LastWrite;
            FileWatch.Filter = "*.csv";
            FileWatch.IncludeSubdirectories = false;
            FileWatch.Changed += new FileSystemEventHandler(Watch_Changed);
            FileWatch.EnableRaisingEvents = true;
        }

        /// <summary>
        /// When the csv file has been changed, this method will send the notification.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void Watch_Changed(object source, FileSystemEventArgs e)
        {
            if (FileWatch != null)
            {
                try
                {
                    FileWatch.EnableRaisingEvents = false;
                    MessageBox.Show("The file of current directory that you have imported has been changed! ", "Directory Path:" + FileDirectory,
                        MessageBoxButtons.OK);
                }
                finally
                {
                    FileWatch.EnableRaisingEvents = true;
                }
            }
        }
    }
}
