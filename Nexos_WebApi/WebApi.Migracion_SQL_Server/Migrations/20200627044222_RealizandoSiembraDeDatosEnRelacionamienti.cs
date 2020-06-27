using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migracion_SQL_Server.Migrations
{
    public partial class RealizandoSiembraDeDatosEnRelacionamienti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DoctoresEspecialidades",
                columns: new[] { "DoctorId", "EspecialidadId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 8, 3 },
                    { 7, 2 },
                    { 7, 1 },
                    { 6, 4 },
                    { 5, 3 },
                    { 5, 2 },
                    { 4, 3 },
                    { 4, 2 },
                    { 5, 1 },
                    { 3, 2 },
                    { 3, 1 },
                    { 2, 4 },
                    { 2, 3 },
                    { 2, 1 },
                    { 1, 4 },
                    { 1, 3 },
                    { 1, 2 },
                    { 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "PacientesDoctores",
                columns: new[] { "DoctorId", "PacienteId" },
                values: new object[,]
                {
                    { 4, 7 },
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 1, 4 },
                    { 4, 5 },
                    { 5, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "DoctoresEspecialidades",
                keyColumns: new[] { "DoctorId", "EspecialidadId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "PacientesDoctores",
                keyColumns: new[] { "DoctorId", "PacienteId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PacientesDoctores",
                keyColumns: new[] { "DoctorId", "PacienteId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "PacientesDoctores",
                keyColumns: new[] { "DoctorId", "PacienteId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PacientesDoctores",
                keyColumns: new[] { "DoctorId", "PacienteId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "PacientesDoctores",
                keyColumns: new[] { "DoctorId", "PacienteId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "PacientesDoctores",
                keyColumns: new[] { "DoctorId", "PacienteId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "PacientesDoctores",
                keyColumns: new[] { "DoctorId", "PacienteId" },
                keyValues: new object[] { 5, 8 });
        }
    }
}
