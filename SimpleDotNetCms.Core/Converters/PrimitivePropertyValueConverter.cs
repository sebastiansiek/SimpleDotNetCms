using System;
using System.Reflection;
using System.Threading;
using SimpleDotNetCms.Core.Domain;
using SimpleDotNetCms.Core.Extensions;

namespace SimpleDotNetCms.Core.Converters
{
    public class PrimitivePropertyValueConverter : PropertyValueConverterBase, IPropertyValueConverter
    {
        public bool CanManageProperty(Type type)
        {
            return (type.IsSimpleType());
        }

        public PropertyValueBase ToCmsPropertyValue<T>(PropertyInfo propertyInfo, T item)
        {
            var result = new PrimitivePropertyValue()
                             {
                                 CreatedDate = DateTime.Now,
                                 IsCurrent = true,
                                 Locale = Thread.CurrentThread.CurrentCulture.Name,
                                 VersionGuid = Guid.NewGuid(),
                                 VersionTimeStamp = DateTime.Now.Ticks,
                                 Value = propertyInfo.GetValue(item, null).ToString()
                             };

            return result;
        }

        public T FromCmsPropertyValue<T>(PropertyValueBase propertyValue)
        {
            throw new NotImplementedException();
        }
    }
}
