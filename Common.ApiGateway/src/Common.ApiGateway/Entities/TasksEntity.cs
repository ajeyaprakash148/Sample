using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Entities
{
    public class TasksEntity : BaseEntity
    {
        [Key]
        public int TasksId { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Completed { get; set; }
        public bool? Starred { get; set; }
        public bool? Important { get; set; }
        public bool? Deleted { get; set; }
        public List<TagsEntity> Tags { get; set; }
    }
}
