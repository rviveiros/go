using System.Linq;
using Go.Web.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace Go.Web.Services
{
    public class UrlDataServiceContext : TableServiceContext
    {
        public UrlDataServiceContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
        }

        public IQueryable<Url> Urls
        {
            get
            {
                return this.CreateQuery<Url>("Urls");
            }
        }

        public void AddUrl(Url url)
        {
            this.AddObject("Urls", url);
            this.SaveChanges();
        }

        public void AddUrl(string key, string address)
        {
            AddUrl(new Url { Key = key, Address = address });
        }

    }
}