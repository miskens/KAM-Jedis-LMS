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
            name: "RouteToSenderAfterRegistration",
            url: "Account/Register/{sender}/{gId}",
            defaults: new { controller = "Account", action = "Register", sender = UrlParameter.Optional, gId = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "RouteToReferrerAtCreate",
            url: "{controller}/Create/{sender}/{gId}/{cId}",
            defaults: new { controller = "Group", action = "Create", sender = UrlParameter.Optional, gId = UrlParameter.Optional, cId = UrlParameter.Optional }
            );

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
            name: "RouteToSenderCourseActivitiesCreate",
            url: "Activities/Create/{sender}/{gId}/{cId}",
            defaults: new { controller = "Activities", action = "Create", sender = UrlParameter.Optional, gId = UrlParameter.Optional, cId = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "RouteToSenderCourseActivities",
            url: "Activities/{action}/{id}/{sender}/{gId}/{cId}",
            defaults: new { controller = "Activities", action = "Index", id = UrlParameter.Optional, sender = UrlParameter.Optional, gId = UrlParameter.Optional, cId = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "RouteToSenderGroupDocumentsCreate",
            url: "Documents/Create/{gId}",
            defaults: new { controller = "Documents", action = "Create", gId = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "RouteToSenderCourseDocumentsCreate",
            url: "Documents/Create/{cId}",
            defaults: new { controller = "Documents", action = "Create", cId = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "RouteToSenderActivityDocumentsCreate",
            url: "Documents/Create/{aId}",
            defaults: new { controller = "Documents", action = "Create", aId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
