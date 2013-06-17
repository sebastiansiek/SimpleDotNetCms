using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SimpleDotNetCms.Core.Converters;
using SimpleDotNetCms.Core.Domain;
using SimpleDotNetCms.Core.Extensions;
using SimpleDotNetCms.Core.Supporting.Reflection;

namespace SimpleDotNetCms.Core.Supporting
{
    public interface ICmsItemFactory
    {
        Item CreateCmsItem(object o, bool isChild);
    }

    public class CmsItemFactory : ICmsItemFactory
    {
        private readonly IPropertyValueConverterFactory _propertyValueConverterFactory;

        public CmsItemFactory(IPropertyValueConverterFactory propertyValueConverterFactory)
        {
            _propertyValueConverterFactory = propertyValueConverterFactory;
        }

        private static Item CreateItem(string objectId, string fullTypeName)
        {
            return new Item()
                {
                    ObjectId = objectId,
                    Properties = new List<Property>(),
                    ValueType = fullTypeName
                };
        }

        public Item CreateCmsItem(object o, bool isChild)
        {
            if (o == null)
                return null;

            var objectReader = ObjectReader.CreateReader(o);

            var objectId = objectReader.GetCmsObjectId();

            if (!isChild && String.IsNullOrEmpty(objectId))
                throw new Exception("Parent item must have CmsId attribute specified");

            var cmsItem = CreateItem(objectId, objectReader.FullTypeName);

            foreach (var propertyInfo in objectReader.GetCmsProperties())
            {
                var property = new Property()
                {
                    Name = propertyInfo.Name,
                    ValueType = propertyInfo.PropertyType.FullName
                };


                var propertyValueConverter = _propertyValueConverterFactory.GetConverter(propertyInfo.PropertyType);
                if (propertyValueConverter != null)
                {
                    property.Value = propertyValueConverter.ToCmsPropertyValue(propertyInfo, o);
                }

                //THIS IS FOR COMPLEX TYPES - NEEDS TO BE REFACTORED AND IMPLEMENTED
                //property.Value = new ComplexPropertyValue()
                //{
                //    CreatedDate = DateTime.Now,
                //    IsCurrent = true,
                //    Locale = Thread.CurrentThread.CurrentCulture.Name,
                //    VersionGuid = Guid.NewGuid(),
                //    VersionTimeStamp = DateTime.Now.Ticks,
                //    Value = CreateCmsItem(propertyInfo.GetValue(o, null), true)
                //};

                cmsItem.Properties.Add(property);
            }

            return cmsItem;
        }
    }
}
