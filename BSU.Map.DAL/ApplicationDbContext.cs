using BSU.Map.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BSU.Map.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<AddMaterial> AddMaterials { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<BuildingAddress> BuildingAddresses { get; set; }
        public virtual DbSet<BuildingType> BuildingTypes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Coordinate> Coordinates { get; set; }
        public virtual DbSet<MemoryPhoto> MemoryPhotos { get; set; }
        public virtual DbSet<MemoryPlace> MemoryPlaces { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Scientist> Scientists { get; set; }
        public virtual DbSet<StructuralObject> StructuralObjects { get; set; }
        public virtual DbSet<StructuralObjectsIcon> StructuralObjectsIcons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<AddMaterial>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(100)
                    .HasColumnName("file_path");

                entity.Property(e => e.ScientistId).HasColumnName("scientist_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Scientist)
                    .WithMany(p => p.AddMaterials)
                    .HasForeignKey(d => d.ScientistId)
                    .HasConstraintName("AddMaterials_scientist_id_fkey");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasIndex(e => e.AddressId, "buildings_address_id_ukey")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.InventoryUsrreNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("inventory_usrre_number");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Address)
                    .WithOne(p => p.Building)
                    .HasForeignKey<Building>(d => d.AddressId)
                    .HasConstraintName("Buildings_address_id_fkey");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("Buildings_type_id_fkey");
            });

            modelBuilder.Entity<BuildingAddress>(entity =>
            {
                entity.HasIndex(e => e.CoordinatesId, "buildingaddresses_coordinates_id_ukey")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CoordinatesId).HasColumnName("coordinates_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.HasOne(d => d.Coordinates)
                    .WithOne(p => p.BuildingAddress)
                    .HasForeignKey<BuildingAddress>(d => d.CoordinatesId)
                    .HasConstraintName("BuildingAddresses_coordinates_id_fkey");
            });

            modelBuilder.Entity<BuildingType>(entity =>
            {
                entity.HasIndex(e => e.MarkerPath, "buildingtypes_marker_path_ukey")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.MarkerPath)
                    .HasMaxLength(100)
                    .HasColumnName("marker_path");

                entity.Property(e => e.Type)
                    .HasMaxLength(70)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Coordinate>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");
            });

            modelBuilder.Entity<MemoryPhoto>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(1200)
                    .HasColumnName("description");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .HasColumnName("image_path");

                entity.Property(e => e.MemoryPlaceId).HasColumnName("memory_place_id");

                entity.HasOne(d => d.MemoryPlace)
                    .WithMany(p => p.MemoryPhotos)
                    .HasForeignKey(d => d.MemoryPlaceId)
                    .HasConstraintName("MemoryPhotos_memory_place_id_fkey");
            });

            modelBuilder.Entity<MemoryPlace>(entity =>
            {
                entity.HasIndex(e => e.CoordinatesId, "memoryplaces_coordinates_id_ukey")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CoordinatesId).HasColumnName("coordinates_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.ScientistId).HasColumnName("scientist_id");

                entity.HasOne(d => d.Coordinates)
                    .WithOne(p => p.MemoryPlace)
                    .HasForeignKey<MemoryPlace>(d => d.CoordinatesId)
                    .HasConstraintName("MemoryPlaces_coordinates_id_fkey");

                entity.HasOne(d => d.Scientist)
                    .WithMany(p => p.MemoryPlaces)
                    .HasForeignKey(d => d.ScientistId)
                    .HasConstraintName("MemoryPlaces_scientist_id_fkey");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(1200)
                    .HasColumnName("description");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .HasColumnName("image_path");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("Photos_building_id_fkey");
            });

            modelBuilder.Entity<Scientist>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");
               
                entity.Property(e => e.DeathDate)
                    .HasColumnType("date")
                    .HasColumnName("death_date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");
            });

            modelBuilder.Entity<StructuralObject>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Subdivision)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("subdivision");

                entity.Property(e => e.Website)
                    .HasMaxLength(500)
                    .HasColumnName("website");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.StructuralObjects)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("StructuralObjects_building_id_fkey");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.StructuralObjects)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("StructuralObjects_category_id_fkey");
            });

            modelBuilder.Entity<StructuralObjectsIcon>(entity =>
            {
                entity.HasKey(e => e.StructuralObjectId)
                    .HasName("StructuralObjectsIcons_pkey");

                entity.Property(e => e.StructuralObjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("structural_object_id");

                entity.Property(e => e.LogoPath)
                    .HasMaxLength(100)
                    .HasColumnName("logo_path");

                entity.Property(e => e.Subdivision)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("subdivision");

                entity.HasOne(d => d.StructuralObject)
                    .WithOne(p => p.StructuralObjectsIcon)
                    .HasForeignKey<StructuralObjectsIcon>(d => d.StructuralObjectId)
                    .HasConstraintName("StructuralObjectsIcons_structural_object_id_fkey");
            });
        }
    }
}
