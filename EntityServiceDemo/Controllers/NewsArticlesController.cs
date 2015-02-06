using MikeRobbins.EntityServiceDemo.Models;
using MikeRobbins.EntityServiceDemo.Repositories;
using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;

namespace MikeRobbins.EntityServiceDemo.Controllers
{

    [ServicesController]
    public class NewsArticlesController : EntityService<NewsArticle>
    {
        public NewsArticlesController(IRepository<NewsArticle> repository)
            : base(repository)
        {
        }

        public NewsArticlesController()
            : this(new NewsArticleRepository())
        {
        }


    }
}