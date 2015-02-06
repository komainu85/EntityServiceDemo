using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MikeRobbins.EntityServiceDemo.Models;
using Sitecore.Data;

namespace MikeRobbins.EntityServiceDemo.Repositories
{
    public class NewsArticleRepository : Sitecore.Services.Core.IRepository<NewsArticle>
    {
        public IQueryable<NewsArticle> GetAll()
        {
            var articles = new List<NewsArticle>();

            articles.Add(new NewsArticle(){Date = DateTime.Now.ToString(), itemId ="fsfdfsd", Id = "fsfdfsd", Title = "sdfsdfsdf"});

            return articles.AsQueryable();
        }

        public NewsArticle FindById(string id)
        {
            var newsArticle = Sitecore.Data.Database.GetDatabase("master").GetItem(new ID(id));

            if (newsArticle != null)
            {
                return new NewsArticle() { Id = newsArticle.ID.ToString(), Title = newsArticle["Title"], Description = newsArticle["Description"]};
            }
            else
            {
                return null;
            }
        }

        public void Add(NewsArticle entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(NewsArticle entity)
        {
            var newsArticle = Sitecore.Data.Database.GetDatabase("master").GetItem(new ID(entity.Id));

            return newsArticle != null;
        }

        public void Update(NewsArticle entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(NewsArticle entity)
        {
            throw new NotImplementedException();
        }
    }
}