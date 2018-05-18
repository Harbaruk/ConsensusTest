using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ConsensusTester.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Hash = table.Column<string>(nullable: false),
                    BlockState = table.Column<string>(nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    Miner = table.Column<string>(nullable: false),
                    Nonce = table.Column<long>(nullable: false),
                    PreviousBlockHash = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Hash);
                });

            migrationBuilder.CreateTable(
                name: "TransactionEntity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BlockHash = table.Column<string>(nullable: true),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionEntity_Blocks_BlockHash",
                        column: x => x.BlockHash,
                        principalTable: "Blocks",
                        principalColumn: "Hash",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionEntity_BlockHash",
                table: "TransactionEntity",
                column: "BlockHash");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionEntity");

            migrationBuilder.DropTable(
                name: "Blocks");
        }
    }
}