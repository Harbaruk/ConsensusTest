using ConsensusTester.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsensusTester.DataAccess.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.Owner).IsRequired();
            builder.HasOne(x => x.Block).WithMany(x => x.Transactions);
        }
    }
}