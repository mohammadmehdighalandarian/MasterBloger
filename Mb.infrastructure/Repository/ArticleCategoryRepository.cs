using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mb.Domain;
using Mb.Domain.Repository;

namespace Mb.infrastructure.Repository
{
    public class ArticleCategoryRepository:IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleCategory> Get_all_Articles()
        {
            return _context.ArticleCategories.ToList();
        }

        public void Create(ArticleCategory command)
        {
            _context.ArticleCategories.Add(command);
            _context.SaveChanges();
        }
    }
}
