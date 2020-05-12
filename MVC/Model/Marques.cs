using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.MVC.Model
{
    /// <summary>
    /// The class of <c>Marques</c>. 
    /// Contains all the constructors and accessors of the class.
    /// </summary>
    public class Marques
    {
        public int RefMarque { get; set; }
        public string MarqueName { get; set; }

        /// <summary>
        /// The constructor of Marques.
        /// </summary>
        public Marques()
        {
            this.RefMarque = 0;
            this.MarqueName = null;
        }

        /// <summary>
        /// The constructor of Marques.
        /// </summary>
        /// <param name="MarqueName"></param>
        public Marques(string MarqueName)
        {
            this.MarqueName = MarqueName;
        }

        /// <summary>
        /// The constructor of Marques.
        /// </summary>
        /// <param name="RefMarque"></param>
        /// <param name="MarqueName"></param>
        public Marques(int RefMarque, string MarqueName)
        {
            this.RefMarque = RefMarque;
            this.MarqueName = MarqueName;
        }

        /// <summary>
        /// Get the values of all variables.
        /// </summary>
        /// <returns>A string Array contains the values of all variables of <c>Marques</c>.</returns>
        public string[] InfoTable()
        {
            string[] Table = { this.MarqueName };
            return Table;
        }
    }
}
