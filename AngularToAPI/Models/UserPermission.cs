using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularToAPI.Models
{
    public class UserPermission
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public int componentId { get; set; }
        public string componentName { get; set; }
        public bool InsertYN { get; set; }
        public bool UpdateYN { get; set; }
        public bool DeleteYN { get; set; }
        public bool ViewYN { get; set; }
        public bool PrintYN { get; set; }
    }
}
