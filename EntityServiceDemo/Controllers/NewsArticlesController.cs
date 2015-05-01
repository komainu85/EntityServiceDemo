using System.Web.Http.Cors;
using MikeRobbins.EntityServiceDemo.Models;
using MikeRobbins.EntityServiceDemo.Repositories;
using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;

namespace MikeRobbins.EntityServiceDemo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [ServicesController]
    public class NewsArticlesController : EntityService<NewsArticle>
    {
     
        //public NewsArticlesController()
        //    : this(new NewsArticleRepository())
        //{
        //}
        public NewsArticlesController(IRepository<NewsArticle> repository) : base(repository)
        {
        }
    }
}