using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleDotNetCms.Core.Converters
{
    public class PropertyValueConverterFactory : IPropertyValueConverterFactory
    {
        private readonly IPropertyValueConverter[] _propertyValueConverters;

        public PropertyValueConverterFactory(IPropertyValueConverter[] propertyValueConverters)
        {
            _propertyValueConverters = propertyValueConverters;
        }

        public IPropertyValueConverter GetConverter(Type type)
        {
            return _propertyValueConverters.FirstOrDefault(c => c.CanManageProperty(type));
        }
    }
}
