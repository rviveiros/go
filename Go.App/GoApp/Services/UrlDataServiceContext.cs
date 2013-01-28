<<<<<<< HEAD
﻿using System.Linq;
using GoApp.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace GoApp.Services
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
=======
﻿using System.Linq;
using GoApp.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace GoApp.Services
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
>>>>>>> 84c628054bb0e29387fcf436fe3a3589a312ed0f
}