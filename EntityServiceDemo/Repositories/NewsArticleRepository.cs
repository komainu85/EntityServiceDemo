using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MikeRobbins.EntityServiceDemo.DataAccess;
using MikeRobbins.EntityServiceDemo.Interfaces;
using MikeRobbins.EntityServiceDemo.Models;
using MikeRobbins.EntityServiceDemo.Utilties;
using Sitecore.Data;
using StructureMap;

namespace MikeRobbins.EntityServiceDemo.Repositories
{
    public class NewsArticleRepository : Sitecore.Services.Core.IRepository<NewsArticle>
    {
        public NewsArticleRepository()
        {
            ObjectFactory.Initialize(x=>x.AddRegistry(new IoC.Registry()));
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

            // newsCreator.ParentItem= 
            //newsCreator.Template

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