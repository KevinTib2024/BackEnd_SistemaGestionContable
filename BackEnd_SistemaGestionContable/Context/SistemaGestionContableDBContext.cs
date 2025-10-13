using BackEnd_SistemaGestionContable.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_SistemaGestionContable.Context
{
    public class SistemaGestionContableDBContext : DbContext
    {
        public SistemaGestionContableDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Ciudad
            modelBuilder.Entity<Ciudad>().HasKey(c => c.CiudadId);

            //Clientes
            modelBuilder.Entity<Clientes>().HasOne(u => u.ciudad).WithMany(ut => ut.clientes).HasForeignKey(u => u.Ciudad_Id);
            modelBuilder.Entity<Clientes>().HasKey(u => u.ClientesId);

            //DetalleVentas
            modelBuilder.Entity<DetalleVenta>().HasOne(u => u.ventas).WithMany(ut => ut.detalleVenta).HasForeignKey(u => u.Ventas_Id);
            modelBuilder.Entity<DetalleVenta>().HasOne(u => u.productos).WithMany(ut => ut.detalleVenta).HasForeignKey(u => u.Producto_Id);
            modelBuilder.Entity<DetalleVenta>().HasKey(u => u.DetalleVentaId);

            //EntradasInventario
            modelBuilder.Entity<EntradasInventario>().HasOne(u => u.usuarios).WithMany(ut => ut.entradasInventario).HasForeignKey(u => u.Usuarios_Id);
            modelBuilder.Entity<EntradasInventario>().HasOne(u => u.productos).WithMany(ut => ut.entradasInventario).HasForeignKey(u => u.Productos_Id);
            modelBuilder.Entity<EntradasInventario>().HasOne(u => u.proveedores).WithMany(ut => ut.entradasInventario).HasForeignKey(u => u.Proveedores_Id);
            modelBuilder.Entity<EntradasInventario>().HasKey(u => u.EntradasInventarioId);

            //Genero 
            modelBuilder.Entity<Genero>().HasKey(u => u.GeneroId);

            //Mesas
            modelBuilder.Entity<Mesas>().HasKey(u => u.MesasId);

            //MovimientosFinancieros
            modelBuilder.Entity<MovimientosFinancieros>().HasOne(u => u.usuarios).WithMany(ut => ut.movimientosFinancieros).HasForeignKey(u => u.Usuarios_Id);
            modelBuilder.Entity<MovimientosFinancieros>().HasOne(u => u.ventas).WithMany(ut => ut.movimientosFinancieros).HasForeignKey(u => u.Ventas_Id);
            modelBuilder.Entity<MovimientosFinancieros>().HasOne(u => u.entradasInventario).WithMany(ut => ut.movimientosFinancieros).HasForeignKey(u => u.EntradasInventario_Id);
            modelBuilder.Entity<MovimientosFinancieros>().HasOne(u => u.proveedores).WithMany(ut => ut.movimientosFinancieros).HasForeignKey(u => u.Proveedores_Id);
            modelBuilder.Entity<MovimientosFinancieros>().HasKey(u => u.MovimientosFinancierosId);

            //Permisos
            modelBuilder.Entity<Permisos>().HasKey(u => u.PermisosId);

            //PermisosXTipoUsuario
            modelBuilder.Entity<PermisosXTipoUsuario>().HasOne(u => u.tiposUsuario).WithMany(ut => ut.permisoXTipoUsuario).HasForeignKey(u => u.tipoUsuario_Id);
            modelBuilder.Entity<PermisosXTipoUsuario>().HasOne(u => u.permisos).WithMany(ut => ut.permisosXTipoUsuario).HasForeignKey(u => u.permisos_Id);
            modelBuilder.Entity<PermisosXTipoUsuario>().HasKey(u => u.PermisosXTipoUsuarioId);

            //Planificacion Compras
            modelBuilder.Entity<PlanificacionCompras>().HasOne(u => u.usuarios).WithMany(ut => ut.planificacionCompras).HasForeignKey(u => u.Usuarios_Id);
            modelBuilder.Entity<PlanificacionCompras>().HasOne(u => u.productos).WithMany(ut => ut.planificacionCompras).HasForeignKey(u => u.Productos_Id);
            modelBuilder.Entity<PlanificacionCompras>().HasKey(u => u.PlanificacionComprasId);

            //Productos
            modelBuilder.Entity<Productos>().HasOne(u => u.proveedores).WithMany(ut => ut.productos).HasForeignKey(u => u.Proveedores_Id);
            modelBuilder.Entity<Productos>().HasKey(u => u.ProductosId);

            //Proveedores
            modelBuilder.Entity<Proveedores>().HasOne(u => u.ciudad).WithMany(ut => ut.proveedores).HasForeignKey(u => u.Ciudad_Id);
            modelBuilder.Entity<Proveedores>().HasKey(u => u.ProveedoresId);

            //ReporteGeneral
            modelBuilder.Entity<ReporteGeneral>().HasOne(u => u.usuarios).WithMany(ut => ut.reporteGeneral).HasForeignKey(u => u.Usuarios_Id);
            modelBuilder.Entity<ReporteGeneral>().HasKey(u => u.ReporteGeneralId);

            //SalidasInventario
            modelBuilder.Entity<SalidasInventario>().HasOne(u => u.usuarios).WithMany(ut => ut.salidasInventario).HasForeignKey(u => u.Usuarios_Id);
            modelBuilder.Entity<SalidasInventario>().HasOne(u => u.productos).WithMany(ut => ut.salidasInventario).HasForeignKey(u => u.Productos_Id);
            modelBuilder.Entity<SalidasInventario>().HasKey(u => u.SalidasInventarioId);

            //Tipo Identificacion
            modelBuilder.Entity<TipoIdentificacion>().HasKey(u => u.TipoIdentificacionId);

            //TiposUsuario
            modelBuilder.Entity<TiposUsuario>().HasKey(u => u.tiposUsuarioId);

            //Usuarios
            modelBuilder.Entity<Usuarios>().HasOne(u => u.tipos_Usuario).WithMany(ut => ut.usuarios).HasForeignKey(u => u.tipo_Usuario_Id);
            modelBuilder.Entity<Usuarios>().HasOne(u => u.tipoIdentificacion).WithMany(ut => ut.usuarios).HasForeignKey(u => u.tipoIdentificacion_Id);
            modelBuilder.Entity<Usuarios>().HasOne(u => u.genero).WithMany(ut => ut.usuarios).HasForeignKey(u => u.genero_Id);
            modelBuilder.Entity<Usuarios>().HasOne(u => u.ciudad).WithMany(ut => ut.usuarios).HasForeignKey(u => u.ciudad_Id);
            modelBuilder.Entity<Usuarios>().HasKey(u => u.UsuariosId);

            //Ventas

            modelBuilder.Entity<Ventas>().HasOne(u => u.usuarios).WithMany(ut => ut.ventas).HasForeignKey(u => u.Usuarios_Id);
            modelBuilder.Entity<Ventas>().HasOne(u => u.clientes).WithMany(ut => ut.ventas).HasForeignKey(u => u.Clientes_Id);
            modelBuilder.Entity<Ventas>().HasOne(u => u.mesas).WithMany(ut => ut.ventas).HasForeignKey(u => u.Mesas_Id);
            modelBuilder.Entity<Ventas>().HasKey(u => u.VentasId);

        }
        public DbSet<Ciudad> ciudad { get; set; }
        public DbSet<DetalleVenta> detalleVenta { get; set; }
        public DbSet<EntradasInventario> entradasInventario { get; set; }
        public DbSet<Genero> genero { get; set; }
        public DbSet<Mesas> mesas { get; set; }
        public DbSet<MovimientosFinancieros> movimientosFinancieros { get; set; }
        public DbSet<Permisos> permisos { get; set; }
        public DbSet<PermisosXTipoUsuario> permisosXTipoUsuario { get; set; }
        public DbSet<PlanificacionCompras> planificacionCompras { get; set; }
        public DbSet<Productos> productos { get; set; }
        public DbSet<Proveedores> proveedores { get; set; }
        public DbSet<ReporteGeneral> reporteGeneral { get; set; }
        public DbSet<SalidasInventario> salidasInventario { get; set; }
        public DbSet<TipoIdentificacion> tipoIdentificacion { get; set; }
        public DbSet<TiposUsuario> tiposUsuario { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Ventas> ventas { get; set; }
    }
}
