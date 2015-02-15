using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MikeRobbins.EntityServiceDemo.Interfaces;
using MikeRobbins.EntityServiceDemo.Models;
using MikeRobbins.EntityServiceDemo.Utilties;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace MikeRobbins.EntityServiceDemo.DataAccess
{
    public class NewsReader : INewsReader
    {
        private INewsMapper _iNewsMapper;

        public NewsReader(INewsMapper iNewsMapper)
        {
            _iNewsMapper = iNewsMapper;
        }

        public Item GetNewsItem(ID id)
        {
            return Sitecore.Data.Database.GetDatabase("master").GetItem(id);
        }

        public NewsArticle GetNewsArticle(ID id)
        {
            var item = GetNewsItem(id);

            return _iNewsMapper.GetNewsArticle(item);
        }

        public List<NewsArticle> GetNewsArticles()
        {
            var newsItems = new List<NewsArticle>();

            //TODO: Replace with search
            var newsFolder = Sitecore.Data.Database.GetDatabase("master").GetItem(new ID("{68DA2C9B-DA93-4848-9EF3-07DA58E17319}"));

            foreach (Item newsItem in newsFolder.Children)
            {
                newsItems.Add(_iNewsMapper.GetNewsArticle(newsItem));
            }

            return newsItems;
        }

        public bool NewsAticleExists(NewsArticle newsArticle)
        {
            var exists = false;

            if (newsArticle.Id != null)
            {
                var id = SitecoreUtilities.ParseId(newsArticle.Id);
                exists = Sitecore.Data.Database.GetDatabase("master").GetItem(id) != null;
            }

            return exists;
        }

    }
}