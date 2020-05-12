using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Bacchus.MVC.Model
{
    /// <summary>
    /// The class of <c>Articles</c>. 
    /// Contains all the constructors and accessors of the class.
    /// </summary>
    public class Articles
    {
        public string RefArticle { get; set; }
        public string Description { get; set; }
        public Familles Famille { get; set; }
        public SousFamilles SousFamille { get; set; }
        public Marques Marque { get; set; }
        public float PrixHT { get; set; }
        public int Quantite { get; set; }

        /// <summary>
        /// The constructor of Articles.
        /// </summary>
        public Articles()
        {
            this.RefArticle = null;
            this.Description = null;
            this.Famille = new Familles();
            this.SousFamille = new SousFamilles();
            this.Marque = new Marques();
            this.PrixHT = 0;
            this.Quantite = 0;
        }

        /// <summary>
        /// The constructor of Articles.
        /// </summary>
        /// <param name="RefArticle"></param>
        /// <param name="Description"></param>
        /// <param name="Famille"></param>
        /// <param name="SousFamille"></param>
        /// <param name="Marque"></param>
        /// <param name="PrixHT"></param>
        /// <param name="Quantite"></param>
        public Articles(string RefArticle, string Description, Familles Famille, SousFamilles SousFamille, Marques Marque, float PrixHT, int Quantite)
        {
            this.RefArticle = RefArticle;
            this.Description = Description;
            this.Famille = Famille;
            this.SousFamille = SousFamille;
            this.Marque = Marque;
            this.PrixHT = PrixHT;
            this.Quantite = Quantite;
        }

        /// <summary>
        /// Get the values of all variables.
        /// </summary>
        /// <returns>A string Array contains the values of all variables of <c>Articles</c>.</returns>
        public string[] InfoTable()
        {
            string[] Table =
            {
                this.RefArticle, this.Description, this.Famille.FamilleName, this.SousFamille.SousFamilleName, this.Marque.MarqueName, this.PrixHT.ToString(CultureInfo.InvariantCulture),
                this.Quantite.ToString()
            };
            return Table;
        }
    }
}
