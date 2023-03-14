using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mb.Application.contracts.ArticaleCategory;

namespace Mb.Domain.Repository
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory>Get_all_Articles();
        void Create(ArticleCategory command);
        ArticleCategory GetBy(long id);
        void Edit(EditArticleCategory command);
        void Save();

    }
}
