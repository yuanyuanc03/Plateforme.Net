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
    /// The view of modifying a marque.
    /// </summary>
    public partial class ModifyMarque : Form
    {
        private MarquesDao MarqueDao;
        private FamillesController FamilleController;
        private SousFamillesController SousFamilleController;
        private MarquesController MarqueController;

        /// <summary>
        /// The constructor of ModifyMarque.
        /// </summary>
        /// <param name="MarqueName"></param>
        public ModifyMarque(string MarqueName)
        {
            InitializeComponent();
            this.label_Marque_Name.Text = MarqueName;
            this.MarqueDao = new MarquesDao();
            this.FamilleController = new FamillesController();
            this.MarqueController = new MarquesController();
            this.SousFamilleController = new SousFamillesController();
        }

        /// <summary>
        /// Modify a marque of the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Modify_Click(object sender, EventArgs e)
        {
            var MarqueName = this.textBox_NewMarqueName.Text;

            if (MarqueName == "")
            {
                MessageBox.Show("Please enter the Marque Name!", "ERROR");
                return;
            }

            else if (MarqueName == this.label_Marque_Name.Text)
            {
                MessageBox.Show("MarqueName can't be the same before and after modification!", "ERROR");
                this.textBox_NewMarqueName.Text = "";
                return;
            }

            else if (MarqueName == "Familles")
            {
                MessageBox.Show("MarqueName can't be Familles!", "ERROR");
                this.textBox_NewMarqueName.Text = "";
                return;
            }

            else if (MarqueName == "Marques")
            {
                MessageBox.Show("MarqueName can't be Marques!", "ERROR");
                this.textBox_NewMarqueName.Text = "";
                return;
            }

            else if (MarqueName == "Tous les articles")
            {
                MessageBox.Show("MarqueName can't be Tous les articles!", "ERROR");
                this.textBox_NewMarqueName.Text = "";
                return;
            }

            else if (FamilleController.FindFamilleByFamilleName(MarqueName))
            {
                MessageBox.Show("This name has already been used by a Famille!", "ERROR");
                this.textBox_NewMarqueName.Text = "";
                return;
            }

            else if (SousFamilleController.FindSousFamilleBySousFamilleName(MarqueName))
            {
                MessageBox.Show("This name has already been used by a SousFamille!", "ERROR");
                this.textBox_NewMarqueName.Text = "";
                return;
            }

            else if (MarqueController.FindMarqueByMarqueName(MarqueName))
            {
                MessageBox.Show("Marque Already exsited!", "ERROR");
                this.textBox_NewMarqueName.Text = "";
                return;
            }
            else
            {
                Marques Marque = MarqueController.FindMarquesByMarqueName(this.label_Marque_Name.Text);
                Marque.MarqueName = MarqueName;
                MarqueDao.ModifyMarque(Marque);

                if (MarqueController.FindMarqueByMarqueName(Marque.MarqueName))
                {
                    MessageBox.Show("Modify succeed!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Modify Failed!");
                }
            }
        }

        /// <summary>
        /// Cancle modifying a marque.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancle_Click(object sender, EventArgs e)
        {
            this.textBox_NewMarqueName.Text = "";
            this.Close();
        }
    }
}
