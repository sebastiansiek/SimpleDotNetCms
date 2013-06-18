using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SimpleDotNetCms.Core.Converters;
using SimpleDotNetCms.Core.Repositories;

namespace SimpleDotNetCms.Core.Supporting.IoC.CastleWindsor
{
    public class ComponentInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IPropertyValueConverter>().ImplementedBy<PrimitivePropertyValueConverter>());
            container.Register(Component.For<IPropertyValueConverter>().ImplementedBy<ComplexPropertyValueConverter>());
            container.Register(Component.For<IItemManager>().ImplementedBy<ItemManager>());
            container.Register(Component.For<IItemConverter>().ImplementedBy<ItemConverter>());
            container.Register(Component.For<IPropertyValueConverterFactory>().ImplementedBy<PropertyValueConverterFactory>());
            container.Register(Component.For<ICmsItemFactory>().ImplementedBy<CmsItemFactory>());
        }
    }
}
