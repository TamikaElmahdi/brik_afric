using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionCommerciale.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Ice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deviss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Montant = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deviss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: false),
                    Societe = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SousCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(nullable: false),
                    IdCategorie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SousCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SousCategories_Categories_IdCategorie",
                        column: x => x.IdCategorie,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModePayement = table.Column<string>(nullable: true),
                    NumCheque = table.Column<string>(nullable: true),
                    Credit = table.Column<decimal>(nullable: false),
                    Avance = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    NomClient = table.Column<string>(nullable: false),
                    IdClient = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commandes_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Achats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFournisseur = table.Column<int>(nullable: false),
                    Montant = table.Column<decimal>(nullable: false),
                    ModePayement = table.Column<string>(nullable: false),
                    NumCheque = table.Column<string>(nullable: true),
                    Credit = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Avance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achats_Fournisseurs_IdFournisseur",
                        column: x => x.IdFournisseur,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomComplete = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    IdRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    TitreFr = table.Column<string>(nullable: false),
                    TitreAr = table.Column<string>(nullable: false),
                    EmplacementMagasin = table.Column<string>(nullable: true),
                    EmplacementDepot = table.Column<string>(nullable: true),
                    DateDernierAchat = table.Column<DateTime>(nullable: false),
                    PrixUnitaire = table.Column<decimal>(nullable: false),
                    QteStock = table.Column<decimal>(nullable: false),
                    StockMin = table.Column<decimal>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Unite = table.Column<string>(nullable: true),
                    Constructeur = table.Column<string>(nullable: true),
                    BestSell = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IdSousCategorie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_SousCategories_IdSousCategorie",
                        column: x => x.IdSousCategorie,
                        principalTable: "SousCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailCmds",
                columns: table => new
                {
                    IdArticle = table.Column<int>(nullable: false),
                    IdCommande = table.Column<int>(nullable: false),
                    PrixVente = table.Column<decimal>(nullable: false),
                    QtePrise = table.Column<decimal>(nullable: false),
                    Remise = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailCmds", x => new { x.IdArticle, x.IdCommande });
                    table.ForeignKey(
                        name: "FK_DetailCmds_Articles_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailCmds_Commandes_IdCommande",
                        column: x => x.IdCommande,
                        principalTable: "Commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DevisAcrticles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qte = table.Column<decimal>(nullable: false),
                    Pu = table.Column<decimal>(nullable: false),
                    Remise = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    IdArticle = table.Column<int>(nullable: false),
                    IdDevis = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevisAcrticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevisAcrticles_Articles_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevisAcrticles_Deviss_IdDevis",
                        column: x => x.IdDevis,
                        principalTable: "Deviss",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fournitures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArticle = table.Column<int>(nullable: false),
                    IdFournisseur = table.Column<int>(nullable: false),
                    Qte = table.Column<decimal>(nullable: false),
                    PrixAchat = table.Column<decimal>(nullable: false),
                    DateAchat = table.Column<DateTime>(nullable: false),
                    IdAchat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournitures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fournitures_Achats_IdAchat",
                        column: x => x.IdAchat,
                        principalTable: "Achats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fournitures_Articles_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fournitures_Fournisseurs_IdFournisseur",
                        column: x => x.IdFournisseur,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Libelle" },
                values: new object[,]
                {
                    { 1, "plombie" },
                    { 2, "electricite" },
                    { 3, "quincaillerie" },
                    { 4, "peinture" },
                    { 5, "divers" },
                    { 6, "outillage" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[,]
                {
                    { 21, null, null, "", "Alice", null, "(+212)6 93 42-13-43" },
                    { 20, null, null, "", "Théo", null, "(+212)6 55 92-19-61" },
                    { 19, null, null, "", "Victor", null, "(+212)6 50 76-78-80" },
                    { 18, null, null, "", "Mael", null, "(+212)6 78 57-00-38" },
                    { 17, null, null, "", "Anaïs", null, "(+212)6 95 19-51-17" },
                    { 16, null, null, "", "Louna", null, "(+212)6 39 14-60-51" },
                    { 15, null, null, "", "Mathéo", null, "(+212)6 29 32-08-15" },
                    { 14, null, null, "", "Romane", null, "(+212)6 05 27-12-04" },
                    { 13, null, null, "", "Alice", null, "(+212)6 37 58-37-49" },
                    { 12, null, null, "", "Thomas", null, "(+212)6 56 91-44-13" },
                    { 11, null, null, "", "Victor", null, "(+212)6 45 79-18-80" },
                    { 10, null, null, "", "Maxence", null, "(+212)6 06 97-44-54" },
                    { 9, null, null, "", "Alicia", null, "(+212)6 95 18-81-15" },
                    { 8, null, null, "", "Tom", null, "(+212)6 37 16-65-96" },
                    { 7, null, null, "", "Manon", null, "(+212)6 64 04-37-03" },
                    { 6, null, null, "", "Célia", null, "(+212)6 26 64-11-24" },
                    { 5, null, null, "", "Victor", null, "(+212)6 00 72-29-37" },
                    { 4, null, null, "", "Mathilde", null, "(+212)6 01 87-90-08" },
                    { 3, null, null, "", "Anaïs", null, "(+212)6 73 72-98-80" },
                    { 2, null, null, "", "Baptiste", null, "(+212)6 41 77-33-60" },
                    { 1, null, null, "00", "Client caisse 1", null, "00" }
                });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Nom", "Prenom", "Societe", "Telephone" },
                values: new object[,]
                {
                    { 1, "Anaïs", "Schneider", "Dupuis SCOP", "(+212)6 59 59-54-09" },
                    { 2, "Romain", "Menard", "Paris GIE", "(+212)6 97 01-48-97" },
                    { 3, "Clara", "Moulin", "Chevalier, Deschamps and Moreau", "(+212)6 86 79-75-01" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Commercial" },
                    { 2, "Manager" },
                    { 3, "Administrateur" }
                });

            migrationBuilder.InsertData(
                table: "Achats",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdFournisseur", "ModePayement", "Montant", "NumCheque" },
                values: new object[,]
                {
                    { 9, 0m, 0m, new DateTime(2020, 7, 19, 23, 22, 56, 134, DateTimeKind.Local).AddTicks(4863), 3, "crédit", 8000m, "" },
                    { 4, 0m, 0m, new DateTime(2020, 5, 7, 15, 29, 29, 889, DateTimeKind.Local).AddTicks(731), 1, "crédit", 2987m, "" },
                    { 6, 0m, 0m, new DateTime(2020, 2, 28, 20, 16, 18, 472, DateTimeKind.Local).AddTicks(7475), 1, "éspece", 8460m, "" },
                    { 10, 0m, 0m, new DateTime(2020, 9, 3, 18, 28, 39, 579, DateTimeKind.Local).AddTicks(311), 2, "éspece", 50616m, "" },
                    { 1, 0m, 0m, new DateTime(2020, 3, 22, 0, 7, 36, 55, DateTimeKind.Local).AddTicks(9805), 3, "chèque", 26748m, "" },
                    { 2, 0m, 0m, new DateTime(2020, 1, 8, 5, 6, 15, 214, DateTimeKind.Local).AddTicks(6383), 1, "crédit", 47908m, "" },
                    { 5, 0m, 0m, new DateTime(2020, 2, 10, 3, 1, 30, 629, DateTimeKind.Local).AddTicks(1604), 3, "éspece", 1767m, "" },
                    { 7, 0m, 0m, new DateTime(2020, 5, 16, 20, 41, 24, 706, DateTimeKind.Local).AddTicks(4612), 3, "crédit", 1840m, "" },
                    { 8, 0m, 0m, new DateTime(2020, 11, 16, 0, 12, 55, 221, DateTimeKind.Local).AddTicks(9421), 3, "chèque", 44330m, "" },
                    { 3, 0m, 0m, new DateTime(2020, 4, 6, 7, 34, 1, 619, DateTimeKind.Local).AddTicks(9402), 3, "chèque", 94560m, "" }
                });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[,]
                {
                    { 12, 0m, 0m, new DateTime(2020, 5, 21, 21, 34, 9, 214, DateTimeKind.Local).AddTicks(4864), 2, "éspece", "", "", "00:00", 18216m },
                    { 1, 0m, 0m, new DateTime(2020, 4, 30, 20, 13, 30, 984, DateTimeKind.Local).AddTicks(7222), 1, "éspece", "", "", "00:00", 14860m },
                    { 2, 0m, 0m, new DateTime(2020, 8, 29, 15, 41, 22, 692, DateTimeKind.Local).AddTicks(3105), 1, "éspece", "", "", "00:00", 2312m },
                    { 3, 0m, 0m, new DateTime(2020, 3, 4, 7, 18, 50, 540, DateTimeKind.Local).AddTicks(4942), 1, "chèque", "", "", "00:00", 16647m },
                    { 4, 0m, 0m, new DateTime(2020, 2, 22, 7, 55, 34, 645, DateTimeKind.Local).AddTicks(8203), 1, "crédit", "", "", "00:00", 7840m },
                    { 5, 0m, 0m, new DateTime(2020, 10, 12, 11, 28, 30, 613, DateTimeKind.Local).AddTicks(5032), 1, "éspece", "", "", "00:00", 15536m },
                    { 15, 0m, 0m, new DateTime(2020, 11, 1, 21, 32, 32, 263, DateTimeKind.Local).AddTicks(911), 1, "chèque", "", "", "00:00", 48459m },
                    { 10, 0m, 0m, new DateTime(2019, 11, 25, 19, 33, 33, 957, DateTimeKind.Local).AddTicks(3284), 2, "éspece", "", "", "00:00", 15100m },
                    { 11, 0m, 0m, new DateTime(2020, 7, 2, 5, 58, 5, 333, DateTimeKind.Local).AddTicks(2180), 2, "chèque", "", "", "00:00", 85914m },
                    { 14, 0m, 0m, new DateTime(2019, 12, 20, 20, 27, 2, 702, DateTimeKind.Local).AddTicks(4682), 2, "éspece", "", "", "00:00", 66780m },
                    { 6, 0m, 0m, new DateTime(2019, 12, 31, 8, 11, 14, 679, DateTimeKind.Local).AddTicks(7885), 3, "éspece", "", "", "00:00", 59422m },
                    { 19, 0m, 0m, new DateTime(2020, 2, 4, 19, 4, 51, 745, DateTimeKind.Local).AddTicks(5867), 2, "éspece", "", "", "00:00", 45694m },
                    { 7, 0m, 0m, new DateTime(2020, 1, 27, 1, 57, 59, 109, DateTimeKind.Local).AddTicks(1587), 3, "éspece", "", "", "00:00", 41971m },
                    { 8, 0m, 0m, new DateTime(2020, 2, 9, 5, 56, 7, 954, DateTimeKind.Local).AddTicks(9771), 3, "chèque", "", "", "00:00", 21526m },
                    { 9, 0m, 0m, new DateTime(2020, 11, 14, 1, 49, 28, 165, DateTimeKind.Local).AddTicks(7218), 3, "crédit", "", "", "00:00", 52536m },
                    { 13, 0m, 0m, new DateTime(2020, 10, 11, 13, 19, 38, 781, DateTimeKind.Local).AddTicks(6025), 3, "chèque", "", "", "00:00", 19588m },
                    { 16, 0m, 0m, new DateTime(2020, 9, 27, 5, 32, 8, 420, DateTimeKind.Local).AddTicks(1171), 3, "crédit", "", "", "00:00", 1684m },
                    { 17, 0m, 0m, new DateTime(2019, 12, 24, 19, 22, 18, 932, DateTimeKind.Local).AddTicks(1824), 3, "éspece", "", "", "00:00", 97000m },
                    { 20, 0m, 0m, new DateTime(2020, 9, 7, 3, 21, 3, 846, DateTimeKind.Local).AddTicks(745), 3, "chèque", "", "", "00:00", 40425m },
                    { 18, 0m, 0m, new DateTime(2019, 12, 11, 17, 44, 22, 415, DateTimeKind.Local).AddTicks(6333), 2, "chèque", "", "", "00:00", 13120m }
                });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[,]
                {
                    { 23, 6, "Juliette" },
                    { 41, 6, "Maëlle" },
                    { 40, 6, "Tom" },
                    { 39, 6, "Jade" },
                    { 25, 6, "Zoe" },
                    { 1, 1, "Generale" },
                    { 15, 6, "Lou" },
                    { 5, 6, "Mathéo" },
                    { 17, 2, "Gabriel" },
                    { 13, 2, "Jeanne" },
                    { 11, 2, "Alexandre" },
                    { 8, 2, "Manon" },
                    { 3, 2, "Evan" },
                    { 38, 1, "Mélissa" },
                    { 22, 2, "Océane" },
                    { 34, 1, "Pierre" },
                    { 31, 1, "Louna" },
                    { 30, 1, "Paul" },
                    { 21, 1, "Tom" },
                    { 10, 1, "Yanis" },
                    { 9, 1, "Justine" },
                    { 2, 1, "Léo" },
                    { 33, 1, "Emilie" },
                    { 12, 6, "Louis" },
                    { 29, 2, "Victor" },
                    { 36, 2, "Romane" },
                    { 37, 5, "Zoe" },
                    { 35, 5, "Célia" },
                    { 27, 5, "Yanis" },
                    { 26, 5, "Maxence" },
                    { 19, 5, "Lucie" },
                    { 18, 5, "Lucie" },
                    { 32, 2, "Lucie" },
                    { 16, 5, "Mathis" },
                    { 28, 3, "Maeva" },
                    { 24, 3, "Arthur" },
                    { 20, 3, "Evan" },
                    { 14, 3, "Adam" },
                    { 7, 3, "Noa" },
                    { 4, 3, "Mael" },
                    { 6, 4, "Zoe" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IdRole", "NomComplete", "Password", "Tel" },
                values: new object[] { 1, "admin@angular.io", 3, "admin", "123", "" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[,]
                {
                    { 12, false, "Code-12", "Constructeur1", new DateTime(2020, 3, 14, 17, 39, 23, 42, DateTimeKind.Local).AddTicks(9293), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 597m, -250m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-12", "titre long pour un produit avec la nature de super hasardouze-12", "L" },
                    { 9, false, "Code-9", "Constructeur2", new DateTime(2020, 3, 9, 11, 13, 43, 358, DateTimeKind.Local).AddTicks(3710), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 563m, 0m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-9", "titre long pour un produit avec la nature de super hasardouze-9", "L" },
                    { 100, false, "Code-100", "Constructeur3", new DateTime(2019, 12, 5, 15, 18, 54, 719, DateTimeKind.Local).AddTicks(7012), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 582m, -225m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-100", "titre long pour un produit avec la nature de super hasardouze-100", "Kg" },
                    { 99, true, "Code-99", "Constructeur3", new DateTime(2020, 3, 30, 23, 36, 40, 93, DateTimeKind.Local).AddTicks(1895), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 230m, -248m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-99", "titre long pour un produit avec la nature de super hasardouze-99", "U" },
                    { 96, false, "Code-96", "Constructeur3", new DateTime(2020, 7, 12, 1, 45, 46, 457, DateTimeKind.Local).AddTicks(4126), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 893m, -422m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-96", "titre long pour un produit avec la nature de super hasardouze-96", "Kg" },
                    { 88, false, "Code-88", "Constructeur2", new DateTime(2020, 7, 18, 17, 16, 35, 590, DateTimeKind.Local).AddTicks(5993), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 160m, -299m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-88", "titre long pour un produit avec la nature de super hasardouze-88", "Kg" },
                    { 80, false, "Code-80", "Constructeur2", new DateTime(2020, 1, 11, 22, 40, 26, 270, DateTimeKind.Local).AddTicks(6106), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 742m, -540m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-80", "titre long pour un produit avec la nature de super hasardouze-80", "L" },
                    { 65, false, "Code-65", "Constructeur1", new DateTime(2020, 9, 25, 16, 7, 9, 126, DateTimeKind.Local).AddTicks(4131), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 478m, -71m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-65", "titre long pour un produit avec la nature de super hasardouze-65", "U" },
                    { 62, false, "Code-62", "Constructeur2", new DateTime(2020, 7, 9, 8, 20, 5, 257, DateTimeKind.Local).AddTicks(8840), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 842m, -407m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-62", "titre long pour un produit avec la nature de super hasardouze-62", "L" },
                    { 50, false, "Code-50", "Constructeur3", new DateTime(2019, 12, 20, 22, 19, 18, 88, DateTimeKind.Local).AddTicks(3919), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 608m, -50m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-50", "titre long pour un produit avec la nature de super hasardouze-50", "U" },
                    { 45, false, "Code-45", "Constructeur2", new DateTime(2020, 7, 10, 16, 20, 53, 33, DateTimeKind.Local).AddTicks(5519), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 211m, -301m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-45", "titre long pour un produit avec la nature de super hasardouze-45", "L" },
                    { 41, false, "Code-41", "Constructeur3", new DateTime(2020, 5, 5, 11, 41, 49, 680, DateTimeKind.Local).AddTicks(3054), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 624m, 48m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-41", "titre long pour un produit avec la nature de super hasardouze-41", "U" },
                    { 26, false, "Code-26", "Constructeur2", new DateTime(2020, 4, 28, 10, 23, 41, 336, DateTimeKind.Local).AddTicks(4311), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 800m, -164m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-26", "titre long pour un produit avec la nature de super hasardouze-26", "Kg" },
                    { 21, false, "Code-21", "Constructeur3", new DateTime(2020, 7, 3, 4, 57, 43, 282, DateTimeKind.Local).AddTicks(2162), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 488m, -269m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-21", "titre long pour un produit avec la nature de super hasardouze-21", "U" },
                    { 20, false, "Code-20", "Constructeur1", new DateTime(2020, 10, 22, 23, 16, 12, 212, DateTimeKind.Local).AddTicks(2610), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 180m, -83m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-20", "titre long pour un produit avec la nature de super hasardouze-20", "L" },
                    { 11, false, "Code-11", "Constructeur3", new DateTime(2020, 3, 20, 14, 30, 44, 656, DateTimeKind.Local).AddTicks(2769), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 355m, -291m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-11", "titre long pour un produit avec la nature de super hasardouze-11", "L" },
                    { 7, false, "Code-7", "Constructeur3", new DateTime(2020, 9, 9, 2, 52, 36, 608, DateTimeKind.Local).AddTicks(631), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 282m, -209m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-7", "titre long pour un produit avec la nature de super hasardouze-7", "U" },
                    { 2, false, "Code-2", "Constructeur2", new DateTime(2020, 5, 13, 14, 15, 38, 760, DateTimeKind.Local).AddTicks(6470), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 415m, -150m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-2", "titre long pour un produit avec la nature de super hasardouze-2", "U" },
                    { 92, false, "Code-92", "Constructeur3", new DateTime(2020, 7, 19, 4, 38, 7, 103, DateTimeKind.Local).AddTicks(5219), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 703m, -367m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-92", "titre long pour un produit avec la nature de super hasardouze-92", "Kg" },
                    { 79, false, "Code-79", "Constructeur1", new DateTime(2020, 6, 30, 6, 6, 43, 955, DateTimeKind.Local).AddTicks(5948), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 803m, -407m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-79", "titre long pour un produit avec la nature de super hasardouze-79", "L" },
                    { 77, false, "Code-77", "Constructeur2", new DateTime(2020, 4, 5, 7, 44, 12, 40, DateTimeKind.Local).AddTicks(3125), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 100m, -107m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-77", "titre long pour un produit avec la nature de super hasardouze-77", "Kg" },
                    { 76, false, "Code-76", "Constructeur1", new DateTime(2020, 4, 7, 11, 19, 49, 605, DateTimeKind.Local).AddTicks(3084), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 790m, -150m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-76", "titre long pour un produit avec la nature de super hasardouze-76", "Kg" },
                    { 16, false, "Code-16", "Constructeur2", new DateTime(2020, 10, 31, 8, 9, 21, 38, DateTimeKind.Local).AddTicks(5656), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 625m, -177m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-16", "titre long pour un produit avec la nature de super hasardouze-16", "Kg" },
                    { 75, false, "Code-75", "Constructeur1", new DateTime(2020, 10, 5, 12, 31, 15, 512, DateTimeKind.Local).AddTicks(2586), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 971m, -70m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-75", "titre long pour un produit avec la nature de super hasardouze-75", "L" },
                    { 18, false, "Code-18", "Constructeur2", new DateTime(2020, 1, 14, 20, 28, 37, 709, DateTimeKind.Local).AddTicks(8824), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 869m, -364m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-18", "titre long pour un produit avec la nature de super hasardouze-18", "U" },
                    { 25, false, "Code-25", "Constructeur1", new DateTime(2020, 7, 4, 17, 59, 47, 781, DateTimeKind.Local).AddTicks(5695), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 825m, 79m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-25", "titre long pour un produit avec la nature de super hasardouze-25", "U" },
                    { 33, false, "Code-33", "Constructeur1", new DateTime(2020, 7, 1, 3, 3, 22, 123, DateTimeKind.Local).AddTicks(6126), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 396m, -93m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-33", "titre long pour un produit avec la nature de super hasardouze-33", "U" },
                    { 15, false, "Code-15", "Constructeur2", new DateTime(2020, 2, 7, 4, 45, 38, 27, DateTimeKind.Local).AddTicks(3688), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 488m, -188m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-15", "titre long pour un produit avec la nature de super hasardouze-15", "U" },
                    { 3, false, "Code-3", "Constructeur1", new DateTime(2020, 5, 13, 17, 1, 41, 681, DateTimeKind.Local).AddTicks(6273), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 225m, -130m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-3", "titre long pour un produit avec la nature de super hasardouze-3", "L" },
                    { 94, false, "Code-94", "Constructeur2", new DateTime(2020, 3, 13, 0, 37, 45, 210, DateTimeKind.Local).AddTicks(3059), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 224m, -268m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-94", "titre long pour un produit avec la nature de super hasardouze-94", "L" },
                    { 72, false, "Code-72", "Constructeur2", new DateTime(2020, 1, 1, 10, 35, 14, 99, DateTimeKind.Local).AddTicks(7629), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 503m, -64m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-72", "titre long pour un produit avec la nature de super hasardouze-72", "Kg" },
                    { 63, false, "Code-63", "Constructeur1", new DateTime(2020, 6, 26, 2, 30, 18, 169, DateTimeKind.Local).AddTicks(8183), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 931m, 88m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-63", "titre long pour un produit avec la nature de super hasardouze-63", "U" },
                    { 47, false, "Code-47", "Constructeur3", new DateTime(2020, 6, 18, 5, 50, 3, 883, DateTimeKind.Local).AddTicks(5293), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 308m, -291m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-47", "titre long pour un produit avec la nature de super hasardouze-47", "Kg" },
                    { 43, false, "Code-43", "Constructeur1", new DateTime(2020, 4, 28, 20, 23, 26, 988, DateTimeKind.Local).AddTicks(6949), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 550m, -120m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-43", "titre long pour un produit avec la nature de super hasardouze-43", "Kg" },
                    { 35, false, "Code-35", "Constructeur2", new DateTime(2020, 4, 29, 20, 13, 50, 968, DateTimeKind.Local).AddTicks(3630), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 961m, -253m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-35", "titre long pour un produit avec la nature de super hasardouze-35", "L" },
                    { 29, false, "Code-29", "Constructeur1", new DateTime(2020, 2, 29, 18, 45, 55, 156, DateTimeKind.Local).AddTicks(595), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 93m, -174m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-29", "titre long pour un produit avec la nature de super hasardouze-29", "Kg" },
                    { 6, false, "Code-6", "Constructeur3", new DateTime(2020, 6, 3, 7, 19, 41, 41, DateTimeKind.Local).AddTicks(2095), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 698m, -208m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-6", "titre long pour un produit avec la nature de super hasardouze-6", "Kg" },
                    { 1, false, "Code-1", "Constructeur1", new DateTime(2020, 3, 22, 3, 17, 45, 486, DateTimeKind.Local).AddTicks(7322), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 898m, -25m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-1", "titre long pour un produit avec la nature de super hasardouze-1", "L" },
                    { 97, true, "Code-97", "Constructeur3", new DateTime(2019, 12, 21, 0, 40, 52, 69, DateTimeKind.Local).AddTicks(6023), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 788m, -147m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-97", "titre long pour un produit avec la nature de super hasardouze-97", "U" },
                    { 90, false, "Code-90", "Constructeur1", new DateTime(2020, 1, 26, 22, 49, 0, 878, DateTimeKind.Local).AddTicks(4412), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 414m, -41m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-90", "titre long pour un produit avec la nature de super hasardouze-90", "Kg" },
                    { 74, false, "Code-74", "Constructeur1", new DateTime(2020, 6, 11, 20, 7, 26, 279, DateTimeKind.Local).AddTicks(2806), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 34m, -232m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-74", "titre long pour un produit avec la nature de super hasardouze-74", "L" },
                    { 71, false, "Code-71", "Constructeur1", new DateTime(2020, 7, 10, 20, 31, 2, 29, DateTimeKind.Local).AddTicks(7594), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 83m, -127m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-71", "titre long pour un produit avec la nature de super hasardouze-71", "Kg" },
                    { 42, false, "Code-42", "Constructeur2", new DateTime(2020, 2, 29, 23, 11, 49, 444, DateTimeKind.Local).AddTicks(6658), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 1000m, -369m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-42", "titre long pour un produit avec la nature de super hasardouze-42", "U" },
                    { 40, false, "Code-40", "Constructeur3", new DateTime(2020, 7, 21, 8, 18, 44, 152, DateTimeKind.Local).AddTicks(2285), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 872m, -197m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-40", "titre long pour un produit avec la nature de super hasardouze-40", "Kg" },
                    { 38, false, "Code-38", "Constructeur1", new DateTime(2020, 6, 12, 5, 30, 43, 600, DateTimeKind.Local).AddTicks(6248), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 598m, -381m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-38", "titre long pour un produit avec la nature de super hasardouze-38", "Kg" },
                    { 37, false, "Code-37", "Constructeur2", new DateTime(2020, 9, 2, 19, 31, 10, 617, DateTimeKind.Local).AddTicks(2523), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 548m, -295m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-37", "titre long pour un produit avec la nature de super hasardouze-37", "Kg" },
                    { 28, false, "Code-28", "Constructeur1", new DateTime(2020, 1, 14, 22, 52, 10, 436, DateTimeKind.Local).AddTicks(1337), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 520m, -196m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-28", "titre long pour un produit avec la nature de super hasardouze-28", "L" },
                    { 23, false, "Code-23", "Constructeur2", new DateTime(2020, 10, 28, 0, 58, 49, 559, DateTimeKind.Local).AddTicks(4736), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 647m, -16m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-23", "titre long pour un produit avec la nature de super hasardouze-23", "Kg" },
                    { 73, false, "Code-73", "Constructeur1", new DateTime(2020, 9, 18, 0, 54, 34, 654, DateTimeKind.Local).AddTicks(3182), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 477m, -314m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-73", "titre long pour un produit avec la nature de super hasardouze-73", "Kg" },
                    { 32, false, "Code-32", "Constructeur1", new DateTime(2020, 4, 29, 12, 47, 5, 306, DateTimeKind.Local).AddTicks(1417), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 392m, -377m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-32", "titre long pour un produit avec la nature de super hasardouze-32", "U" },
                    { 14, false, "Code-14", "Constructeur3", new DateTime(2020, 8, 22, 7, 18, 14, 843, DateTimeKind.Local).AddTicks(8898), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 103m, -359m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-14", "titre long pour un produit avec la nature de super hasardouze-14", "L" },
                    { 8, false, "Code-8", "Constructeur2", new DateTime(2020, 3, 5, 7, 52, 22, 826, DateTimeKind.Local).AddTicks(8279), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 632m, -586m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-8", "titre long pour un produit avec la nature de super hasardouze-8", "Kg" },
                    { 93, true, "Code-93", "Constructeur2", new DateTime(2019, 12, 21, 17, 39, 13, 417, DateTimeKind.Local).AddTicks(1517), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 36m, -203m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-93", "titre long pour un produit avec la nature de super hasardouze-93", "L" },
                    { 87, true, "Code-87", "Constructeur3", new DateTime(2020, 1, 2, 21, 37, 36, 924, DateTimeKind.Local).AddTicks(3672), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 413m, -241m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-87", "titre long pour un produit avec la nature de super hasardouze-87", "L" },
                    { 78, false, "Code-78", "Constructeur3", new DateTime(2020, 6, 6, 6, 58, 56, 442, DateTimeKind.Local).AddTicks(1661), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 985m, -72m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-78", "titre long pour un produit avec la nature de super hasardouze-78", "Kg" },
                    { 70, false, "Code-70", "Constructeur2", new DateTime(2020, 4, 7, 4, 54, 24, 671, DateTimeKind.Local).AddTicks(2234), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 812m, -204m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-70", "titre long pour un produit avec la nature de super hasardouze-70", "U" },
                    { 52, false, "Code-52", "Constructeur2", new DateTime(2020, 7, 18, 19, 27, 1, 542, DateTimeKind.Local).AddTicks(6023), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 53m, -56m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-52", "titre long pour un produit avec la nature de super hasardouze-52", "L" },
                    { 46, false, "Code-46", "Constructeur1", new DateTime(2020, 8, 26, 19, 36, 2, 334, DateTimeKind.Local).AddTicks(9620), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 682m, -357m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-46", "titre long pour un produit avec la nature de super hasardouze-46", "Kg" },
                    { 36, false, "Code-36", "Constructeur2", new DateTime(2020, 8, 4, 15, 11, 58, 552, DateTimeKind.Local).AddTicks(3747), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 999m, -536m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-36", "titre long pour un produit avec la nature de super hasardouze-36", "Kg" },
                    { 13, false, "Code-13", "Constructeur3", new DateTime(2020, 1, 22, 23, 25, 43, 310, DateTimeKind.Local).AddTicks(8332), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 625m, -209m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-13", "titre long pour un produit avec la nature de super hasardouze-13", "L" },
                    { 10, false, "Code-10", "Constructeur2", new DateTime(2020, 5, 29, 18, 28, 43, 952, DateTimeKind.Local).AddTicks(2377), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 142m, -188m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-10", "titre long pour un produit avec la nature de super hasardouze-10", "Kg" },
                    { 5, false, "Code-5", "Constructeur1", new DateTime(2020, 4, 9, 23, 25, 38, 946, DateTimeKind.Local).AddTicks(8255), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 980m, -486m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-5", "titre long pour un produit avec la nature de super hasardouze-5", "U" },
                    { 4, false, "Code-4", "Constructeur2", new DateTime(2020, 6, 22, 9, 20, 7, 414, DateTimeKind.Local).AddTicks(5292), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 243m, -89m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-4", "titre long pour un produit avec la nature de super hasardouze-4", "Kg" },
                    { 89, true, "Code-89", "Constructeur3", new DateTime(2019, 11, 26, 0, 41, 11, 396, DateTimeKind.Local).AddTicks(314), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 107m, -195m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-89", "titre long pour un produit avec la nature de super hasardouze-89", "L" },
                    { 82, false, "Code-82", "Constructeur2", new DateTime(2020, 6, 29, 19, 47, 42, 85, DateTimeKind.Local).AddTicks(3411), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 477m, -137m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-82", "titre long pour un produit avec la nature de super hasardouze-82", "Kg" },
                    { 81, true, "Code-81", "Constructeur3", new DateTime(2020, 4, 16, 7, 41, 12, 417, DateTimeKind.Local).AddTicks(1869), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 292m, -257m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-81", "titre long pour un produit avec la nature de super hasardouze-81", "Kg" },
                    { 67, false, "Code-67", "Constructeur2", new DateTime(2020, 5, 10, 2, 42, 54, 520, DateTimeKind.Local).AddTicks(7755), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 962m, -9m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-67", "titre long pour un produit avec la nature de super hasardouze-67", "Kg" },
                    { 66, false, "Code-66", "Constructeur3", new DateTime(2020, 6, 14, 2, 28, 37, 918, DateTimeKind.Local).AddTicks(3403), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 201m, -190m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-66", "titre long pour un produit avec la nature de super hasardouze-66", "L" },
                    { 64, false, "Code-64", "Constructeur1", new DateTime(2020, 3, 29, 2, 54, 9, 230, DateTimeKind.Local).AddTicks(2121), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 37m, -71m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-64", "titre long pour un produit avec la nature de super hasardouze-64", "U" },
                    { 61, false, "Code-61", "Constructeur3", new DateTime(2020, 7, 12, 10, 57, 10, 542, DateTimeKind.Local).AddTicks(7941), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 743m, -310m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-61", "titre long pour un produit avec la nature de super hasardouze-61", "Kg" },
                    { 49, false, "Code-49", "Constructeur2", new DateTime(2020, 6, 12, 2, 44, 21, 816, DateTimeKind.Local).AddTicks(5000), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 444m, -169m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-49", "titre long pour un produit avec la nature de super hasardouze-49", "U" },
                    { 19, false, "Code-19", "Constructeur2", new DateTime(2020, 10, 8, 8, 19, 0, 40, DateTimeKind.Local).AddTicks(5752), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 229m, -353m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-19", "titre long pour un produit avec la nature de super hasardouze-19", "Kg" },
                    { 17, false, "Code-17", "Constructeur2", new DateTime(2020, 7, 22, 9, 58, 52, 532, DateTimeKind.Local).AddTicks(6369), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 755m, -333m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-17", "titre long pour un produit avec la nature de super hasardouze-17", "U" },
                    { 34, false, "Code-34", "Constructeur1", new DateTime(2019, 12, 6, 4, 11, 16, 282, DateTimeKind.Local).AddTicks(4856), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 932m, -245m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-34", "titre long pour un produit avec la nature de super hasardouze-34", "Kg" },
                    { 48, false, "Code-48", "Constructeur1", new DateTime(2020, 4, 16, 20, 51, 6, 1, DateTimeKind.Local).AddTicks(5438), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 483m, -323m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-48", "titre long pour un produit avec la nature de super hasardouze-48", "Kg" },
                    { 59, false, "Code-59", "Constructeur1", new DateTime(2020, 5, 2, 22, 11, 52, 69, DateTimeKind.Local).AddTicks(4873), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 933m, -493m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-59", "titre long pour un produit avec la nature de super hasardouze-59", "U" },
                    { 95, true, "Code-95", "Constructeur1", new DateTime(2019, 12, 15, 18, 42, 46, 893, DateTimeKind.Local).AddTicks(3911), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 727m, -329m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-95", "titre long pour un produit avec la nature de super hasardouze-95", "L" },
                    { 85, true, "Code-85", "Constructeur1", new DateTime(2020, 6, 6, 2, 50, 17, 93, DateTimeKind.Local).AddTicks(7524), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 264m, -208m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-85", "titre long pour un produit avec la nature de super hasardouze-85", "L" },
                    { 84, false, "Code-84", "Constructeur2", new DateTime(2020, 10, 21, 6, 47, 46, 819, DateTimeKind.Local).AddTicks(5255), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 640m, -225m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-84", "titre long pour un produit avec la nature de super hasardouze-84", "U" },
                    { 58, false, "Code-58", "Constructeur2", new DateTime(2020, 9, 19, 19, 37, 14, 948, DateTimeKind.Local).AddTicks(4487), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 117m, -166m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-58", "titre long pour un produit avec la nature de super hasardouze-58", "U" },
                    { 57, false, "Code-57", "Constructeur3", new DateTime(2020, 4, 3, 22, 17, 15, 983, DateTimeKind.Local).AddTicks(9244), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 404m, -349m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-57", "titre long pour un produit avec la nature de super hasardouze-57", "U" },
                    { 53, false, "Code-53", "Constructeur1", new DateTime(2020, 11, 4, 10, 58, 54, 168, DateTimeKind.Local).AddTicks(9872), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 60m, -255m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-53", "titre long pour un produit avec la nature de super hasardouze-53", "U" },
                    { 51, false, "Code-51", "Constructeur3", new DateTime(2020, 1, 5, 1, 42, 22, 444, DateTimeKind.Local).AddTicks(6385), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 263m, -344m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-51", "titre long pour un produit avec la nature de super hasardouze-51", "U" },
                    { 39, false, "Code-39", "Constructeur2", new DateTime(2020, 6, 4, 3, 7, 36, 14, DateTimeKind.Local).AddTicks(4504), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 332m, -171m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-39", "titre long pour un produit avec la nature de super hasardouze-39", "U" },
                    { 27, false, "Code-27", "Constructeur1", new DateTime(2020, 1, 2, 9, 9, 27, 867, DateTimeKind.Local).AddTicks(8872), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 115m, -55m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-27", "titre long pour un produit avec la nature de super hasardouze-27", "Kg" },
                    { 24, false, "Code-24", "Constructeur1", new DateTime(2020, 10, 24, 11, 40, 49, 597, DateTimeKind.Local).AddTicks(1873), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 401m, -252m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-24", "titre long pour un produit avec la nature de super hasardouze-24", "Kg" },
                    { 55, false, "Code-55", "Constructeur2", new DateTime(2020, 7, 8, 21, 6, 29, 166, DateTimeKind.Local).AddTicks(8850), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 514m, -113m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-55", "titre long pour un produit avec la nature de super hasardouze-55", "L" },
                    { 22, false, "Code-22", "Constructeur2", new DateTime(2020, 9, 13, 6, 8, 16, 881, DateTimeKind.Local).AddTicks(4637), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 134m, -470m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-22", "titre long pour un produit avec la nature de super hasardouze-22", "Kg" },
                    { 83, true, "Code-83", "Constructeur3", new DateTime(2020, 10, 15, 20, 46, 19, 876, DateTimeKind.Local).AddTicks(387), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 580m, -62m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-83", "titre long pour un produit avec la nature de super hasardouze-83", "L" },
                    { 68, false, "Code-68", "Constructeur3", new DateTime(2019, 12, 31, 0, 13, 50, 669, DateTimeKind.Local).AddTicks(9069), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 525m, -127m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-68", "titre long pour un produit avec la nature de super hasardouze-68", "U" },
                    { 54, false, "Code-54", "Constructeur2", new DateTime(2020, 8, 16, 23, 15, 59, 859, DateTimeKind.Local).AddTicks(4412), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 563m, -474m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-54", "titre long pour un produit avec la nature de super hasardouze-54", "Kg" },
                    { 44, false, "Code-44", "Constructeur2", new DateTime(2020, 1, 15, 21, 49, 52, 946, DateTimeKind.Local).AddTicks(8891), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 464m, -339m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-44", "titre long pour un produit avec la nature de super hasardouze-44", "L" },
                    { 31, false, "Code-31", "Constructeur3", new DateTime(2020, 3, 15, 11, 28, 26, 260, DateTimeKind.Local).AddTicks(2814), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 448m, -292m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-31", "titre long pour un produit avec la nature de super hasardouze-31", "L" },
                    { 30, false, "Code-30", "Constructeur3", new DateTime(2020, 5, 30, 15, 18, 17, 441, DateTimeKind.Local).AddTicks(8104), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 354m, -252m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-30", "titre long pour un produit avec la nature de super hasardouze-30", "U" },
                    { 98, false, "Code-98", "Constructeur1", new DateTime(2020, 7, 23, 2, 49, 43, 668, DateTimeKind.Local).AddTicks(234), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 612m, -112m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-98", "titre long pour un produit avec la nature de super hasardouze-98", "U" },
                    { 86, false, "Code-86", "Constructeur2", new DateTime(2020, 7, 24, 13, 5, 9, 817, DateTimeKind.Local).AddTicks(2583), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 483m, -60m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-86", "titre long pour un produit avec la nature de super hasardouze-86", "L" },
                    { 69, false, "Code-69", "Constructeur1", new DateTime(2020, 7, 23, 10, 29, 51, 772, DateTimeKind.Local).AddTicks(2413), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 537m, -233m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-69", "titre long pour un produit avec la nature de super hasardouze-69", "Kg" },
                    { 60, false, "Code-60", "Constructeur1", new DateTime(2020, 6, 30, 16, 3, 29, 546, DateTimeKind.Local).AddTicks(5539), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 400m, -317m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-60", "titre long pour un produit avec la nature de super hasardouze-60", "Kg" },
                    { 91, true, "Code-91", "Constructeur1", new DateTime(2020, 8, 31, 17, 59, 31, 639, DateTimeKind.Local).AddTicks(7942), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 557m, -278m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-91", "titre long pour un produit avec la nature de super hasardouze-91", "Kg" },
                    { 56, false, "Code-56", "Constructeur2", new DateTime(2019, 12, 18, 0, 11, 36, 707, DateTimeKind.Local).AddTicks(1251), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 939m, -229m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-56", "titre long pour un produit avec la nature de super hasardouze-56", "U" }
                });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[,]
                {
                    { 12, 18, 597m, 93m, 0m, 55521m },
                    { 41, 11, 624m, 61m, 0m, 38064m },
                    { 41, 8, 624m, 37m, 0m, 23088m },
                    { 45, 5, 211m, 61m, 0m, 12871m },
                    { 45, 4, 211m, 4m, 0m, 844m },
                    { 45, 16, 211m, 67m, 0m, 14137m },
                    { 45, 11, 211m, 83m, 0m, 17513m },
                    { 41, 17, 624m, 32m, 0m, 19968m },
                    { 45, 14, 211m, 86m, 0m, 18146m },
                    { 50, 6, 608m, 16m, 0m, 9728m },
                    { 50, 13, 608m, 43m, 0m, 26144m },
                    { 62, 1, 842m, 49m, 0m, 41258m },
                    { 62, 9, 842m, 54m, 0m, 45468m },
                    { 62, 7, 842m, 55m, 0m, 46310m },
                    { 62, 13, 842m, 6m, 0m, 5052m },
                    { 50, 5, 608m, 22m, 0m, 13376m },
                    { 62, 3, 842m, 43m, 0m, 36206m },
                    { 41, 10, 624m, 6m, 0m, 3744m },
                    { 26, 9, 800m, 19m, 0m, 15200m },
                    { 20, 4, 180m, 42m, 0m, 7560m },
                    { 20, 2, 180m, 26m, 0m, 4680m },
                    { 20, 11, 180m, 41m, 0m, 7380m },
                    { 21, 20, 488m, 38m, 0m, 18544m },
                    { 21, 14, 488m, 88m, 0m, 42944m },
                    { 21, 5, 488m, 78m, 0m, 38064m },
                    { 26, 16, 800m, 50m, 0m, 40000m },
                    { 21, 2, 488m, 65m, 0m, 31720m },
                    { 26, 14, 800m, 54m, 0m, 43200m },
                    { 26, 17, 800m, 28m, 0m, 22400m },
                    { 26, 6, 800m, 38m, 0m, 30400m },
                    { 26, 20, 800m, 59m, 0m, 47200m },
                    { 26, 4, 800m, 66m, 0m, 52800m },
                    { 26, 18, 800m, 44m, 0m, 35200m },
                    { 26, 15, 800m, 51m, 0m, 40800m },
                    { 62, 5, 842m, 87m, 0m, 73254m },
                    { 62, 14, 842m, 59m, 0m, 49678m },
                    { 62, 2, 842m, 52m, 0m, 43784m },
                    { 88, 15, 160m, 8m, 0m, 1280m },
                    { 88, 20, 160m, 5m, 0m, 800m },
                    { 88, 3, 160m, 46m, 0m, 7360m },
                    { 88, 12, 160m, 11m, 0m, 1760m },
                    { 88, 18, 160m, 82m, 0m, 13120m },
                    { 96, 18, 893m, 54m, 0m, 48222m },
                    { 88, 16, 160m, 61m, 0m, 9760m },
                    { 96, 19, 893m, 99m, 0m, 88407m },
                    { 96, 3, 893m, 27m, 0m, 24111m },
                    { 96, 11, 893m, 63m, 0m, 56259m },
                    { 96, 2, 893m, 30m, 0m, 26790m },
                    { 96, 5, 893m, 33m, 0m, 29469m },
                    { 96, 7, 893m, 47m, 0m, 41971m },
                    { 99, 19, 230m, 85m, 0m, 19550m },
                    { 96, 14, 893m, 69m, 0m, 61617m },
                    { 88, 5, 160m, 44m, 0m, 7040m },
                    { 88, 11, 160m, 93m, 0m, 14880m },
                    { 80, 14, 742m, 90m, 0m, 66780m },
                    { 62, 16, 842m, 2m, 0m, 1684m },
                    { 65, 17, 478m, 56m, 0m, 26768m },
                    { 65, 16, 478m, 33m, 0m, 15774m },
                    { 65, 12, 478m, 31m, 0m, 14818m },
                    { 65, 4, 478m, 46m, 0m, 21988m },
                    { 80, 6, 742m, 59m, 0m, 43778m },
                    { 80, 16, 742m, 38m, 0m, 28196m },
                    { 80, 5, 742m, 95m, 0m, 70490m },
                    { 80, 7, 742m, 59m, 0m, 43778m },
                    { 80, 4, 742m, 60m, 0m, 44520m },
                    { 80, 9, 742m, 32m, 0m, 23744m },
                    { 80, 13, 742m, 41m, 0m, 30422m },
                    { 80, 8, 742m, 22m, 0m, 16324m },
                    { 80, 18, 742m, 43m, 0m, 31906m },
                    { 80, 11, 742m, 55m, 0m, 40810m },
                    { 20, 9, 180m, 91m, 0m, 16380m },
                    { 11, 4, 355m, 92m, 0m, 32660m },
                    { 11, 8, 355m, 15m, 0m, 5325m },
                    { 11, 3, 355m, 33m, 0m, 11715m },
                    { 73, 16, 477m, 54m, 0m, 25758m },
                    { 73, 15, 477m, 44m, 0m, 20988m },
                    { 73, 14, 477m, 85m, 0m, 40545m },
                    { 73, 7, 477m, 12m, 0m, 5724m },
                    { 73, 18, 477m, 87m, 0m, 41499m },
                    { 73, 11, 477m, 1m, 0m, 477m },
                    { 73, 17, 477m, 32m, 0m, 15264m },
                    { 73, 9, 477m, 12m, 0m, 5724m },
                    { 75, 19, 971m, 16m, 0m, 15536m },
                    { 75, 5, 971m, 16m, 0m, 15536m },
                    { 76, 17, 790m, 39m, 0m, 30810m },
                    { 76, 12, 790m, 79m, 0m, 62410m },
                    { 76, 8, 790m, 41m, 0m, 32390m },
                    { 76, 11, 790m, 14m, 0m, 11060m },
                    { 73, 8, 477m, 22m, 0m, 10494m },
                    { 32, 12, 392m, 56m, 0m, 21952m },
                    { 32, 18, 392m, 37m, 0m, 14504m },
                    { 32, 4, 392m, 82m, 0m, 32144m },
                    { 95, 2, 727m, 48m, 0m, 34896m },
                    { 95, 17, 727m, 48m, 0m, 34896m },
                    { 95, 8, 727m, 27m, 0m, 19629m },
                    { 14, 3, 103m, 8m, 0m, 824m },
                    { 14, 20, 103m, 97m, 0m, 9991m },
                    { 14, 11, 103m, 41m, 0m, 4223m },
                    { 14, 2, 103m, 58m, 0m, 5974m },
                    { 14, 13, 103m, 59m, 0m, 6077m },
                    { 14, 8, 103m, 63m, 0m, 6489m },
                    { 14, 18, 103m, 62m, 0m, 6386m },
                    { 32, 14, 392m, 24m, 0m, 9408m },
                    { 32, 17, 392m, 56m, 0m, 21952m },
                    { 32, 9, 392m, 60m, 0m, 23520m },
                    { 32, 7, 392m, 46m, 0m, 18032m },
                    { 32, 1, 392m, 84m, 0m, 32928m },
                    { 76, 1, 790m, 5m, 0m, 3950m },
                    { 99, 5, 230m, 64m, 0m, 14720m },
                    { 77, 13, 100m, 1m, 0m, 100m },
                    { 77, 4, 100m, 92m, 0m, 9200m },
                    { 92, 14, 703m, 98m, 0m, 68894m },
                    { 2, 13, 415m, 36m, 0m, 14940m },
                    { 2, 11, 415m, 5m, 0m, 2075m },
                    { 2, 6, 415m, 81m, 0m, 33615m },
                    { 2, 20, 415m, 28m, 0m, 11620m },
                    { 7, 9, 282m, 14m, 0m, 3948m },
                    { 92, 9, 703m, 40m, 0m, 28120m },
                    { 7, 12, 282m, 8m, 0m, 2256m },
                    { 7, 17, 282m, 10m, 0m, 2820m },
                    { 7, 20, 282m, 35m, 0m, 9870m },
                    { 7, 13, 282m, 95m, 0m, 26790m },
                    { 11, 13, 355m, 20m, 0m, 7100m },
                    { 11, 12, 355m, 97m, 0m, 34435m },
                    { 11, 2, 355m, 78m, 0m, 27690m },
                    { 7, 6, 282m, 47m, 0m, 13254m },
                    { 92, 10, 703m, 33m, 0m, 23199m },
                    { 92, 11, 703m, 62m, 0m, 43586m },
                    { 92, 6, 703m, 24m, 0m, 16872m },
                    { 77, 3, 100m, 6m, 0m, 600m },
                    { 77, 11, 100m, 39m, 0m, 3900m },
                    { 77, 12, 100m, 24m, 0m, 2400m },
                    { 79, 15, 803m, 25m, 0m, 20075m },
                    { 79, 18, 803m, 29m, 0m, 23287m },
                    { 79, 2, 803m, 58m, 0m, 46574m },
                    { 79, 5, 803m, 97m, 0m, 77891m },
                    { 79, 4, 803m, 71m, 0m, 57013m },
                    { 79, 12, 803m, 43m, 0m, 34529m },
                    { 79, 19, 803m, 10m, 0m, 8030m },
                    { 79, 6, 803m, 74m, 0m, 59422m },
                    { 92, 2, 703m, 36m, 0m, 25308m },
                    { 92, 3, 703m, 69m, 0m, 48507m },
                    { 92, 1, 703m, 70m, 0m, 49210m },
                    { 92, 8, 703m, 78m, 0m, 54834m },
                    { 77, 1, 100m, 42m, 0m, 4200m },
                    { 99, 10, 230m, 78m, 0m, 17940m },
                    { 99, 3, 230m, 12m, 0m, 2760m },
                    { 99, 12, 230m, 53m, 0m, 12190m },
                    { 35, 16, 961m, 85m, 0m, 81685m },
                    { 35, 20, 961m, 36m, 0m, 34596m },
                    { 35, 1, 961m, 2m, 0m, 1922m },
                    { 35, 9, 961m, 40m, 0m, 38440m },
                    { 35, 19, 961m, 90m, 0m, 86490m },
                    { 43, 20, 550m, 88m, 0m, 48400m },
                    { 29, 4, 93m, 96m, 0m, 8928m },
                    { 43, 18, 550m, 29m, 0m, 15950m },
                    { 43, 1, 550m, 22m, 0m, 12100m },
                    { 43, 12, 550m, 18m, 0m, 9900m },
                    { 47, 17, 308m, 88m, 0m, 27104m },
                    { 47, 7, 308m, 82m, 0m, 25256m },
                    { 47, 19, 308m, 58m, 0m, 17864m },
                    { 47, 16, 308m, 1m, 0m, 308m },
                    { 43, 15, 550m, 14m, 0m, 7700m },
                    { 29, 19, 93m, 40m, 0m, 3720m },
                    { 29, 14, 93m, 83m, 0m, 7719m },
                    { 29, 20, 93m, 12m, 0m, 1116m },
                    { 90, 3, 414m, 21m, 0m, 8694m },
                    { 90, 16, 414m, 38m, 0m, 15732m },
                    { 90, 7, 414m, 25m, 0m, 10350m },
                    { 97, 15, 788m, 57m, 0m, 44916m },
                    { 97, 12, 788m, 62m, 0m, 48856m },
                    { 97, 6, 788m, 57m, 0m, 44916m },
                    { 1, 16, 898m, 20m, 0m, 17960m },
                    { 1, 6, 898m, 47m, 0m, 42206m },
                    { 1, 19, 898m, 69m, 0m, 61962m },
                    { 1, 10, 898m, 88m, 0m, 79024m },
                    { 1, 18, 898m, 27m, 0m, 24246m },
                    { 1, 2, 898m, 47m, 0m, 42206m },
                    { 6, 11, 698m, 85m, 0m, 59330m },
                    { 6, 20, 698m, 43m, 0m, 30014m },
                    { 6, 3, 698m, 80m, 0m, 55840m },
                    { 47, 1, 308m, 7m, 0m, 2156m },
                    { 90, 10, 414m, 44m, 0m, 18216m },
                    { 47, 12, 308m, 34m, 0m, 10472m },
                    { 63, 19, 931m, 46m, 0m, 42826m },
                    { 15, 16, 488m, 46m, 0m, 22448m },
                    { 33, 2, 396m, 39m, 0m, 15444m },
                    { 33, 20, 396m, 14m, 0m, 5544m },
                    { 33, 12, 396m, 46m, 0m, 18216m },
                    { 55, 7, 514m, 91m, 0m, 46774m },
                    { 55, 10, 514m, 24m, 0m, 12336m },
                    { 15, 5, 488m, 88m, 0m, 42944m },
                    { 55, 4, 514m, 63m, 0m, 32382m },
                    { 56, 2, 939m, 86m, 0m, 80754m },
                    { 56, 16, 939m, 89m, 0m, 83571m },
                    { 56, 3, 939m, 49m, 0m, 46011m },
                    { 56, 6, 939m, 72m, 0m, 67608m },
                    { 56, 18, 939m, 87m, 0m, 81693m },
                    { 56, 15, 939m, 10m, 0m, 9390m },
                    { 55, 16, 514m, 58m, 0m, 29812m },
                    { 15, 17, 488m, 54m, 0m, 26352m },
                    { 3, 1, 225m, 9m, 0m, 2025m },
                    { 3, 6, 225m, 89m, 0m, 20025m },
                    { 63, 17, 931m, 49m, 0m, 45619m },
                    { 63, 16, 931m, 8m, 0m, 7448m },
                    { 63, 9, 931m, 27m, 0m, 25137m },
                    { 63, 20, 931m, 5m, 0m, 4655m },
                    { 72, 13, 503m, 5m, 0m, 2515m },
                    { 72, 19, 503m, 59m, 0m, 29677m },
                    { 94, 8, 224m, 93m, 0m, 20832m },
                    { 94, 15, 224m, 39m, 0m, 8736m },
                    { 94, 6, 224m, 9m, 0m, 2016m },
                    { 94, 7, 224m, 5m, 0m, 1120m },
                    { 94, 18, 224m, 91m, 0m, 20384m },
                    { 94, 4, 224m, 35m, 0m, 7840m },
                    { 3, 9, 225m, 87m, 0m, 19575m },
                    { 3, 17, 225m, 52m, 0m, 11700m },
                    { 3, 20, 225m, 7m, 0m, 1575m },
                    { 47, 15, 308m, 87m, 0m, 26796m },
                    { 95, 9, 727m, 51m, 0m, 37077m },
                    { 74, 2, 34m, 68m, 0m, 2312m },
                    { 74, 11, 34m, 73m, 0m, 2482m },
                    { 18, 1, 869m, 60m, 0m, 52140m },
                    { 18, 13, 869m, 87m, 0m, 75603m },
                    { 23, 8, 647m, 24m, 0m, 15528m },
                    { 23, 15, 647m, 5m, 0m, 3235m },
                    { 23, 11, 647m, 88m, 0m, 56936m },
                    { 23, 4, 647m, 6m, 0m, 3882m },
                    { 18, 6, 869m, 85m, 0m, 73865m },
                    { 23, 3, 647m, 29m, 0m, 18763m },
                    { 25, 13, 825m, 68m, 0m, 56100m },
                    { 25, 7, 825m, 1m, 0m, 825m },
                    { 25, 2, 825m, 30m, 0m, 24750m },
                    { 28, 8, 520m, 58m, 0m, 30160m },
                    { 28, 14, 520m, 28m, 0m, 14560m },
                    { 28, 19, 520m, 29m, 0m, 15080m },
                    { 25, 20, 825m, 7m, 0m, 5775m },
                    { 18, 9, 869m, 30m, 0m, 26070m },
                    { 18, 14, 869m, 91m, 0m, 79079m },
                    { 18, 17, 869m, 1m, 0m, 869m },
                    { 99, 9, 230m, 63m, 0m, 14490m },
                    { 99, 6, 230m, 84m, 0m, 19320m },
                    { 100, 18, 582m, 97m, 0m, 56454m },
                    { 100, 15, 582m, 42m, 0m, 24444m },
                    { 100, 13, 582m, 25m, 0m, 14550m },
                    { 100, 7, 582m, 15m, 0m, 8730m },
                    { 100, 3, 582m, 8m, 0m, 4656m },
                    { 100, 6, 582m, 79m, 0m, 45978m },
                    { 100, 20, 582m, 32m, 0m, 18624m },
                    { 16, 3, 625m, 97m, 0m, 60625m },
                    { 16, 10, 625m, 100m, 0m, 62500m },
                    { 16, 20, 625m, 96m, 0m, 60000m },
                    { 16, 14, 625m, 31m, 0m, 19375m },
                    { 16, 13, 625m, 37m, 0m, 23125m },
                    { 18, 18, 869m, 10m, 0m, 8690m },
                    { 28, 6, 520m, 89m, 0m, 46280m },
                    { 74, 7, 34m, 34m, 0m, 1156m },
                    { 37, 14, 548m, 8m, 0m, 4384m },
                    { 37, 10, 548m, 39m, 0m, 21372m },
                    { 42, 11, 1000m, 82m, 0m, 82000m },
                    { 42, 20, 1000m, 6m, 0m, 6000m },
                    { 42, 2, 1000m, 82m, 0m, 82000m },
                    { 42, 12, 1000m, 90m, 0m, 90000m },
                    { 42, 9, 1000m, 66m, 0m, 66000m },
                    { 42, 7, 1000m, 40m, 0m, 40000m },
                    { 42, 5, 1000m, 36m, 0m, 36000m },
                    { 42, 18, 1000m, 16m, 0m, 16000m },
                    { 71, 4, 83m, 44m, 0m, 3652m },
                    { 71, 9, 83m, 61m, 0m, 5063m },
                    { 71, 8, 83m, 44m, 0m, 3652m },
                    { 71, 6, 83m, 74m, 0m, 6142m },
                    { 74, 14, 34m, 54m, 0m, 1836m },
                    { 74, 16, 34m, 3m, 0m, 102m },
                    { 42, 17, 1000m, 97m, 0m, 97000m },
                    { 40, 10, 872m, 94m, 0m, 81968m },
                    { 40, 19, 872m, 32m, 0m, 27904m },
                    { 40, 17, 872m, 95m, 0m, 82840m },
                    { 37, 2, 548m, 76m, 0m, 41648m },
                    { 37, 9, 548m, 6m, 0m, 3288m },
                    { 37, 19, 548m, 77m, 0m, 42196m },
                    { 37, 1, 548m, 45m, 0m, 24660m },
                    { 37, 7, 548m, 68m, 0m, 37264m },
                    { 37, 16, 548m, 18m, 0m, 9864m },
                    { 38, 2, 598m, 48m, 0m, 28704m },
                    { 38, 10, 598m, 59m, 0m, 35282m },
                    { 38, 8, 598m, 29m, 0m, 17342m },
                    { 38, 4, 598m, 32m, 0m, 19136m },
                    { 38, 13, 598m, 60m, 0m, 35880m },
                    { 38, 11, 598m, 67m, 0m, 40066m },
                    { 38, 7, 598m, 86m, 0m, 51428m },
                    { 40, 3, 872m, 52m, 0m, 45344m },
                    { 40, 4, 872m, 99m, 0m, 86328m },
                    { 37, 12, 548m, 55m, 0m, 30140m },
                    { 95, 3, 727m, 93m, 0m, 67611m },
                    { 75, 2, 971m, 56m, 0m, 54376m },
                    { 95, 16, 727m, 54m, 0m, 39258m },
                    { 70, 13, 812m, 47m, 0m, 38164m },
                    { 78, 3, 985m, 50m, 0m, 49250m },
                    { 78, 17, 985m, 37m, 0m, 36445m },
                    { 78, 11, 985m, 72m, 0m, 70920m },
                    { 78, 12, 985m, 90m, 0m, 88650m },
                    { 87, 13, 413m, 75m, 0m, 30975m },
                    { 70, 17, 812m, 84m, 0m, 68208m },
                    { 87, 20, 413m, 94m, 0m, 38822m },
                    { 87, 12, 413m, 22m, 0m, 9086m },
                    { 87, 10, 413m, 17m, 0m, 7021m },
                    { 93, 3, 36m, 17m, 0m, 612m },
                    { 93, 6, 36m, 31m, 0m, 1116m },
                    { 93, 2, 36m, 67m, 0m, 2412m },
                    { 93, 15, 36m, 89m, 0m, 3204m },
                    { 87, 3, 413m, 37m, 0m, 15281m },
                    { 70, 20, 812m, 88m, 0m, 71456m },
                    { 70, 3, 812m, 44m, 0m, 35728m },
                    { 52, 12, 53m, 32m, 0m, 1696m },
                    { 36, 5, 999m, 94m, 0m, 93906m },
                    { 36, 13, 999m, 60m, 0m, 59940m },
                    { 36, 11, 999m, 86m, 0m, 85914m },
                    { 46, 5, 682m, 99m, 0m, 67518m },
                    { 46, 16, 682m, 92m, 0m, 62744m },
                    { 46, 20, 682m, 44m, 0m, 30008m },
                    { 46, 13, 682m, 40m, 0m, 27280m },
                    { 46, 18, 682m, 53m, 0m, 36146m },
                    { 46, 9, 682m, 16m, 0m, 10912m },
                    { 46, 1, 682m, 34m, 0m, 23188m },
                    { 46, 14, 682m, 51m, 0m, 34782m },
                    { 46, 19, 682m, 67m, 0m, 45694m },
                    { 52, 17, 53m, 8m, 0m, 424m },
                    { 52, 11, 53m, 35m, 0m, 1855m },
                    { 52, 1, 53m, 28m, 0m, 1484m },
                    { 93, 20, 36m, 37m, 0m, 1332m },
                    { 36, 18, 999m, 58m, 0m, 57942m },
                    { 8, 16, 632m, 11m, 0m, 6952m },
                    { 8, 13, 632m, 24m, 0m, 15168m },
                    { 48, 9, 483m, 70m, 0m, 33810m },
                    { 48, 20, 483m, 81m, 0m, 39123m },
                    { 48, 12, 483m, 92m, 0m, 44436m },
                    { 59, 13, 933m, 82m, 0m, 76506m },
                    { 59, 14, 933m, 72m, 0m, 67176m },
                    { 59, 4, 933m, 62m, 0m, 57846m },
                    { 48, 3, 483m, 47m, 0m, 22701m },
                    { 59, 10, 933m, 61m, 0m, 56913m },
                    { 59, 17, 933m, 90m, 0m, 83970m },
                    { 59, 16, 933m, 33m, 0m, 30789m },
                    { 59, 12, 933m, 25m, 0m, 23325m },
                    { 60, 7, 400m, 56m, 0m, 22400m },
                    { 60, 6, 400m, 44m, 0m, 17600m },
                    { 60, 9, 400m, 29m, 0m, 11600m },
                    { 59, 3, 933m, 68m, 0m, 63444m },
                    { 48, 2, 483m, 67m, 0m, 32361m }
                });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[,]
                {
                    { 34, 10, 932m, 97m, 0m, 90404m },
                    { 34, 12, 932m, 14m, 0m, 13048m },
                    { 8, 6, 632m, 96m, 0m, 60672m },
                    { 8, 7, 632m, 41m, 0m, 25912m },
                    { 8, 3, 632m, 95m, 0m, 60040m },
                    { 8, 5, 632m, 42m, 0m, 26544m },
                    { 8, 15, 632m, 26m, 0m, 16432m },
                    { 8, 19, 632m, 87m, 0m, 54984m },
                    { 8, 1, 632m, 71m, 0m, 44872m },
                    { 17, 19, 755m, 77m, 0m, 58135m },
                    { 17, 7, 755m, 61m, 0m, 46055m },
                    { 17, 8, 755m, 98m, 0m, 73990m },
                    { 17, 20, 755m, 99m, 0m, 74745m },
                    { 95, 10, 727m, 58m, 0m, 42166m },
                    { 34, 4, 932m, 40m, 0m, 37280m },
                    { 34, 2, 932m, 48m, 0m, 44736m },
                    { 34, 14, 932m, 80m, 0m, 74560m },
                    { 8, 12, 632m, 93m, 0m, 58776m },
                    { 36, 19, 999m, 29m, 0m, 28971m },
                    { 36, 8, 999m, 92m, 0m, 91908m },
                    { 36, 9, 999m, 29m, 0m, 28971m },
                    { 61, 12, 743m, 67m, 0m, 49781m },
                    { 61, 10, 743m, 72m, 0m, 53496m },
                    { 61, 7, 743m, 93m, 0m, 69099m },
                    { 61, 5, 743m, 52m, 0m, 38636m },
                    { 61, 1, 743m, 20m, 0m, 14860m },
                    { 64, 8, 37m, 25m, 0m, 925m },
                    { 61, 4, 743m, 19m, 0m, 14117m },
                    { 64, 13, 37m, 50m, 0m, 1850m },
                    { 64, 17, 37m, 85m, 0m, 3145m },
                    { 66, 13, 201m, 48m, 0m, 9648m },
                    { 66, 11, 201m, 13m, 0m, 2613m },
                    { 66, 3, 201m, 94m, 0m, 18894m },
                    { 66, 7, 201m, 35m, 0m, 7035m },
                    { 67, 4, 962m, 9m, 0m, 8658m },
                    { 64, 20, 37m, 13m, 0m, 481m },
                    { 61, 2, 743m, 46m, 0m, 34178m },
                    { 61, 16, 743m, 11m, 0m, 8173m },
                    { 61, 18, 743m, 8m, 0m, 5944m },
                    { 12, 4, 597m, 86m, 0m, 51342m },
                    { 12, 19, 597m, 31m, 0m, 18507m },
                    { 12, 9, 597m, 88m, 0m, 52536m },
                    { 19, 7, 229m, 98m, 0m, 22442m },
                    { 19, 2, 229m, 59m, 0m, 13511m },
                    { 19, 5, 229m, 54m, 0m, 12366m },
                    { 19, 6, 229m, 48m, 0m, 10992m },
                    { 19, 8, 229m, 94m, 0m, 21526m },
                    { 49, 20, 444m, 2m, 0m, 888m },
                    { 49, 19, 444m, 9m, 0m, 3996m },
                    { 49, 1, 444m, 77m, 0m, 34188m },
                    { 49, 6, 444m, 38m, 0m, 16872m },
                    { 49, 7, 444m, 22m, 0m, 9768m },
                    { 49, 13, 444m, 43m, 0m, 19092m },
                    { 61, 19, 743m, 10m, 0m, 7430m },
                    { 81, 3, 292m, 92m, 0m, 26864m },
                    { 81, 9, 292m, 81m, 0m, 23652m },
                    { 81, 13, 292m, 2m, 0m, 584m },
                    { 81, 14, 292m, 84m, 0m, 24528m },
                    { 5, 9, 980m, 42m, 0m, 41160m },
                    { 5, 16, 980m, 56m, 0m, 54880m },
                    { 5, 17, 980m, 73m, 0m, 71540m },
                    { 5, 1, 980m, 77m, 0m, 75460m },
                    { 5, 13, 980m, 99m, 0m, 97020m },
                    { 10, 12, 142m, 88m, 0m, 12496m },
                    { 10, 4, 142m, 100m, 0m, 14200m },
                    { 13, 18, 625m, 25m, 0m, 15625m },
                    { 13, 17, 625m, 10m, 0m, 6250m },
                    { 13, 14, 625m, 87m, 0m, 54375m },
                    { 13, 10, 625m, 14m, 0m, 8750m },
                    { 13, 15, 625m, 19m, 0m, 11875m },
                    { 13, 19, 625m, 54m, 0m, 33750m },
                    { 36, 2, 999m, 61m, 0m, 60939m },
                    { 36, 10, 999m, 27m, 0m, 26973m },
                    { 5, 18, 980m, 36m, 0m, 35280m },
                    { 60, 17, 400m, 38m, 0m, 15200m },
                    { 5, 5, 980m, 37m, 0m, 36260m },
                    { 4, 15, 243m, 16m, 0m, 3888m },
                    { 81, 6, 292m, 16m, 0m, 4672m },
                    { 81, 11, 292m, 47m, 0m, 13724m },
                    { 82, 19, 477m, 47m, 0m, 22419m },
                    { 82, 17, 477m, 90m, 0m, 42930m },
                    { 89, 1, 107m, 3m, 0m, 321m },
                    { 89, 16, 107m, 26m, 0m, 2782m },
                    { 89, 20, 107m, 92m, 0m, 9844m },
                    { 89, 9, 107m, 37m, 0m, 3959m },
                    { 89, 12, 107m, 8m, 0m, 856m },
                    { 89, 4, 107m, 41m, 0m, 4387m },
                    { 89, 6, 107m, 15m, 0m, 1605m },
                    { 89, 11, 107m, 91m, 0m, 9737m },
                    { 4, 9, 243m, 20m, 0m, 4860m },
                    { 4, 2, 243m, 45m, 0m, 10935m },
                    { 4, 7, 243m, 8m, 0m, 1944m },
                    { 5, 15, 980m, 66m, 0m, 64680m },
                    { 60, 20, 400m, 76m, 0m, 30400m },
                    { 17, 10, 755m, 20m, 0m, 15100m },
                    { 44, 15, 464m, 95m, 0m, 44080m },
                    { 57, 17, 404m, 21m, 0m, 8484m },
                    { 57, 3, 404m, 90m, 0m, 36360m },
                    { 54, 11, 563m, 49m, 0m, 27587m },
                    { 54, 13, 563m, 7m, 0m, 3941m },
                    { 57, 16, 404m, 39m, 0m, 15756m },
                    { 54, 18, 563m, 76m, 0m, 42788m },
                    { 53, 6, 60m, 12m, 0m, 720m },
                    { 24, 9, 401m, 48m, 0m, 19248m },
                    { 24, 2, 401m, 55m, 0m, 22055m },
                    { 54, 5, 563m, 42m, 0m, 23646m },
                    { 54, 19, 563m, 60m, 0m, 33780m },
                    { 54, 8, 563m, 70m, 0m, 39410m },
                    { 68, 12, 525m, 37m, 0m, 19425m },
                    { 24, 4, 401m, 61m, 0m, 24461m },
                    { 53, 16, 60m, 64m, 0m, 3840m },
                    { 54, 12, 563m, 68m, 0m, 38284m },
                    { 54, 17, 563m, 10m, 0m, 5630m },
                    { 54, 10, 563m, 5m, 0m, 2815m },
                    { 27, 3, 115m, 44m, 0m, 5060m },
                    { 57, 14, 404m, 16m, 0m, 6464m },
                    { 57, 9, 404m, 44m, 0m, 17776m },
                    { 27, 4, 115m, 11m, 0m, 1265m },
                    { 54, 7, 563m, 16m, 0m, 9008m },
                    { 54, 9, 563m, 45m, 0m, 25335m },
                    { 44, 9, 464m, 91m, 0m, 42224m },
                    { 58, 10, 117m, 88m, 0m, 10296m },
                    { 54, 14, 563m, 26m, 0m, 14638m },
                    { 58, 17, 117m, 93m, 0m, 10881m },
                    { 57, 8, 404m, 70m, 0m, 28280m },
                    { 68, 20, 525m, 77m, 0m, 40425m },
                    { 22, 16, 134m, 76m, 0m, 10184m },
                    { 22, 1, 134m, 97m, 0m, 12998m },
                    { 53, 10, 60m, 40m, 0m, 2400m },
                    { 22, 18, 134m, 37m, 0m, 4958m },
                    { 22, 14, 134m, 8m, 0m, 1072m },
                    { 22, 2, 134m, 32m, 0m, 4288m },
                    { 22, 6, 134m, 82m, 0m, 10988m },
                    { 53, 12, 60m, 62m, 0m, 3720m },
                    { 24, 19, 401m, 57m, 0m, 22857m },
                    { 53, 5, 60m, 55m, 0m, 3300m },
                    { 60, 16, 400m, 81m, 0m, 32400m },
                    { 22, 7, 134m, 47m, 0m, 6298m },
                    { 68, 15, 525m, 13m, 0m, 6825m },
                    { 91, 15, 557m, 87m, 0m, 48459m },
                    { 91, 18, 557m, 17m, 0m, 9469m },
                    { 91, 16, 557m, 49m, 0m, 27293m },
                    { 91, 7, 557m, 87m, 0m, 48459m },
                    { 53, 17, 60m, 9m, 0m, 540m },
                    { 83, 6, 580m, 28m, 0m, 16240m },
                    { 83, 9, 580m, 35m, 0m, 20300m },
                    { 57, 11, 404m, 69m, 0m, 27876m },
                    { 24, 18, 401m, 19m, 0m, 7619m },
                    { 24, 16, 401m, 12m, 0m, 4812m },
                    { 83, 13, 580m, 57m, 0m, 33060m },
                    { 83, 11, 580m, 26m, 0m, 15080m },
                    { 83, 7, 580m, 5m, 0m, 2900m },
                    { 91, 4, 557m, 38m, 0m, 21166m },
                    { 22, 13, 134m, 36m, 0m, 4824m },
                    { 22, 19, 134m, 55m, 0m, 7370m },
                    { 58, 18, 117m, 11m, 0m, 1287m },
                    { 85, 8, 264m, 26m, 0m, 6864m },
                    { 30, 12, 354m, 12m, 0m, 4248m },
                    { 69, 8, 537m, 28m, 0m, 15036m },
                    { 30, 19, 354m, 68m, 0m, 24072m },
                    { 30, 13, 354m, 4m, 0m, 1416m },
                    { 30, 3, 354m, 92m, 0m, 32568m },
                    { 51, 9, 263m, 73m, 0m, 19199m },
                    { 98, 20, 612m, 27m, 0m, 16524m },
                    { 98, 9, 612m, 16m, 0m, 9792m },
                    { 98, 13, 612m, 62m, 0m, 37944m },
                    { 98, 14, 612m, 7m, 0m, 4284m },
                    { 44, 20, 464m, 79m, 0m, 36656m },
                    { 39, 13, 332m, 59m, 0m, 19588m },
                    { 86, 17, 483m, 58m, 0m, 28014m },
                    { 86, 7, 483m, 27m, 0m, 13041m },
                    { 51, 5, 263m, 99m, 0m, 26037m },
                    { 51, 17, 263m, 95m, 0m, 24985m },
                    { 86, 20, 483m, 1m, 0m, 483m },
                    { 85, 19, 264m, 11m, 0m, 2904m },
                    { 69, 13, 537m, 71m, 0m, 38127m },
                    { 51, 1, 263m, 22m, 0m, 5786m },
                    { 69, 3, 537m, 31m, 0m, 16647m },
                    { 69, 7, 537m, 12m, 0m, 6444m },
                    { 69, 4, 537m, 56m, 0m, 30072m },
                    { 51, 12, 263m, 16m, 0m, 4208m },
                    { 85, 7, 264m, 94m, 0m, 24816m },
                    { 85, 1, 264m, 25m, 0m, 6600m },
                    { 51, 4, 263m, 8m, 0m, 2104m },
                    { 44, 5, 464m, 33m, 0m, 15312m },
                    { 39, 12, 332m, 26m, 0m, 8632m },
                    { 58, 20, 117m, 34m, 0m, 3978m },
                    { 58, 2, 117m, 38m, 0m, 4446m },
                    { 39, 10, 332m, 20m, 0m, 6640m },
                    { 84, 4, 640m, 15m, 0m, 9600m },
                    { 44, 13, 464m, 41m, 0m, 19024m },
                    { 39, 20, 332m, 66m, 0m, 21912m },
                    { 31, 13, 448m, 30m, 0m, 13440m },
                    { 53, 1, 60m, 13m, 0m, 780m },
                    { 69, 11, 537m, 18m, 0m, 9666m },
                    { 31, 5, 448m, 68m, 0m, 30464m },
                    { 84, 18, 640m, 28m, 0m, 17920m },
                    { 51, 10, 263m, 31m, 0m, 8153m },
                    { 84, 6, 640m, 76m, 0m, 48640m },
                    { 84, 17, 640m, 68m, 0m, 43520m },
                    { 84, 9, 640m, 38m, 0m, 24320m },
                    { 31, 1, 448m, 51m, 0m, 22848m },
                    { 31, 6, 448m, 61m, 0m, 27328m },
                    { 31, 12, 448m, 35m, 0m, 15680m },
                    { 31, 8, 448m, 84m, 0m, 37632m },
                    { 31, 19, 448m, 14m, 0m, 6272m },
                    { 30, 2, 354m, 2m, 0m, 708m },
                    { 30, 14, 354m, 74m, 0m, 26196m },
                    { 85, 12, 264m, 54m, 0m, 14256m },
                    { 69, 1, 537m, 36m, 0m, 19332m },
                    { 95, 13, 727m, 18m, 0m, 13086m }
                });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[,]
                {
                    { 66, new DateTime(2020, 10, 14, 0, 20, 23, 520, DateTimeKind.Local).AddTicks(5545), 1, 75, 1, 971m, 18m },
                    { 64, new DateTime(2020, 5, 5, 5, 41, 2, 759, DateTimeKind.Local).AddTicks(8419), 7, 81, 1, 292m, 65m },
                    { 39, new DateTime(2020, 6, 1, 20, 34, 50, 359, DateTimeKind.Local).AddTicks(302), 5, 76, 3, 790m, 28m },
                    { 85, new DateTime(2020, 2, 17, 11, 56, 12, 195, DateTimeKind.Local).AddTicks(2736), 5, 60, 3, 400m, 7m },
                    { 69, new DateTime(2020, 3, 3, 6, 53, 54, 392, DateTimeKind.Local).AddTicks(7403), 9, 63, 3, 931m, 57m },
                    { 32, new DateTime(2020, 5, 7, 5, 50, 23, 422, DateTimeKind.Local).AddTicks(193), 10, 56, 2, 939m, 90m },
                    { 95, new DateTime(2020, 4, 27, 9, 17, 35, 376, DateTimeKind.Local).AddTicks(7219), 4, 85, 2, 264m, 2m },
                    { 86, new DateTime(2020, 6, 15, 13, 56, 36, 553, DateTimeKind.Local).AddTicks(4765), 6, 12, 2, 597m, 8m },
                    { 93, new DateTime(2019, 12, 10, 13, 46, 24, 551, DateTimeKind.Local).AddTicks(826), 10, 12, 3, 597m, 40m },
                    { 21, new DateTime(2020, 10, 1, 10, 31, 49, 561, DateTimeKind.Local).AddTicks(8179), 9, 95, 1, 727m, 33m },
                    { 82, new DateTime(2020, 5, 7, 0, 50, 9, 310, DateTimeKind.Local).AddTicks(4265), 9, 55, 3, 514m, 85m },
                    { 20, new DateTime(2020, 2, 17, 6, 15, 3, 342, DateTimeKind.Local).AddTicks(1361), 3, 55, 2, 514m, 38m },
                    { 71, new DateTime(2020, 5, 4, 10, 18, 52, 193, DateTimeKind.Local).AddTicks(6744), 9, 95, 1, 727m, 35m },
                    { 16, new DateTime(2020, 5, 28, 17, 14, 45, 883, DateTimeKind.Local).AddTicks(8036), 8, 33, 2, 396m, 6m },
                    { 100, new DateTime(2020, 2, 9, 21, 26, 43, 48, DateTimeKind.Local).AddTicks(9276), 4, 14, 2, 103m, 29m },
                    { 89, new DateTime(2020, 3, 10, 20, 7, 33, 589, DateTimeKind.Local).AddTicks(5931), 2, 3, 3, 225m, 24m },
                    { 8, new DateTime(2020, 5, 30, 17, 23, 31, 882, DateTimeKind.Local).AddTicks(5601), 3, 3, 1, 225m, 90m },
                    { 4, new DateTime(2020, 2, 25, 22, 14, 25, 983, DateTimeKind.Local).AddTicks(3902), 10, 49, 2, 444m, 22m },
                    { 63, new DateTime(2019, 12, 12, 17, 29, 38, 498, DateTimeKind.Local).AddTicks(1537), 4, 58, 3, 117m, 98m },
                    { 50, new DateTime(2020, 2, 16, 1, 4, 30, 570, DateTimeKind.Local).AddTicks(3299), 7, 94, 1, 224m, 4m },
                    { 36, new DateTime(2019, 12, 8, 1, 8, 31, 345, DateTimeKind.Local).AddTicks(5278), 4, 32, 1, 392m, 68m },
                    { 31, new DateTime(2020, 2, 1, 15, 17, 8, 314, DateTimeKind.Local).AddTicks(7182), 9, 61, 1, 743m, 52m },
                    { 96, new DateTime(2020, 4, 10, 0, 35, 41, 838, DateTimeKind.Local).AddTicks(1247), 1, 61, 2, 743m, 36m },
                    { 99, new DateTime(2020, 4, 30, 1, 10, 13, 865, DateTimeKind.Local).AddTicks(9132), 5, 29, 3, 93m, 19m },
                    { 53, new DateTime(2020, 4, 13, 0, 24, 37, 593, DateTimeKind.Local).AddTicks(6887), 7, 63, 2, 931m, 65m },
                    { 19, new DateTime(2020, 5, 12, 19, 47, 53, 156, DateTimeKind.Local).AddTicks(436), 8, 63, 2, 931m, 14m },
                    { 2, new DateTime(2020, 10, 21, 23, 3, 27, 951, DateTimeKind.Local).AddTicks(592), 3, 63, 1, 931m, 87m },
                    { 38, new DateTime(2020, 7, 13, 12, 33, 49, 576, DateTimeKind.Local).AddTicks(2713), 3, 64, 2, 37m, 48m },
                    { 9, new DateTime(2020, 4, 13, 11, 9, 51, 966, DateTimeKind.Local).AddTicks(9406), 2, 47, 2, 308m, 66m },
                    { 56, new DateTime(2019, 12, 7, 5, 50, 36, 13, DateTimeKind.Local).AddTicks(4618), 8, 64, 1, 37m, 54m },
                    { 22, new DateTime(2020, 4, 28, 16, 46, 25, 531, DateTimeKind.Local).AddTicks(8910), 9, 73, 3, 477m, 35m },
                    { 25, new DateTime(2020, 6, 21, 0, 15, 56, 561, DateTimeKind.Local).AddTicks(287), 6, 43, 2, 550m, 51m },
                    { 51, new DateTime(2020, 2, 26, 19, 53, 13, 535, DateTimeKind.Local).AddTicks(6377), 10, 29, 3, 93m, 22m },
                    { 74, new DateTime(2020, 11, 18, 2, 9, 26, 763, DateTimeKind.Local).AddTicks(3205), 3, 42, 2, 1000m, 61m },
                    { 24, new DateTime(2020, 1, 13, 4, 0, 8, 771, DateTimeKind.Local).AddTicks(3928), 10, 29, 3, 93m, 3m },
                    { 12, new DateTime(2020, 2, 21, 3, 35, 34, 122, DateTimeKind.Local).AddTicks(9030), 10, 23, 2, 647m, 45m },
                    { 75, new DateTime(2020, 5, 24, 7, 30, 7, 674, DateTimeKind.Local).AddTicks(4556), 1, 87, 2, 413m, 4m },
                    { 17, new DateTime(2020, 8, 16, 10, 15, 12, 970, DateTimeKind.Local).AddTicks(6429), 5, 26, 1, 800m, 97m },
                    { 28, new DateTime(2020, 6, 16, 20, 56, 23, 509, DateTimeKind.Local).AddTicks(6510), 7, 26, 3, 800m, 83m },
                    { 37, new DateTime(2020, 9, 30, 11, 9, 2, 608, DateTimeKind.Local).AddTicks(5280), 4, 26, 2, 800m, 36m },
                    { 81, new DateTime(2020, 2, 27, 13, 52, 51, 267, DateTimeKind.Local).AddTicks(3517), 6, 26, 3, 800m, 29m },
                    { 45, new DateTime(2019, 12, 5, 23, 57, 42, 960, DateTimeKind.Local).AddTicks(6836), 7, 93, 2, 36m, 38m },
                    { 55, new DateTime(2020, 7, 10, 5, 56, 35, 955, DateTimeKind.Local).AddTicks(9876), 4, 31, 1, 448m, 51m },
                    { 68, new DateTime(2020, 4, 16, 3, 17, 10, 898, DateTimeKind.Local).AddTicks(1884), 1, 16, 3, 625m, 91m },
                    { 3, new DateTime(2019, 12, 1, 10, 55, 45, 573, DateTimeKind.Local).AddTicks(3014), 3, 16, 3, 625m, 93m },
                    { 1, new DateTime(2020, 5, 24, 10, 58, 3, 354, DateTimeKind.Local).AddTicks(7710), 4, 41, 1, 624m, 11m },
                    { 7, new DateTime(2020, 2, 12, 20, 49, 33, 369, DateTimeKind.Local).AddTicks(6505), 4, 41, 1, 624m, 74m },
                    { 46, new DateTime(2020, 3, 16, 21, 37, 21, 455, DateTimeKind.Local).AddTicks(1211), 4, 41, 3, 624m, 11m },
                    { 54, new DateTime(2020, 10, 1, 8, 5, 25, 5, DateTimeKind.Local).AddTicks(7200), 4, 41, 1, 624m, 88m },
                    { 73, new DateTime(2020, 8, 1, 3, 18, 58, 769, DateTimeKind.Local).AddTicks(2187), 4, 100, 1, 582m, 73m },
                    { 78, new DateTime(2020, 5, 9, 17, 57, 30, 999, DateTimeKind.Local).AddTicks(2015), 3, 99, 3, 230m, 80m },
                    { 76, new DateTime(2020, 1, 22, 10, 1, 6, 872, DateTimeKind.Local).AddTicks(5160), 7, 99, 2, 230m, 8m },
                    { 67, new DateTime(2020, 7, 13, 16, 2, 4, 31, DateTimeKind.Local).AddTicks(3792), 10, 99, 1, 230m, 35m },
                    { 5, new DateTime(2020, 3, 28, 17, 56, 21, 652, DateTimeKind.Local).AddTicks(5649), 8, 99, 1, 230m, 68m },
                    { 77, new DateTime(2020, 3, 30, 22, 56, 22, 668, DateTimeKind.Local).AddTicks(6745), 2, 17, 3, 755m, 22m },
                    { 13, new DateTime(2020, 8, 14, 3, 23, 51, 309, DateTimeKind.Local).AddTicks(524), 9, 50, 3, 608m, 31m },
                    { 57, new DateTime(2019, 11, 25, 2, 55, 50, 975, DateTimeKind.Local).AddTicks(960), 1, 34, 3, 932m, 34m },
                    { 59, new DateTime(2020, 7, 27, 1, 12, 8, 724, DateTimeKind.Local).AddTicks(2724), 3, 86, 2, 483m, 26m },
                    { 42, new DateTime(2019, 12, 10, 5, 36, 22, 813, DateTimeKind.Local).AddTicks(6233), 6, 48, 3, 483m, 34m },
                    { 70, new DateTime(2019, 12, 9, 13, 29, 41, 795, DateTimeKind.Local).AddTicks(4268), 5, 88, 2, 160m, 31m },
                    { 26, new DateTime(2020, 3, 28, 9, 24, 23, 529, DateTimeKind.Local).AddTicks(7285), 10, 88, 2, 160m, 20m },
                    { 72, new DateTime(2019, 12, 17, 8, 55, 0, 571, DateTimeKind.Local).AddTicks(7584), 7, 69, 2, 537m, 19m },
                    { 52, new DateTime(2020, 3, 10, 23, 44, 9, 810, DateTimeKind.Local).AddTicks(2356), 8, 65, 2, 478m, 95m },
                    { 44, new DateTime(2020, 8, 22, 8, 5, 2, 392, DateTimeKind.Local).AddTicks(6059), 3, 80, 1, 742m, 54m },
                    { 41, new DateTime(2020, 7, 2, 20, 21, 5, 499, DateTimeKind.Local).AddTicks(98), 2, 23, 3, 647m, 91m },
                    { 94, new DateTime(2019, 12, 7, 11, 3, 40, 82, DateTimeKind.Local).AddTicks(9789), 3, 78, 2, 985m, 96m },
                    { 43, new DateTime(2020, 8, 30, 6, 17, 48, 790, DateTimeKind.Local).AddTicks(16), 8, 25, 3, 825m, 94m },
                    { 60, new DateTime(2020, 9, 15, 19, 47, 31, 613, DateTimeKind.Local).AddTicks(3723), 6, 25, 2, 825m, 91m },
                    { 79, new DateTime(2019, 12, 7, 16, 57, 29, 587, DateTimeKind.Local).AddTicks(6336), 1, 77, 3, 100m, 97m },
                    { 18, new DateTime(2020, 4, 4, 9, 55, 39, 174, DateTimeKind.Local).AddTicks(720), 2, 89, 2, 107m, 66m },
                    { 62, new DateTime(2020, 6, 29, 11, 46, 38, 340, DateTimeKind.Local).AddTicks(7718), 4, 1, 2, 898m, 84m },
                    { 58, new DateTime(2020, 10, 28, 7, 40, 38, 74, DateTimeKind.Local).AddTicks(8588), 5, 1, 2, 898m, 97m },
                    { 10, new DateTime(2020, 7, 11, 6, 55, 14, 165, DateTimeKind.Local).AddTicks(7134), 3, 1, 1, 898m, 92m },
                    { 49, new DateTime(2020, 1, 24, 22, 50, 20, 491, DateTimeKind.Local).AddTicks(2785), 1, 89, 1, 107m, 52m },
                    { 27, new DateTime(2020, 9, 6, 21, 7, 41, 80, DateTimeKind.Local).AddTicks(9510), 8, 97, 1, 788m, 29m },
                    { 47, new DateTime(2020, 11, 4, 8, 32, 16, 790, DateTimeKind.Local).AddTicks(1789), 1, 90, 3, 414m, 72m },
                    { 14, new DateTime(2020, 4, 21, 14, 57, 56, 47, DateTimeKind.Local).AddTicks(8636), 3, 90, 1, 414m, 15m },
                    { 23, new DateTime(2020, 11, 19, 16, 45, 38, 985, DateTimeKind.Local).AddTicks(3319), 7, 71, 2, 83m, 96m },
                    { 87, new DateTime(2020, 7, 6, 5, 26, 23, 733, DateTimeKind.Local).AddTicks(9918), 4, 92, 1, 703m, 71m },
                    { 98, new DateTime(2020, 5, 16, 21, 58, 44, 323, DateTimeKind.Local).AddTicks(1986), 10, 92, 1, 703m, 72m },
                    { 92, new DateTime(2020, 8, 11, 17, 46, 20, 350, DateTimeKind.Local).AddTicks(4147), 5, 42, 3, 1000m, 52m },
                    { 91, new DateTime(2019, 11, 28, 5, 22, 53, 154, DateTimeKind.Local).AddTicks(7677), 9, 42, 3, 1000m, 8m },
                    { 30, new DateTime(2020, 1, 22, 18, 43, 20, 882, DateTimeKind.Local).AddTicks(1750), 6, 29, 2, 93m, 13m },
                    { 80, new DateTime(2020, 7, 13, 9, 41, 2, 901, DateTimeKind.Local).AddTicks(5363), 5, 42, 1, 1000m, 25m },
                    { 35, new DateTime(2020, 9, 20, 12, 49, 0, 184, DateTimeKind.Local).AddTicks(1267), 9, 40, 1, 872m, 59m },
                    { 11, new DateTime(2020, 10, 26, 18, 55, 50, 444, DateTimeKind.Local).AddTicks(7160), 2, 40, 2, 872m, 81m },
                    { 6, new DateTime(2020, 5, 2, 12, 1, 14, 456, DateTimeKind.Local).AddTicks(3983), 9, 40, 1, 872m, 35m },
                    { 29, new DateTime(2020, 1, 28, 20, 56, 55, 893, DateTimeKind.Local).AddTicks(3820), 5, 11, 1, 355m, 9m },
                    { 83, new DateTime(2020, 7, 28, 17, 44, 42, 327, DateTimeKind.Local).AddTicks(1282), 5, 11, 1, 355m, 35m },
                    { 15, new DateTime(2020, 6, 11, 18, 9, 46, 106, DateTimeKind.Local).AddTicks(2586), 6, 46, 3, 682m, 74m },
                    { 90, new DateTime(2020, 5, 29, 21, 44, 51, 8, DateTimeKind.Local).AddTicks(6677), 8, 46, 2, 682m, 65m },
                    { 48, new DateTime(2020, 11, 10, 9, 9, 59, 42, DateTimeKind.Local).AddTicks(9667), 9, 37, 2, 548m, 97m },
                    { 33, new DateTime(2020, 4, 13, 10, 27, 32, 289, DateTimeKind.Local).AddTicks(7069), 9, 20, 2, 180m, 70m },
                    { 40, new DateTime(2019, 12, 6, 19, 18, 16, 766, DateTimeKind.Local).AddTicks(7241), 10, 52, 2, 53m, 47m },
                    { 88, new DateTime(2020, 11, 4, 6, 19, 58, 425, DateTimeKind.Local).AddTicks(257), 6, 20, 2, 180m, 47m },
                    { 97, new DateTime(2020, 3, 28, 7, 14, 55, 374, DateTimeKind.Local).AddTicks(6359), 2, 70, 3, 812m, 59m },
                    { 84, new DateTime(2020, 9, 22, 14, 40, 52, 690, DateTimeKind.Local).AddTicks(5493), 4, 28, 1, 520m, 8m },
                    { 65, new DateTime(2020, 3, 11, 16, 30, 54, 797, DateTimeKind.Local).AddTicks(476), 5, 78, 1, 985m, 81m },
                    { 61, new DateTime(2020, 6, 20, 14, 14, 38, 286, DateTimeKind.Local).AddTicks(4549), 4, 83, 1, 580m, 89m },
                    { 34, new DateTime(2020, 9, 6, 20, 20, 44, 125, DateTimeKind.Local).AddTicks(8005), 5, 56, 1, 939m, 74m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achats_IdFournisseur",
                table: "Achats",
                column: "IdFournisseur");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdSousCategorie",
                table: "Articles",
                column: "IdSousCategorie");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_IdClient",
                table: "Commandes",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_DetailCmds_IdCommande",
                table: "DetailCmds",
                column: "IdCommande");

            migrationBuilder.CreateIndex(
                name: "IX_DevisAcrticles_IdArticle",
                table: "DevisAcrticles",
                column: "IdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_DevisAcrticles_IdDevis",
                table: "DevisAcrticles",
                column: "IdDevis");

            migrationBuilder.CreateIndex(
                name: "IX_Fournitures_IdAchat",
                table: "Fournitures",
                column: "IdAchat");

            migrationBuilder.CreateIndex(
                name: "IX_Fournitures_IdArticle",
                table: "Fournitures",
                column: "IdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_Fournitures_IdFournisseur",
                table: "Fournitures",
                column: "IdFournisseur");

            migrationBuilder.CreateIndex(
                name: "IX_SousCategories_IdCategorie",
                table: "SousCategories",
                column: "IdCategorie");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                column: "IdRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailCmds");

            migrationBuilder.DropTable(
                name: "DevisAcrticles");

            migrationBuilder.DropTable(
                name: "Fournitures");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Deviss");

            migrationBuilder.DropTable(
                name: "Achats");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "SousCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
