using Mb.Application.contracts.Article;
using Mb.Domain.ArticleAgg;
using Mb.Domain.ArticleAgg.Repository;
using Mb.Domain.ArticleAgg.Services;
using Mb.Domain.ArticleCategoryAgg.Repository;

namespace Mb.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _categoryRepository;
        private readonly IArticleValidatorServices _validatorServices;

        public ArticleApplication(IArticleRepository articleRepository, IArticleCategoryRepository categoryRepository, IArticleValidatorServices validatorServices)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _validatorServices = validatorServices;
        }
        
        public List<ArticleViewModel> Get_All_Articles()
        {
            var Article = _articleRepository.Get_all_Articles();
            var ArticlesVM = new List<ArticleViewModel>();

            foreach (var item in Article)
            {
                ArticlesVM.Add(new ArticleViewModel
                {
                    id = item.id,
                    CreationDate = item.CreationDate,
                    IsDeleted = item.IsDeleted,
                    Title = item.Title,
                    ArticleCategory = _categoryRepository.GetBy(item.ArticleCategoryId).Title,
                    Comments = _articleRepository.Get_Comment_Of_Article(item.id)
                });
            }

            return ArticlesVM;
        }

        public void Create(CreateArticle command)
        {
            var articleCategory = _articleRepository.Get(command.ArticleCategoryId);
            var Article = new Article(command.Title, command.ShortDiscreption, command.Image, command.Context, command.ArticleCategoryId);
            Article.IsExist(_validatorServices,command.Title);
            _articleRepository.Create(Article);

        }

        public EditArticle Get_ById(long id)
        {
            var Article = _articleRepository.Get_BY_Id(id);
            var article = new EditArticle()
            {
                id = Article.id,
                Title = Article.Title,
                ArticleCategory = _categoryRepository.GetBy(Article.ArticleCategoryId).Title,
                Content = Article.Context,
                ShortDiscreption = Article.ShortDiscreption,
                Image = Article.Image,
                ArticleCategoryId = Article.ArticleCategoryId

            };

            return article;
        }

        public void Edit(EditArticle Command)
        {
            var Article = _articleRepository.Get_BY_Id(Command.id);
            Article.Edit(Command.Title, Command.ShortDiscreption, Command.Image, Command.Content, Command.ArticleCategoryId);
            _articleRepository.Save();
        }

        public void Remove(long id)
        {
            var Article = _articleRepository.Get_BY_Id(id);
            Article.Remove();
            _articleRepository.Save();
        }

        public void Restore(long id)
        {
            var Article = _articleRepository.Get_BY_Id(id);
            Article.Restore();
            _articleRepository.Save();
        }
    }
}
