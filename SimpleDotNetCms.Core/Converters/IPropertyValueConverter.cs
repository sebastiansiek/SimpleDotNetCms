using System;
using System.Reflection;
using SimpleDotNetCms.Core.Domain;

namespace SimpleDotNetCms.Core.Converters
{
    public interface IPropertyValueConverter
    {
        bool CanManageProperty(Type type);

        PropertyValueBase ToCmsPropertyValue<T>(PropertyInfo propertyInfo, T item);
        T FromCmsPropertyValue<T>(PropertyValueBase propertyValue);
    }
}
