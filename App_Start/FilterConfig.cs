﻿using System.Web;
using System.Web.Mvc;

namespace Sample_ASP.NET_Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
