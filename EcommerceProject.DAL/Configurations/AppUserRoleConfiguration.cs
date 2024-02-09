using EcommerceProject.ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DAL.Configurations
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");


            var superadminUserRole = new AppUserRole
            {
                UserId = 1,
                RoleId = 1
            };
            var adminUserRole = new AppUserRole
            {
                UserId = 2,
                RoleId = 2
            };
            builder.HasData(superadminUserRole,adminUserRole);
        }
    }
}
