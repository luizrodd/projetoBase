using HelperStockBeta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperStockBeta.Infra.Data.EntityConfiguration
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.HasData(
                new Category(1, "Material de Escritorio"),
                new Category(2, "Tecnologia eletronica"),
                new Category(3, "Acessorios e Equipamentos")
                );
        }
    }
}
