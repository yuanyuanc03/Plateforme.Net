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

namespace Bacchus.MVC.View.SousFamillesView
{
    /// <summary>
    /// The view of modifying a sousfamille.
    /// </summary>
    public partial class ModifySousFamilles : Form
    {
        private MarquesController MarqueController;
        private FamillesController FamilleController;
        private SousFamillesDao SousFamilleDao;
        private SousFamillesController SousFamilleController;

        /// <summary>
        /// The constructor of ModifySousFamille.
        /// </summary>
        /// <param name="FamilleName"></param>
        /// <param name="SousFamilleName"></param>
        public ModifySousFamilles(String FamilleName, string SousFamilleName)
        {
            InitializeComponent();
            this.label_Famille_Name.Text = FamilleName;
            this.label_SousFamille_Name.Text = SousFamilleName;
            this.MarqueController = new MarquesController();
            this.FamilleController = new FamillesController();
            this.SousFamilleDao = new SousFamillesDao();
            this.SousFamilleController = new SousFamillesController();
        }

        /// <summary>
        /// Modify a sousfamille of the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Modify_Click(object sender, EventArgs e)
        {
            var SousFamilleName = this.textBox_NewSousFamilleName.Text;

            if (SousFamilleName == "")
            {
                MessageBox.Show("Please enter the SousFamille Name!", "ERROR");
                return;
            }

            else if (SousFamilleName == this.label_Famille_Name.Text)
            {
                MessageBox.Show("SousFamilleName and FamilleName can't be the same!", "ERROR");
                this.textBox_NewSousFamilleName.Text = "";
                return;
            }

            else if (SousFamilleName == this.label_SousFamille_Name.Text)
            {
                MessageBox.Show("SousFamilleName can't be the same before and after modification!", "ERROR");
                this.textBox_NewSousFamilleName.Text = "";
                return;
            }

            else if (SousFamilleName == "Familles")
            {
                MessageBox.Show("SousFamilleName can't be Familles!");
                this.textBox_NewSousFamilleName.Text = "";
                return;
            }

            else if (SousFamilleName == "Marques")
            {
                MessageBox.Show("SousFamilleName can't be Marques!");
                this.textBox_NewSousFamilleName.Text = "";
                return;
            }

            else if (SousFamilleName == "Tous les articles")
            {
                MessageBox.Show("SousFamilleName can't be Tous les articles!", "ERROR");
                this.textBox_NewSousFamilleName.Text = "";
                return;
            }

            else if (MarqueController.FindMarqueByMarqueName(SousFamilleName))
            {
                MessageBox.Show("This name has already been used by a Marque!", "ERROR");
                this.textBox_NewSousFamilleName.Text = "";
                return;
            }

            else if (FamilleController.FindFamilleByFamilleName(SousFamilleName))
            {
                MessageBox.Show("This name has already been used by a Famille!", "ERROR");
                this.textBox_NewSousFamilleName.Text = "";
                return;
            }

            else if (SousFamilleController.FindSousFamilleBySousFamilleName(SousFamilleName))
            {
                MessageBox.Show("SousFamille Already exsited!", "ERROR");
                this.textBox_NewSousFamilleName.Text = "";
                return;
            }

            else
            {
                SousFamilles SousFamille = SousFamilleController.FindSousFamillesBySousFamilleName(this.label_SousFamille_Name.Text);
                SousFamille.SousFamilleName = SousFamilleName;
                SousFamilleDao.ModifySousFamille(SousFamille);

                if (SousFamilleController.FindSousFamilleBySousFamilleName(SousFamille.SousFamilleName))
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
        /// Cancle modifying a sousfamille.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancle_Click(object sender, EventArgs e)
        {
            this.textBox_NewSousFamilleName.Text = "";
            this.Close();
        }
    }
}
