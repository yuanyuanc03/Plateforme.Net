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

namespace Bacchus.MVC.View.MarquesView
{
    /// <summary>
    /// The view of adding a marque.
    /// </summary>
    public partial class AddMarque : Form
    {
        private MarquesDao MarqueDao;
        private FamillesController FamilleController;
        private SousFamillesController SousFamilleController;
        private MarquesController MarqueController;

        /// <summary>
        /// The constructor of AddMarque.
        /// </summary>
        public AddMarque()
        {
            InitializeComponent();
            this.MarqueDao = new MarquesDao();
            this.FamilleController = new FamillesController();
            this.MarqueController = new MarquesController();
            this.SousFamilleController = new SousFamillesController();
        }

        /// <summary>
        /// Add a marque to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Add_Click(object sender, EventArgs e)
        {
            var MarqueName = this.textBox_MarqueName.Text;

            if (MarqueName == "")
            {
                MessageBox.Show("Please enter the Marque Name!", "ERROR");
                return;
            }

            if (MarqueName == "Familles")
            {
                MessageBox.Show("MarqueName can't be Familles!", "ERROR");
                this.textBox_MarqueName.Text = "";
                return;
            }

            if (MarqueName == "Marques")
            {
                MessageBox.Show("MarqueName can't be Marques!", "ERROR");
                this.textBox_MarqueName.Text = "";
                return;
            }

            if (MarqueName == "Familles")
            {
                MessageBox.Show("MarqueName can't be Familles!", "ERROR");
                this.textBox_MarqueName.Text = "";
                return;
            }

            if (MarqueName == "Tous les articles")
            {
                MessageBox.Show("MarqueName can't be Tous les articles!", "ERROR");
                this.textBox_MarqueName.Text = "";
                return;
            }

            if (FamilleController.FindFamilleByFamilleName(MarqueName))
            {
                MessageBox.Show("This name has already been used by a Famille!", "ERROR");
                this.textBox_MarqueName.Text = "";
                return;
            }

            if (SousFamilleController.FindSousFamilleBySousFamilleName(MarqueName))
            {
                MessageBox.Show("This name has already been used by a SousFamille!", "ERROR");
                this.textBox_MarqueName.Text = "";
                return;
            }

            if (MarqueController.FindMarqueByMarqueName(MarqueName))
            {
                MessageBox.Show("Marque Already exsited!", "ERROR");
                this.textBox_MarqueName.Text = "";
                return;
            }
            else
            {
                Marques Marque = new Marques(MarqueName);
                Marque.RefMarque = MarqueDao.GetMaxRefMarque() + 1;
                MarqueDao.AddMarque(Marque);
                if (MarqueController.FindMarqueByMarqueName(MarqueName))
                {
                    MessageBox.Show("Add Marque succeed!");
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Cancle adding a marque.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancle_Click(object sender, EventArgs e)
        {
            this.textBox_MarqueName.Text = "";
            this.Close();
        }
    }
}
