using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleDotNetCms.Core.Domain;

namespace SimpleDotNetCms.Core
{
    public interface ICmsRepository
    {
        void AddOrUpdate(Item cmsItem);
        void Delete(int id);
        Item Get(int id);
        Item Find(string objectId, string valueType);
    }
}
