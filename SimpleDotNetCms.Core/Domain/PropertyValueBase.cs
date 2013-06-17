using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleDotNetCms.Core.Domain
{
    public abstract class PropertyValueBase
    {
        public bool IsCurrent { get; set; }
        public string Locale { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid VersionGuid { get; set; }
        public long VersionTimeStamp { get; set; }
    }
}
