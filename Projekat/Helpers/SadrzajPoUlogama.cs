using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekat.Helpers
{
    public static class SadrzajPoUlogama
    {
        public static bool isUrednik(this ViewUserControl pg)
        {
            return pg.Page.User.IsInRole("Urednik");
        }
        public static bool isAdmin(this ViewUserControl pg)
        {
            return pg.Page.User.IsInRole("Administrator");
        }
    }
}