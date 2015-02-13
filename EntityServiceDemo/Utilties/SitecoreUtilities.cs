using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace MikeRobbins.EntityServiceDemo.Utilties
{
    public static class SitecoreUtilities
    {

        public static ID ParseId(string id)
        {
            var sID = ID.Null;

            ID.TryParse(id, out sID);

            return sID;
        }

    }
}