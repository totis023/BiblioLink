using BiblioLink.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class LibroConfiguration : IEntityTypeConfiguration<Libro>
{
    public void Configure(EntityTypeBuilder<Libro> builder)
    {
        builder.Property(l => l.Titulo).IsRequired().HasMaxLength(200);
        builder.Property(l => l.Autores).IsRequired().HasMaxLength(300);
        builder.Property(l => l.ISBN).IsRequired().HasMaxLength(20);
        builder.Property(l => l.Editorial).IsRequired().HasMaxLength(150);
        builder.Property(l => l.UbicacionFisica).IsRequired().HasMaxLength(100);

        builder.HasIndex(l => l.ISBN).IsUnique();

        builder.ToTable(t => t.HasCheckConstraint(
            "CK_Libros_Stock",
            "CantidadDisponible >= 0 AND CantidadDisponible <= CantidadTotal"));
    }
}