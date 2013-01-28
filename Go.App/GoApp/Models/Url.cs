<<<<<<< HEAD
﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.WindowsAzure.StorageClient;

namespace GoApp.Models
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
=======
﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.WindowsAzure.StorageClient;

namespace GoApp.Models
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
>>>>>>> 84c628054bb0e29387fcf436fe3a3589a312ed0f
}