using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MikeRobbins.EntityServiceDemo.DataAccess;
using MikeRobbins.EntityServiceDemo.Interfaces;
using MikeRobbins.EntityServiceDemo.Models;
using MikeRobbins.EntityServiceDemo.Utilties;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Sites;
using StructureMap;

namespace MikeRobbins.EntityServiceDemo.Repositories
{
    public class NewsArticleRepository : Sitecore.Services.Core.IRepository<NewsArticle>
    {
        public NewsArticleRepository()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new IoC.Registry()));
        }

        public IQueryable<NewsArticle> GetAll()
        {
            var newsReader = ObjectFactory.GetInstance<INewsReader>();

            return newsReader.GetNewsArticles().AsQueryable();
        }

        public NewsArticle FindById(string id)
        {
            var newsReader = ObjectFactory.GetInstance<INewsReader>();

            var sId = SitecoreUtilities.ParseId(id);

            return newsReader.GetNewsArticle(sId);
        }

        public void Add(NewsArticle entity)
        {
            var newsCreator = ObjectFactory.GetInstance<INewsCreator>();

            newsCreator.ParentItem = Sitecore.Data.Database.GetDatabase("master").GetItem(new ID("{68DA2C9B-DA93-4848-9EF3-07DA58E17319}"));
            newsCreator.Template = new TemplateItem(Sitecore.Data.Database.GetDatabase("master").GetItem(new ID("{18FF6308-E01B-4460-A884-C1DA8A25E515}")));

            newsCreator.CreateNewsArticle(entity);
        }

        public bool Exists(NewsArticle entity)
        {
            var newsReader = ObjectFactory.GetInstance<INewsReader>();

            return newsReader.NewsAticleExists(entity);
        }

        public void Update(NewsArticle entity)
        {
            var newsUpdater = ObjectFactory.GetInstance<NewsUpdater>();

            newsUpdater.UpdateNewsArticle(entity);
        }

        public void Delete(NewsArticle entity)
        {
            var newsUpdater = ObjectFactory.GetInstance<INewsUpdater>();
            newsUpdater.DeleteNewsArticle(entity);
        }
    }
}