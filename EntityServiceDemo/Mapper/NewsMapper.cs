using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MikeRobbins.EntityServiceDemo.Interfaces;
using MikeRobbins.EntityServiceDemo.Models;
using Sitecore.Data.Items;

namespace MikeRobbins.EntityServiceDemo.Mapper
{
    public class NewsMapper : INewsMapper
    {
        public NewsArticle GetNewsArticle(Item item)
        {
            var newsArticle = new NewsArticle();

            var dateField = (Sitecore.Data.Fields.DateField)item.Fields["Date"];

            newsArticle.Title = item["Title"];
            newsArticle.Description = item["Description"];
            newsArticle.Date = dateField.DateTime;
            newsArticle.itemId = item.ID.ToString();
            newsArticle.Id = item.ID.ToString();
            newsArticle.Url = item.Paths.ContentPath;

            return newsArticle;
        }
    }
}