using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MikeRobbins.EntityServiceDemo.Interfaces;
using Sitecore.Data;

namespace MikeRobbins.EntityServiceDemo.Utilties
{
    public class SitecoreUtilities : ISitecoreUtilities
    {
        public ID ParseId(string id)
        {
            var sID = ID.Null;

            ID.TryParse(id, out sID);

            return sID;
        }

    }
}