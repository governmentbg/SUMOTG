
using Common.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess.EFCore.Configuration.System
{
    public class ObhvatConfig : BaseEntityConfig<Obhvat>
    {
        public ObhvatConfig() : base("Obhvat") { }

        public override void Configure(EntityTypeBuilder<Obhvat> builder)
        {
            base.Configure(builder);
            builder.Property(obj => obj.Name);

            builder
                .HasMany(r => r.UserObhvat)
                .WithOne()
                .HasForeignKey(ur => ur.ObhvatId)
                .IsRequired();
        }
    }
}
