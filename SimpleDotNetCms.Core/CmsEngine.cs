using SimpleDotNetCms.Core.Converters;
using SimpleDotNetCms.Core.Supporting;

namespace SimpleDotNetCms.Core
{
    public class CmsEngine : ICmsEngine
    {
        private readonly IItemManager _itemManager;
        private readonly IItemConverter _itemConverter;
        private readonly ICmsRepository _cmsRepository;

        public CmsEngine(IItemManager itemManager, IItemConverter itemConverter, ICmsRepository cmsRepository)
        {
            _itemManager = itemManager;
            _itemConverter = itemConverter;
            _cmsRepository = cmsRepository;
        }

        public void SaveOrUpdate<T>(T item)
        {
            var cmsItem = _itemConverter.ToCmsItem(item);

            _cmsRepository.AddOrUpdate(cmsItem);
        }
    }
}
