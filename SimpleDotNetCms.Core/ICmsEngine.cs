using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleDotNetCms.Core
{
    public interface ICmsEngine
    {
        void SaveOrUpdate<T>(T item);
    }
}
