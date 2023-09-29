using BookStore.RoutesConstraints;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace BookStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("minhaestacao", typeof(ValuesConstraint));

            routes.MapMvcAttributeRoutes(constraintsResolver);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
