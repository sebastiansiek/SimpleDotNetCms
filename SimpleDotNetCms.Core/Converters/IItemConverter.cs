using SimpleDotNetCms.Core.Domain;

namespace SimpleDotNetCms.Core.Converters
{
    public interface IItemConverter
    {
        Item ToCmsItem<T>(T o);
        T FromCmsItem<T>(Item item);
    }
}