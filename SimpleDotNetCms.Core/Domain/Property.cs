using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleDotNetCms.Core.Domain
{
    public class Property
    {
        public string Name { get; set; }
        public string ValueType { get; set; }

        public PropertyValueBase Value { get; set; }
    }
}
