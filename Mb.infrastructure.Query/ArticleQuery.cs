using System.Globalization;
using System.Linq;
using Mb.Domain.CommentAgg;
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
        return _context.Articles
            .Include(x => x.ArticleCategory)
            .Include(x=>x.Comments)
            .Where(x=>x.IsDeleted==false)
            .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Image = x.Image,
                ShortDiscreption = x.ShortDiscreption,
                ArticleCategory = x.ArticleCategory.Title,
                Titel = x.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                CommentCount = x.Comments.Count(x=>x.Status==Status.Confirmed),
            }).ToList();
    }

    public ArticleQueryView Get_ById(long id)
    {
        return _context.Articles.Include(x => x.ArticleCategory)
            .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Image = x.Image,
                ShortDiscreption = x.ShortDiscreption,
                ArticleCategory = x.ArticleCategory.Title,
                Titel = x.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Content = x.Context,
                CommentCount = x.Comments.Count(x => x.Status == Status.Confirmed),
                Comments = MapComments(x.Comments.Where(x=>x.Status==Status.Confirmed))
            }).FirstOrDefault(x=>x.Id==id);
    }

    private static List<CommentQueryView> MapComments(IEnumerable<Comment> Comments)
    {
        var comments = new List<CommentQueryView>();
        foreach (var item in Comments)
        {
            comments.Add(new CommentQueryView()
            {
                Name = item.Name,
                CreationDate = item.CreationDate.ToString(),
                Message = item.Message
            });
        }

        return comments;
    }
}