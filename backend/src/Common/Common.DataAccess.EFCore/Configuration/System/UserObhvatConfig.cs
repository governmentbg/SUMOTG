/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess.EFCore.Configuration.System
{
    public class UserObhvatConfig : IEntityTypeConfiguration<UserObhvat>
    {
        public void Configure(EntityTypeBuilder<UserObhvat> builder)
        {
            builder.ToTable("UserObhvat");
            builder.HasKey("UserId", "ObhvatId");
            builder.Property(obj => obj.ObhvatId).IsRequired();
            builder.Property(obj => obj.UserId).IsRequired();

            builder.Ignore(x => x.Obhvat);
            builder.Ignore(x => x.User);

            builder
                .HasOne(ur => ur.Obhvat)
                .WithMany(r => r.UserObhvat)
                .HasForeignKey(r => r.ObhvatId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
