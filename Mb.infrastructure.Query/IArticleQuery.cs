namespace Mb.infrastructure.Query
{
    public interface IArticleQuery
    {
        List<ArticleQueryView> Get_All_Articles();
        ArticleQueryView Get_ById(long id);
    }
}
