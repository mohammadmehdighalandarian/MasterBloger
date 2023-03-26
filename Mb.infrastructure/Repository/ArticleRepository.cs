using Mb.Domain.ArticleAgg;
using Mb.Domain.ArticleAgg.Repository;
using Mb.Domain.ArticleCategoryAgg.Services;

namespace Mb.infrastructure.EFCore.Repository
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<Article> Get_all_Articles()
        {
            return _context.Articles.ToList();
        }

        public void Create(Article article)
        {
            _context.Articles.Add(article);
            Save();
        }

        public Article Get_BY_Id(long id)
        {
            return _context.Articles.FirstOrDefault(x => x.id == id);
        }

        public ArticleCategory Get(long id)
        {
            return _context.ArticleCategories.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
