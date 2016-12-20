using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Models
{

    public class InvoiceModel
    {
        [Key]
        public int InvoiceId { get; set; }
        
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }

        public decimal? Subtotal { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Total { get; set; }
        public ClientModel From { get; set; }
        public ClientModel Client { get; set; }
        public IList<ServiceModel> Services { get; set; }
        
    }
}
