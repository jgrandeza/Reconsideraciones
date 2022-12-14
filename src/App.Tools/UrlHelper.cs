using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Tools
{
    public static class UrlHelper
    {
        public static string GetLocalUrl(this IUrlHelper urlHelper, string localUrl)
        {
            if (!urlHelper.IsLocalUrl(localUrl))
            {
                return urlHelper.Content("~/Home/");
            }

            return localUrl;
        }
        public static string GetPath(HttpRequest request)
        {
            string Url = string.Format("{0}://{1}", request.Scheme, request.Host);
            if (!string.IsNullOrEmpty(request.PathBase))
            {
                Url += request.PathBase + "/";
            }
            else
            {
                Url = string.Format("{0}://{1}/", request.Scheme, request.Host);
            }
            return Url;
        }
    }
}
