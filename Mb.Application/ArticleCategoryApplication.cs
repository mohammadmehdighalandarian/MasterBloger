using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mb.Application.contracts.ArticaleCategory;
using Mb.Domain.Repository;

namespace Mb.Application
{
    public class ArticleCategory:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _repository;

        public ArticleCategory(IArticleCategoryRepository repository)
        {
            this._repository = repository;
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
    }
}
