using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.WindowsAzure.StorageClient;

namespace Go.Web.Models
{
    public sealed class Url : TableServiceEntity
    {
        [Required]
        public string Key { get; set; }

        [Required]
        [Url]
        public string Address { get; set; }

        public Url()
        {
            PartitionKey = "a";
            RowKey = string.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid());
        }
    }
}