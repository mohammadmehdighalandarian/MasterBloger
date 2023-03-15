using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mb.Domain.ArticleCategoryAgg.Repository;

namespace Mb.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorServices:IArticleCategoryValidatorServices
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorServices(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void ArticleCategoryExist(string title)
        {
            if (_articleCategoryRepository.ArticleCategoryExist(title))
                throw new Exception();
        }
    }
}
