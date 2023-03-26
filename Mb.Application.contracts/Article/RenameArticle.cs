using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mb.Application.contracts.Article
{
    public class RenameArticle:CreateArticle
    {
        public long Id { get; set; }
    }
}
