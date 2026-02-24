using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WEBASE.LogSdk.Migrations.PgSqlMigrations
{
    /// <inheritdoc />
    public partial class Create_Local : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "log");

            migrationBuilder.CreateTable(
                name: "sys_error_scope",
                schema: "log",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    host_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    normalized_request_path = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    title = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    code = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    is_fixed = table.Column<bool>(type: "boolean", nullable: true),
                    scope_key = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_error_scope", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_error_scope_archive",
                schema: "log",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    host_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    normalized_request_path = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    title = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    code = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    is_fixed = table.Column<bool>(type: "boolean", nullable: true),
                    scope_key = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_error_scope_archive", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sys_app_error",
                schema: "log",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    host_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    user_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    user_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    request_trace_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    request_path = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    request_params = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    request_body = table.Column<string>(type: "text", nullable: true),
                    status_code = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    detail = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ip_address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    user_agent = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    user_agent_os = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    user_agent_device = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    user_agent_ua = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    normalized_request_path = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    code = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    error_scope_id = table.Column<long>(type: "BIGINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_app_error", x => x.id);
                    table.ForeignKey(
                        name: "fk_log__sys_app_error__scope",
                        column: x => x.error_scope_id,
                        principalSchema: "log",
                        principalTable: "sys_error_scope",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sys_app_error_archive",
                schema: "log",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    host_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    user_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    user_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    request_trace_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    request_path = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    request_params = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    request_body = table.Column<string>(type: "text", nullable: true),
                    status_code = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    detail = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ip_address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    user_agent = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    user_agent_os = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    user_agent_device = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    user_agent_ua = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    normalized_request_path = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    code = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    error_scope_id = table.Column<long>(type: "BIGINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_app_error_archive", x => x.id);
                    table.ForeignKey(
                        name: "fk_log__sys_app_error_archive__scope",
                        column: x => x.error_scope_id,
                        principalSchema: "log",
                        principalTable: "sys_error_scope_archive",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sys_app_error_error_scope_id",
                schema: "log",
                table: "sys_app_error",
                column: "error_scope_id");

            migrationBuilder.CreateIndex(
                name: "IX_sys_app_error_archive_error_scope_id",
                schema: "log",
                table: "sys_app_error_archive",
                column: "error_scope_id");

            migrationBuilder.CreateIndex(
                name: "ux_log__sys_error_scope__structure_unique",
                schema: "log",
                table: "sys_error_scope",
                columns: new[] { "host_name", "type", "normalized_request_path", "scope_key", "code" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_app_error",
                schema: "log");

            migrationBuilder.DropTable(
                name: "sys_app_error_archive",
                schema: "log");

            migrationBuilder.DropTable(
                name: "sys_error_scope",
                schema: "log");

            migrationBuilder.DropTable(
                name: "sys_error_scope_archive",
                schema: "log");
        }
    }
}
