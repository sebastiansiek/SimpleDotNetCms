using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleDotNetCms.Core.Domain;

namespace SimpleDotNetCms.Core.Repositories
{
    public class SimpleXmlRepository : ICmsRepository
    {
        private readonly SimpleXmlRepositoryConfiguration _configuration;

        public SimpleXmlRepository(SimpleXmlRepositoryConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddOrUpdate(Item cmsItem)
        {
            var dbItem = Find(cmsItem.ObjectId, cmsItem.ValueType);

            var x = 1;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Item Get(int id)
        {
            throw new NotImplementedException();
        }

        public Item Find(string objectId, string valueType)
        {
            //throw new NotImplementedException();
            return null;
        }
    }
}
