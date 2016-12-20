using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Entities
{
    public class TagsMasterEntity : BaseEntity
    {
        [Key]
        public int TagsId { get; set; }

        public string Name { get; set; }

        public string Label { get; set; }

        public string Color { get; set; }
    }
}
