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
    /// The view of modifying a famille.
    /// </summary>
    public partial class ModifyFamille : Form
    {
        private FamillesDao FamilleDao;
        private MarquesController MarqueController;
        private FamillesController FamilleController;
        private SousFamillesController SousFamilleController;

        /// <summary>
        /// The constructor of ModifyFamille.
        /// </summary>
        /// <param name="FamilleName"></param>
        public ModifyFamille(string FamilleName)
        {
            InitializeComponent();
            this.label_Famille_Name.Text = FamilleName;
            this.FamilleDao = new FamillesDao();
            this.MarqueController = new MarquesController();
            this.FamilleController = new FamillesController();
            this.SousFamilleController = new SousFamillesController();
        }

        /// <summary>
        /// Modify a famille of the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Modify_Click(object sender, EventArgs e)
        {
            var FamilleName = this.textBox_NewFamilleName.Text;

            if (FamilleName == "")
            {
                MessageBox.Show("Please enter the Famille Name!", "ERROR");
                return;
            }

            else if(FamilleName == this.label_Famille_Name.Text)
            {
                MessageBox.Show("FamilleName can't be the same before and after modification!", "ERROR");
                return;
            }

            else if (FamilleName == "Familles")
            {
                MessageBox.Show("FamilleName can't be Familles!");
                this.textBox_NewFamilleName.Text = "";
                return;
            }

            else if (FamilleName == "Marques")
            {
                MessageBox.Show("FamilleName can't be Marques!");
                this.textBox_NewFamilleName.Text = "";
                return;
            }

            else if (FamilleName == "Tous les articles")
            {
                MessageBox.Show("FamilleName can't be Tous les articles!");
                this.textBox_NewFamilleName.Text = "";
                return;
            }

            else if (MarqueController.FindMarqueByMarqueName(FamilleName))
            {
                MessageBox.Show("This name has already been used by a Marque!", "ERROR");
                this.textBox_NewFamilleName.Text = "";
                return;
            }

            else if (SousFamilleController.FindSousFamilleBySousFamilleName(FamilleName))
            {
                MessageBox.Show("This name has already been used by a SousFamille!", "ERROR");
                this.textBox_NewFamilleName.Text = "";
                return;
            }

            else if (FamilleController.FindFamilleByFamilleName(FamilleName))
            {
                MessageBox.Show("SousFamille Already exsited!", "ERROR");
                this.textBox_NewFamilleName.Text = "";
                return;
            }
            else
            {
                Familles Famille = FamilleController.FindFamillesByFamilleName(this.label_Famille_Name.Text);
                Famille.FamilleName = FamilleName;
                FamilleDao.ModifyFamille(Famille);

                if (FamilleController.FindFamilleByFamilleName(Famille.FamilleName))
                {
                    MessageBox.Show("Modify succeed!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Modify Failed!");
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Cancle modifying a famille.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancle_Click(object sender, EventArgs e)
        {
            this.textBox_NewFamilleName.Text = "";
            this.Close();
        }
    }
}
