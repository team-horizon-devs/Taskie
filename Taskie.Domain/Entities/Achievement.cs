using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskie.Domain.Entities
{
    class Achievement : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority1 { get; set; }
        public int Priority2 { get; set; }
        public int Priority3 { get; set; }
    }
}
