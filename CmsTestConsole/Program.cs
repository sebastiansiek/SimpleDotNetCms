using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using SimpleDotNetCms.Core;
using SimpleDotNetCms.Core.Attributes;
using SimpleDotNetCms.Core.Converters;
using SimpleDotNetCms.Core.Repositories;
using SimpleDotNetCms.Core.Supporting;

namespace CmsTestConsole
{
    class Program
    {
        private static IWindsorContainer _container;

        private static void SetupWindsorContainer()
        {
            _container = new WindsorContainer();

            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel));

            //_container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter("Bin")).BasedOn<IPropertyValueConverter>().WithService.Base());
            _container.Register(Component.For<ICmsEngine>().ImplementedBy<CmsEngine>().LifestyleTransient());
            _container.Register(Component.For<IPropertyValueConverter>().ImplementedBy<PrimitivePropertyValueConverter>());
            _container.Register(Component.For<IPropertyValueConverter>().ImplementedBy<ComplexPropertyValueConverter>());
            _container.Register(Component.For<IItemManager>().ImplementedBy<ItemManager>());
            _container.Register(Component.For<ICmsRepository>().ImplementedBy<SimpleXmlRepository>());
            _container.Register(Component.For<IItemConverter>().ImplementedBy<ItemConverter>());
            _container.Register(Component.For<IPropertyValueConverterFactory>().ImplementedBy<PropertyValueConverterFactory>());
            _container.Register(Component.For<ICmsItemFactory>().ImplementedBy<CmsItemFactory>());
        }

        static void Main(string[] args)
        {
            SetupWindsorContainer();

            var cmsEngine = _container.Resolve<ICmsEngine>();

            var car = new Car()
                          {
                              CarId = "11",
                              Color = "Red",
                              IsAvailable = true,
                              NoDoors = 4,
                              VersionNumber = Guid.NewGuid(),
                              BodyInfo = new Body()
                                             {
                                                 BodyType = BodyType.Cabrio,
                                                 Name = "Body Body"
                                             },
                              Attributes = new List<string>()
                                               {
                                                   "family",
                                                   "diesel",
                                                   "no insurance claim",
                                                   "airbag"
                                               }
                          };

            cmsEngine.SaveOrUpdate(car);

            Console.ReadLine();
        }
    }

    public class Car
    {
        [CmsId]
        public string CarId { get; set; }

        [CmsItem]
        public string Color { get; set; }
        [CmsItem]
        public int NoDoors { get; set; }
        [CmsItem]
        public bool IsAvailable { get; set; }
        [CmsItem]
        public Guid VersionNumber { get; set; }

        [CmsItem]
        public Body BodyInfo { get; set; }

        [CmsItem]
        public List<string> Attributes { get; set; }
    }

    public class Body
    {
        [CmsItem]
        public string Name { get; set; }
        [CmsItem]
        public BodyType BodyType { get; set; }
    }

    public enum BodyType
    {
        Unknown = 0,
        Cabrio = 1
    }
}
