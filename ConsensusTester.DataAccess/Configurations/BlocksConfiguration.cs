using ConsensusTester.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsensusTester.DataAccess.Configurations
{
    public class BlocksConfiguration : IEntityTypeConfiguration<BlockEntity>
    {
        public void Configure(EntityTypeBuilder<BlockEntity> builder)
        {
            builder.ToTable("Blocks");

            builder.HasKey(x => x.Hash);

            builder.Property(x => x.BlockState).IsRequired();
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Miner).IsRequired();
            builder.Property(x => x.Nonce).IsRequired();
            builder.Property(x => x.PreviousBlockHash).IsRequired();

            builder.HasMany(x => x.Transactions).WithOne(x => x.Block);
        }
    }
}