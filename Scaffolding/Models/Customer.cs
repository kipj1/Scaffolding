using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Scaffolding.Models
{
    public class Customer
    {
        //---------------Customer Object------------------------
        [Key]
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
    }
}