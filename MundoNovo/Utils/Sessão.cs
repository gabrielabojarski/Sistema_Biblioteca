using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MundoNovo.Utils
{
    public class Sessão
    {

        public static string RetornarGuidId()
        {
            if (HttpContext.Current.Session["GuidId"] == null)
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session["GuidId"] = guid.ToString();
            }
            return HttpContext.Current.Session["GuidId"].ToString();
        }
        public static void ReiniciarSessao()
        {
            HttpContext.Current.Session["GuidId"] = null;
        }
    }
}