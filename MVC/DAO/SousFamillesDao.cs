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
    ///  The class <c>SousFamillesDao</c> which contains all the basic methods of the management of the sousfamilles.
    /// </summary>
    class SousFamillesDao
    {
        private SQLiteConnection Connection;
        private FamillesDao FamilleDao;
        private String Query;

        /// <summary>
        /// The constructor of SousFamillesDao.
        /// </summary>
        public SousFamillesDao()
        {
            this.Connection = Util.GetConnection.ConnectionSQLite();
            this.FamilleDao = new FamillesDao();
            this.Query = null;
        }

        /// <summary>
        /// Add a sousfamille to the database.
        /// </summary>
        /// <param name="SousFamille"></param>
        /// <param name="Famille"></param>
        public void AddSousFamille(SousFamilles SousFamille, Familles Famille)
        {
            Query = "INSERT INTO SousFamilles (RefFamille, Nom) values('" + Famille.RefFamille + "', '" + SousFamille.SousFamilleName + "')";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
            SousFamille.RefSousFamille = GetRefSousFamille(SousFamille.SousFamilleName);
            SousFamille.RefFamille = FamilleDao.GetRefFamille(Famille.FamilleName);
        }

        /// <summary>
        /// Delete a sousfamille from database.
        /// </summary>
        /// <param name="SousFamille"></param>
        public void DeleteSousFamille(SousFamilles SousFamille)
        {
            Query = "DELETE FROM SousFamilles WHERE Nom = '" + SousFamille.SousFamilleName + "'; DELETE FROM Articles WHERE RefSousFamille = '"+ SousFamille.RefSousFamille +"'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Update all the values of a sousfamille.
        /// </summary>
        /// <param name="SousFamille"></param>
        public void ModifySousFamille(SousFamilles SousFamille)
        {
            Query = "UPDATE SousFamilles SET Nom = '" + SousFamille.SousFamilleName + "' WHERE RefSousFamille = '" + SousFamille.RefSousFamille + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Get all the sousfamilles in the database.
        /// </summary>
        /// <returns></returns>
        public List<SousFamilles> GetAllSousFamilles()
        {
            Query = "SELECT * FROM SousFamilles";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var Reader = Command.ExecuteReader();
            var SousFamilles = new List<SousFamilles>();

            while (Reader.Read())
            {
                var RefSousFamille = Reader.GetInt32(0);
                var RefFamille = Reader.GetInt32(1);
                var SousFamilleName = Reader.GetString(2);

                SousFamilles.Add(new SousFamilles(RefSousFamille, RefFamille, SousFamilleName));
            }

            Reader.Close();

            return SousFamilles;
        }

        /// <summary>
        /// Clear all the sousfamilles in the database.
        /// </summary>
        public void EmptySousFamilles()
        {
            Query = "DELETE FROM SousFamilles; DELETE FROM sqlite_sequence WHERE name = 'SousFamilles'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Get the Reference of sousfamille by the sousfamille name.
        /// </summary>
        /// <param name="SousFamilleName"></param>
        /// <returns>An integrer.</returns>
        public int GetRefSousFamille(string SousFamilleName)
        {
            Query = "SELECT RefSousFamille FROM SousFamilles WHERE Nom = '" + SousFamilleName + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var RefSousFamille = Command.ExecuteScalar().ToString().Trim();

            return Int32.Parse(RefSousFamille);
        }

        /// <summary>
        /// Get the amount of the sousfamilles.
        /// </summary>
        /// <returns>An integrer.</returns>
        public int CountSousFamilles()
        {
            Query = "SELECT COUNT(*) FROM SousFamilles";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var Count = Command.ExecuteScalar().ToString().Trim();

            return Int32.Parse(Count);
        }

        /// <summary>
        /// Get the maximum ID of the sousfamille.
        /// </summary>
        /// <returns>An integrer.</returns>
        public int GetMaxRefSousFamille()
        {
            Query = "SELECT MAX(RefSousFamille) FROM SousFamilles";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var MaxRefSousFamille = Command.ExecuteScalar().ToString().Trim();

            return Int32.Parse(MaxRefSousFamille);
        }
    }
}
