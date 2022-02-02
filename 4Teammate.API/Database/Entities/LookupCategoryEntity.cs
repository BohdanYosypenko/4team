using System.Collections.Generic;

namespace _4Teammate.API.Database.Entities
{
    public class LookupCategoryEntity
    {
        public int Id { get; set; }

        public string DefaultName { get; set; }

        public string Name { get; set; }


        public List<SportLookupEntity> SportLookups { get; set; }
    }
}
