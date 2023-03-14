namespace Mb.Application.contracts.ArticaleCategory;

public interface IArticleCategoryApplication
{
    List<ArticleCategoryViewModel> Get_Alllist();

    void Create(CreateArticleCategory Command);

    void Edit();
    

}