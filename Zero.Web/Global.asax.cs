using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Zero.Web.Infrastructure;
using static Zero.Web.Infrastructure.CustomSearchModelBinding;

namespace Zero.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            ModelBinderProviders.BinderProviders.Insert(0, new DataTablesToObjectModelBinderProvider());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
        }
    }
}