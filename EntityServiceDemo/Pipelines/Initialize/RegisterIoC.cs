using System.Web.Http;
using System.Web.Routing;
using MikeRobbins.EntityServiceDemo.IoC;
using Sitecore.Pipelines;
using Sitecore.Services.Infrastructure.Sitecore;
using Sitecore.Services.Infrastructure.Web.Http;
using StructureMap;

namespace MikeRobbins.EntityServiceDemo.Pipelines.Initialize
{
    public class RegisterIoC
    {
        public void Process(PipelineArgs args)
        {
            var servicesConfig = GlobalConfiguration.Configuration;




            var container = new Container(new Registry());
            servicesConfig.DependencyResolver = new StructureMapDependencyResolver(container);
        }
    }
}