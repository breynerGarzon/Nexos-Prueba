using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migracion_SQL_Server.Migrations
{
    public partial class CreacionBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    SeguroSocial = table.Column<string>(nullable: true),
                    CodigoPostal = table.Column<string>(nullable: true),
                    Telefono = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    NumeroCredencial = table.Column<int>(nullable: false),
                    HospitalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctoresEspecialidades",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false),
                    EspecialidadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctoresEspecialidades", x => new { x.DoctorId, x.EspecialidadId });
                    table.ForeignKey(
                        name: "FK_DoctoresEspecialidades_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctoresEspecialidades_Especialidad_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacientesDoctores",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientesDoctores", x => new { x.DoctorId, x.PacienteId });
                    table.ForeignKey(
                        name: "FK_PacientesDoctores_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacientesDoctores_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Especialidad",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Especialidad 1" },
                    { 2, "Especialidad 2" },
                    { 3, "Especialidad 3" },
                    { 4, "Especialidad 4" }
                });

            migrationBuilder.InsertData(
                table: "Hospital",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Hospital 1" },
                    { 2, "Hospital 2" },
                    { 3, "Hospital 3" }
                });

            migrationBuilder.InsertData(
                table: "Paciente",
                columns: new[] { "Id", "Apellidos", "CodigoPostal", "Nombres", "SeguroSocial", "Telefono" },
                values: new object[,]
                {
                    { 10, "Pruebas 10", null, "Paciente 10", "323334", 38394041 },
                    { 9, "Pruebas 9", null, "Paciente 9", "293031", 34353637 },
                    { 8, "Pruebas 8", null, "Paciente 8", "262728", 30313233 },
                    { 7, "Pruebas 7", null, "Paciente 7", "232425", 26272829 },
                    { 6, "Pruebas 6", null, "Paciente 6", "202122", 22232425 },
                    { 3, "Pruebas 3", null, "Paciente 3", "101112", 10111213 },
                    { 4, "Pruebas 4", null, "Paciente 4", "131415", 14151617 },
                    { 11, "Pruebas 11", null, "Paciente 11", "353637", 42434445 },
                    { 2, "Pruebas 2", null, "Paciente 2", "456789", 123456789 },
                    { 1, "Pruebas 1", null, "Paciente 1", "123456", 123456789 },
                    { 5, "Pruebas 5", null, "Paciente 5", "161718", 18192021 },
                    { 12, "Pruebas 12", null, "Paciente 12", "383940", 46474850 }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "Apellidos", "HospitalId", "Nombres", "NumeroCredencial" },
                values: new object[,]
                {
                    { 1, "Pruebas 1", 1, "Doctor 1", 0 },
                    { 2, "Pruebas 2", 1, "Doctor 2", 0 },
                    { 3, "Pruebas 3", 1, "Doctor 3", 0 },
                    { 6, "Pruebas 6", 1, "Doctor 6", 0 },
                    { 11, "Pruebas 11", 1, "Doctor 11", 0 },
                    { 12, "Pruebas 12", 1, "Doctor 12", 0 },
                    { 4, "Pruebas 4", 2, "Doctor 4", 0 },
                    { 5, "Pruebas 5", 2, "Doctor 5", 0 },
                    { 10, "Pruebas 10", 2, "Doctor 10", 0 },
                    { 7, "Pruebas 7", 3, "Doctor 7", 0 },
                    { 8, "Pruebas 8", 3, "Doctor 8", 0 },
                    { 9, "Pruebas 9", 3, "Doctor 9", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_HospitalId",
                table: "Doctor",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctoresEspecialidades_EspecialidadId",
                table: "DoctoresEspecialidades",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesDoctores_PacienteId",
                table: "PacientesDoctores",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctoresEspecialidades");

            migrationBuilder.DropTable(
                name: "PacientesDoctores");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Hospital");
        }
    }
}
