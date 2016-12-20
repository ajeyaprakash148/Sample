using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Models
{
    public class TagsMasterModel
    {
        public int TagsId { get; set; }

        
        public string Name { get; set; }
        public string Label { get; set; }
        public string Color { get; set; }
    }
}
