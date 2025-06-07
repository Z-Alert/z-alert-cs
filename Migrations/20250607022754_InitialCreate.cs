using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZAlert.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsu = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NmUsu = table.Column<string>(type: "text", nullable: false),
                    EmailUsu = table.Column<string>(type: "text", nullable: false),
                    SenhaUsu = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsu);
                });

            migrationBuilder.CreateTable(
                name: "Dependentes",
                columns: table => new
                {
                    IdDepen = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NmDepen = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    IdadeDepen = table.Column<int>(type: "integer", nullable: false),
                    UsuarioIdUsu = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependentes", x => x.IdDepen);
                    table.ForeignKey(
                        name: "FK_Dependentes_Usuarios_UsuarioIdUsu",
                        column: x => x.UsuarioIdUsu,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alertas",
                columns: table => new
                {
                    IdAlerta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Localizacao = table.Column<string>(type: "text", nullable: false),
                    SttsAlerta = table.Column<string>(type: "text", nullable: false),
                    DependenteIdDepen = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertas", x => x.IdAlerta);
                    table.ForeignKey(
                        name: "FK_Alertas_Dependentes_DependenteIdDepen",
                        column: x => x.DependenteIdDepen,
                        principalTable: "Dependentes",
                        principalColumn: "IdDepen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dispositivos",
                columns: table => new
                {
                    IdDisposit = table.Column<int>(type: "integer", nullable: false),
                    TipoDisposit = table.Column<string>(type: "text", nullable: false),
                    StatusDisposit = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivos", x => x.IdDisposit);
                    table.ForeignKey(
                        name: "FK_Dispositivos_Dependentes_IdDisposit",
                        column: x => x.IdDisposit,
                        principalTable: "Dependentes",
                        principalColumn: "IdDepen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    IdLocali = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LatLocali = table.Column<decimal>(type: "numeric", nullable: false),
                    LngLocali = table.Column<decimal>(type: "numeric", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DependenteIdDepen = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.IdLocali);
                    table.ForeignKey(
                        name: "FK_Localizacoes_Dependentes_DependenteIdDepen",
                        column: x => x.DependenteIdDepen,
                        principalTable: "Dependentes",
                        principalColumn: "IdDepen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_DependenteIdDepen",
                table: "Alertas",
                column: "DependenteIdDepen");

            migrationBuilder.CreateIndex(
                name: "IX_Dependentes_UsuarioIdUsu",
                table: "Dependentes",
                column: "UsuarioIdUsu");

            migrationBuilder.CreateIndex(
                name: "IX_Localizacoes_DependenteIdDepen",
                table: "Localizacoes",
                column: "DependenteIdDepen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alertas");

            migrationBuilder.DropTable(
                name: "Dispositivos");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropTable(
                name: "Dependentes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
