using Bacchus.MVC.Controller;
using Bacchus.MVC.DAO;
using Bacchus.MVC.Model;
using Bacchus.MVC.View.FamillesView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.MVC.View.SousFamillesView
{
    /// <summary>
    /// The view of adding a sousfamille.
    /// </summary>
    public partial class AddSousFamille : Form
    {
        private FamillesDao FamilleDao;
        private MarquesController MarqueController;
        private SousFamillesDao SousFamilleDao;
        private FamillesController FamilleController;
        private SousFamillesController SousFamilleController;

        /// <summary>
        /// The constructor of AddSousFamille.
        /// </summary>
        public AddSousFamille()
        {
            InitializeComponent();
            this.FamilleDao = new FamillesDao();
            this.MarqueController = new MarquesController();
            this.SousFamilleDao = new SousFamillesDao();
            this.FamilleController = new FamillesController();
            this.SousFamilleController = new SousFamillesController();
        }

        /// <summary>
        /// Add a sousfamille to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Add_Click(object sender, EventArgs e)
        {
            var SousFamilleName = this.textBox_SousFamilleName.Text;
            var FamilleName = this.label_Famille_Name.Text;

            if (SousFamilleName == "")
            {
                MessageBox.Show("Please enter the SousFamille Name!", "ERROR");
                return;
            }

            if (SousFamilleName == FamilleName)
            {
                MessageBox.Show("SousFamilleName and FamilleName can't be the same!", "ERROR");
                this.textBox_SousFamilleName.Text = "";
                return;
            }

            if (SousFamilleName == "Familles")
            {
                MessageBox.Show("SousFamilleName can't be Familles!");
                this.textBox_SousFamilleName.Text = "";
                return;
            }

            if (SousFamilleName == "Marques")
            {
                MessageBox.Show("SousFamilleName can't be Marques!");
                this.textBox_SousFamilleName.Text = "";
                return;
            }

            if (SousFamilleName == "Tous les articles")
            {
                MessageBox.Show("SousFamilleName can't be Tous les articles!", "ERROR");
                this.textBox_SousFamilleName.Text = "";
                return;
            }

            if (MarqueController.FindMarqueByMarqueName(SousFamilleName))
            {
                MessageBox.Show("This name has already been used by a Marque!", "ERROR");
                this.textBox_SousFamilleName.Text = "";
                return;
            }

            if (FamilleController.FindFamilleByFamilleName(SousFamilleName))
            {
                MessageBox.Show("This name has already been used by a Famille!", "ERROR");
                this.textBox_SousFamilleName.Text = "";
                return;
            }

            if (SousFamilleController.FindSousFamilleBySousFamilleName(SousFamilleName))
            {
                MessageBox.Show("SousFamille Already exsited!", "ERROR");
                this.textBox_SousFamilleName.Text = "";
                return;
            }   
            else
            {
                if (!FamilleController.FindFamilleByFamilleName(FamilleName))
                {
                    if (MessageBox.Show("Famille doesn't exsite! Do you want to add a new Famille?", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Familles NewFamille = new Familles(FamilleName);
                        NewFamille.RefFamille = FamilleDao.GetMaxRefFamille() + 1;
                        FamilleDao.AddFamille(NewFamille);
                        if (FamilleController.FindFamilleByFamilleName(FamilleName))
                            MessageBox.Show("Add Famille succeed!");
                    }
                }
                SousFamilles SousFamille = new SousFamilles(SousFamilleName);
                Familles Famille = FamilleController.FindFamillesByFamilleName(FamilleName);
                SousFamille.RefSousFamille = SousFamilleDao.GetMaxRefSousFamille() + 1;
                
                SousFamilleDao.AddSousFamille(SousFamille, Famille);

                if (SousFamilleController.FindSousFamilleBySousFamilleName(SousFamilleName))
                {
                    MessageBox.Show("Add SousFamille succeed!");
                    this.Close();
                } 
            }
        }

        /// <summary>
        /// Cancle adding a sousfamille.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancle_Click(object sender, EventArgs e)
        {
            this.textBox_SousFamilleName.Text = "";
            this.Close();
        }
    }
}
