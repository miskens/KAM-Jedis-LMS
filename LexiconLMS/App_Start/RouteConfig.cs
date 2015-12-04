using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LexiconLMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "RouteToSenderCourses",
            url: "Courses/{action}/{id}/{sender}/{gId}",
            defaults: new { controller = "Courses", action = "Details", id = UrlParameter.Optional, sender = UrlParameter.Optional, gId = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "RouteToSenderUserDetails",
            url: "Users/{action}/{id}/{sender}/{gId}",
            defaults: new { controller = "Users", action = "Details", id = UrlParameter.Optional, sender = UrlParameter.Optional, gId = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "RouteToSenderGroupDetails",
            url: "Group/{action}/{id}/{sender}/{gId}",
            defaults: new { controller = "Group", action = "Details", id = UrlParameter.Optional, sender = UrlParameter.Optional, gId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
