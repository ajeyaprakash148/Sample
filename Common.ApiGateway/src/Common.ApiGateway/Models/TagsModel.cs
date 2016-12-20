using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Models
{
    public class TagsModel
    {
        public int TagsId { get; set; }

        
        public string Name { get; set; }
        public string Label { get; set; }
        public string Color { get; set; }

        public int TasksId { get; set; }

        public TasksModel TasksModel { get; set; }
    }
}
