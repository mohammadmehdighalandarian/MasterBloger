using Mb.Application;
using Mb.Application.contracts.ArticaleCategory;
using Mb.Application.contracts.Article;
using Mb.Application.contracts.Comment;
using Mb.Domain.ArticleAgg.Repository;
using Mb.Domain.ArticleAgg.Services;
using Mb.Domain.ArticleCategoryAgg.Repository;
using Mb.Domain.ArticleCategoryAgg.Services;
using Mb.Domain.CommentAgg.Repository;
using Mb.infrastructure;
using Mb.infrastructure.EFCore.Repository;
using Mb.infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mb.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            service.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            service.AddTransient<IArticleCategoryValidatorServices, ArticleCategoryValidatorServices>();

            service.AddTransient<IArticleApplication,ArticleApplication>();
            service.AddTransient<IArticleRepository, ArticleRepository>();
            service.AddTransient<IArticleValidatorServices, ArticleValidatoreservices>();

            service.AddTransient<IArticleQuery, ArticleQuery>();

            service.AddTransient<ICommentRepository, CommentRepository>();
            service.AddTransient<ICommentApplication, CommentApplication>();
            

            #region DBcontext

            service.AddDbContext<MasterBloggerContext>(options =>
                options.UseSqlServer(connectionString));

            #endregion

        }
    }
}