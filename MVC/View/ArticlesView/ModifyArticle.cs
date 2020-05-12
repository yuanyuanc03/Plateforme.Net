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
    /// The view of modifying an article.
    /// </summary>
    public partial class ModifyArticle : Form
    {
        private ModelList ModelList;
        private Articles Article;
        private ArticlesDao ArticleDao;
        private ArticlesController ArticleController;
        private MarquesController MarqueController;
        private FamillesController FamilleController;
        private SousFamillesController SousFamilleController;

        /// <summary>
        /// The constructor of ModifyArticle.
        /// </summary>
        /// <param name="Article"></param>
        public ModifyArticle(Articles Article)
        {
            InitializeComponent();
            this.Article = Article;
            this.ModelList = new ModelList();
            this.ArticleDao = new ArticlesDao();
            this.ArticleController = new ArticlesController();
            this.MarqueController = new MarquesController();
            this.FamilleController = new FamillesController();
            this.SousFamilleController = new SousFamillesController();
        }

        /// <summary>
        /// Modify an article of the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Modify_Click(object sender, EventArgs e)
        {
            var Description = this.textBox_Description.Text;
            var MarqueName = this.comboBox_Marque.Text;
            var FamilleName = this.comboBox_Famille.Text;
            var SousFamilleName = this.comboBox_SousFamille.Text;
            var PrixHT = this.textBox_PrixHT.Text;
            var Quantite = this.textBox_Quantite.Text;

            if (Description == "")
                MessageBox.Show("Please enter the Description!", "ERROR");
         
            else if (MarqueName == "")
                MessageBox.Show("Please enter the Marque Name!", "ERROR");

            else if (FamilleName == "")
                MessageBox.Show("Please enter the Famille Name!", "ERROR");

            else if (SousFamilleName == "")
                MessageBox.Show("Please enter the SousFamille Name!", "ERROR");

            else if (PrixHT == "")
                MessageBox.Show("Please enter the Price!", "ERROR");

            else if (Quantite == "")
                MessageBox.Show("Please enter the Quantite!", "ERROR");

            else if (!float.TryParse(PrixHT, out var Prix))
                MessageBox.Show("Please enter the right price!");

            else if (!int.TryParse(Quantite, out var Number))
                MessageBox.Show("Please enter the right quantity!");

            else
            {
                if (!SousFamilleController.FindSousFamilleBySousFamilleName(SousFamilleName))
                {
                    if (MessageBox.Show("SousFamille doesn't exsite! Do you want to add a new SousFamille?", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        AddSousFamille AddSousFamille = new AddSousFamille { StartPosition = FormStartPosition.CenterParent };
                        AddSousFamille.ShowDialog(this);
                    }
                    else
                        return;
                }
                if (!MarqueController.FindMarqueByMarqueName(MarqueName))
                {
                    if (MessageBox.Show("Marque doesn't exsite! Do you want to add a new Marque?", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        AddMarque AddMarque = new AddMarque { StartPosition = FormStartPosition.CenterParent };
                        AddMarque.ShowDialog(this);
                    }
                    else
                        return;
                }

                SousFamilles SousFamille = SousFamilleController.FindSousFamillesBySousFamilleName(SousFamilleName);
                Marques Marque = MarqueController.FindMarquesByMarqueName(MarqueName);
                Articles Article = new Articles(this.label_ReferenceArticle.Text, Description, FamilleController.FindFamillesByRefSousFamille(SousFamille.RefSousFamille), SousFamille, Marque, float.Parse(PrixHT), int.Parse(Quantite));
                
                if(!ArticleController.CompareArticles(ArticleController.FindArticlesByRefArticle(Article.RefArticle), Article))
                {
                    ArticleDao.ModifyArticle(Article);
                    if (ArticleController.FindArticleByRefArticle(Article.RefArticle))
                    {
                        MessageBox.Show("Modify succeed!");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("The article can't be the same before and after modification!");
                    return;
                }
            }
        }

        /// <summary>
        /// Cancle modifying an article.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Load the view of ModifyArticle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyArticle_Load(object sender, EventArgs e)
        {
            this.label_ReferenceArticle.Text = this.Article.RefArticle;
            this.textBox_Description.Text = this.Article.Description;
            this.textBox_PrixHT.Text = this.Article.PrixHT.ToString();
            this.textBox_Quantite.Text = this.Article.Quantite.ToString();

            this.comboBox_Marque.DataSource = this.ModelList.Marques;
            this.comboBox_Marque.DisplayMember = "MarqueName";
            this.comboBox_Marque.ValueMember = "MarqueName";
            this.comboBox_Marque.SelectedIndex = this.comboBox_Marque.FindString(Article.Marque.MarqueName);

            this.comboBox_Famille.DataSource = this.ModelList.Familles;
            this.comboBox_Famille.DisplayMember = "FamilleName";
            this.comboBox_Famille.ValueMember = "FamilleName";
            this.comboBox_Famille.SelectedIndex = this.comboBox_Famille.FindString(Article.Famille.FamilleName);

            this.comboBox_SousFamille.DataSource = SousFamilleController.FindSousFamillesByFamilleName(this.comboBox_Famille.Text);
            this.comboBox_SousFamille.DisplayMember = "SousFamilleName";
            this.comboBox_SousFamille.ValueMember = "SousFamilleName";
            this.comboBox_SousFamille.SelectedIndex = this.comboBox_SousFamille.FindString(Article.SousFamille.SousFamilleName);
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
