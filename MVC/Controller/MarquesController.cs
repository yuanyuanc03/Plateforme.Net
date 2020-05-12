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
    /// The class <c>MarquesController</c> contains the methods which are more complex than the methods in DAO. 
    /// </summary>
    class MarquesController
    {
        private SQLiteConnection Connection;
        private String Query;

        /// <summary>
        /// The constructor of MarquesController.
        /// </summary>
        public MarquesController()
        {
            this.Connection = Util.GetConnection.ConnectionSQLite();
            this.Query = null;
        }

        /// <summary>
        /// Verify the exist of a marque by the marque name.
        /// </summary>
        /// <param name="MarqueName"></param>
        /// <returns>True if exists. False if not.</returns>
        public Boolean FindMarqueByMarqueName(string MarqueName)
        {
            Query = "SELECT * FROM Marques WHERE Nom = '" + MarqueName + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            if (Reader.Read())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get a marque by the marque name if it exists.
        /// </summary>
        /// <param name="MarqueName"></param>
        /// <returns>A class <c>Marques</c> if it exists. Null if not.</returns>
        public Marques FindMarquesByMarqueName(string MarqueName)
        {
            Query = "SELECT * FROM Marques WHERE Nom = '" + MarqueName + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            if (Reader.Read())
            {
                var RefMarque = Reader.GetInt32(0);
                Marques Marque = new Marques(RefMarque, MarqueName);
                Reader.Close();
                return Marque;
            }
            else
                return null;
        }

        /// <summary>
        /// Get a marque by the reference if it exists.
        /// </summary>
        /// <param name="RefMarque"></param>
        /// <returns>A class <c>Marques</c> if it exists. Null if not.</returns>
        public Marques FindMarqueByRefMarque(int RefMarque)
        {
            Query = "SELECT * FROM Marques WHERE RefMarque = '"+RefMarque+"'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                var MarqueName = Reader.GetString(1);
                Marques Marque = new Marques(RefMarque, MarqueName);
                Reader.Close();
                return Marque;
            }
            else
                return null;
        }

        /// <summary>
        /// Get all marques by the sousfamille name if it exists.
        /// </summary>
        /// <param name="SousFamilleNAme"></param>
        /// <returns>A list of class <c>Marques</c>.</returns>
        public List<Marques> FindMarquesBySousFamilleName(string SousFamilleName)
        {
            Query = "SELECT * FROM Marques WHERE RefMarque IN (SELECT RefMarque FROM Articles WHERE RefSousFamille = (SELECT RefSousFamille FROM SousFamilles WHERE Nom = '" + SousFamilleName + "'))";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            List<Marques> Marques = new List<Marques>();
            while (Reader.Read())
            {
                var RefMarque = Reader.GetInt32(0);
                var MarqueName = Reader.GetString(1);

                Marques Marque = new Marques(RefMarque, MarqueName);
                Marques.Add(Marque);
            }
            Reader.Close();
            return Marques;
        }

        /// <summary>
        /// Verify if two marques are same.
        /// </summary>
        /// <param name="Marque"></param>
        /// <param name="NewMarque"></param>
        /// <returns>True if they are same. Flase if not.</returns>
        public Boolean CompareMarques(Marques Marque, Marques NewMarque)
        {
            if (Marque.MarqueName != NewMarque.MarqueName)
                return false;
            else
                return true;
        }
    }
}
