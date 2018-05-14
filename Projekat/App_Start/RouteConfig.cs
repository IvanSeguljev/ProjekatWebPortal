using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projekat
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Materijali",
                url: "Materijali/Prikaz/{id}/{namenaID}",
                defaults: new { controller = "Materijal", action = "MaterijaliPrikaz", id = UrlParameter.Optional, namenaID = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "MaterijaliZaProf",
              url: "Materijali/ZaProfesore/{namenaID}",
              defaults: new { controller = "Materijal", action = "MaterijaliPrikaz", namenaID = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }    
            );
            
        }
    }
}
