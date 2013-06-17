using System;

namespace SimpleDotNetCms.Core.Converters
{
    public interface IPropertyValueConverterFactory
    {
        IPropertyValueConverter GetConverter(Type type);
    }
}