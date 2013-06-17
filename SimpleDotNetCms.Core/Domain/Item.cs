using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleDotNetCms.Core.Domain
{
    public class Item
    {
        public int Id { get; set; }
        public string ObjectId { get; set; }
        public string ValueType { get; set; }
        public IList<Property> Properties { get; set; }
    }
}
