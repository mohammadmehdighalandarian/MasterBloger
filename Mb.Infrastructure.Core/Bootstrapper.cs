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
        public static void Config(IServiceCollection services, string? connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();


            services.AddDbContext<MasterBloggerContext>(options =>
                options.UseSqlServer(connectionString));

        }
    }
}