using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiALMTextil.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactoUsuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Usuario = table.Column<int>(type: "int", nullable: false),
                    direccion1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codigo_postal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactoUsuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Locales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombre_Sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locales", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Telas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    material = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descrip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPrendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPrendas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idtipo_Doc = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoDocid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoDocs_TipoDocid",
                        column: x => x.TipoDocid,
                        principalTable: "TipoDocs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Tela = table.Column<int>(type: "int", nullable: false),
                    id_tipoPrenda = table.Column<int>(type: "int", nullable: false),
                    Telaid = table.Column<int>(type: "int", nullable: true),
                    TipoPrendaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prendas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Prendas_Telas_Telaid",
                        column: x => x.Telaid,
                        principalTable: "Telas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prendas_TipoPrendas_TipoPrendaid",
                        column: x => x.TipoPrendaid,
                        principalTable: "TipoPrendas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Usuario = table.Column<int>(type: "int", nullable: false),
                    nombre_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usuarioid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Usuario = table.Column<int>(type: "int", nullable: false),
                    id_Local = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ruc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usuarioid = table.Column<int>(type: "int", nullable: true),
                    Localid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Empresas_Locales_Localid",
                        column: x => x.Localid,
                        principalTable: "Locales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresas_Usuarios_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Pedido = table.Column<int>(type: "int", nullable: false),
                    id_Prenda = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<float>(type: "real", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prendaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Prendas_Prendaid",
                        column: x => x.Prendaid,
                        principalTable: "Prendas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medidas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Cliente = table.Column<int>(type: "int", nullable: false),
                    datos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clienteid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Medidas_Clientes_Clienteid",
                        column: x => x.Clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Cliente = table.Column<int>(type: "int", nullable: false),
                    id_Empresa = table.Column<int>(type: "int", nullable: false),
                    id_Local = table.Column<int>(type: "int", nullable: false),
                    id_Medidas = table.Column<int>(type: "int", nullable: false),
                    fecha_Entrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Clienteid = table.Column<int>(type: "int", nullable: true),
                    Empresaid = table.Column<int>(type: "int", nullable: true),
                    Localid = table.Column<int>(type: "int", nullable: true),
                    Medidasid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_Clienteid",
                        column: x => x.Clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Empresas_Empresaid",
                        column: x => x.Empresaid,
                        principalTable: "Empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Locales_Localid",
                        column: x => x.Localid,
                        principalTable: "Locales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Medidas_Medidasid",
                        column: x => x.Medidasid,
                        principalTable: "Medidas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Usuarioid",
                table: "Clientes",
                column: "Usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_Prendaid",
                table: "DetallePedidos",
                column: "Prendaid");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Localid",
                table: "Empresas",
                column: "Localid");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Usuarioid",
                table: "Empresas",
                column: "Usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Medidas_Clienteid",
                table: "Medidas",
                column: "Clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Clienteid",
                table: "Pedidos",
                column: "Clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Empresaid",
                table: "Pedidos",
                column: "Empresaid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Localid",
                table: "Pedidos",
                column: "Localid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Medidasid",
                table: "Pedidos",
                column: "Medidasid");

            migrationBuilder.CreateIndex(
                name: "IX_Prendas_Telaid",
                table: "Prendas",
                column: "Telaid");

            migrationBuilder.CreateIndex(
                name: "IX_Prendas_TipoPrendaid",
                table: "Prendas",
                column: "TipoPrendaid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoDocid",
                table: "Usuarios",
                column: "TipoDocid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactoUsuarios");

            migrationBuilder.DropTable(
                name: "DetallePedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Prendas");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Medidas");

            migrationBuilder.DropTable(
                name: "Telas");

            migrationBuilder.DropTable(
                name: "TipoPrendas");

            migrationBuilder.DropTable(
                name: "Locales");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoDocs");
        }
    }
}
