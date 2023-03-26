using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mb.Domain.ArticleAgg.Repository;
using Mb.Domain.ArticleCategoryAgg.Repository;

namespace Mb.Domain.ArticleAgg.Services
{
    public class ArticleValidatoreservices:IArticleValidatorServices
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleValidatoreservices(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void ArticleExist(string title)
        {
            if (_articleRepository.Exist(title))
                throw new Exception();
        }
    }
}
