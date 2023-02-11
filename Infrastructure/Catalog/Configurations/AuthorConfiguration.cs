using Domain.Catalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Common.Models.ModelConstants.Common;
namespace Infrastructure.Catalog.Configurations
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
            .HasKey(a => a.Id);

            builder
                .Property(a => a.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .Property(a => a.Description)
                .HasMaxLength(MaxDescriptionLength);
                
        }
    }
}
