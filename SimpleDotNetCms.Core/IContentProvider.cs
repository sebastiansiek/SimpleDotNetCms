using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleDotNetCms.Core
{
    public interface IContentProvider
    {
        void SaveOrUpdate<T>(T item);
        T Load<T>(T item);
    }
}
