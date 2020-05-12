using Bacchus.MVC.Controller;
using Bacchus.MVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.MVC.DAO
{
    /// <summary>
    /// The class <c>ArticlesDao</c> which contains all the basic methods of the management of the articles.
    /// </summary>
    class ArticlesDao
    {
        private SQLiteConnection Connection;
        private String Query;

        /// <summary>
        /// The constructor of ArticlesDao.
        /// </summary>
        public ArticlesDao()
        {
            this.Connection = Util.GetConnection.ConnectionSQLite();
            this.Query = null;
        }

        /// <summary>
        /// Add an article to the database.
        /// </summary>
        /// <param name="Article"></param>
        public void AddArticle(Articles Article)
        {
            Query = "INSERT INTO Articles (RefArticle, Description, RefSousFamille, RefMarque, PrixHT" +
                    ", Quantite) values('"+Article.RefArticle+"','"+Article.Description+"','"+Article.SousFamille.RefSousFamille+"'," +
                    "'"+Article.Marque.RefMarque+"','"+Article.PrixHT+"','"+Article.Quantite+"')";  
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Delete an article from the databse.
        /// </summary>
        /// <param name="Article"></param>
        public void DeleteArticle(Articles Article)
        {
            Query = "DELETE FROM Articles WHERE RefArticle = '" + Article.RefArticle + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Update the values of an article.
        /// </summary>
        /// <param name="Article"></param>
        public void ModifyArticle(Articles Article)
        {
            Query = "UPDATE Articles SET Description = '" + Article.Description + "', RefSousFamille = '" + Article.SousFamille.RefSousFamille + "', " +
                "RefMarque = '" + Article.Marque.RefMarque + "', PrixHT = '" + Article.PrixHT + "', Quantite = '" + Article.Quantite + "' WHERE RefArticle = '"+ Article.RefArticle +"'";
            Console.WriteLine(Query);
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Get all the articles in the database.
        /// </summary>
        /// <returns>A list of class <c>Articles</c>c>.</returns>
        public List<Articles> GetAllArticles()
        {
            Query = "SELECT * FROM Articles";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();

            var Reader = Command.ExecuteReader();
            var Articles = new List<Articles>();
            MarquesController MarqueController = new MarquesController();
            FamillesController FamilleController = new FamillesController();
            SousFamillesController SousFamilleController = new SousFamillesController();

            while (Reader.Read())
            {
                var RefArticle = Reader.GetString(0);
                var Description = Reader.GetString(1);
                var SousFamille = SousFamilleController.FindSousFamilleByRefSousFamille(Reader.GetInt32(2));
                var Marque = MarqueController.FindMarqueByRefMarque(Reader.GetInt32(3));
                var Prix = Reader.GetString(4);
                if(Prix.IndexOf(",") != -1)
                    Prix = Prix.Replace(",", ".");
                var PrixHT = float.Parse(Prix, CultureInfo.InvariantCulture.NumberFormat);
                //var PrixHT = Reader.GetFloat(4);
                var Quantite = Reader.GetInt32(5);

                Articles.Add(new Articles(RefArticle, Description, FamilleController.FindFamillesByRefSousFamille(SousFamille.RefSousFamille) , SousFamille, Marque, PrixHT, Quantite));
            }

            Reader.Close();

            return Articles;
        }

        /// <summary>
        /// Clear all the articles in the database.
        /// </summary>
        public void EmptyArticles()
        {
            Query = "DELETE FROM Articles; DELETE FROM sqlite_sequence WHERE name = 'Articles'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            Command.ExecuteNonQuery();
        }
    }
}
