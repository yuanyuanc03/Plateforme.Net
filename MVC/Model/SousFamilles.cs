using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.MVC.Model
{
    /// <summary>
    /// The class of <c>SousFamilles</c>. 
    /// Contains all the constructors and accessors of the class.
    /// </summary>
    public class SousFamilles
    {
        public int RefSousFamille { get; set; }
        public int RefFamille { get; set; }
        public string SousFamilleName { get; set; }

        /// <summary>
        /// The constructor of SousFamilles.
        /// </summary>
        public SousFamilles()
        {
            this.RefSousFamille = 0;
            this.RefFamille = 0;
            this.SousFamilleName = null;
        }

        /// <summary>
        /// The constructor of SousFamilles.
        /// </summary>
        /// <param name="SousFamilleName"></param>
        public SousFamilles(string SousFamilleName)
        {
            this.SousFamilleName = SousFamilleName;
        }

        /// <summary>
        /// The constructor of SousFamilles.
        /// </summary>
        /// <param name="SousFamilleName"></param>
        /// <param name="FamilleName"></param>
        public SousFamilles(string SousFamilleName, string FamilleName)
        {
            this.SousFamilleName = SousFamilleName;
            this.SousFamilleName = FamilleName;
        }

        /// <summary>
        /// The constructor of SousFamilles.
        /// </summary>
        /// <param name="RefSousFamille"></param>
        /// <param name="RefFamille"></param>
        /// <param name="SousFamilleName"></param>
        public SousFamilles(int RefSousFamille, int RefFamille, string SousFamilleName)
        {
            this.RefSousFamille = RefSousFamille;
            this.RefFamille = RefFamille;
            this.SousFamilleName = SousFamilleName;
        }

        /// <summary>
        /// Get the values of all variables.
        /// </summary>
        /// <returns>A string Array contains the values of all variables of <c>SousFamilles</c>.</returns>
        public string[] InfoTable()
        {
            string[] Table = { this.SousFamilleName };
            return Table;
        }
    }
}
