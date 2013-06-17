using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SimpleDotNetCms.Core.Domain;
using SimpleDotNetCms.Core.Extensions;
using SimpleDotNetCms.Core.Supporting;
using SimpleDotNetCms.Core.Supporting.Reflection;

namespace SimpleDotNetCms.Core.Converters
{
    public class ItemConverter : IItemConverter
    {
        private readonly ICmsItemFactory _cmsItemFactory;

        public ItemConverter(ICmsItemFactory cmsItemFactory)
        {
            _cmsItemFactory = cmsItemFactory;
        }

        public Item ToCmsItem<T>(T o)
        {
            return _cmsItemFactory.CreateCmsItem(o, false);
        }

        public T FromCmsItem<T>(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
