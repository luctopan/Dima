using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings;

public class OrderMapping : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Number)
            .IsRequired()
            .HasColumnName("CHAR")
            .HasMaxLength(8);
        
        builder.Property(x => x.ExternalReference)
            .IsRequired(false)
            .HasColumnName("VARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.Gateway)
            .IsRequired()
            .HasColumnName("SMALLINT");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("DATETIME2");
        
        builder.Property(x => x.UpdatedAt)
            .IsRequired()
            .HasColumnName("DATETIME2");
        
        builder.Property(x => x.Status)
            .IsRequired()
            .HasColumnName("SMALLINT");
        
        builder.Property(x => x.UserId)
            .IsRequired(false)
            .HasColumnName("VARCHAR")
            .HasMaxLength(160);

        builder.HasOne(x => x.Product).WithMany();
        builder.HasOne(x => x.Voucher).WithMany();
    }
}