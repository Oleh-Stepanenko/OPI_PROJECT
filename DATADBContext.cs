using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WpfApp3
{
    public partial class DATADBContext : DbContext
    {
        public DATADBContext()
        {
        }

        public DATADBContext(DbContextOptions<DATADBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Network> Networks { get; set; }

        public virtual DbSet<Devices> Devices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-J1AJQ1B\\MOI_SERVER;Database=DATADB;Trusted_Connection=True;");
            }
            else
            {
                Console.WriteLine("Підключення до бази даних не відбулося");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<User>(entity =>
            {

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMAILS");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LOGINS");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORDS");
            });

            modelBuilder.Entity<Network>(entity =>
            {

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Name_Network");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_Network");

                entity.Property(e => e.Id_User)
                   .IsRequired()
                   .HasMaxLength(1)
                   .IsUnicode(false)
                   .HasColumnName("ID_User");

                entity.Property(e => e.ID_Device)
                   .IsRequired()
                   .HasMaxLength(1)
                   .IsUnicode(false)
                   .HasColumnName("ID_Device");

            });


            modelBuilder.Entity<Devices>(entity =>
            {

                entity.Property(e => e.Name_Device)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Name_Device");

                entity.Property(e => e.Id_Device)

                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
                    

            });



            OnModelCreatingPartial(modelBuilder);
        }

      


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}