using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MikeRobbins.EntityServiceDemo.DataAccess;
using MikeRobbins.EntityServiceDemo.Interfaces;
using MikeRobbins.EntityServiceDemo.Mapper;

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
        }
    }
}