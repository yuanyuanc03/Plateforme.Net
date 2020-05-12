using Bacchus.MVC.DAO;
using Bacchus.MVC.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.MVC.Controller
{
    /// <summary>
    /// The class <c>ArticlesController</c> contains the methods which are more complex than the methods in DAO. 
    /// </summary>
    class ArticlesController
    {
        private SQLiteConnection Connection;
        private String Query;
        private MarquesController MarqueController;
        private FamillesController FamilleController;
        private SousFamillesController SousFamilleController;

        /// <summary>
        /// The constructor of ArticlesController.
        /// </summary>
        public ArticlesController()
        {
            this.Connection = Util.GetConnection.ConnectionSQLite();
            this.Query = null;
            this.MarqueController = new MarquesController();
            this.FamilleController = new FamillesController();
            this.SousFamilleController = new SousFamillesController();
        }

        /// <summary>
        /// Verify the exist of an article by the reference.
        /// </summary>
        /// <param name="RefArticle"></param>
        /// <returns>True if exists. False if not.</returns>
        public Boolean FindArticleByRefArticle(string RefArticle)
        {
            Query = "SELECT * FROM Articles WHERE RefArticle = '"+RefArticle+"'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            if (Reader.Read())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get an article by the reference if it exists.
        /// </summary>
        /// <param name="RefArticle"></param>
        /// <returns>A class <c>Articles</c> if it exists. Null if not.</returns>
        public Articles FindArticlesByRefArticle(string RefArticle)
        {
            Query = "SELECT * FROM Articles WHERE RefArticle = '" + RefArticle + "'";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            if (Reader.Read())
            {
                var Description = Reader.GetString(1);
                var RefSousFamille = Reader.GetInt32(2);
                var RefMarque = Reader.GetInt32(3);
                var Prix = Reader.GetString(4);
                Prix = Prix.Replace(",", ".");
                var PrixHT = float.Parse(Prix, CultureInfo.InvariantCulture.NumberFormat);
                var Quantite = Reader.GetInt32(5);
                
                Articles Article = new Articles(RefArticle, Description, FamilleController.FindFamillesByRefSousFamille(RefSousFamille),
                    SousFamilleController.FindSousFamilleByRefSousFamille(RefSousFamille), 
                    MarqueController.FindMarqueByRefMarque(RefMarque), PrixHT, Quantite);
                Reader.Close();
                return Article;
            }
            else
                return null;
        }

        /// <summary>
        /// Verify the exist of an article by famille name.
        /// </summary>
        /// <param name="FamilleName"></param>
        /// <returns>True if exists. False if not.</returns>
        public Boolean FindArticleByFamilleName(string FamilleName)
        {
            Query = "SELECT * FROM Articles WHERE RefSousFamille = ( SELECT RefSousFamille FROM SousFamilles WHERE RefFamille = (SELECT RefFamille FROM Familles WHERE Nom = '" + FamilleName + "'))";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            if (Reader.Read())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get all articles by the famille name if it exists.
        /// </summary>
        /// <param name="FamilleName"></param>
        /// <returns>A list of class <c>Articles</c>.</returns>
        public List<Articles> FindArticlesByFamilleName(string FamilleName)
        {
            Query = "SELECT * FROM Articles WHERE RefSousFamille = ( SELECT RefSousFamille FROM SousFamilles WHERE RefFamille = (SELECT RefFamille FROM Familles WHERE Nom = '" + FamilleName + "'))";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            List<Articles> Articles = new List<Articles>();
            while (Reader.Read())
            {
                var RefArticle = Reader.GetString(0);
                var Description = Reader.GetString(1);
                var RefSousFamille = Reader.GetInt32(2);
                var RefMarque = Reader.GetInt32(3);
                var Prix = Reader.GetString(4);
                Prix = Prix.Replace(",", ".");
                var PrixHT = float.Parse(Prix, CultureInfo.InvariantCulture.NumberFormat);
                var Quantite = Reader.GetInt32(5);

                Articles Article = new Articles(RefArticle, Description, FamilleController.FindFamillesByRefSousFamille(RefSousFamille), 
                    SousFamilleController.FindSousFamilleByRefSousFamille(RefSousFamille),
                    MarqueController.FindMarqueByRefMarque(RefMarque), PrixHT, Quantite);
                Articles.Add(Article);
            }
            Reader.Close();
            return Articles;
        }

        /// <summary>
        /// Verify the exist of an article by marque name.
        /// </summary>
        /// <param name="MarqueName"></param>
        /// <returns>True if exists. False if not.</returns>
        public Boolean FindArticleByMarqueName(string MarqueName)
        {
            Query = "SELECT * FROM Articles WHERE RefMarque = (SELECT RefMarque FROM Marques WHERE Nom = '" + MarqueName + "')";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            if (Reader.Read())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get all articles by the marque name if it exists.
        /// </summary>
        /// <param name="MarqueName"></param>
        /// <returns>A list of class <c>Articles</c>.</returns>
        public List<Articles> FindArticlesByMarqueName(string MarqueName)
        {
            Query = "SELECT * FROM Articles WHERE RefMarque = (SELECT RefMarque FROM Marques WHERE Nom = '" + MarqueName + "')";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            List<Articles> Articles = new List<Articles>();
            while (Reader.Read())
            {
                var RefArticle = Reader.GetString(0);
                var Description = Reader.GetString(1);
                var RefSousFamille = Reader.GetInt32(2);
                var RefMarque = Reader.GetInt32(3);
                var Prix = Reader.GetString(4);
                Prix = Prix.Replace(",", ".");
                var PrixHT = float.Parse(Prix, CultureInfo.InvariantCulture.NumberFormat);
                var Quantite = Reader.GetInt32(5);

                Articles Article = new Articles(RefArticle, Description, FamilleController.FindFamillesByRefSousFamille(RefSousFamille), 
                    SousFamilleController.FindSousFamilleByRefSousFamille(RefSousFamille),
                    MarqueController.FindMarqueByRefMarque(RefMarque), PrixHT, Quantite);
                Articles.Add(Article);
            }
            Reader.Close();
            return Articles;
        }

        /// <summary>
        /// Verify the exist of an article by sousfamille name.
        /// </summary>
        /// <param name="SousFamilleName"></param>
        /// <returns>True if exists. False if not.</returns>
        public Boolean FindArticleBySousFamilleName(string SousFamilleName)
        {
            Query = "SELECT * FROM Articles WHERE RefSousFamille = (SELECT RefSousFamille FROM SousFamilles WHERE Nom = '" + SousFamilleName + "')";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            if (Reader.Read())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get all articles by the sousfamille name if it exists.
        /// </summary>
        /// <param name="SousFamilleName"></param>
        /// <returns>A list of class <c>Articles</c>.</returns>
        public List<Articles> FindArticlesBySousFamilleName(string SousFamilleName)
        {
            Query = "SELECT * FROM Articles WHERE RefSousFamille = (SELECT RefSousFamille FROM SousFamilles WHERE Nom = '" + SousFamilleName + "')";
            SQLiteCommand Command = new SQLiteCommand(Query, Connection);
            var Reader = Command.ExecuteReader();

            List<Articles> Articles = new List<Articles>();
            while (Reader.Read())
            {
                var RefArticle = Reader.GetString(0);
                var Description = Reader.GetString(1);
                var RefSousFamille = Reader.GetInt32(2);
                var RefMarque = Reader.GetInt32(3);
                var Prix = Reader.GetString(4);
                Prix = Prix.Replace(",", ".");
                var PrixHT = float.Parse(Prix, CultureInfo.InvariantCulture.NumberFormat);
                var Quantite = Reader.GetInt32(5);

                Articles Article = new Articles(RefArticle, Description, FamilleController.FindFamillesByRefSousFamille(RefSousFamille), 
                    SousFamilleController.FindSousFamilleByRefSousFamille(RefSousFamille),
                    MarqueController.FindMarqueByRefMarque(RefMarque), PrixHT, Quantite);
                Articles.Add(Article);
            }
            Reader.Close();
            return Articles;
        }

        /// <summary>
        /// Verify if two articles are same.
        /// </summary>
        /// <param name="Article"></param>
        /// <param name="NewArticle"></param>
        /// <returns>True if they are same. Flase if not.</returns>
        public Boolean CompareArticles(Articles Article, Articles NewArticle)
        {
            if (Article.Description != NewArticle.Description || 
                Article.PrixHT != NewArticle.PrixHT || Article.Quantite != NewArticle.Quantite || Article.Marque.RefMarque 
                != NewArticle.Marque.RefMarque || Article.SousFamille.RefSousFamille != NewArticle.SousFamille.RefSousFamille)
                return false;
            else
                return true;
        }

    }
}
