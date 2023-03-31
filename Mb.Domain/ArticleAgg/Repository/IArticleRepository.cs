using Mb.Domain.ArticleCategoryAgg.Services;
using Mb.Domain.CommentAgg;

namespace Mb.Domain.ArticleAgg.Repository
{
    public interface IArticleRepository
    {
        List<Article> Get_all_Articles();

        List<Comment> Get_Comment_Of_Article(long articleId);

        void Create(Article article);

        Article Get_BY_Id(long id);

        ArticleCategory Get(long id);

        bool Exist(string titel);

        void Save();
    }
}
