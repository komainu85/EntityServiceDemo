using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikeRobbins.EntityServiceDemo.Models
{
    public class NewsArticle : Sitecore.Services.Core.Model.EntityIdentity
    {
        public string itemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}