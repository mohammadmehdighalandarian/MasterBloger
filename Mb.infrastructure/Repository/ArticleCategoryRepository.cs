using Mb.Domain.ArticleCategoryAgg.Repository;
using Mb.Domain.ArticleCategoryAgg.Services;

namespace Mb.infrastructure.EFCore.Repository
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
            Save();
        }

        public ArticleCategory GetBy(long id)
        {
            return _context.ArticleCategories.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool ArticleCategoryExist(string title)
        {
            return _context.ArticleCategories.Any(x => x.Title == title);
        }
    }
}
