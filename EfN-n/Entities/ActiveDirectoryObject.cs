using System;
using System.Collections.Generic;

namespace EfN_n.Entities
{
    public class ActiveDirectoryObject : BaseEntity<Guid>
    {

        public string Name { get; private set; }
        public ActiveDirectoryObjectType ObjectType { get; set; }
        //public IList<RoleActiveDirectoryObject> RoleActiveDirectoryObjects { get; private set; }

        public static ActiveDirectoryObject Create(string name, ActiveDirectoryObjectType activeDirectoryObjectType)
        {
            var role = new ActiveDirectoryObject
            {
                Id = Guid.NewGuid(),
                Name = name,
                ObjectType = activeDirectoryObjectType
            };
            return role;
        }
    }
}
