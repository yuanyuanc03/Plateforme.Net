using Bacchus.MVC.DAO;
using Bacchus.MVC.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.MVC.Controller
{
    /// <summary>
    /// The class <c>SousFamillesController</c> contains the methods which are more complex than the methods in DAO. 
    /// </summary>
    class SousFamillesController
    {
        private SQLiteConnection Connection;
        private String Query;

        /// <summary>
        /// The constructor of SousFamillesController.
        /// </summary>
        public SousFamillesController()
        {
            this.Connection = Util.GetConnection.ConnectionSQLite();
            this.Query = null;
        }

        /// <summary>
        /// Verify the exist of a sousfamille by the sousfamille name.
        /// </summary>
        /// <param name="SousFamilleName"></param>
        /// <returns>True if exists. False if not.</returns>
        public Boolean FindSousFamilleBySousFamilleName(string SousFamilleName)
        {
            Query = "SELECT * FROM SousFamilles WHERE Nom = '" + SousFamilleName + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            if (Reader.Read())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get a sousfamille by the sousfamille name if it exists.
        /// </summary>
        /// <param name="SousFamilleName"></param>
        /// <returns>A class <c>SousFamilles</c> if it exists. Null if not.</returns>
        public SousFamilles FindSousFamillesBySousFamilleName(string SousFamilleName)
        {
            Query = "SELECT * FROM SousFamilles WHERE Nom = '" + SousFamilleName + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            if (Reader.Read())
            {
                var RefSousFamille = Reader.GetInt32(0);
                var RefFamille = Reader.GetInt32(1);

                SousFamilles SousFamille = new SousFamilles(RefSousFamille, RefFamille, SousFamilleName);
                Reader.Close();
                return SousFamille;
            }
            else
                return null;
        }

        /// <summary>
        /// Get a sousfamille by the reference if it exists.
        /// </summary>
        /// <param name="RefSousFamille"></param>
        /// <returns>A class <c>SousFamilles</c> if it exists. Null if not.</returns>
        public SousFamilles FindSousFamilleByRefSousFamille(int RefSousFamille)
        {
            Query = "SELECT * FROM SousFamilles WHERE RefSousFamille = '" + RefSousFamille + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                var RefFamille = Reader.GetInt32(1);
                var SousFamilleName = Reader.GetString(2);

                SousFamilles SousFamille = new SousFamilles(RefSousFamille, RefFamille, SousFamilleName);
                Reader.Close();
                return SousFamille;
            }
            else
                return null;
        }

        /// <summary>
        /// Get all sousfamilles by the famille name if it exists.
        /// </summary>
        /// <param name="FamilleName"></param>
        /// <returns>A list of class <c>SousFamilles</c>.</returns>
        public List<SousFamilles> FindSousFamillesByFamilleName(string FamilleName)
        {
            Query = "SELECT * FROM SousFamilles WHERE RefFamille = (SELECT RefFamille FROM Familles WHERE Nom = '" + FamilleName + "')";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            List<SousFamilles> SousFamilles = new List<SousFamilles>();
            while (Reader.Read())
            {
                var RefSousFamille = Reader.GetInt32(0);
                var RefFamille = Reader.GetInt32(1);
                var SousFamilleName = Reader.GetString(2);

                SousFamilles SousFamille = new SousFamilles(RefSousFamille, RefFamille, SousFamilleName);
                SousFamilles.Add(SousFamille);
            }
            Reader.Close();
            return SousFamilles;
        }

        /// <summary>
        /// Get all sousfamilles by the marque name if it exists.
        /// </summary>
        /// <param name="MarqueName"></param>
        /// <returns>A list of class <c>SousFamilles</c>.</returns>
        public List<SousFamilles> FindSousFamillesByMarqueName(string MarqueName)
        {
            Query = "SELECT * FROM SousFamilles WHERE RefSousFamille IN (SELECT RefSousFamille FROM Articles WHERE RefMarque = (SELECT RefMarque FROM Marques WHERE Nom = '" + MarqueName + "'))";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            List<SousFamilles> SousFamilles = new List<SousFamilles>();
            while (Reader.Read())
            {
                var RefSousFamille = Reader.GetInt32(0);
                var RefFamille = Reader.GetInt32(1);
                var SousFamilleName = Reader.GetString(2);

                SousFamilles SousFamille = new SousFamilles(RefSousFamille, RefFamille, SousFamilleName);
                SousFamilles.Add(SousFamille);
            }
            Reader.Close();
            return SousFamilles;
        } 

        /// <summary>
        /// Verify if two sousfamilles are same.
        /// </summary>
        /// <param name="SousFamille"></param>
        /// <param name="NewSousFamille"></param>
        /// <returns>True if they are same. Flase if not.</returns>
        public Boolean CompareSousFamilles(SousFamilles SousFamille, SousFamilles NewSousFamille)
        {
            if (SousFamille.SousFamilleName != NewSousFamille.SousFamilleName)
                return false;
            else
                return true;
        }
    }
}
