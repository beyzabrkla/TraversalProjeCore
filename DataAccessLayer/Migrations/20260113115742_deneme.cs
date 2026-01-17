using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Veritabanında zaten var olan tabloların hata vermemesi için
            // buradaki CreateTable kodlarını sildik.
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Gerekirse burayı da boş bırakabilirsin.
        }
    }
}