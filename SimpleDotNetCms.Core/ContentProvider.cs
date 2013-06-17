using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleDotNetCms.Core
{
    public class ContentProvider : IContentProvider
    {
        public void SaveOrUpdate<T>(T item)
        {
            throw new NotImplementedException();
        }

        public T Load<T>(T item)
        {
            throw new NotImplementedException();
        }
    }
}
