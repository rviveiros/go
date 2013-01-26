using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GoApp.Models;
using GoApp.Services;
using Microsoft.WindowsAzure;

namespace GoApp.Controllers
{
    public class UrlController : Controller
    {
        public ActionResult Redir(string urlKey)
        {
            var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            var context = new UrlDataServiceContext(account.TableEndpoint.ToString(), account.Credentials)
                              {
                                  ResolveType = s => typeof (Url)
                              };

            var url = (from u in context.Urls
                      where urlKey.Equals(u.Key, StringComparison.InvariantCultureIgnoreCase)
                      select u).SingleOrDefault();
            
            if (url != null)
                return RedirectPermanent(url.Address);

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult List()
        {
            var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            var context = new UrlDataServiceContext(account.TableEndpoint.ToString(), account.Credentials);
            
            return View(context.Urls);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Url url)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }                

            try
            {
                var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                var context = new UrlDataServiceContext(account.TableEndpoint.ToString(), account.Credentials);

                context.AddUrl(url);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Exception", e.Message);
                return View();
            }

            return RedirectToAction("List");
        }
    }
}
