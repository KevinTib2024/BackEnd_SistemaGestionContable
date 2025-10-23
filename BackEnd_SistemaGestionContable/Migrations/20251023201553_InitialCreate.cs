using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_SistemaGestionContable.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.CiudadId);
                });

            migrationBuilder.CreateTable(
                name: "genero",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genero", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "mesas",
                columns: table => new
                {
                    MesasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_mesa = table.Column<int>(type: "int", nullable: false),
                    capacidad = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mesas", x => x.MesasId);
                });

            migrationBuilder.CreateTable(
                name: "permisos",
                columns: table => new
                {
                    PermisosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permisos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permisos", x => x.PermisosId);
                });

            migrationBuilder.CreateTable(
                name: "tipoIdentificacion",
                columns: table => new
                {
                    TipoIdentificacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoIdentificacion", x => x.TipoIdentificacionId);
                });

            migrationBuilder.CreateTable(
                name: "tiposUsuario",
                columns: table => new
                {
                    tiposUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tiposUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiposUsuario", x => x.tiposUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    ClientesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ciudad_Id = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.ClientesId);
                    table.ForeignKey(
                        name: "FK_clientes_ciudad_Ciudad_Id",
                        column: x => x.Ciudad_Id,
                        principalTable: "ciudad",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    ProveedoresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ciudad_Id = table.Column<int>(type: "int", nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores", x => x.ProveedoresId);
                    table.ForeignKey(
                        name: "FK_proveedores_ciudad_Ciudad_Id",
                        column: x => x.Ciudad_Id,
                        principalTable: "ciudad",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permisosXTipoUsuario",
                columns: table => new
                {
                    PermisosXTipoUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoUsuario_Id = table.Column<int>(type: "int", nullable: false),
                    permisos_Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permisosXTipoUsuario", x => x.PermisosXTipoUsuarioId);
                    table.ForeignKey(
                        name: "FK_permisosXTipoUsuario_permisos_permisos_Id",
                        column: x => x.permisos_Id,
                        principalTable: "permisos",
                        principalColumn: "PermisosId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_permisosXTipoUsuario_tiposUsuario_tipoUsuario_Id",
                        column: x => x.tipoUsuario_Id,
                        principalTable: "tiposUsuario",
                        principalColumn: "tiposUsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    tipoIdentificacion_Id = table.Column<int>(type: "int", nullable: false),
                    genero_Id = table.Column<int>(type: "int", nullable: false),
                    ciudad_Id = table.Column<int>(type: "int", nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numeroIdentificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.UsuariosId);
                    table.ForeignKey(
                        name: "FK_usuarios_ciudad_ciudad_Id",
                        column: x => x.ciudad_Id,
                        principalTable: "ciudad",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarios_genero_genero_Id",
                        column: x => x.genero_Id,
                        principalTable: "genero",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarios_tipoIdentificacion_tipoIdentificacion_Id",
                        column: x => x.tipoIdentificacion_Id,
                        principalTable: "tipoIdentificacion",
                        principalColumn: "TipoIdentificacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarios_tiposUsuario_tipo_Usuario_Id",
                        column: x => x.tipo_Usuario_Id,
                        principalTable: "tiposUsuario",
                        principalColumn: "tiposUsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    ProductosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Proveedores_Id = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unidad_medida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stock_actual = table.Column<float>(type: "real", nullable: false),
                    stock_minimo = table.Column<float>(type: "real", nullable: false),
                    stock_compra = table.Column<float>(type: "real", nullable: false),
                    stock_venta = table.Column<float>(type: "real", nullable: false),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.ProductosId);
                    table.ForeignKey(
                        name: "FK_productos_proveedores_Proveedores_Id",
                        column: x => x.Proveedores_Id,
                        principalTable: "proveedores",
                        principalColumn: "ProveedoresId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reporteGeneral",
                columns: table => new
                {
                    ReporteGeneralId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuarios_Id = table.Column<int>(type: "int", nullable: false),
                    tipo_reporte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_generacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    archivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reporteGeneral", x => x.ReporteGeneralId);
                    table.ForeignKey(
                        name: "FK_reporteGeneral_usuarios_Usuarios_Id",
                        column: x => x.Usuarios_Id,
                        principalTable: "usuarios",
                        principalColumn: "UsuariosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    VentasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuarios_Id = table.Column<int>(type: "int", nullable: false),
                    Clientes_Id = table.Column<int>(type: "int", nullable: false),
                    Mesas_Id = table.Column<int>(type: "int", nullable: false),
                    fecha_venta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    metodo_pago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total = table.Column<float>(type: "real", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.VentasId);
                    table.ForeignKey(
                        name: "FK_ventas_clientes_Clientes_Id",
                        column: x => x.Clientes_Id,
                        principalTable: "clientes",
                        principalColumn: "ClientesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ventas_mesas_Mesas_Id",
                        column: x => x.Mesas_Id,
                        principalTable: "mesas",
                        principalColumn: "MesasId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ventas_usuarios_Usuarios_Id",
                        column: x => x.Usuarios_Id,
                        principalTable: "usuarios",
                        principalColumn: "UsuariosId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "entradasInventario",
                columns: table => new
                {
                    EntradasInventarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuarios_Id = table.Column<int>(type: "int", nullable: false),
                    Productos_Id = table.Column<int>(type: "int", nullable: false),
                    Proveedores_Id = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<float>(type: "real", nullable: false),
                    precio_unitario = table.Column<float>(type: "real", nullable: false),
                    fecha_entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entradasInventario", x => x.EntradasInventarioId);
                    table.ForeignKey(
                        name: "FK_entradasInventario_productos_Productos_Id",
                        column: x => x.Productos_Id,
                        principalTable: "productos",
                        principalColumn: "ProductosId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_entradasInventario_proveedores_Proveedores_Id",
                        column: x => x.Proveedores_Id,
                        principalTable: "proveedores",
                        principalColumn: "ProveedoresId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_entradasInventario_usuarios_Usuarios_Id",
                        column: x => x.Usuarios_Id,
                        principalTable: "usuarios",
                        principalColumn: "UsuariosId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "planificacionCompras",
                columns: table => new
                {
                    PlanificacionComprasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuarios_Id = table.Column<int>(type: "int", nullable: false),
                    Productos_Id = table.Column<int>(type: "int", nullable: false),
                    fecha_planificada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad = table.Column<float>(type: "real", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planificacionCompras", x => x.PlanificacionComprasId);
                    table.ForeignKey(
                        name: "FK_planificacionCompras_productos_Productos_Id",
                        column: x => x.Productos_Id,
                        principalTable: "productos",
                        principalColumn: "ProductosId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_planificacionCompras_usuarios_Usuarios_Id",
                        column: x => x.Usuarios_Id,
                        principalTable: "usuarios",
                        principalColumn: "UsuariosId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "salidasInventario",
                columns: table => new
                {
                    SalidasInventarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuarios_Id = table.Column<int>(type: "int", nullable: false),
                    Productos_Id = table.Column<int>(type: "int", nullable: false),
                    fecha_salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salidasInventario", x => x.SalidasInventarioId);
                    table.ForeignKey(
                        name: "FK_salidasInventario_productos_Productos_Id",
                        column: x => x.Productos_Id,
                        principalTable: "productos",
                        principalColumn: "ProductosId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_salidasInventario_usuarios_Usuarios_Id",
                        column: x => x.Usuarios_Id,
                        principalTable: "usuarios",
                        principalColumn: "UsuariosId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detalleVenta",
                columns: table => new
                {
                    DetalleVentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ventas_Id = table.Column<int>(type: "int", nullable: false),
                    Producto_Id = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<float>(type: "real", nullable: false),
                    subtotal = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleVenta", x => x.DetalleVentaId);
                    table.ForeignKey(
                        name: "FK_detalleVenta_productos_Producto_Id",
                        column: x => x.Producto_Id,
                        principalTable: "productos",
                        principalColumn: "ProductosId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detalleVenta_ventas_Ventas_Id",
                        column: x => x.Ventas_Id,
                        principalTable: "ventas",
                        principalColumn: "VentasId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "movimientosFinancieros",
                columns: table => new
                {
                    MovimientosFinancierosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuarios_Id = table.Column<int>(type: "int", nullable: false),
                    Ventas_Id = table.Column<int>(type: "int", nullable: false),
                    EntradasInventario_Id = table.Column<int>(type: "int", nullable: false),
                    Proveedores_Id = table.Column<int>(type: "int", nullable: false),
                    tipo_movimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    monto = table.Column<float>(type: "real", nullable: false),
                    fecha_movimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientosFinancieros", x => x.MovimientosFinancierosId);
                    table.ForeignKey(
                        name: "FK_movimientosFinancieros_entradasInventario_EntradasInventario_Id",
                        column: x => x.EntradasInventario_Id,
                        principalTable: "entradasInventario",
                        principalColumn: "EntradasInventarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_movimientosFinancieros_proveedores_Proveedores_Id",
                        column: x => x.Proveedores_Id,
                        principalTable: "proveedores",
                        principalColumn: "ProveedoresId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_movimientosFinancieros_usuarios_Usuarios_Id",
                        column: x => x.Usuarios_Id,
                        principalTable: "usuarios",
                        principalColumn: "UsuariosId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_movimientosFinancieros_ventas_Ventas_Id",
                        column: x => x.Ventas_Id,
                        principalTable: "ventas",
                        principalColumn: "VentasId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clientes_Ciudad_Id",
                table: "clientes",
                column: "Ciudad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_detalleVenta_Producto_Id",
                table: "detalleVenta",
                column: "Producto_Id");

            migrationBuilder.CreateIndex(
                name: "IX_detalleVenta_Ventas_Id",
                table: "detalleVenta",
                column: "Ventas_Id");

            migrationBuilder.CreateIndex(
                name: "IX_entradasInventario_Productos_Id",
                table: "entradasInventario",
                column: "Productos_Id");

            migrationBuilder.CreateIndex(
                name: "IX_entradasInventario_Proveedores_Id",
                table: "entradasInventario",
                column: "Proveedores_Id");

            migrationBuilder.CreateIndex(
                name: "IX_entradasInventario_Usuarios_Id",
                table: "entradasInventario",
                column: "Usuarios_Id");

            migrationBuilder.CreateIndex(
                name: "IX_movimientosFinancieros_EntradasInventario_Id",
                table: "movimientosFinancieros",
                column: "EntradasInventario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_movimientosFinancieros_Proveedores_Id",
                table: "movimientosFinancieros",
                column: "Proveedores_Id");

            migrationBuilder.CreateIndex(
                name: "IX_movimientosFinancieros_Usuarios_Id",
                table: "movimientosFinancieros",
                column: "Usuarios_Id");

            migrationBuilder.CreateIndex(
                name: "IX_movimientosFinancieros_Ventas_Id",
                table: "movimientosFinancieros",
                column: "Ventas_Id");

            migrationBuilder.CreateIndex(
                name: "IX_permisosXTipoUsuario_permisos_Id",
                table: "permisosXTipoUsuario",
                column: "permisos_Id");

            migrationBuilder.CreateIndex(
                name: "IX_permisosXTipoUsuario_tipoUsuario_Id",
                table: "permisosXTipoUsuario",
                column: "tipoUsuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_planificacionCompras_Productos_Id",
                table: "planificacionCompras",
                column: "Productos_Id");

            migrationBuilder.CreateIndex(
                name: "IX_planificacionCompras_Usuarios_Id",
                table: "planificacionCompras",
                column: "Usuarios_Id");

            migrationBuilder.CreateIndex(
                name: "IX_productos_Proveedores_Id",
                table: "productos",
                column: "Proveedores_Id");

            migrationBuilder.CreateIndex(
                name: "IX_proveedores_Ciudad_Id",
                table: "proveedores",
                column: "Ciudad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_reporteGeneral_Usuarios_Id",
                table: "reporteGeneral",
                column: "Usuarios_Id");

            migrationBuilder.CreateIndex(
                name: "IX_salidasInventario_Productos_Id",
                table: "salidasInventario",
                column: "Productos_Id");

            migrationBuilder.CreateIndex(
                name: "IX_salidasInventario_Usuarios_Id",
                table: "salidasInventario",
                column: "Usuarios_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_ciudad_Id",
                table: "usuarios",
                column: "ciudad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_genero_Id",
                table: "usuarios",
                column: "genero_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_tipo_Usuario_Id",
                table: "usuarios",
                column: "tipo_Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_tipoIdentificacion_Id",
                table: "usuarios",
                column: "tipoIdentificacion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_Clientes_Id",
                table: "ventas",
                column: "Clientes_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_Mesas_Id",
                table: "ventas",
                column: "Mesas_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_Usuarios_Id",
                table: "ventas",
                column: "Usuarios_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleVenta");

            migrationBuilder.DropTable(
                name: "movimientosFinancieros");

            migrationBuilder.DropTable(
                name: "permisosXTipoUsuario");

            migrationBuilder.DropTable(
                name: "planificacionCompras");

            migrationBuilder.DropTable(
                name: "reporteGeneral");

            migrationBuilder.DropTable(
                name: "salidasInventario");

            migrationBuilder.DropTable(
                name: "entradasInventario");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "permisos");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "mesas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
                name: "genero");

            migrationBuilder.DropTable(
                name: "tipoIdentificacion");

            migrationBuilder.DropTable(
                name: "tiposUsuario");

            migrationBuilder.DropTable(
                name: "ciudad");
        }
    }
}
