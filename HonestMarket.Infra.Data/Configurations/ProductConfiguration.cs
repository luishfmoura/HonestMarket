using HonestMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonestMarket.Infra.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasIndex(k => k.Guid);
            builder.Property<bool>("isDeleted");
            builder.HasQueryFilter(m => EF.Property<bool>(m, "isDeleted") == false);
        }
    }
}
