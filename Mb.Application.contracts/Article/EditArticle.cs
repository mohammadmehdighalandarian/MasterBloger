using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mb.Application.contracts.Article
{
    public class EditArticle:ArticleViewModel
    {
        public String Image { get; set; }

        public String Content { get; set; }

        public string ShortDiscreption { get; set; }

        public long ArticleCategoryId { get; set; }
    }
}
