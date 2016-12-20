using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Entities
{

    public class InvoiceEntity : BaseEntity
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
        public ClientEntity From { get; set; }
        public ClientEntity Client { get; set; }
        public IList<ServiceEntity> Services { get; set; }
        
    }
}
