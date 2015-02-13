using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MikeRobbins.EntityServiceDemo.Interfaces;
using MikeRobbins.EntityServiceDemo.Models;
using Sitecore.Data.Items;

namespace MikeRobbins.EntityServiceDemo.DataAccess
{
    public class NewsCreator : INewsCreator
    {
        public TemplateItem Template { get; set; }
        public Item ParentItem { get; set; }

        private IFieldUpdater _iFieldUpdater = null;

        public NewsCreator(IFieldUpdater iFieldUpdater)
        {
            _iFieldUpdater = iFieldUpdater;
        }

        public void CreateNewsArticle(NewsArticle newsArticle)
        {
            var newItem = ParentItem.Add(newsArticle.Title, Template);

            _iFieldUpdater.AddFieldsToItem(newItem, newsArticle);
        }

    }
}