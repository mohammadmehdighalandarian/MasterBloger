namespace Mb.Application.contracts.ArticaleCategory;

public interface IArticleCategoryApplication
{
    List<ArticleCategoryViewModel> Get_All_list();

    void Create(CreateArticleCategory Command);

    void Rename(RenameArticleCategory command);

    RenameArticleCategory Get(long id);

    void Delete(long id);

    void Activated(long id);


}