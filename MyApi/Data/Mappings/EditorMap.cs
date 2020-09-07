using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApi.Models;

namespace MyApi.Data.Mappings
{
    public class EditorMap : IEntityTypeConfiguration<Editor>
    {
        public void Configure(EntityTypeBuilder<Editor> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).HasMaxLength(150).IsRequired();

            builder.Property(t => t.Presentation).HasMaxLength(500).IsRequired(false);

            builder.ToTable(nameof(Editor));

        }
    }
}
