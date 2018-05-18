using ConsensusTester.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsensusTester.DataAccess.Configurations
{
    public class BlockVerificationConfiguration : IEntityTypeConfiguration<BlockVerificationEntity>
    {
        public void Configure(EntityTypeBuilder<BlockVerificationEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserPublicKey).IsRequired();
            builder.HasOne(x => x.Block).WithMany(x => x.Verifications);
        }
    }
}