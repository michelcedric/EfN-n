using System;
using System.Collections.Generic;

namespace EfN_n.Entities
{
    public class Role : BaseEntity<Guid>
    {
        public Role()
        {
            RoleFeatures = new List<RoleFeature>();          
        }

        public string Name { get; private set; }

        public IList<RoleFeature> RoleFeatures { get; private set; }    

        public static Role Create(string name)
        {
            return new Role() { Id = Guid.NewGuid(), Name = name };
        }

        public void AddRoleFeature(params RoleFeature[] roleFeatures)
        {
            foreach (var roleFeature in roleFeatures)
                RoleFeatures.Add(roleFeature);
        }     
    }
}
