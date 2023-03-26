using Mb.Application;
using Mb.Application.contracts.ArticaleCategory;
using Mb.Application.contracts.Article;
using Mb.Domain.ArticleAgg.Repository;
using Mb.Domain.ArticleCategoryAgg.Repository;
using Mb.Domain.ArticleCategoryAgg.Services;
using Mb.infrastructure;
using Mb.infrastructure.EFCore.Repository;
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
            service.AddTransient<IArticleApplication,ArticleApplication>();
            service.AddTransient<IArticleRepository, ArticleRepository>();
            service.AddTransient<IArticleCategoryValidatorServices,ArticleCategoryValidatorServices>();


            service.AddDbContext<MasterBloggerContext>(options =>
                options.UseSqlServer(connectionString));

        }
    }
}