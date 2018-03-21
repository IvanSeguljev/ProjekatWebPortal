using System.Web;
using System.Web.Mvc;

namespace Projekat
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            /* filters.Add(new System.Web.Mvc.AuthorizeAttribute());
             filters.Add(new RequireHttpsAttribute());*/
            filters.Add(new AuthorizeAttribute() { Roles = "Administrator, Ucenik, Urednik, Profesor" });
        }
    }
}
