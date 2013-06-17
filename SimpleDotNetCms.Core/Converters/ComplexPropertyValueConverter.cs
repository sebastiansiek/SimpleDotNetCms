using System;
using System.Reflection;
using SimpleDotNetCms.Core.Domain;
using SimpleDotNetCms.Core.Extensions;

namespace SimpleDotNetCms.Core.Converters
{
    public class ComplexPropertyValueConverter : PropertyValueConverterBase, IPropertyValueConverter
    {
        public bool CanManageProperty(Type type)
        {
            return (!type.IsSimpleType());
        }

        public PropertyValueBase ToCmsPropertyValue<T>(PropertyInfo propertyInfo, T item)
        {
            return null;
        }

        public T FromCmsPropertyValue<T>(PropertyValueBase propertyValue)
        {
            throw new NotImplementedException();
        }
    }
}
