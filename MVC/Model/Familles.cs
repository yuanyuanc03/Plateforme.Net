using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.MVC.Model
{
    /// <summary>
    /// The class of <c>Familles</c>. 
    /// Contains all the constructors and accessors of the class.
    /// </summary>
    public class Familles
    {
        public int RefFamille { get; set; }
        public string FamilleName { get; set; }

        /// <summary>
        /// The constructor of Familles.
        /// </summary>
        public Familles()
        {
            this.RefFamille = 0;
            this.FamilleName = null;
        }

        /// <summary>
        /// The constructor of Familles.
        /// </summary>
        /// <param name="FamilleName"></param>
        public Familles(string FamilleName)
        {
            this.FamilleName = FamilleName;
        }

        /// <summary>
        /// The constructor of Familles.
        /// </summary>
        /// <param name="RefFamille"></param>
        /// <param name="FamilleName"></param>
        public Familles(int RefFamille, string FamilleName)
        {
            this.RefFamille = RefFamille;
            this.FamilleName = FamilleName;
        }

        /// <summary>
        /// Get the values of all variables.
        /// </summary>
        /// <returns>A string Array contains the values of all variables of <c>Familles</c>.</returns>
        public string[] InfoTable()
        {
            string[] Table = { this.FamilleName };
            return Table;
        }
    }
}
