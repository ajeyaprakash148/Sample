using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Models
{
    public class ServiceModel
    {
        [Key]
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Unit { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Quantity { get; set; }
        public decimal? Total { get; set; }

        public int InvoiceId { get; set; }
        public InvoiceModel Invoice { get; set; }
    }
}
