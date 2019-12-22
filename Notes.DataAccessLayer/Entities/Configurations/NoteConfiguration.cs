using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.DataAccessLayer.Entities.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<NoteEntity>
    {
        public void Configure(EntityTypeBuilder<NoteEntity> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Text)
                .IsRequired();
        }
    }
}
