using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularToAPI.Models
{
    public class RolePermission
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public int componentId { get; set; }
        public string componentName { get; set; }
        public int componentKindCode { get; set; }
        public bool InsertYN { get; set; }
        public bool UpdateYN { get; set; }
        public bool DeleteYN { get; set; }
        public bool ViewYN { get; set; }
        public bool PrintYN { get; set; }
    }
}
