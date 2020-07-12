using System;
using System.Collections.Generic;

namespace EfN_n.Entities
{
    public class Role : BaseEntity<Guid>
    {
        public Role()
        {
            RoleFeatures = new List<RoleFeature>();
            //RoleActiveDirectoryObjects = new List<RoleActiveDirectoryObject>();
        }

        public string Name { get; private set; }

        public IList<RoleFeature> RoleFeatures { get; private set; }

        //public IList<RoleActiveDirectoryObject> RoleActiveDirectoryObjects { get; private set; }

        public static Role Create(string name)
        {
            return new Role() { Id = Guid.NewGuid(), Name = name };
        }

        public void AddRoleFeature(params RoleFeature[] roleFeatures)
        {
            foreach (var roleFeature in roleFeatures)
                RoleFeatures.Add(roleFeature);
        }

        //public void AddRoleActiveDirectoryObject(params RoleActiveDirectoryObject[] roleActiveDirectoryRoles)
        //{
        //    foreach (var roleFeature in roleActiveDirectoryRoles)
        //        RoleActiveDirectoryObjects.Add(roleFeature);
        //}
    }
}
