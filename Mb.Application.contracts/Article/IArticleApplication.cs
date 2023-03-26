using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mb.Application.contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> Get_All_Articles();

        void Create(CreateArticle command);

        EditArticle Get_ById(long id);

        void Edit(EditArticle Command);

        void Remove(long id);

        void Restore(long id);

    }
}
