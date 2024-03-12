using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.Commensality.Models;
public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
{
    public void Configure(EntityTypeBuilder<Voucher> builder)
    {
        builder.ToTable("Vouchers")
        .HasKey(t => t.Id);

        builder.Property(v => v.Id)
        .ValueGeneratedOnAdd();

        builder.Property(p => p.Amount)
        .HasColumnType("decimal(18, 2)");

        builder.Property(p=> p.Total)
        .HasColumnType("decimal(18, 2)");

        builder.Ignore(p => p.Tip);
    }
}