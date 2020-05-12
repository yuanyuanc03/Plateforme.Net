using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bacchus.MVC.Model;

namespace Bacchus.MVC.DAO
{
    /// <summary>
    /// The class of <c>ModelList</c>. 
    /// Contains the necessary lists of class which can be used when access to the DB.
    /// </summary>
    public class ModelList
    {
        public List<Articles> Articles { get; set; }
        public List<Familles> Familles { get; set; }
        public List<Marques> Marques { get; set; }
        public List<SousFamilles> SousFamilles { get; set; }

        /// <summary>
        /// The constructor of ModelLists.
        /// </summary>
        public ModelList()
        {
            ArticlesDao ArticleDao = new ArticlesDao();
            MarquesDao MarqueDao = new MarquesDao();
            FamillesDao FamilleDao = new FamillesDao();
            SousFamillesDao SousFamilleDao = new SousFamillesDao();

            this.Articles = ArticleDao.GetAllArticles();
            this.Familles = FamilleDao.GetAllFamilles();
            this.Marques = MarqueDao.GetAllMarques();
            this.SousFamilles = SousFamilleDao.GetAllSousFamilles();
        }
    }
}
