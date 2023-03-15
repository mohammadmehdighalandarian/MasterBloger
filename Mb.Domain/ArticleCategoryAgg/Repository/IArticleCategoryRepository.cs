namespace Mb.Domain.ArticleCategoryAgg.Repository
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> Get_all_Articles();

        void Create(ArticleCategory command);

        ArticleCategory GetBy(long id);

        void Save();

        bool ArticleCategoryExist(string title);

    }
}
