using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Entities
{
    public class ShortcutsEntity : BaseEntity
    {
        [Key]
        public int ShortcutId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string State { get; set; }
        //public BadgeEntity Badge { get; set; }
        public int Weight { get; set; }
        //public string[] Children { get; set; }
        public string Id { get; set; }
        public string Path { get; set; }
        public string Uisref { get; set; }
        public bool HasShortcut { get; set; }
    }
    //public class BadgeEntity
    //{
    //    public int Content { get; set; }
    //    public string Color { get; set; }
    //}
}
