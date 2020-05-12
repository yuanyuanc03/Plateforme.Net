using Bacchus.MVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.MVC.DAO
{
    /// <summary>
    ///  The class <c>FamillesDao</c> which contains all the basic methods of the management of the familles.
    /// </summary>
    class FamillesDao
    {
        private SQLiteConnection Connection;
        private String Query;

        /// <summary>
        /// The constructor of FamillesDao.
        /// </summary>
        public FamillesDao()
        {
            this.Connection = Util.GetConnection.ConnectionSQLite();
            this.Query = null;
        }

        /// <summary>
        /// Add a famille to database.
        /// </summary>
        /// <param name="Famille"></param>
        public void AddFamille(Familles Famille)
        {
            Query = "INSERT INTO Familles (Nom) values('" + Famille.FamilleName + "')";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
            Famille.RefFamille = GetRefFamille(Famille.FamilleName);
        }

        /// <summary>
        /// Delete a famille from database.
        /// </summary>
        /// <param name="Famille"></param>
        public void DeleteFamille(Familles Famille)
        {
            Query = "DELETE FROM Familles WHERE Nom = '" + Famille.FamilleName + "' ; DELETE FROM Articles WHERE RefSousFamille IN (SELECT RefSousFamille FROM SousFamilles WHERE RefFamille = '" + Famille.RefFamille + "'); DELETE FROM SousFamilles WHERE RefFamille = '" + Famille.RefFamille +"'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Update the values of a famille.
        /// </summary>
        /// <param name="Famille"></param>
        public void ModifyFamille(Familles Famille)
        {
            Query = "UPDATE Familles SET Nom = '" + Famille.FamilleName + "' WHERE RefFamille = '" + Famille.RefFamille + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Get all the familles in the database.
        /// </summary>
        /// <returns>A list of class <c>Familles</c>c>.</returns>
        public List<Familles> GetAllFamilles()
        {
            Query = "SELECT * FROM Familles";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var Reader = Command.ExecuteReader();
            var Familles = new List<Familles>();

            while (Reader.Read())
            {
                var RefFamille = Reader.GetInt32(0);
                var FamilleName = Reader.GetString(1);

                Familles.Add(new Familles(RefFamille, FamilleName));
            }

            Reader.Close();

            return Familles;
        }

        /// <summary>
        /// Clear all the familles in the database.
        /// </summary>
        public void EmptyFamilles()
        {
            Query = "DELETE FROM Familles; DELETE FROM sqlite_sequence WHERE name = 'Familles'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Get the Reference of famille by the famille name.
        /// </summary>
        /// <param name="FamilleName"></param>
        /// <returns>An integrer.</returns>
        public int GetRefFamille(string FamilleName)
        {
            Query = "SELECT RefFamille FROM Familles WHERE Nom = '"+FamilleName+"'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var RefFamille = Command.ExecuteScalar().ToString().Trim();

            return Int32.Parse(RefFamille);
        }

        /// <summary>
        /// Get the amount of the familles.
        /// </summary>
        /// <returns>An integrer.</returns>
        public int CountFamilles()
        {
            Query = "SELECT COUNT(*) FROM Familles";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var Count = Command.ExecuteScalar().ToString().Trim();

            return Int32.Parse(Count);
        }

        /// <summary>
        /// Get the maximum ID of the famille.
        /// </summary>
        /// <returns>An intergrer.</returns>
        public int GetMaxRefFamille()
        {
            Query = "SELECT MAX(RefFamille) FROM Familles";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var MaxRefFamille = Command.ExecuteScalar().ToString().Trim();

            return Int32.Parse(MaxRefFamille);
        }
    }
}