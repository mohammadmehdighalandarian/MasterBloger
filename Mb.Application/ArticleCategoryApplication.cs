using Mb.Application.contracts.ArticaleCategory;
using Mb.Domain.ArticleCategoryAgg;
using Mb.Domain.ArticleCategoryAgg.Repository;
using Mb.Domain.ArticleCategoryAgg.Services;

namespace Mb.Application
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _repository;
        private readonly IArticleCategoryValidatorServices _validatorServices;

        public ArticleCategoryApplication(IArticleCategoryRepository repository)
        {
            _repository = repository;
        }

        public List<ArticleCategoryViewModel> Get_All_list()
        {
            var articles = _repository.Get_all_Articles();
            var result=new List<ArticleCategoryViewModel>();

            foreach (var Article in articles)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = Article.Id,
                    Title = Article.Title,
                    IsDeleted = Article.IsDeleted,
                    CreationDate = Article.CreationDate.ToString()

                });
            }

            return result;
        }

        public void Create(CreateArticleCategory Command)
        {
            var newArticleCategory = new ArticleCategory(Command.Title, _validatorServices);
            _repository.Create(newArticleCategory);
        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _repository.GetBy(command.Id);
            articleCategory.Rename(command.Title, _validatorServices);
            _repository.Save();
        }

        public RenameArticleCategory Get(long id)
        {
            var articleCategory= _repository.GetBy(id);

            return new RenameArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
            };

        }

        public void Delete(long id)
        {
            var articleCategory=_repository.GetBy(id);
            articleCategory.Remove();
            _repository.Save();
        }

        public void Activated(long id)
        {
            var articleCategory = _repository.GetBy(id);
            articleCategory.Activate();
            _repository.Save();
        }
    }   
}
