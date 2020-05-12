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
    /// The class <c>MarquesDao</c> which contains all the basic methods of the management of the marques.
    /// </summary>
    class MarquesDao
    {
        private SQLiteConnection Connection;
        private String Query;

        /// <summary>
        /// The constructor of MarquesDao.
        /// </summary>
        public MarquesDao()
        {
            this.Connection = Util.GetConnection.ConnectionSQLite();
            this.Query = null;
        }

        /// <summary>
        /// Add a marque to the database.
        /// </summary>
        /// <param name="Marque"></param>
        public void AddMarque(Marques Marque)
        {
            Query = "INSERT INTO Marques (Nom) values('" + Marque.MarqueName + "')";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
            Marque.RefMarque = GetRefMarque(Marque.MarqueName);
        }

        /// <summary>
        /// Delete a marque from the database.
        /// </summary>
        /// <param name="Marque"></param>
        public void DeleteMarque(Marques Marque)
        {
            Query = "DELETE FROM Marques WHERE Nom = '" + Marque.MarqueName + "' ; DELETE FROM Articles WHERE RefMarque = '"+ Marque.RefMarque +"'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Update the values of a marque.
        /// </summary>
        /// <param name="Marque"></param>
        public void ModifyMarque(Marques Marque)
        {
            Query = "UPDATE Marques SET Nom = '" + Marque.MarqueName + "' WHERE RefMarque = '" + Marque.RefMarque + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Get all marques in the database.
        /// </summary>
        /// <returns>A list of class <c>Marques</c>c>.</returns>
        public List<Marques> GetAllMarques()
        {
            Query = "SELECT * FROM Marques";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var Reader = Command.ExecuteReader();
            var Marques = new List<Marques>();

            while (Reader.Read())
            {
                var RefMarque = Reader.GetInt32(0);
                var MarqueName = Reader.GetString(1);

                Marques.Add(new Marques(RefMarque, MarqueName));
            }

            Reader.Close();

            return Marques;
        }

        /// <summary>
        /// Clear all the marques in the database.
        /// </summary>
        public void EmptyMarques()
        {
            Query = "DELETE FROM Marques; DELETE FROM sqlite_sequence WHERE name = 'Marques'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Get the Reference of marque by the marque name.
        /// </summary>
        /// <param name="MarqueName"></param>
        /// <returns>An integrer.</returns>
        public int GetRefMarque(string MarqueName)
        {
            Query = "SELECT RefMarque FROM Marques WHERE Nom = '" + MarqueName + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var RefMarque = Command.ExecuteScalar().ToString().Trim();

            return Int32.Parse(RefMarque);
        }

        /// <summary>
        /// Get the amount of the marques.
        /// </summary>
        /// <returns>An integrer.</returns>
        public int CountMarques()
        {
            Query = "SELECT COUNT(*) FROM Marques";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var Count = Command.ExecuteScalar().ToString().Trim();

            return Int32.Parse(Count);
        }

        /// <summary>
        /// Get the maximum ID of the marque.
        /// </summary>
        /// <returns>An integrer.</returns>
        public int GetMaxRefMarque()
        {
            Query = "SELECT MAX(RefMarque) FROM Marques";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var MaxRefMarque = Command.ExecuteScalar().ToString().Trim();

            return Int32.Parse(MaxRefMarque);
        }
    }
}
