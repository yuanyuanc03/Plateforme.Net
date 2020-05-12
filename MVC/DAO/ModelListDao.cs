using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.MVC.DAO
{
    /// <summary>
    /// The class <c>ModelList</c> which contains the basic method of the management of the database.
    /// </summary>
    class ModelListDao
    {
        public static ArticlesDao ArticleDao = new ArticlesDao();
        public static FamillesDao FamilleDao = new FamillesDao();
        public static SousFamillesDao SousFamilleDao = new SousFamillesDao();
        public static MarquesDao MarqueDao = new MarquesDao();

        /// <summary>
        /// Empty the database.
        /// </summary>
        public static void EmptyDataBase()
        {
            ArticleDao.EmptyArticles();
            FamilleDao.EmptyFamilles();
            SousFamilleDao.EmptySousFamilles();
            MarqueDao.EmptyMarques();
        }
    }
}
