using System;

namespace EfN_n.Entities
{
    public class RoleFeature : BaseEntity<Guid>
    {
        public Guid RoleId { get; private set; }
        public Role Role { get; private set; }
        public Guid FeatureId { get; private set; }
        public Feature Feature { get; private set; }

        public static RoleFeature Create(Role role, Feature feature)
        {
            var roleFeature = new RoleFeature
            {
                Id = Guid.NewGuid(),
                Feature = feature,
                Role = role,
                FeatureId = feature.Id,
                RoleId = role.Id
            };

            return roleFeature;
        }
    }
}
