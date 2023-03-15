using Mb.Application;
using Mb.Application.contracts.ArticaleCategory;
using Mb.Domain.ArticleCategoryAgg.Repository;
using Mb.infrastructure;
using Mb.infrastructure.Repository;
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


            service.AddDbContext<MasterBloggerContext>(options =>
                options.UseSqlServer(connectionString));

        }
    }
}