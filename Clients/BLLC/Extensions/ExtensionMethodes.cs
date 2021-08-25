using System;
using System.Linq;
using System.Web;

namespace BLLC.Extensions
{
    public static class ExtensionMethodes
    {
        /// <summary>
        /// Permet de créer automatiquement la partie requête de l'URI selon les requêtes demandées
        /// </summary>
        /// <param name="obj">L'objet appelant la méthode</param>
        /// <returns>La partie requête de l'URI au format string</returns>
        public static string ToUriQuery(this object obj)
        {
            var proprietes = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());
            return "?" + String.Join("&", proprietes.ToArray());
        }
    }
}
