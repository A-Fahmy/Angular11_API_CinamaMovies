using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularToAPI.Models
{
    public class ComponentsMenu
    {
        public int Id { get; set; }
        public int componentId { get; set; }
        public string componentName { get; set; }
        public string componentEnglishName { get; set; }
        public int componentKindCode { get; set; }
        public bool IsParentYN { get; set; }
    }
}
