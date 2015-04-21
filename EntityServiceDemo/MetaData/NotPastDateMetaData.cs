using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MikeRobbins.EntityServiceDemo.Attributes;
using Sitecore.Services.Core.MetaData;

namespace MikeRobbins.EntityServiceDemo.MetaData
{
    public class NotPastDateMetaData : ValidationMetaDataBase<NotPastDateAttribute>
    {
        public NotPastDateMetaData()
            : base("notPastDate")
        {
        }
    }
}