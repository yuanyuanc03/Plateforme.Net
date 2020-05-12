using Bacchus.MVC.Controller;
using Bacchus.MVC.DAO;
using Bacchus.MVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.MVC.View.FamillesView
{
    /// <summary>
    /// The view of adding a famille.
    /// </summary>
    public partial class AddFamille : Form
    {
        private FamillesDao FamilleDao;
        private MarquesController MarqueController;
        private FamillesController FamilleController;
        private SousFamillesController SousFamilleController;

        /// <summary>
        /// The constructor of AddFamille.
        /// </summary>
        public AddFamille()
        {
            InitializeComponent();
            this.FamilleDao = new FamillesDao();
            this.MarqueController = new MarquesController();
            this.FamilleController = new FamillesController();
            this.SousFamilleController = new SousFamillesController();
        }

        /// <summary>
        /// Add a famille to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Add_Click(object sender, EventArgs e)
        {
            var FamilleName = this.textBox_FamilleName.Text;

            if (FamilleName == "")
            {
                MessageBox.Show("Please enter the Famille Name!", "ERROR");
                return;
            }

            if(FamilleName == "Familles")
            {
                MessageBox.Show("FamilleName can't be Familles!");
                this.textBox_FamilleName.Text = "";
                return;
            }

            if (FamilleName == "Marques")
            {
                MessageBox.Show("FamilleName can't be Marques!");
                this.textBox_FamilleName.Text = "";
                return;
            }

            if (FamilleName == "Tous les articles")
            {
                MessageBox.Show("FamilleName can't be Tous les articles!");
                this.textBox_FamilleName.Text = "";
                return;
            }

            if (MarqueController.FindMarqueByMarqueName(FamilleName))
            {
                MessageBox.Show("FamilleName already used by a Marque!", "ERROR");
                this.textBox_FamilleName.Text = "";
                return;
            }

            if (SousFamilleController.FindSousFamilleBySousFamilleName(FamilleName))
            {
                MessageBox.Show("FamilleName already used by a SousFamille!", "ERROR");
                this.textBox_FamilleName.Text = "";
                return;
            }

            if (FamilleController.FindFamilleByFamilleName(FamilleName))
            {
                MessageBox.Show("Famille Already exsited!", "ERROR");
                this.textBox_FamilleName.Text = "";
                return;
            }
            else
            {
                Familles Famille = new Familles(FamilleName);
                Famille.RefFamille = FamilleDao.GetMaxRefFamille() + 1;
                FamilleDao.AddFamille(Famille);

                if (FamilleController.FindFamilleByFamilleName(FamilleName))
                {
                    MessageBox.Show("Add Famille succeed!");
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Cancle adding a famille.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancle_Click(object sender, EventArgs e)
        {
            this.textBox_FamilleName.Text = "";
            this.Close();
        }
    }
}
