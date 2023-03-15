using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mb.Application.contracts.ArticaleCategory;
using Mb.Domain.Repository;

namespace Mb.Application
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _repository;

        public ArticleCategoryApplication(IArticleCategoryRepository repository)
        {
            _repository = repository;
        }

        public List<ArticleCategoryViewModel> Get_Alllist()
        {
            var Articles = _repository.Get_all_Articles();
            var Result=new List<ArticleCategoryViewModel>();

            foreach (var Article in Articles)
            {
                Result.Add(new ArticleCategoryViewModel
                {
                    Id = Article.Id,
                    Title = Article.Title,
                    IsDeleted = Article.IsDeleted,
                    CreationDate = Article.CreationDate.ToString()

                });
            }

            return Result;
        }

        public void Create(CreateArticleCategory Command)
        {
            var NewArticleCategory = new Domain.ArticleCategory(Command.Title);
            _repository.Create(NewArticleCategory);
        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _repository.GetBy(command.Id);
            articleCategory.Rename(command.Title);
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
    }   
}
