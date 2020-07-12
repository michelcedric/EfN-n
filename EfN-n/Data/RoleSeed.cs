using EfN_n.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EfN_n.Data
{
    public static class RoleSeed
    {

        private static SecurityConfiguration SecurityConfiguration
        {
            get
            {
                var role1 = new SecurityRoleConfiguration
                {
                    Name = "Role1",
                    Users = new []
                    {
                        "User1"
                    }
                };

                var feature1 = new FeaturesConfiguration
                {
                    Name = "Feature1",
                    Roles = new []
                    {
                        role1.Name
                    }
                };

                return new SecurityConfiguration
                {
                    Roles = new []
                    {
                        role1
                    },
                    Features = new []
                    {
                       feature1
                    }
                };
            }
        }

        public static void Seed(ApplicationDbContext context)
        {
            if (context.Features.Count() != SecurityConfiguration.Features.Count())
            {
                context.Features.RemoveRange(context.Features);
                var features = SecurityConfiguration.Features.Select(feat => Feature.Create(feat.Name));
                context.Features.AddRange(features);
                context.SaveChanges();
            }

            if (context.Roles.Count() != SecurityConfiguration.Roles.Count())
            {
                context.Roles.RemoveRange(context.Roles);

                var roles = SecurityConfiguration.Roles
                    .Select(r => Role.Create(r.Name))
                    .ToList();

                context.Roles.AddRange(roles);

                foreach (var roleConfig in SecurityConfiguration.Roles)
                {
                    var featureConfigs = SecurityConfiguration.Features.Where(f => f.Roles.Contains(roleConfig.Name));
                    var role = roles.Single(r => r.Name == roleConfig.Name);

                    foreach (var feature in featureConfigs)
                    {
                        var roleFeature = RoleFeature.Create(role, context.Features.Single(x => x.Name == feature.Name));

                        role.AddRoleFeature(roleFeature);

                        //EF workarround to avoid DbUpdateConcurrencyException. 
                        //EF considered (bug?) the entity in modified state (n-n relationship) but it's a new object (Added)
                        //https://docs.microsoft.com/fr-fr/ef/core/saving/concurrency
                        //context.Entry(roleFeature).State = EntityState.Added;
                    }
                }
                context.SaveChanges();
            }

        }
    }

    public class SecurityConfiguration
    {
        public IEnumerable<FeaturesConfiguration> Features { get; set; }
        public IEnumerable<SecurityRoleConfiguration> Roles { get; set; }
    }

    public class FeaturesConfiguration
    {
        public string Name { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }

    public class SecurityRoleConfiguration
    {
        public string Name { get; set; }
        public IEnumerable<string> Users { get; set; }
    }

    //public class SecurityUserConfiguration
    //{
    //    public string Name { get; set; }
    //    public ActiveDirectoryObjectType ObjectType { get; set; }
    //}
}
