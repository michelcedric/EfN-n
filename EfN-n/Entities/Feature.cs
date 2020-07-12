using System;
using System.Collections.Generic;

namespace EfN_n.Entities
{
    public class Feature : BaseEntity<Guid>
    {
        public string Name { get; private set; }

        public IList<RoleFeature> RoleFeatures { get; private set; }

        public static Feature Create(string name)
        {
            var feature = new Feature
            {
                Id = Guid.NewGuid(),
                Name = name
            };
            return feature;
        }
    }
}
