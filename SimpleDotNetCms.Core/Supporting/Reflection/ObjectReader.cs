using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SimpleDotNetCms.Core.Attributes;

namespace SimpleDotNetCms.Core.Supporting.Reflection
{
    public class ObjectReader
    {
        public static ObjectReader CreateReader<T>(T o)
        {
            return new ObjectReader(o.GetType(), o);
        }

        private readonly List<PropertyInfo> _properties;
        private readonly object _object;
        private readonly Type _type;

        private ObjectReader(Type type, object o)
        {
            _type = type;
            _properties = type.GetProperties().ToList();
            _object = o;
        }

        public IEnumerable<PropertyInfo> Properties
        {
            get { return _properties; }
        }

        private PropertyInfo GetCmsIdProperty()
        {
            return _properties.FirstOrDefault(p => Attribute.IsDefined(p, typeof (CmsIdAttribute)));
        }

        public IEnumerable<PropertyInfo> GetCmsProperties()
        {
            return _properties.Where(p => Attribute.IsDefined(p, typeof (CmsItemAttribute)));
        }

        public string GetCmsObjectId()
        {
            var idProperty = GetCmsIdProperty();
            return idProperty == null ? string.Empty : idProperty.GetValue(_object, null).ToString();
        }

        public string FullTypeName
        {
            get { return _type.FullName; }
        }

        
    }
}
