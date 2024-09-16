using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entidades.SQLServer
{
    public partial class HotelProyectoContext : DbContext
    {
        public HotelProyectoContext()
        {
        }

        public HotelProyectoContext(DbContextOptions<HotelProyectoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Habitaciones> Habitaciones { get; set; }
        public virtual DbSet<Reservaciones> Reservaciones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = HotelProyecto; Persist Security info = true; user id = sa; password = sa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.CedulaCliente);

                entity.ToTable("CLIENTES", "SCH_CLIENTES");

                entity.Property(e => e.CedulaCliente)
                    .HasColumnName("cedula_cliente")
                    .HasMaxLength(20);

                entity.Property(e => e.Apellido1Cliente)
                    .IsRequired()
                    .HasColumnName("apellido1_cliente")
                    .HasMaxLength(50);

                entity.Property(e => e.Apellido2Cliente)
                    .IsRequired()
                    .HasColumnName("apellido2_cliente")
                    .HasMaxLength(50);

                entity.Property(e => e.CorreoCliente)
                    .IsRequired()
                    .HasColumnName("correo_cliente")
                    .HasMaxLength(50);

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasColumnName("nombre_cliente")
                    .HasMaxLength(50);

                entity.Property(e => e.TelefonoCliente)
                    .IsRequired()
                    .HasColumnName("telefono_cliente")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Habitaciones>(entity =>
            {
                entity.HasKey(e => e.CodHabitacion);

                entity.ToTable("HABITACIONES", "SCH_RESERVACIONES");

                entity.Property(e => e.CodHabitacion)
                    .HasColumnName("cod_habitacion")
                    .ValueGeneratedNever();

                entity.Property(e => e.CapacidadHabitacion).HasColumnName("capacidad_habitacion");

                entity.Property(e => e.EstadoHabitacion)
                    .IsRequired()
                    .HasColumnName("estado_habitacion")
                    .HasMaxLength(30);

                entity.Property(e => e.TipoHabitacion)
                    .IsRequired()
                    .HasColumnName("tipo_habitacion")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Reservaciones>(entity =>
            {
                entity.HasKey(e => e.IdReserva);

                entity.ToTable("RESERVACIONES", "SCH_RESERVACIONES");

                entity.Property(e => e.IdReserva)
                    .HasColumnName("id_reserva")
                    .ValueGeneratedNever();

                entity.Property(e => e.CantidadAdultos).HasColumnName("cantidad_adultos");

                entity.Property(e => e.CantidadNinos).HasColumnName("cantidad_ninos");

                entity.Property(e => e.CedulaCliente)
                    .IsRequired()
                    .HasColumnName("cedula_cliente")
                    .HasMaxLength(20);

                entity.Property(e => e.CodHabitacion).HasColumnName("cod_habitacion");

                entity.Property(e => e.CodReserva)
                    .IsRequired()
                    .HasColumnName("cod_reserva")
                    .HasMaxLength(50);

                entity.Property(e => e.FechaEntrada)
                    .HasColumnName("fecha_entrada")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaSalida)
                    .HasColumnName("fecha_salida")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.PrecioHabitacion)
                    .HasColumnName("precio_habitacion")
                    .HasColumnType("smallmoney");

                entity.HasOne(d => d.CedulaClienteNavigation)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.CedulaCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESERVACIONES_CLIENTES");

                entity.HasOne(d => d.CodHabitacionNavigation)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.CodHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESERVACIONES_HABITACIONES");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("USUARIOS", "SCH_RESERVACIONES");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_USUARIO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .HasColumnName("APELLIDOS")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(150);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("PASS")
                    .HasMaxLength(50);

                entity.Property(e => e.Tipo)
                    .HasColumnName("TIPO")
                    .HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
