using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MikeRobbins.EntityServiceDemo.DataAccess;
using MikeRobbins.EntityServiceDemo.Interfaces;
using MikeRobbins.EntityServiceDemo.Mapper;
using Sitecore.Services.Core;

namespace MikeRobbins.EntityServiceDemo.IoC
{
    public class Registry: StructureMap.Configuration.DSL.Registry
    {
        public Registry()
        {
            For<IFieldUpdater>().Use<FieldUpdater>();
            For<INewsUpdater>().Use<NewsUpdater>();
            For<INewsMapper>().Use<NewsMapper>();
            For<INewsReader>().Use<NewsReader>();
            For<INewsCreator>().Use<NewsCreator>();
            For<ISitecoreUtilities>().Use<ISitecoreUtilities>();
            For(typeof(IRepository<>)).Use(typeof(MikeRobbins.EntityServiceDemo.Repositories.NewsArticleRepository));
        }
    }
}