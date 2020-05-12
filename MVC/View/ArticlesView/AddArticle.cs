using Bacchus.MVC.Controller;
using Bacchus.MVC.DAO;
using Bacchus.MVC.Model;
using Bacchus.MVC.View.MarquesView;
using Bacchus.MVC.View.SousFamillesView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.MVC.View.ArticlesView
{
    /// <summary>
    /// The view of adding an article.
    /// </summary>
    public partial class AddArticle : Form
    {
        private ModelList ModelList;
        private ArticlesDao ArticleDao;
        private MarquesDao MarqueDao;
        private ArticlesController ArticleController;
        private MarquesController MarqueController;
        private FamillesController FamilleController;
        private SousFamillesController SousFamilleController;

        /// <summary>
        /// The constructor of AddArticle.
        /// </summary>
        public AddArticle()
        {
            InitializeComponent();
            this.ModelList = new ModelList();
            this.ArticleDao = new ArticlesDao();
            this.MarqueDao = new MarquesDao();
            this.ArticleController = new ArticlesController();
            this.MarqueController = new MarquesController();
            this.FamilleController = new FamillesController();
            this.SousFamilleController = new SousFamillesController();
        }

        /// <summary>
        /// Add an article to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Add_Click(object sender, EventArgs e)
        {
            var RefArticle = this.textBox_RefArticle.Text;
            var Description = this.textBoxDescription.Text;
            var MarqueName = this.comboBox_Marque.Text;
            var FamilleName = this.comboBox_Famille.Text;
            var SousFamilleName = this.comboBox_SousFamille.Text;
            var PrixHT = this.textBox_PrixHT.Text;
            var Quantite = this.textBox_Quantite.Text;

            if (RefArticle == "")
                MessageBox.Show("Please enter the RefArticle!", "ERROR");

            else if (Description == "")
                MessageBox.Show("Please enter the Description!", "ERROR");

            else if (PrixHT == "")
                MessageBox.Show("Please enter the Price!", "ERROR");

            else if (Quantite == "")
                MessageBox.Show("Please enter the Quantite!", "ERROR");

            else if (MarqueName == "")
                MessageBox.Show("Please enter the Marque Name!", "ERROR");

            else if (FamilleName == "")
                MessageBox.Show("Please enter the Famille Name!", "ERROR");

            else if (SousFamilleName == "")
                MessageBox.Show("Please enter the SousFamille Name!", "ERROR");

            else if (RefArticle.Length >= 15)
                MessageBox.Show("RefArticle is too long! The maximum length of the RefArticle is 15!");

            else if (!float.TryParse(PrixHT, out var Prix))
                MessageBox.Show("Please enter the right price!");

            else if(!int.TryParse(Quantite, out var Number))
                MessageBox.Show("Please enter the right quantity!");

            else if (ArticleController.FindArticleByRefArticle(RefArticle))
                MessageBox.Show("Article Already exsited!", "ERROR");

            else
            {
                if (!SousFamilleController.FindSousFamilleBySousFamilleName(SousFamilleName))
                {
                    var Result = MessageBox.Show("SousFamille doesn't exsite! Do you want to add a new SousFamille?", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (Result == DialogResult.OK)
                    {
                        AddSousFamille AddSousFamille = new AddSousFamille { StartPosition = FormStartPosition.CenterParent };
                        AddSousFamille.ShowDialog(this);
                    }
                    else
                        return;

                }
                if (!MarqueController.FindMarqueByMarqueName(MarqueName))
                {
                    var Result = MessageBox.Show("Marque doesn't exsite! Do you want to add a new Marque?", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (Result == DialogResult.OK)
                    {
                        Marques NewMarque = new Marques(MarqueName);
                        NewMarque.RefMarque = MarqueDao.GetMaxRefMarque() + 1;
                        MarqueDao.AddMarque(NewMarque);
                    }
                    else
                        return;
                }

                SousFamilles SousFamille = SousFamilleController.FindSousFamillesBySousFamilleName(SousFamilleName);
                Marques Marque = MarqueController.FindMarquesByMarqueName(MarqueName);
                string Price = float.Parse(PrixHT).ToString();
                Price = Price.Replace(".", ",");
                Articles Article = new Articles(RefArticle, Description, FamilleController.FindFamillesByRefSousFamille(SousFamille.RefSousFamille), SousFamille, Marque, float.Parse(Price), int.Parse(Quantite));
                ArticleDao.AddArticle(Article);
               
                if (ArticleController.FindArticleByRefArticle(RefArticle))
                {
                    MessageBox.Show("Add Article succeed!");
                    this.Close();
                }
            }   
        }

        /// <summary>
        /// Cancle adding an article.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Load the view of AddArticle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddArticle_Load(object sender, EventArgs e)
        {
            this.comboBox_Marque.DataSource = this.ModelList.Marques;
            this.comboBox_Marque.DisplayMember = "MarqueName";
            this.comboBox_Marque.ValueMember = "MarqueName";

            this.comboBox_Famille.DataSource = this.ModelList.Familles;
            this.comboBox_Famille.DisplayMember = "FamilleName";
            this.comboBox_Famille.ValueMember = "FamilleName";

            this.comboBox_SousFamille.DataSource = this.ModelList.SousFamilles;
            this.comboBox_SousFamille.DisplayMember = "SousFamilleName";
            this.comboBox_SousFamille.ValueMember = "SousFamilleName";

            this.comboBox_Marque.SelectedIndex = -1;
            this.comboBox_Famille.SelectedIndex = -1;
            this.comboBox_SousFamille.SelectedIndex = -1;
        }

        /// <summary>
        /// When the comboBox of Famille changed, load all the sousfamilles of current famille.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_Famille_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox_SousFamille.DataSource = SousFamilleController.FindSousFamillesByFamilleName(this.comboBox_Famille.Text);
            this.comboBox_SousFamille.DisplayMember = "SousFamilleName";
            this.comboBox_SousFamille.ValueMember = "SousFamilleName";
            this.comboBox_SousFamille.SelectedIndex = -1;
        }
    }
}
