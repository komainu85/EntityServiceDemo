using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MikeRobbins.EntityServiceDemo.Attributes;
using MikeRobbins.EntityServiceDemo.MetaData;

namespace MikeRobbins.EntityServiceDemo.Models
{
    public class NewsArticle : Sitecore.Services.Core.Model.EntityIdentity
    {
        public string itemId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [NotPastDate(ErrorMessage = "Date must be in the past")]
        public DateTime Date { get; set; }
    }
}