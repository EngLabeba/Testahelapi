using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Relationship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RelationshipEnglish = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnpublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnpublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnpublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnpublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NameEnglish = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PositionEnglish = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DepartmentEnglish = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnpublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnpublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfferCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnpublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnpublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfferLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnpublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnpublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfferPlatforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnpublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnpublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferPlatforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfferSharingMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnpublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnpublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferSharingMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DiscountTypeId = table.Column<int>(type: "int", nullable: false),
                    DiscountValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OrganizationNameEnglish = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DirectionsUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Rating = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    RatingCount = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TermsAndConditions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CurrentUses = table.Column<int>(type: "int", nullable: false),
                    DependentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnpublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnpublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Dependents_DependentId",
                        column: x => x.DependentId,
                        principalTable: "Dependents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_DiscountTypes_DiscountTypeId",
                        column: x => x.DiscountTypeId,
                        principalTable: "DiscountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_OfferCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "OfferCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferOfferLocation",
                columns: table => new
                {
                    LocationsId = table.Column<int>(type: "int", nullable: false),
                    OffersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferOfferLocation", x => new { x.LocationsId, x.OffersId });
                    table.ForeignKey(
                        name: "FK_OfferOfferLocation_OfferLocations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "OfferLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferOfferLocation_Offers_OffersId",
                        column: x => x.OffersId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferOfferPlatform",
                columns: table => new
                {
                    OffersId = table.Column<int>(type: "int", nullable: false),
                    PlatformsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferOfferPlatform", x => new { x.OffersId, x.PlatformsId });
                    table.ForeignKey(
                        name: "FK_OfferOfferPlatform_OfferPlatforms_PlatformsId",
                        column: x => x.PlatformsId,
                        principalTable: "OfferPlatforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferOfferPlatform_Offers_OffersId",
                        column: x => x.OffersId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferOfferSharingMethod",
                columns: table => new
                {
                    OffersId = table.Column<int>(type: "int", nullable: false),
                    SharingMethodsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferOfferSharingMethod", x => new { x.OffersId, x.SharingMethodsId });
                    table.ForeignKey(
                        name: "FK_OfferOfferSharingMethod_OfferSharingMethods_SharingMethodsId",
                        column: x => x.SharingMethodsId,
                        principalTable: "OfferSharingMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferOfferSharingMethod_Offers_OffersId",
                        column: x => x.OffersId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferShares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    SharedByUserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SharedWithUserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DependentId = table.Column<int>(type: "int", nullable: true),
                    ShareToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    QrCodeIdentifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QrCodeData = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SharedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsScanned = table.Column<bool>(type: "bit", nullable: false),
                    ScannedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScannedByUserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UsageNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnpublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnpublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferShares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferShares_Dependents_DependentId",
                        column: x => x.DependentId,
                        principalTable: "Dependents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferShares_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferShares_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DependentId = table.Column<int>(type: "int", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LocationUsed = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AmountSaved = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    VerifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DependentId1 = table.Column<int>(type: "int", nullable: true),
                    EmployeeId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnpublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnpublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferUsages_Dependents_DependentId",
                        column: x => x.DependentId,
                        principalTable: "Dependents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferUsages_Dependents_DependentId1",
                        column: x => x.DependentId1,
                        principalTable: "Dependents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferUsages_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferUsages_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferUsages_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SavedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnpublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnpublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedOffers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SavedOffers_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dependents",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsActive", "IsPublished", "PublishedAt", "PublishedBy", "Relationship", "RelationshipEnglish", "UnpublishedAt", "UnpublishedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, true, null, null, "زوجة", "Wife", null, null, null, null },
                    { 2, null, null, null, null, true, true, null, null, "ابن", "Son", null, null, null, null },
                    { 3, null, null, null, null, true, true, null, null, "أبنة", "Daughter", null, null, null, null },
                    { 4, null, null, null, null, true, true, null, null, "أب", "Father", null, null, null, null },
                    { 5, null, null, null, null, true, true, null, null, "أم", "Mother", null, null, null, null },
                    { 6, null, null, null, null, true, true, null, null, "أخ", "Brother", null, null, null, null },
                    { 7, null, null, null, null, true, true, null, null, "أخت", "Sister", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "DiscountTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Icon", "IsActive", "IsPublished", "Name", "PublishedAt", "PublishedBy", "UnpublishedAt", "UnpublishedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Percentage Discount", "📊", true, true, "نسبة مئوية", null, null, null, null, null, null },
                    { 2, null, null, null, null, "Special Offers", "⭐", true, true, "عروض خاصة", null, null, null, null, null, null },
                    { 3, null, null, null, null, "Fixed Amount Discount", "💰", true, true, "مبلغ ثابت", null, null, null, null, null, null },
                    { 4, null, null, null, null, "Free Offer", "🎁", true, true, "عرض مجاني", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Department", "DepartmentEnglish", "Email", "EmployeeId", "IsActive", "IsPublished", "Name", "NameEnglish", "PhoneNumber", "Position", "PositionEnglish", "PublishedAt", "PublishedBy", "Rank", "UnpublishedAt", "UnpublishedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 21, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3333), null, null, null, "إدارة الإعلام والاتصال المؤسسي", "Media and Corporate Communication Department", "mohammed.ahmed@riyadh.gov.sa", "EMP001", true, true, "محمد عبدالله أحمد", "Mohammed Abdullah Ahmed", "+966501234567", "مدير وحدة التصوير", "Director of Photography Unit", null, null, 8, null, null, null, null },
                    { 2, new DateTime(2025, 9, 21, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3337), null, null, null, "إدارة الإعلام والاتصال المؤسسي", "Media and Corporate Communication Department", "fatima.alsaeed@riyadh.gov.sa", "EMP002", true, true, "فاطمة محمد السعيد", "Fatima Mohammed Al-Saeed", "+966501234568", "أخصائية علاقات عامة", "Public Relations Specialist", null, null, 6, null, null, null, null },
                    { 3, new DateTime(2025, 9, 21, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3339), null, null, null, "إدارة تقنية المعلومات", "Information Technology Department", "ahmed.almutairi@riyadh.gov.sa", "EMP003", true, true, "أحمد خالد المطيري", "Ahmed Khalid Al-Mutairi", "+966501234569", "مطور تطبيقات", "Application Developer", null, null, 7, null, null, null, null },
                    { 4, new DateTime(2025, 9, 21, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3342), null, null, null, "إدارة المالية", "Finance Department", "nora.alqahtani@riyadh.gov.sa", "EMP004", true, true, "نورا عبدالرحمن القحطاني", "Nora Abdulrahman Al-Qahtani", "+966501234570", "محاسبة", "Accountant", null, null, 5, null, null, null, null },
                    { 5, new DateTime(2025, 9, 21, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3344), null, null, null, "إدارة الموارد البشرية", "Human Resources Department", "saad.alghamdi@riyadh.gov.sa", "EMP005", true, true, "سعد محمد الغامدي", "Saad Mohammed Al-Ghamdi", "+966501234571", "مدير الموارد البشرية", "Human Resources Manager", null, null, 9, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Icon", "IsActive", "IsPublished", "Name", "PublishedAt", "PublishedBy", "UnpublishedAt", "UnpublishedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Diverse Offers", "🎯", true, true, "عروض متنوعة", null, null, null, null, null, null },
                    { 2, null, null, null, null, "Banking Services", "🏦", true, true, "خدمات مصرفيه", null, null, null, null, null, null },
                    { 3, null, null, null, null, "Health and Medicine", "🏥", true, true, "صحة وطب", null, null, null, null, null, null },
                    { 4, null, null, null, null, "Travel and Tourism", "✈️", true, true, "سفر وسياحة", null, null, null, null, null, null },
                    { 5, null, null, null, null, "Shopping and Retail", "🛍️", true, true, "تسوق وبيع", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "OfferLocations",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsActive", "IsPublished", "Latitude", "Longitude", "Name", "PostalCode", "PublishedAt", "PublishedBy", "State", "UnpublishedAt", "UnpublishedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, "الرياض", "السعودية", null, null, null, null, true, true, 24.7136, 46.6753, "الرياض", null, null, null, "الرياض", null, null, null, null },
                    { 2, null, "جدة", "السعودية", null, null, null, null, true, true, 21.485800000000001, 39.192500000000003, "جدة", null, null, null, "مكة", null, null, null, null },
                    { 3, null, "", "", null, null, null, null, true, true, null, null, "أونلاين", null, null, null, "", null, null, null, null },
                    { 4, null, "الدمام", "السعودية", null, null, null, null, true, true, 26.4207, 50.088799999999999, "الدمام", null, null, null, "الشرقية", null, null, null, null },
                    { 5, null, "مكة المكرمة", "السعودية", null, null, null, null, true, true, 21.389099999999999, 39.857900000000001, "مكة المكرمة", null, null, null, "مكة", null, null, null, null },
                    { 6, null, "المدينة المنورة", "السعودية", null, null, null, null, true, true, 24.524699999999999, 39.569200000000002, "المدينة المنورة", null, null, null, "المدينة", null, null, null, null },
                    { 7, null, "الطائف", "السعودية", null, null, null, null, true, true, 21.270299999999999, 40.415799999999997, "الطائف", null, null, null, "مكة", null, null, null, null },
                    { 8, null, "بريدة", "السعودية", null, null, null, null, true, true, 26.326000000000001, 43.975000000000001, "بريدة", null, null, null, "القصيم", null, null, null, null },
                    { 9, null, "تبوك", "السعودية", null, null, null, null, true, true, 28.383800000000001, 36.555, "تبوك", null, null, null, "تبوك", null, null, null, null },
                    { 10, null, "خميس مشيط", "السعودية", null, null, null, null, true, true, 18.300000000000001, 42.7333, "خميس مشيط", null, null, null, "عسير", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "OfferPlatforms",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Icon", "IsActive", "IsPublished", "Name", "PublishedAt", "PublishedBy", "UnpublishedAt", "UnpublishedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Website", "🌐", true, true, "موقع", null, null, null, null, null, null },
                    { 2, null, null, null, null, "Mobile App", "📱", true, true, "تطبيق", null, null, null, null, null, null },
                    { 3, null, null, null, null, "WhatsApp", "💬", true, true, "واتساب", null, null, null, null, null, null },
                    { 4, null, null, null, null, "Social Media", "📢", true, true, "وسائل التواصل", null, null, null, null, null, null },
                    { 5, null, null, null, null, "Email", "📧", true, true, "بريد إلكتروني", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "OfferSharingMethods",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Icon", "IsActive", "IsPublished", "Name", "PublishedAt", "PublishedBy", "Type", "UnpublishedAt", "UnpublishedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Share with Dependents", "👨‍👩‍👧‍👦", true, true, "مشاركة مع التابعين", null, null, null, null, null, null, null },
                    { 2, null, null, null, null, "Share with Municipality Employees", "👥", true, true, "مشاركة مع منسوبي الأمانة", null, null, null, null, null, null, null },
                    { 3, null, null, null, null, "Share on Social Media", "📱", true, true, "مشاركة على وسائل التواصل", null, null, null, null, null, null, null },
                    { 4, null, null, null, null, "Direct Link", "🔗", true, true, "رابط مباشر", null, null, null, null, null, null, null },
                    { 5, null, null, null, null, "Cannot be Shared", "🚫", true, true, "لا يمكن المشاركة", null, null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "CurrentUses", "DeletedAt", "DeletedBy", "DependentId", "Description", "DirectionsUrl", "DiscountTypeId", "DiscountValue", "EmployeeId", "ImageUrl", "IsActive", "IsPublished", "Name", "OrganizationName", "OrganizationNameEnglish", "PublishedAt", "PublishedBy", "Rating", "RatingCount", "TermsAndConditions", "Title", "UnpublishedAt", "UnpublishedBy", "UpdatedAt", "UpdatedBy", "ValidFrom", "ValidUntil" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2025, 9, 11, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1742), null, 269, null, null, null, "خصم على حجوزات الفنادق عبر تطبيق المسافر", "https://maps.google.com/?q=المسافر", 3, "15", null, "https://example.com/images/المسافر.jpg", true, true, "المسافر", "أمانة منطقة الرياض", "Riyadh Region Municipality", null, null, 4.0m, 125, "صالح على  حجوزات الفنادق عبر تطبيق المسافر. يجب الحجز مسبقاً.", "المسافر", null, null, null, null, new DateTime(2025, 8, 31, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1716), new DateTime(2026, 3, 20, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1716) },
                    { 2, 4, new DateTime(2025, 9, 19, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1827), null, 387, null, null, null, "خصم على تذاكر الطيران الداخلي", "https://maps.google.com/?q=طيران+ناس", 4, "20", null, "https://example.com/images/طيران-ناس.jpg", true, true, "طيران ناس", "طيران ناس", "Flynas", null, null, 4.0m, 194, "صالح على  تذاكر الطيران الداخلي. يجب الحجز مسبقاً.", "طيران ناس", null, null, null, null, new DateTime(2025, 9, 14, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1825), new DateTime(2026, 4, 5, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1825) },
                    { 3, 4, new DateTime(2025, 9, 19, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1846), null, 708, null, null, null, "خصم على الرحلات الدولية", "https://maps.google.com/?q=الخطوط+السعودية", 4, "40", null, "https://example.com/images/الخطوط-السعودية.jpg", true, true, "الخطوط السعودية", "الخطوط السعودية", "Saudi Airlines", null, null, 3.3m, 90, "صالح على  الرحلات الدولية. يجب الحجز مسبقاً.", "الخطوط السعودية", null, null, null, null, new DateTime(2025, 8, 28, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1844), new DateTime(2026, 3, 26, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1844) },
                    { 4, 4, new DateTime(2025, 8, 18, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1854), null, 194, null, null, null, "خصم على الإقامة في فندق الفيصلية", "https://maps.google.com/?q=فندق+الفيصلية", 3, "15", null, "https://example.com/images/فندق-الفيصلية.jpg", true, true, "فندق الفيصلية", "فندق الفيصلية", "Al Faisaliah Hotel", null, null, 4.4m, 282, "صالح على  الإقامة في فندق الفيصلية. يجب الحجز مسبقاً.", "فندق الفيصلية", null, null, null, null, new DateTime(2025, 9, 20, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1853), new DateTime(2026, 1, 31, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1853) },
                    { 5, 4, new DateTime(2025, 9, 18, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1862), null, 390, null, null, null, "خصم على حجوزات الأجنحة الفندقية", "https://maps.google.com/?q=أجنحة+الرياض", 4, "10", null, "https://example.com/images/أجنحة-الرياض.jpg", true, true, "أجنحة الرياض", "أجنحة الرياض", "Riyadh Suites", null, null, 4.6m, 386, "صالح على  حجوزات الأجنحة الفندقية. يجب الحجز مسبقاً.", "أجنحة الرياض", null, null, null, null, new DateTime(2025, 9, 17, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1860), new DateTime(2025, 10, 25, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1860) },
                    { 6, 4, new DateTime(2025, 9, 19, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1870), null, 296, null, null, null, "خصم على رحلات الحج والعمرة", "https://maps.google.com/?q=رحلات+الحج", 4, "50", null, "https://example.com/images/رحلات-الحج.jpg", true, true, "رحلات الحج", "مؤسسة الحج", "Hajj Foundation", null, null, 3.5m, 397, "صالح على  رحلات الحج والعمرة. يجب الحجز مسبقاً.", "رحلات الحج", null, null, null, null, new DateTime(2025, 9, 2, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1869), new DateTime(2025, 11, 19, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1869) },
                    { 7, 4, new DateTime(2025, 8, 31, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1958), null, 632, null, null, null, "خصم على الجولات السياحية في جدة", "https://maps.google.com/?q=سياحة+جدة", 3, "40", null, "https://example.com/images/سياحة-جدة.jpg", true, true, "سياحة جدة", "هيئة السياحة", "Tourism Authority", null, null, 3.8m, 367, "صالح على  الجولات السياحية في جدة. يجب الحجز مسبقاً.", "سياحة جدة", null, null, null, null, new DateTime(2025, 9, 15, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1876), new DateTime(2025, 10, 19, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1876) },
                    { 8, 4, new DateTime(2025, 8, 22, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1968), null, 21, null, null, null, "خصم على الإقامة في فندق الماريوت", "https://maps.google.com/?q=فندق+الماريوت", 2, "10", null, "https://example.com/images/فندق-الماريوت.jpg", true, true, "فندق الماريوت", "فندق الماريوت", "Marriott Hotel", null, null, 3.1m, 258, "صالح على  الإقامة في فندق الماريوت. يجب الحجز مسبقاً.", "فندق الماريوت", null, null, null, null, new DateTime(2025, 8, 29, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1966), new DateTime(2026, 2, 22, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1966) },
                    { 9, 4, new DateTime(2025, 7, 29, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1975), null, 73, null, null, null, "خصم على رحلات الطائف الصيفية", "https://maps.google.com/?q=رحلات+الطائف", 2, "10", null, "https://example.com/images/رحلات-الطائف.jpg", true, true, "رحلات الطائف", "شركة الطائف للسياحة", "Taif Tourism Company", null, null, 3.0m, 51, "صالح على  رحلات الطائف الصيفية. يجب الحجز مسبقاً.", "رحلات الطائف", null, null, null, null, new DateTime(2025, 9, 2, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1973), new DateTime(2025, 10, 13, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1973) },
                    { 10, 4, new DateTime(2025, 8, 5, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1984), null, 379, null, null, null, "خصم على الإقامة في فندق الهيلتون", "https://maps.google.com/?q=فندق+الهيلتون", 4, "30", null, "https://example.com/images/فندق-الهيلتون.jpg", true, true, "فندق الهيلتون", "فندق الهيلتون", "Hilton Hotel", null, null, 4.2m, 69, "صالح على  الإقامة في فندق الهيلتون. يجب الحجز مسبقاً.", "فندق الهيلتون", null, null, null, null, new DateTime(2025, 9, 17, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1982), new DateTime(2026, 3, 12, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1982) },
                    { 11, 3, new DateTime(2025, 7, 26, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1991), null, 737, null, null, null, "خصم على الاستشارات الطبية والفحوصات", "https://maps.google.com/?q=مستشفى+المملكة", 3, "30", null, "https://example.com/images/مستشفى-المملكة.jpg", true, true, "مستشفى المملكة", "مستشفى المملكة", "Kingdom Hospital", null, null, 4.8m, 314, "صالح على  الاستشارات الطبية والفحوصات. يجب الحجز مسبقاً.", "مستشفى المملكة", null, null, null, null, new DateTime(2025, 9, 21, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1990), new DateTime(2026, 8, 12, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1990) },
                    { 12, 3, new DateTime(2025, 9, 13, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1998), null, 339, null, null, null, "خصم على علاجات الأسنان", "https://maps.google.com/?q=عيادة+الأسنان", 2, "عرض خاص", null, "https://example.com/images/عيادة-الأسنان.jpg", true, true, "عيادة الأسنان", "عيادة الأسنان المتقدمة", "Advanced Dental Clinic", null, null, 3.2m, 253, "صالح على  علاجات الأسنان. يجب الحجز مسبقاً.", "عيادة الأسنان", null, null, null, null, new DateTime(2025, 8, 29, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1997), new DateTime(2025, 11, 16, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(1997) },
                    { 13, 3, new DateTime(2025, 8, 19, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2006), null, 675, null, null, null, "خصم على العمليات الجراحية", "https://maps.google.com/?q=مستشفى+الملك+فهد", 1, "40", null, "https://example.com/images/مستشفى-الملك-فهد.jpg", true, true, "مستشفى الملك فهد", "مستشفى الملك فهد", "King Fahd Hospital", null, null, 5.0m, 394, "صالح على  العمليات الجراحية. يجب الحجز مسبقاً.", "مستشفى الملك فهد", null, null, null, null, new DateTime(2025, 8, 31, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2004), new DateTime(2026, 1, 4, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2004) },
                    { 14, 3, new DateTime(2025, 9, 19, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2013), null, 36, null, null, null, "خصم على الأدوية والمستلزمات الطبية", "https://maps.google.com/?q=صيدلية+النهدي", 4, "50", null, "https://example.com/images/صيدلية-النهدي.jpg", true, true, "صيدلية النهدي", "صيدلية النهدي", "Nahdi Pharmacy", null, null, 3.7m, 468, "صالح على  الأدوية والمستلزمات الطبية. يجب الحجز مسبقاً.", "صيدلية النهدي", null, null, null, null, new DateTime(2025, 9, 15, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2011), new DateTime(2026, 1, 11, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2011) },
                    { 15, 3, new DateTime(2025, 9, 2, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2056), null, 130, null, null, null, "خصم على فحوصات العيون", "https://maps.google.com/?q=عيادة+العيون", 1, "40", null, "https://example.com/images/عيادة-العيون.jpg", true, true, "عيادة العيون", "عيادة العيون المتخصصة", "Specialized Eye Clinic", null, null, 3.2m, 497, "صالح على  فحوصات العيون. يجب الحجز مسبقاً.", "عيادة العيون", null, null, null, null, new DateTime(2025, 9, 18, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2054), new DateTime(2026, 2, 2, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2054) },
                    { 16, 3, new DateTime(2025, 8, 2, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2063), null, 896, null, null, null, "خصم على الخدمات الطبية", "https://maps.google.com/?q=مستشفى+الملك+خالد", 4, "مجاني", null, "https://example.com/images/مستشفى-الملك-خالد.jpg", true, true, "مستشفى الملك خالد", "مستشفى الملك خالد", "King Khalid Hospital", null, null, 3.1m, 428, "صالح على  الخدمات الطبية. يجب الحجز مسبقاً.", "مستشفى الملك خالد", null, null, null, null, new DateTime(2025, 9, 14, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2062), new DateTime(2026, 8, 20, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2062) },
                    { 17, 3, new DateTime(2025, 9, 8, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2071), null, 304, null, null, null, "خصم على استشارات الأطفال", "https://maps.google.com/?q=عيادة+الأطفال", 2, "40", null, "https://example.com/images/عيادة-الأطفال.jpg", true, true, "عيادة الأطفال", "عيادة الأطفال المتخصصة", "Specialized Children Clinic", null, null, 4.3m, 136, "صالح على  استشارات الأطفال. يجب الحجز مسبقاً.", "عيادة الأطفال", null, null, null, null, new DateTime(2025, 9, 16, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2070), new DateTime(2025, 10, 25, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2070) },
                    { 18, 3, new DateTime(2025, 8, 19, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2081), null, 194, null, null, null, "خصم على الفحوصات الطبية", "https://maps.google.com/?q=مستشفى+الملك+عبدالعزيز", 4, "مبلغ ثابت", null, "https://example.com/images/مستشفى-الملك-عبدالعزيز.jpg", true, true, "مستشفى الملك عبدالعزيز", "مستشفى الملك عبدالعزيز", "King Abdulaziz Hospital", null, null, 3.3m, 447, "صالح على  الفحوصات الطبية. يجب الحجز مسبقاً.", "مستشفى الملك عبدالعزيز", null, null, null, null, new DateTime(2025, 9, 13, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2079), new DateTime(2026, 4, 18, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2079) },
                    { 19, 3, new DateTime(2025, 8, 25, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2089), null, 450, null, null, null, "خصم على علاجات الجلد", "https://maps.google.com/?q=عيادة+الجلدية", 3, "15", null, "https://example.com/images/عيادة-الجلدية.jpg", true, true, "عيادة الجلدية", "عيادة الجلدية المتقدمة", "Advanced Dermatology Clinic", null, null, 3.8m, 446, "صالح على  علاجات الجلد. يجب الحجز مسبقاً.", "عيادة الجلدية", null, null, null, null, new DateTime(2025, 9, 11, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2088), new DateTime(2026, 8, 29, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2088) },
                    { 20, 3, new DateTime(2025, 8, 9, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2096), null, 12, null, null, null, "خصم على الخدمات الطبية المتخصصة", "https://maps.google.com/?q=مستشفى+الملك+سلمان", 3, "مبلغ ثابت", null, "https://example.com/images/مستشفى-الملك-سلمان.jpg", true, true, "مستشفى الملك سلمان", "مستشفى الملك سلمان", "King Salman Hospital", null, null, 3.3m, 98, "صالح على  الخدمات الطبية المتخصصة. يجب الحجز مسبقاً.", "مستشفى الملك سلمان", null, null, null, null, new DateTime(2025, 9, 16, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2094), new DateTime(2026, 8, 27, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2094) },
                    { 21, 2, new DateTime(2025, 9, 1, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2103), null, 964, null, null, null, "خصم على الخدمات المصرفية والاستثمارية", "https://maps.google.com/?q=بنك+الجزيرة", 2, "40", null, "https://example.com/images/بنك-الجزيرة.jpg", true, true, "بنك الجزيرة", "بنك الجزيرة", "AlJazira Bank", null, null, 3.2m, 459, "صالح على  الخدمات المصرفية والاستثمارية. يجب الحجز مسبقاً.", "بنك الجزيرة", null, null, null, null, new DateTime(2025, 8, 26, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2102), new DateTime(2025, 11, 21, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2102) },
                    { 22, 2, new DateTime(2025, 8, 4, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2137), null, 287, null, null, null, "خصم على القروض الشخصية", "https://maps.google.com/?q=البنك+الأهلي", 3, "50", null, "https://example.com/images/البنك-الأهلي.jpg", true, true, "البنك الأهلي", "البنك الأهلي التجاري", "National Commercial Bank", null, null, 4.6m, 386, "صالح على  القروض الشخصية. يجب الحجز مسبقاً.", "البنك الأهلي", null, null, null, null, new DateTime(2025, 9, 11, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2135), new DateTime(2026, 4, 5, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2135) },
                    { 23, 2, new DateTime(2025, 9, 17, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2144), null, 236, null, null, null, "خصم على خدمات الاستثمار", "https://maps.google.com/?q=بنك+الراجحي", 1, "مجاني", null, "https://example.com/images/بنك-الراجحي.jpg", true, true, "بنك الراجحي", "بنك الراجحي", "Al Rajhi Bank", null, null, 3.4m, 174, "صالح على  خدمات الاستثمار. يجب الحجز مسبقاً.", "بنك الراجحي", null, null, null, null, new DateTime(2025, 8, 27, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2142), new DateTime(2026, 4, 28, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2142) },
                    { 24, 2, new DateTime(2025, 7, 25, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2150), null, 943, null, null, null, "خصم على البطاقات الائتمانية", "https://maps.google.com/?q=بنك+ساب", 2, "مجاني", null, "https://example.com/images/بنك-ساب.jpg", true, true, "بنك ساب", "بنك ساب", "SABB Bank", null, null, 4.6m, 479, "صالح على  البطاقات الائتمانية. يجب الحجز مسبقاً.", "بنك ساب", null, null, null, null, new DateTime(2025, 9, 8, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2149), new DateTime(2026, 8, 2, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2149) },
                    { 25, 2, new DateTime(2025, 9, 1, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2161), null, 711, null, null, null, "خصم على الخدمات المصرفية", "https://maps.google.com/?q=البنك+السعودي+الفرنسي", 1, "40", null, "https://example.com/images/البنك-السعودي-الفرنسي.jpg", true, true, "البنك السعودي الفرنسي", "البنك السعودي الفرنسي", "Saudi French Bank", null, null, 4.3m, 275, "صالح على  الخدمات المصرفية. يجب الحجز مسبقاً.", "البنك السعودي الفرنسي", null, null, null, null, new DateTime(2025, 9, 18, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2160), new DateTime(2026, 7, 15, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2160) },
                    { 26, 2, new DateTime(2025, 9, 18, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2169), null, 585, null, null, null, "خصم على التمويل العقاري", "https://maps.google.com/?q=بنك+الإنماء", 3, "عرض خاص", null, "https://example.com/images/بنك-الإنماء.jpg", true, true, "بنك الإنماء", "بنك الإنماء", "Alinma Bank", null, null, 4.1m, 404, "صالح على  التمويل العقاري. يجب الحجز مسبقاً.", "بنك الإنماء", null, null, null, null, new DateTime(2025, 9, 16, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2167), new DateTime(2026, 8, 25, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2167) },
                    { 27, 2, new DateTime(2025, 8, 30, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2175), null, 277, null, null, null, "خصم على الخدمات المصرفية الرقمية", "https://maps.google.com/?q=بنك+الرياض", 1, "20", null, "https://example.com/images/بنك-الرياض.jpg", true, true, "بنك الرياض", "بنك الرياض", "Riyad Bank", null, null, 3.3m, 181, "صالح على  الخدمات المصرفية الرقمية. يجب الحجز مسبقاً.", "بنك الرياض", null, null, null, null, new DateTime(2025, 8, 26, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2174), new DateTime(2026, 3, 1, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2174) },
                    { 28, 2, new DateTime(2025, 7, 27, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2182), null, 857, null, null, null, "خصم على خدمات الاستثمار", "https://maps.google.com/?q=البنك+السعودي+للاستثمار", 2, "عرض خاص", null, "https://example.com/images/البنك-السعودي-للاستثمار.jpg", true, true, "البنك السعودي للاستثمار", "البنك السعودي للاستثمار", "Saudi Investment Bank", null, null, 5.0m, 210, "صالح على  خدمات الاستثمار. يجب الحجز مسبقاً.", "البنك السعودي للاستثمار", null, null, null, null, new DateTime(2025, 9, 12, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2181), new DateTime(2025, 12, 12, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2181) },
                    { 29, 2, new DateTime(2025, 7, 28, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2218), null, 476, null, null, null, "خصم على الخدمات المصرفية", "https://maps.google.com/?q=بنك+الخليج", 3, "50", null, "https://example.com/images/بنك-الخليج.jpg", true, true, "بنك الخليج", "بنك الخليج", "Gulf Bank", null, null, 4.9m, 85, "صالح على  الخدمات المصرفية. يجب الحجز مسبقاً.", "بنك الخليج", null, null, null, null, new DateTime(2025, 8, 26, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2216), new DateTime(2026, 1, 7, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2216) },
                    { 30, 2, new DateTime(2025, 8, 12, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2225), null, 28, null, null, null, "خصم على القروض التجارية", "https://maps.google.com/?q=البنك+العربي+الوطني", 4, "مجاني", null, "https://example.com/images/البنك-العربي-الوطني.jpg", true, true, "البنك العربي الوطني", "البنك العربي الوطني", "Arab National Bank", null, null, 3.6m, 311, "صالح على  القروض التجارية. يجب الحجز مسبقاً.", "البنك العربي الوطني", null, null, null, null, new DateTime(2025, 8, 26, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2223), new DateTime(2026, 2, 9, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2223) },
                    { 31, 1, new DateTime(2025, 9, 19, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2233), null, 40, null, null, null, "خصم على وجبات الطعام والشراب", "https://maps.google.com/?q=مطعم+اللوفر", 3, "مبلغ ثابت", null, "https://example.com/images/مطعم-اللوفر.jpg", true, true, "مطعم اللوفر", "مطعم اللوفر", "Louvre Restaurant", null, null, 4.9m, 388, "صالح على  وجبات الطعام والشراب. يجب الحجز مسبقاً.", "مطعم اللوفر", null, null, null, null, new DateTime(2025, 9, 11, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2232), new DateTime(2026, 5, 19, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2232) },
                    { 32, 1, new DateTime(2025, 9, 2, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2240), null, 609, null, null, null, "خصم على الوجبات السريعة", "https://maps.google.com/?q=مطعم+البيك", 3, "40", null, "https://example.com/images/مطعم-البيك.jpg", true, true, "مطعم البيك", "مطعم البيك", "Al Baik Restaurant", null, null, 3.7m, 148, "صالح على  الوجبات السريعة. يجب الحجز مسبقاً.", "مطعم البيك", null, null, null, null, new DateTime(2025, 9, 2, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2238), new DateTime(2026, 4, 22, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2238) },
                    { 33, 1, new DateTime(2025, 8, 18, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2247), null, 979, null, null, null, "خصم على المشروبات الساخنة", "https://maps.google.com/?q=كافيه+ستاربكس", 3, "10", null, "https://example.com/images/كافيه-ستاربكس.jpg", true, true, "كافيه ستاربكس", "ستاربكس", "Starbucks", null, null, 4.7m, 180, "صالح على  المشروبات الساخنة. يجب الحجز مسبقاً.", "كافيه ستاربكس", null, null, null, null, new DateTime(2025, 9, 11, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2245), new DateTime(2025, 10, 11, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2245) },
                    { 34, 1, new DateTime(2025, 9, 10, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2256), null, 945, null, null, null, "خصم على الوجبات السريعة", "https://maps.google.com/?q=مطعم+كنتاكي", 2, "15", null, "https://example.com/images/مطعم-كنتاكي.jpg", true, true, "مطعم كنتاكي", "كنتاكي", "KFC", null, null, 4.3m, 98, "صالح على  الوجبات السريعة. يجب الحجز مسبقاً.", "مطعم كنتاكي", null, null, null, null, new DateTime(2025, 9, 16, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2254), new DateTime(2026, 5, 23, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2254) },
                    { 35, 1, new DateTime(2025, 8, 5, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2263), null, 427, null, null, null, "خصم على الوجبات السريعة", "https://maps.google.com/?q=مطعم+ماكدونالدز", 3, "50", null, "https://example.com/images/مطعم-ماكدونالدز.jpg", true, true, "مطعم ماكدونالدز", "ماكدونالدز", "McDonald's", null, null, 3.7m, 326, "صالح على  الوجبات السريعة. يجب الحجز مسبقاً.", "مطعم ماكدونالدز", null, null, null, null, new DateTime(2025, 9, 9, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2262), new DateTime(2025, 12, 13, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2262) },
                    { 36, 1, new DateTime(2025, 9, 3, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2298), null, 974, null, null, null, "خصم على البيتزا", "https://maps.google.com/?q=مطعم+بيتزا+هت", 3, "40", null, "https://example.com/images/مطعم-بيتزا-هت.jpg", true, true, "مطعم بيتزا هت", "بيتزا هت", "Pizza Hut", null, null, 3.8m, 344, "صالح على  البيتزا. يجب الحجز مسبقاً.", "مطعم بيتزا هت", null, null, null, null, new DateTime(2025, 9, 1, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2296), new DateTime(2025, 12, 15, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2296) },
                    { 37, 1, new DateTime(2025, 8, 22, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2312), null, 754, null, null, null, "خصم على البيتزا والوجبات", "https://maps.google.com/?q=مطعم+دومينوز", 3, "مجاني", null, "https://example.com/images/مطعم-دومينوز.jpg", true, true, "مطعم دومينوز", "دومينوز", "Domino's", null, null, 3.6m, 315, "صالح على  البيتزا والوجبات. يجب الحجز مسبقاً.", "مطعم دومينوز", null, null, null, null, new DateTime(2025, 9, 8, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2310), new DateTime(2026, 9, 4, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2310) },
                    { 38, 1, new DateTime(2025, 7, 26, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2319), null, 567, null, null, null, "خصم على الوجبات السريعة", "https://maps.google.com/?q=مطعم+هارديز", 4, "10", null, "https://example.com/images/مطعم-هارديز.jpg", true, true, "مطعم هارديز", "هارديز", "Hardee's", null, null, 3.8m, 123, "صالح على  الوجبات السريعة. يجب الحجز مسبقاً.", "مطعم هارديز", null, null, null, null, new DateTime(2025, 9, 9, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2317), new DateTime(2025, 10, 9, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2317) },
                    { 39, 1, new DateTime(2025, 8, 25, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2326), null, 104, null, null, null, "خصم على الوجبات الفرنسية", "https://maps.google.com/?q=مطعم+شوبارد", 2, "25", null, "https://example.com/images/مطعم-شوبارد.jpg", true, true, "مطعم شوبارد", "شوبارد", "Chopard", null, null, 4.4m, 236, "صالح على  الوجبات الفرنسية. يجب الحجز مسبقاً.", "مطعم شوبارد", null, null, null, null, new DateTime(2025, 9, 16, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2324), new DateTime(2026, 7, 9, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2324) },
                    { 40, 1, new DateTime(2025, 8, 2, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2332), null, 884, null, null, null, "خصم على الوجبات اللبنانية", "https://maps.google.com/?q=مطعم+نادين", 4, "مبلغ ثابت", null, "https://example.com/images/مطعم-نادين.jpg", true, true, "مطعم نادين", "مطعم نادين", "Nadine Restaurant", null, null, 3.4m, 476, "صالح على  الوجبات اللبنانية. يجب الحجز مسبقاً.", "مطعم نادين", null, null, null, null, new DateTime(2025, 9, 2, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2331), new DateTime(2026, 5, 4, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2331) },
                    { 41, 5, new DateTime(2025, 9, 12, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2339), null, 629, null, null, null, "خصم على خدمات التجميل والعناية بالبشرة", "https://maps.google.com/?q=صالون+الجمال", 3, "25", null, "https://example.com/images/صالون-الجمال.jpg", true, true, "صالون الجمال", "صالون الجمال", "Beauty Salon", null, null, 3.2m, 457, "صالح على  خدمات التجميل والعناية بالبشرة. يجب الحجز مسبقاً.", "صالون الجمال", null, null, null, null, new DateTime(2025, 8, 25, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2338), new DateTime(2026, 4, 2, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2338) },
                    { 42, 5, new DateTime(2025, 7, 29, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2346), null, 656, null, null, null, "خصم على الأثاث المنزلي", "https://maps.google.com/?q=متجر+إيكيا", 2, "15", null, "https://example.com/images/متجر-إيكيا.jpg", true, true, "متجر إيكيا", "إيكيا", "IKEA", null, null, 3.2m, 52, "صالح على  الأثاث المنزلي. يجب الحجز مسبقاً.", "متجر إيكيا", null, null, null, null, new DateTime(2025, 9, 21, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2344), new DateTime(2026, 1, 7, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2344) },
                    { 43, 5, new DateTime(2025, 9, 18, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2431), null, 794, null, null, null, "خصم على البقالة والأدوات المنزلية", "https://maps.google.com/?q=متجر+كارفور", 4, "مجاني", null, "https://example.com/images/متجر-كارفور.jpg", true, true, "متجر كارفور", "كارفور", "Carrefour", null, null, 4.2m, 107, "صالح على  البقالة والأدوات المنزلية. يجب الحجز مسبقاً.", "متجر كارفور", null, null, null, null, new DateTime(2025, 9, 13, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2428), new DateTime(2026, 4, 13, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2428) },
                    { 44, 5, new DateTime(2025, 8, 12, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2440), null, 528, null, null, null, "خصم على الأدوات المنزلية", "https://maps.google.com/?q=متجر+هوم+سنتر", 1, "50", null, "https://example.com/images/متجر-هوم-سنتر.jpg", true, true, "متجر هوم سنتر", "هوم سنتر", "Home Center", null, null, 4.1m, 404, "صالح على  الأدوات المنزلية. يجب الحجز مسبقاً.", "متجر هوم سنتر", null, null, null, null, new DateTime(2025, 8, 31, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2438), new DateTime(2026, 7, 28, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2438) },
                    { 45, 5, new DateTime(2025, 8, 13, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2447), null, 846, null, null, null, "خصم على الأجهزة الإلكترونية", "https://maps.google.com/?q=متجر+إكس+ترا", 4, "25", null, "https://example.com/images/متجر-إكس-ترا.jpg", true, true, "متجر إكس ترا", "إكس ترا", "Extra", null, null, 4.7m, 407, "صالح على  الأجهزة الإلكترونية. يجب الحجز مسبقاً.", "متجر إكس ترا", null, null, null, null, new DateTime(2025, 8, 24, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2445), new DateTime(2026, 6, 21, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2445) },
                    { 46, 5, new DateTime(2025, 8, 4, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2454), null, 714, null, null, null, "خصم على الكتب والأدوات المكتبية", "https://maps.google.com/?q=متجر+جرير", 1, "عرض خاص", null, "https://example.com/images/متجر-جرير.jpg", true, true, "متجر جرير", "جرير", "Jarir", null, null, 4.7m, 134, "صالح على  الكتب والأدوات المكتبية. يجب الحجز مسبقاً.", "متجر جرير", null, null, null, null, new DateTime(2025, 8, 24, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2452), new DateTime(2026, 6, 20, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2452) },
                    { 47, 5, new DateTime(2025, 7, 28, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2460), null, 366, null, null, null, "خصم على البقالة", "https://maps.google.com/?q=متجر+العثيم", 2, "مبلغ ثابت", null, "https://example.com/images/متجر-العثيم.jpg", true, true, "متجر العثيم", "العثيم", "Al Othaim", null, null, 3.5m, 419, "صالح على  البقالة. يجب الحجز مسبقاً.", "متجر العثيم", null, null, null, null, new DateTime(2025, 9, 4, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2459), new DateTime(2026, 8, 7, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2459) },
                    { 48, 5, new DateTime(2025, 7, 31, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2468), null, 112, null, null, null, "خصم على البقالة والأدوات المنزلية", "https://maps.google.com/?q=متجر+بنده", 1, "مجاني", null, "https://example.com/images/متجر-بنده.jpg", true, true, "متجر بنده", "بنده", "Panda", null, null, 4.7m, 225, "صالح على  البقالة والأدوات المنزلية. يجب الحجز مسبقاً.", "متجر بنده", null, null, null, null, new DateTime(2025, 8, 23, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2466), new DateTime(2025, 11, 5, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2466) },
                    { 49, 5, new DateTime(2025, 8, 8, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2475), null, 324, null, null, null, "خصم على البقالة", "https://maps.google.com/?q=متجر+لولو", 3, "مبلغ ثابت", null, "https://example.com/images/متجر-لولو.jpg", true, true, "متجر لولو", "لولو هايبرماركت", "Lulu Hypermarket", null, null, 4.1m, 345, "صالح على  البقالة. يجب الحجز مسبقاً.", "متجر لولو", null, null, null, null, new DateTime(2025, 9, 18, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2473), new DateTime(2025, 12, 23, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2473) },
                    { 50, 5, new DateTime(2025, 7, 24, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2514), null, 980, null, null, null, "خصم على الأدوات المنزلية", "https://maps.google.com/?q=متجر+ساكو", 1, "15", null, "https://example.com/images/متجر-ساكو.jpg", true, true, "متجر ساكو", "ساكو", "SACO", null, null, 3.8m, 303, "صالح على  الأدوات المنزلية. يجب الحجز مسبقاً.", "متجر ساكو", null, null, null, null, new DateTime(2025, 8, 31, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2480), new DateTime(2025, 12, 31, 13, 57, 34, 203, DateTimeKind.Local).AddTicks(2480) }
                });

            migrationBuilder.InsertData(
                table: "OfferOfferLocation",
                columns: new[] { "LocationsId", "OffersId" },
                values: new object[,]
                {
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 12 },
                    { 1, 16 },
                    { 1, 18 },
                    { 1, 23 },
                    { 1, 28 },
                    { 1, 29 },
                    { 1, 32 },
                    { 1, 34 },
                    { 1, 38 },
                    { 1, 43 },
                    { 1, 45 },
                    { 1, 47 },
                    { 2, 5 },
                    { 2, 19 },
                    { 2, 21 },
                    { 2, 23 },
                    { 2, 27 },
                    { 2, 41 },
                    { 3, 2 },
                    { 3, 4 },
                    { 3, 9 },
                    { 3, 26 },
                    { 3, 30 },
                    { 3, 33 },
                    { 3, 35 },
                    { 3, 36 },
                    { 3, 38 },
                    { 3, 47 },
                    { 4, 3 },
                    { 4, 5 },
                    { 4, 8 },
                    { 4, 14 },
                    { 4, 24 },
                    { 4, 28 },
                    { 4, 40 },
                    { 4, 43 },
                    { 4, 49 },
                    { 4, 50 },
                    { 5, 1 },
                    { 5, 4 },
                    { 5, 13 },
                    { 5, 17 },
                    { 5, 20 },
                    { 5, 21 },
                    { 5, 22 },
                    { 5, 24 },
                    { 5, 26 },
                    { 5, 31 },
                    { 5, 32 },
                    { 5, 33 },
                    { 5, 49 },
                    { 5, 50 },
                    { 6, 1 },
                    { 6, 6 },
                    { 6, 12 },
                    { 6, 18 },
                    { 6, 27 },
                    { 6, 30 },
                    { 6, 37 },
                    { 6, 38 },
                    { 6, 41 },
                    { 6, 46 },
                    { 6, 50 },
                    { 7, 1 },
                    { 7, 12 },
                    { 7, 15 },
                    { 7, 19 },
                    { 7, 21 },
                    { 7, 26 },
                    { 7, 30 },
                    { 7, 39 },
                    { 7, 45 },
                    { 8, 10 },
                    { 8, 20 },
                    { 8, 24 },
                    { 8, 25 },
                    { 8, 27 },
                    { 8, 28 },
                    { 8, 33 },
                    { 8, 36 },
                    { 8, 40 },
                    { 9, 7 },
                    { 9, 8 },
                    { 9, 11 },
                    { 9, 17 },
                    { 9, 19 },
                    { 9, 22 },
                    { 9, 23 },
                    { 9, 29 },
                    { 9, 42 },
                    { 9, 43 },
                    { 9, 44 },
                    { 9, 46 },
                    { 9, 49 },
                    { 10, 2 },
                    { 10, 18 },
                    { 10, 35 },
                    { 10, 41 },
                    { 10, 48 }
                });

            migrationBuilder.InsertData(
                table: "OfferOfferPlatform",
                columns: new[] { "OffersId", "PlatformsId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 5 },
                    { 4, 1 },
                    { 4, 3 },
                    { 4, 5 },
                    { 5, 2 },
                    { 5, 4 },
                    { 5, 5 },
                    { 6, 1 },
                    { 6, 3 },
                    { 6, 4 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 4 },
                    { 8, 1 },
                    { 8, 3 },
                    { 9, 2 },
                    { 9, 3 },
                    { 10, 1 },
                    { 10, 2 },
                    { 10, 4 },
                    { 11, 2 },
                    { 11, 3 },
                    { 11, 5 },
                    { 12, 1 },
                    { 12, 5 },
                    { 13, 3 },
                    { 13, 4 },
                    { 14, 1 },
                    { 14, 3 },
                    { 14, 5 },
                    { 15, 2 },
                    { 15, 4 },
                    { 16, 1 },
                    { 16, 2 },
                    { 16, 4 },
                    { 17, 3 },
                    { 17, 5 },
                    { 18, 4 },
                    { 19, 3 },
                    { 20, 2 },
                    { 20, 4 },
                    { 21, 1 },
                    { 22, 1 },
                    { 22, 2 },
                    { 23, 4 },
                    { 24, 1 },
                    { 24, 5 },
                    { 25, 1 },
                    { 25, 5 },
                    { 26, 1 },
                    { 27, 4 },
                    { 27, 5 },
                    { 28, 1 },
                    { 28, 3 },
                    { 28, 5 },
                    { 29, 1 },
                    { 29, 2 },
                    { 29, 5 },
                    { 30, 2 },
                    { 31, 1 },
                    { 32, 1 },
                    { 33, 3 },
                    { 33, 4 },
                    { 34, 3 },
                    { 35, 2 },
                    { 35, 3 },
                    { 35, 5 },
                    { 36, 1 },
                    { 36, 3 },
                    { 37, 1 },
                    { 37, 2 },
                    { 37, 3 },
                    { 38, 2 },
                    { 38, 3 },
                    { 38, 5 },
                    { 39, 1 },
                    { 39, 3 },
                    { 40, 1 },
                    { 41, 5 },
                    { 42, 1 },
                    { 42, 5 },
                    { 43, 1 },
                    { 43, 2 },
                    { 43, 5 },
                    { 44, 3 },
                    { 44, 4 },
                    { 45, 1 },
                    { 46, 1 },
                    { 46, 2 },
                    { 46, 3 },
                    { 47, 4 },
                    { 48, 1 },
                    { 48, 2 },
                    { 48, 4 },
                    { 49, 1 },
                    { 49, 5 },
                    { 50, 2 }
                });

            migrationBuilder.InsertData(
                table: "OfferOfferSharingMethod",
                columns: new[] { "OffersId", "SharingMethodsId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 5 },
                    { 3, 1 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 1 },
                    { 5, 3 },
                    { 5, 4 },
                    { 6, 5 },
                    { 7, 1 },
                    { 7, 3 },
                    { 7, 5 },
                    { 8, 5 },
                    { 9, 2 },
                    { 9, 3 },
                    { 10, 1 },
                    { 10, 3 },
                    { 10, 4 },
                    { 11, 1 },
                    { 11, 2 },
                    { 11, 3 },
                    { 12, 1 },
                    { 12, 4 },
                    { 13, 4 },
                    { 13, 5 },
                    { 14, 1 },
                    { 14, 3 },
                    { 14, 4 },
                    { 15, 3 },
                    { 15, 5 },
                    { 16, 1 },
                    { 16, 4 },
                    { 17, 3 },
                    { 17, 5 },
                    { 18, 3 },
                    { 19, 2 },
                    { 19, 3 },
                    { 19, 4 },
                    { 20, 3 },
                    { 21, 1 },
                    { 22, 2 },
                    { 22, 4 },
                    { 22, 5 },
                    { 23, 1 },
                    { 23, 3 },
                    { 24, 1 },
                    { 24, 4 },
                    { 24, 5 },
                    { 25, 1 },
                    { 25, 3 },
                    { 25, 4 },
                    { 26, 1 },
                    { 26, 3 },
                    { 27, 4 },
                    { 28, 1 },
                    { 29, 2 },
                    { 29, 4 },
                    { 30, 1 },
                    { 31, 3 },
                    { 31, 4 },
                    { 31, 5 },
                    { 32, 1 },
                    { 32, 3 },
                    { 32, 5 },
                    { 33, 2 },
                    { 33, 5 },
                    { 34, 1 },
                    { 35, 1 },
                    { 35, 4 },
                    { 36, 2 },
                    { 36, 5 },
                    { 37, 2 },
                    { 37, 5 },
                    { 38, 3 },
                    { 38, 5 },
                    { 39, 1 },
                    { 40, 2 },
                    { 40, 4 },
                    { 40, 5 },
                    { 41, 4 },
                    { 42, 1 },
                    { 42, 2 },
                    { 43, 1 },
                    { 43, 2 },
                    { 43, 4 },
                    { 44, 2 },
                    { 45, 1 },
                    { 45, 2 },
                    { 45, 4 },
                    { 46, 3 },
                    { 46, 5 },
                    { 47, 2 },
                    { 47, 4 },
                    { 48, 1 },
                    { 48, 3 },
                    { 48, 4 },
                    { 49, 1 },
                    { 49, 5 },
                    { 50, 1 }
                });

            migrationBuilder.InsertData(
                table: "SavedOffers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EmployeeId", "IsActive", "IsPublished", "IsUsed", "Notes", "OfferId", "PublishedAt", "PublishedBy", "SavedAt", "UnpublishedAt", "UnpublishedBy", "UpdatedAt", "UpdatedBy", "UsedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 17, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3642), null, null, null, null, true, true, true, "ملاحظة للمستخدم user101", 8, null, null, new DateTime(2025, 9, 17, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3642), null, null, null, null, new DateTime(2025, 9, 28, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3642), "user101" },
                    { 2, new DateTime(2025, 8, 29, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3654), null, null, null, null, true, true, true, null, 9, null, null, new DateTime(2025, 8, 29, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3654), null, null, null, null, null, "user789" },
                    { 3, new DateTime(2025, 9, 13, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3656), null, null, null, null, true, true, true, "ملاحظة للمستخدم user456", 20, null, null, new DateTime(2025, 9, 13, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3656), null, null, null, null, null, "user456" },
                    { 4, new DateTime(2025, 9, 16, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3657), null, null, null, null, true, true, false, null, 20, null, null, new DateTime(2025, 9, 16, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3657), null, null, null, null, null, "user789" },
                    { 5, new DateTime(2025, 8, 31, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3659), null, null, null, null, true, true, false, null, 3, null, null, new DateTime(2025, 8, 31, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3659), null, null, null, null, null, "user789" },
                    { 6, new DateTime(2025, 9, 19, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3662), null, null, null, null, true, true, false, null, 10, null, null, new DateTime(2025, 9, 19, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3662), null, null, null, null, null, "user789" },
                    { 7, new DateTime(2025, 8, 28, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3664), null, null, null, null, true, true, false, "ملاحظة للمستخدم user123", 27, null, null, new DateTime(2025, 8, 28, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3664), null, null, null, null, new DateTime(2025, 8, 29, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3664), "user123" },
                    { 8, new DateTime(2025, 9, 2, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3666), null, null, null, null, true, true, true, null, 40, null, null, new DateTime(2025, 9, 2, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3666), null, null, null, null, null, "user123" },
                    { 9, new DateTime(2025, 9, 16, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3667), null, null, null, null, true, true, false, null, 33, null, null, new DateTime(2025, 9, 16, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3667), null, null, null, null, null, "user456" },
                    { 10, new DateTime(2025, 8, 31, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3670), null, null, null, null, true, true, true, "ملاحظة للمستخدم user123", 22, null, null, new DateTime(2025, 8, 31, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3670), null, null, null, null, new DateTime(2025, 9, 6, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3670), "user123" },
                    { 11, new DateTime(2025, 8, 31, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3672), null, null, null, null, true, true, false, null, 4, null, null, new DateTime(2025, 8, 31, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3672), null, null, null, null, new DateTime(2025, 9, 12, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3672), "user456" },
                    { 12, new DateTime(2025, 9, 6, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3673), null, null, null, null, true, true, false, null, 26, null, null, new DateTime(2025, 9, 6, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3673), null, null, null, null, new DateTime(2025, 9, 7, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3673), "user789" },
                    { 13, new DateTime(2025, 9, 19, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3675), null, null, null, null, true, true, false, "ملاحظة للمستخدم user123", 33, null, null, new DateTime(2025, 9, 19, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3675), null, null, null, null, null, "user123" },
                    { 14, new DateTime(2025, 9, 19, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3714), null, null, null, null, true, true, true, null, 31, null, null, new DateTime(2025, 9, 19, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3714), null, null, null, null, null, "user456" },
                    { 15, new DateTime(2025, 9, 9, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3716), null, null, null, null, true, true, false, null, 27, null, null, new DateTime(2025, 9, 9, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3716), null, null, null, null, null, "user101" },
                    { 16, new DateTime(2025, 8, 26, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3717), null, null, null, null, true, true, true, "ملاحظة للمستخدم user101", 1, null, null, new DateTime(2025, 8, 26, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3717), null, null, null, null, null, "user101" },
                    { 17, new DateTime(2025, 9, 7, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3719), null, null, null, null, true, true, false, null, 6, null, null, new DateTime(2025, 9, 7, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3719), null, null, null, null, new DateTime(2025, 9, 9, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3719), "user123" },
                    { 18, new DateTime(2025, 9, 6, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3722), null, null, null, null, true, true, false, "ملاحظة للمستخدم user456", 30, null, null, new DateTime(2025, 9, 6, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3722), null, null, null, null, null, "user456" },
                    { 19, new DateTime(2025, 9, 4, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3724), null, null, null, null, true, true, false, "ملاحظة للمستخدم user101", 15, null, null, new DateTime(2025, 9, 4, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3724), null, null, null, null, new DateTime(2025, 9, 9, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3724), "user101" },
                    { 20, new DateTime(2025, 9, 14, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3726), null, null, null, null, true, true, true, null, 2, null, null, new DateTime(2025, 9, 14, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3726), null, null, null, null, new DateTime(2025, 9, 23, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3726), "user202" },
                    { 21, new DateTime(2025, 8, 23, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3728), null, null, null, null, true, true, true, null, 5, null, null, new DateTime(2025, 8, 23, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3728), null, null, null, null, new DateTime(2025, 8, 28, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3728), "user789" },
                    { 22, new DateTime(2025, 9, 20, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3729), null, null, null, null, true, true, false, null, 42, null, null, new DateTime(2025, 9, 20, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3729), null, null, null, null, null, "user101" },
                    { 23, new DateTime(2025, 8, 27, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3731), null, null, null, null, true, true, false, null, 47, null, null, new DateTime(2025, 8, 27, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3731), null, null, null, null, null, "user456" },
                    { 24, new DateTime(2025, 9, 12, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3732), null, null, null, null, true, true, true, null, 10, null, null, new DateTime(2025, 9, 12, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3732), null, null, null, null, new DateTime(2025, 9, 26, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3732), "user101" },
                    { 25, new DateTime(2025, 9, 17, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3734), null, null, null, null, true, true, true, "ملاحظة للمستخدم user202", 40, null, null, new DateTime(2025, 9, 17, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3734), null, null, null, null, new DateTime(2025, 9, 25, 10, 57, 34, 203, DateTimeKind.Utc).AddTicks(3734), "user202" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfferOfferLocation_OffersId",
                table: "OfferOfferLocation",
                column: "OffersId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferOfferPlatform_PlatformsId",
                table: "OfferOfferPlatform",
                column: "PlatformsId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferOfferSharingMethod_SharingMethodsId",
                table: "OfferOfferSharingMethod",
                column: "SharingMethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CategoryId",
                table: "Offers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_DependentId",
                table: "Offers",
                column: "DependentId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_DiscountTypeId",
                table: "Offers",
                column: "DiscountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_EmployeeId",
                table: "Offers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferShares_DependentId",
                table: "OfferShares",
                column: "DependentId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferShares_EmployeeId",
                table: "OfferShares",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferShares_OfferId",
                table: "OfferShares",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferShares_QrCodeIdentifier",
                table: "OfferShares",
                column: "QrCodeIdentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfferShares_ShareToken",
                table: "OfferShares",
                column: "ShareToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfferUsages_DependentId",
                table: "OfferUsages",
                column: "DependentId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferUsages_DependentId1",
                table: "OfferUsages",
                column: "DependentId1");

            migrationBuilder.CreateIndex(
                name: "IX_OfferUsages_EmployeeId",
                table: "OfferUsages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferUsages_EmployeeId1",
                table: "OfferUsages",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_OfferUsages_OfferId",
                table: "OfferUsages",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferUsages_OfferId_EmployeeId_DependentId_UsedAt",
                table: "OfferUsages",
                columns: new[] { "OfferId", "EmployeeId", "DependentId", "UsedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_OfferUsages_UsedAt",
                table: "OfferUsages",
                column: "UsedAt");

            migrationBuilder.CreateIndex(
                name: "IX_SavedOffers_EmployeeId",
                table: "SavedOffers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedOffers_OfferId",
                table: "SavedOffers",
                column: "OfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferOfferLocation");

            migrationBuilder.DropTable(
                name: "OfferOfferPlatform");

            migrationBuilder.DropTable(
                name: "OfferOfferSharingMethod");

            migrationBuilder.DropTable(
                name: "OfferShares");

            migrationBuilder.DropTable(
                name: "OfferUsages");

            migrationBuilder.DropTable(
                name: "SavedOffers");

            migrationBuilder.DropTable(
                name: "OfferLocations");

            migrationBuilder.DropTable(
                name: "OfferPlatforms");

            migrationBuilder.DropTable(
                name: "OfferSharingMethods");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "DiscountTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OfferCategories");
        }
    }
}
