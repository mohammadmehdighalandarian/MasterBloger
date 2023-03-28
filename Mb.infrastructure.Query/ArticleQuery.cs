using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Mb.infrastructure.Query;

public class ArticleQuery : IArticleQuery
{
    private readonly MasterBloggerContext _context;

    public ArticleQuery(MasterBloggerContext context)
    {
        _context = context;
    }
    public List<ArticleQueryView> Get_All_Articles()
    {
        return _context.Articles.Include(x => x.ArticleCategory)
            .Where(x=>x.IsDeleted==false)
            .Select(x => new ArticleQueryView
            {
                Id = x.id,
                Image = x.Image,
                ShortDiscreption = x.ShortDiscreption,
                ArticleCategory = x.ArticleCategory.Title,
                Titel = x.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).ToList();
    }

    public ArticleQueryView Get_ById(long id)
    {
        return _context.Articles.Include(x => x.ArticleCategory)
            .Select(x => new ArticleQueryView
            {
                Id = x.id,
                Image = x.Image,
                ShortDiscreption = x.ShortDiscreption,
                ArticleCategory = x.ArticleCategory.Title,
                Titel = x.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Content = x.Context
            }).FirstOrDefault(x=>x.Id==id);
    }
}