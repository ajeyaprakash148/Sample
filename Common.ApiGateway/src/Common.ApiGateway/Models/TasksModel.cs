using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Common.ApiGateway.Models
{
    public class TasksModel
    {

        public int TasksId { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Completed { get; set; }
        public bool? Starred { get; set; }
        public bool? Important { get; set; }
        public bool? Deleted { get; set; }
        public List<TagsModel> Tags { get; set; }
    }
}
