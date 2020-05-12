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
    /// The class <c>FamillesController</c> contains the methods which are more complex than the methods in DAO. 
    /// </summary>
    class FamillesController
    {
        private SQLiteConnection Connection;
        private String Query;

        /// <summary>
        /// The constructor of FamillesController.
        /// </summary>
        public FamillesController()
        {
            this.Connection = Util.GetConnection.ConnectionSQLite();
            this.Query = null;
        }

        /// <summary>
        /// Verify the exist of a famille by the famille name.
        /// </summary>
        /// <param name="FamilleName"></param>
        /// <returns>True if exists. False if not.</returns>
        public Boolean FindFamilleByFamilleName(string FamilleName)
        {
            Query = "SELECT * FROM Familles WHERE Nom = '" + FamilleName + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            if (Reader.Read())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get a famille by the famille name if it exists.
        /// </summary>
        /// <param name="FamilleName"></param>
        /// <returns>A class <c>Familles</c> if it exists. Null if not.</returns>
        public Familles FindFamillesByFamilleName(string FamilleName)
        {
            Query = "SELECT * FROM Familles WHERE Nom = '" + FamilleName + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            if (Reader.Read())
            {
                var RefFamille = Reader.GetInt32(0);
                Familles Famille = new Familles(RefFamille, FamilleName);
                Reader.Close();
                return Famille;
            }
            else
                return null;
        }

        /// <summary>
        /// Get a famille by the reference of the famille if it exists.
        /// </summary>
        /// <param name="RefFamille"></param>
        /// <returns>A class <c>Familles</c> if it exists. Null if not.</returns>
        public Familles FindFamillesByRefFamille(int RefFamille)
        {
            Query = "SELECT * FROM Familles WHERE RefFamille = '" + RefFamille + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            if (Reader.Read())
            {
                var FamilleName = Reader.GetString(1);
                Familles Famille = new Familles(RefFamille, FamilleName);
                Reader.Close();
                return Famille;
            }
            else
                return null;
        }

        /// <summary>
        /// Get a famille by the reference of the sousfamille if it exists.
        /// </summary>
        /// <param name="RefSousFamille"></param>
        /// <returns>A class <c>Familles</c> if it exists. Null if not.</returns>
        public Familles FindFamillesByRefSousFamille(int RefSousFamille)
        {
            Query = "SELECT * FROM Familles WHERE RefFamille = (SELECT RefFamille FROM SousFamilles WHERE RefSousFamille = '"+RefSousFamille+"')";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            if (Reader.Read())
            {
                var RefFamille = Reader.GetInt32(0);
                var FamilleName = Reader.GetString(1);
                Familles Famille = new Familles(RefFamille, FamilleName);
                Reader.Close();
                return Famille;
            }
            else
                return null;
        }

        /// <summary>
        /// Get a famille by the sousfamille name if it exists.
        /// </summary>
        /// <param name="SousFamilleName"></param>
        /// <returns>A class <c>Familles</c> if it exists. Null if not.</returns>
        public Familles FindFamillesBySousFamilleName(String SousFamilleName)
        {
            Query = "SELECT * FROM Familles WHERE RefFamille = (SELECT RefFamille FROM SousFamilles WHERE Nom = '" + SousFamilleName + "')";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            if (Reader.Read())
            {
                var RefFamille = Reader.GetInt32(0);
                var FamilleName = Reader.GetString(1);
                Familles Famille = new Familles(RefFamille, FamilleName);
                Reader.Close();
                return Famille;
            }
            else
                return null;
        }

        /// <summary>
        /// Get all familles by marque name if it exists.
        /// </summary>
        /// <param name="MarqueName"></param>
        /// <returns>A list class of <c>Familles</c>.</returns>
        public List<Familles> FindFamillesByMarqueName(string MarqueName)
        {
            Query = "SELECT * FROM Familles WHERE RefFamille IN(SELECT RefFamille FROM SousFamilles WHERE RefSousFamille IN (SELECT RefSousFamille FROM Articles WHERE RefMarque = (SELECT RefMarque FROM Marques WHERE Nom = '" + MarqueName + "')))";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            List<Familles> Familles = new List<Familles>();
            while (Reader.Read())
            {
                var RefFamille = Reader.GetInt32(0);
                var FamilleName = Reader.GetString(1);

                Familles Famille = new Familles(RefFamille, FamilleName);
                Familles.Add(Famille);
            }
            Reader.Close();
            return Familles;
        }

        /// <summary>
        /// Verify if two familles are same.
        /// </summary>
        /// <param name="Famille"></param>
        /// <param name="NewFamille"></param>
        /// <returns>True if they are same. Flase if not.</returns>
        public Boolean CompareFamilles(Familles Famille, Familles NewFamille)
        {
            if (Famille.FamilleName != NewFamille.FamilleName)
                return false;
            else
                return true;
        }

    }
}
