﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EldenRingDatabase.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmmunitionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmmunitionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttackStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phy = table.Column<int>(type: "int", nullable: false),
                    Mag = table.Column<int>(type: "int", nullable: false),
                    Fire = table.Column<int>(type: "int", nullable: false),
                    Ligt = table.Column<int>(type: "int", nullable: false),
                    Holy = table.Column<int>(type: "int", nullable: false),
                    Crit = table.Column<int>(type: "int", nullable: false),
                    Sor = table.Column<int>(type: "int", nullable: true),
                    Inc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DamageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmgNegations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phy = table.Column<double>(type: "float", nullable: false),
                    VSStrike = table.Column<double>(type: "float", nullable: false),
                    VSSlash = table.Column<double>(type: "float", nullable: false),
                    VSPierce = table.Column<double>(type: "float", nullable: false),
                    Magic = table.Column<double>(type: "float", nullable: false),
                    Fire = table.Column<double>(type: "float", nullable: false),
                    Ligt = table.Column<double>(type: "float", nullable: false),
                    Holy = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmgNegations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuardStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phy = table.Column<int>(type: "int", nullable: false),
                    Mag = table.Column<int>(type: "int", nullable: false),
                    Fire = table.Column<int>(type: "int", nullable: false),
                    Ligt = table.Column<int>(type: "int", nullable: false),
                    Holy = table.Column<int>(type: "int", nullable: false),
                    Boost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuardStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MagicSpellType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MagicSpellTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicSpellType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Endurance = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Faith = table.Column<int>(type: "int", nullable: false),
                    Arcane = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resistances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Immunity = table.Column<int>(type: "int", nullable: false),
                    Robustness = table.Column<int>(type: "int", nullable: false),
                    Focus = table.Column<int>(type: "int", nullable: false),
                    Vitality = table.Column<int>(type: "int", nullable: false),
                    Poise = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resistances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scalings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Endurance = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Strength = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Dexterity = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Intelligence = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Faith = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Arcane = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scalings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShieldTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShieldTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FPCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusEffects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusEffects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talismans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TalismanEffects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    IsLegendary = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talismans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ammunitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AmmunitionTypeId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttackStatsId = table.Column<int>(type: "int", nullable: false),
                    DamageTypeId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ammunitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ammunitions_AmmunitionTypes_AmmunitionTypeId",
                        column: x => x.AmmunitionTypeId,
                        principalTable: "AmmunitionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ammunitions_AttackStats_AttackStatsId",
                        column: x => x.AttackStatsId,
                        principalTable: "AttackStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ammunitions_DamageTypes_DamageTypeId",
                        column: x => x.DamageTypeId,
                        principalTable: "DamageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ammunitions_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MagicSpells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MagicSpellTypeId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLegendary = table.Column<bool>(type: "bit", nullable: false),
                    FPCost = table.Column<int>(type: "int", nullable: false),
                    SlotUsed = table.Column<int>(type: "int", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiresId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicSpells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicSpells_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MagicSpells_MagicSpellType_MagicSpellTypeId",
                        column: x => x.MagicSpellTypeId,
                        principalTable: "MagicSpellType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MagicSpells_Requires_RequiresId",
                        column: x => x.RequiresId,
                        principalTable: "Requires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmorStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DmgNegationId = table.Column<int>(type: "int", nullable: false),
                    ResistanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmorStats_DmgNegations_DmgNegationId",
                        column: x => x.DmgNegationId,
                        principalTable: "DmgNegations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmorStats_Resistances_ResistanceId",
                        column: x => x.ResistanceId,
                        principalTable: "Resistances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttackStatsId = table.Column<int>(type: "int", nullable: false),
                    GuardStatsId = table.Column<int>(type: "int", nullable: false),
                    ScalingId = table.Column<int>(type: "int", nullable: false),
                    RequiresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_AttackStats_AttackStatsId",
                        column: x => x.AttackStatsId,
                        principalTable: "AttackStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stats_GuardStats_GuardStatsId",
                        column: x => x.GuardStatsId,
                        principalTable: "GuardStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stats_Requires_RequiresId",
                        column: x => x.RequiresId,
                        principalTable: "Requires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stats_Scalings_ScalingId",
                        column: x => x.ScalingId,
                        principalTable: "Scalings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChestArmors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmorStatsId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChestArmors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChestArmors_ArmorStats_ArmorStatsId",
                        column: x => x.ArmorStatsId,
                        principalTable: "ArmorStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gauntlets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmorStatsId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gauntlets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gauntlets_ArmorStats_ArmorStatsId",
                        column: x => x.ArmorStatsId,
                        principalTable: "ArmorStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Helms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmorStatsId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Helms_ArmorStats_ArmorStatsId",
                        column: x => x.ArmorStatsId,
                        principalTable: "ArmorStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegArmor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmorStatsId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegArmor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegArmor_ArmorStats_ArmorStatsId",
                        column: x => x.ArmorStatsId,
                        principalTable: "ArmorStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShieldTypeId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatsId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    DamageTypeId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shields_DamageTypes_DamageTypeId",
                        column: x => x.DamageTypeId,
                        principalTable: "DamageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shields_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shields_ShieldTypes_ShieldTypeId",
                        column: x => x.ShieldTypeId,
                        principalTable: "ShieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shields_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shields_Stats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "Stats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WeaponTypeId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    StatsId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    StatusEffectId = table.Column<int>(type: "int", nullable: false),
                    IsLegendary = table.Column<bool>(type: "bit", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weapons_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weapons_Stats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "Stats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Weapons_StatusEffects_StatusEffectId",
                        column: x => x.StatusEffectId,
                        principalTable: "StatusEffects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weapons_WeaponTypes_WeaponTypeId",
                        column: x => x.WeaponTypeId,
                        principalTable: "WeaponTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArmorSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    ArmorStatsId = table.Column<int>(type: "int", nullable: false),
                    HelmId = table.Column<int>(type: "int", nullable: false),
                    ChestArmorId = table.Column<int>(type: "int", nullable: false),
                    GauntletsId = table.Column<int>(type: "int", nullable: false),
                    LegArmorId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmorSets_ArmorStats_ArmorStatsId",
                        column: x => x.ArmorStatsId,
                        principalTable: "ArmorStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmorSets_ChestArmors_ChestArmorId",
                        column: x => x.ChestArmorId,
                        principalTable: "ChestArmors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArmorSets_Gauntlets_GauntletsId",
                        column: x => x.GauntletsId,
                        principalTable: "Gauntlets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArmorSets_Helms_HelmId",
                        column: x => x.HelmId,
                        principalTable: "Helms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArmorSets_LegArmor_LegArmorId",
                        column: x => x.LegArmorId,
                        principalTable: "LegArmor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DamageTypeWeapon",
                columns: table => new
                {
                    DamageTypesId = table.Column<int>(type: "int", nullable: false),
                    WeaponsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageTypeWeapon", x => new { x.DamageTypesId, x.WeaponsId });
                    table.ForeignKey(
                        name: "FK_DamageTypeWeapon_DamageTypes_DamageTypesId",
                        column: x => x.DamageTypesId,
                        principalTable: "DamageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DamageTypeWeapon_Weapons_WeaponsId",
                        column: x => x.WeaponsId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RuneLevel = table.Column<int>(type: "int", nullable: false),
                    Vigor = table.Column<int>(type: "int", nullable: false),
                    Mind = table.Column<int>(type: "int", nullable: false),
                    Endurance = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Faith = table.Column<int>(type: "int", nullable: false),
                    Arcane = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    ArmorSetId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterClasses_ArmorSets_ArmorSetId",
                        column: x => x.ArmorSetId,
                        principalTable: "ArmorSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterClasses_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ammunitions_AmmunitionTypeId",
                table: "Ammunitions",
                column: "AmmunitionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ammunitions_AttackStatsId",
                table: "Ammunitions",
                column: "AttackStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ammunitions_DamageTypeId",
                table: "Ammunitions",
                column: "DamageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ammunitions_EquipmentId",
                table: "Ammunitions",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmorSets_ArmorStatsId",
                table: "ArmorSets",
                column: "ArmorStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmorSets_ChestArmorId",
                table: "ArmorSets",
                column: "ChestArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmorSets_GauntletsId",
                table: "ArmorSets",
                column: "GauntletsId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmorSets_HelmId",
                table: "ArmorSets",
                column: "HelmId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmorSets_LegArmorId",
                table: "ArmorSets",
                column: "LegArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmorStats_DmgNegationId",
                table: "ArmorStats",
                column: "DmgNegationId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmorStats_ResistanceId",
                table: "ArmorStats",
                column: "ResistanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClasses_ArmorSetId",
                table: "CharacterClasses",
                column: "ArmorSetId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClasses_EquipmentId",
                table: "CharacterClasses",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ChestArmors_ArmorStatsId",
                table: "ChestArmors",
                column: "ArmorStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageTypeWeapon_WeaponsId",
                table: "DamageTypeWeapon",
                column: "WeaponsId");

            migrationBuilder.CreateIndex(
                name: "IX_Gauntlets_ArmorStatsId",
                table: "Gauntlets",
                column: "ArmorStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Helms_ArmorStatsId",
                table: "Helms",
                column: "ArmorStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_LegArmor_ArmorStatsId",
                table: "LegArmor",
                column: "ArmorStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicSpells_EquipmentId",
                table: "MagicSpells",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicSpells_MagicSpellTypeId",
                table: "MagicSpells",
                column: "MagicSpellTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicSpells_RequiresId",
                table: "MagicSpells",
                column: "RequiresId");

            migrationBuilder.CreateIndex(
                name: "IX_Shields_DamageTypeId",
                table: "Shields",
                column: "DamageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shields_EquipmentId",
                table: "Shields",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Shields_ShieldTypeId",
                table: "Shields",
                column: "ShieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shields_SkillId",
                table: "Shields",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Shields_StatsId",
                table: "Shields",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_AttackStatsId",
                table: "Stats",
                column: "AttackStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_GuardStatsId",
                table: "Stats",
                column: "GuardStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_RequiresId",
                table: "Stats",
                column: "RequiresId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_ScalingId",
                table: "Stats",
                column: "ScalingId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_EquipmentId",
                table: "Weapons",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_SkillId",
                table: "Weapons",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_StatsId",
                table: "Weapons",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_StatusEffectId",
                table: "Weapons",
                column: "StatusEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_WeaponTypeId",
                table: "Weapons",
                column: "WeaponTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ammunitions");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CharacterClasses");

            migrationBuilder.DropTable(
                name: "DamageTypeWeapon");

            migrationBuilder.DropTable(
                name: "MagicSpells");

            migrationBuilder.DropTable(
                name: "Shields");

            migrationBuilder.DropTable(
                name: "Talismans");

            migrationBuilder.DropTable(
                name: "AmmunitionTypes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ArmorSets");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "MagicSpellType");

            migrationBuilder.DropTable(
                name: "DamageTypes");

            migrationBuilder.DropTable(
                name: "ShieldTypes");

            migrationBuilder.DropTable(
                name: "ChestArmors");

            migrationBuilder.DropTable(
                name: "Gauntlets");

            migrationBuilder.DropTable(
                name: "Helms");

            migrationBuilder.DropTable(
                name: "LegArmor");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "StatusEffects");

            migrationBuilder.DropTable(
                name: "WeaponTypes");

            migrationBuilder.DropTable(
                name: "ArmorStats");

            migrationBuilder.DropTable(
                name: "AttackStats");

            migrationBuilder.DropTable(
                name: "GuardStats");

            migrationBuilder.DropTable(
                name: "Requires");

            migrationBuilder.DropTable(
                name: "Scalings");

            migrationBuilder.DropTable(
                name: "DmgNegations");

            migrationBuilder.DropTable(
                name: "Resistances");
        }
    }
}
