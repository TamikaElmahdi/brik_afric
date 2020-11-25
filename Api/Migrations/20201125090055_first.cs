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
                    { 21, null, null, "", "Maxence", null, "(+212)6 77 42-40-40" },
                    { 20, null, null, "", "Mathis", null, "(+212)6 37 63-30-94" },
                    { 19, null, null, "", "Thomas", null, "(+212)6 09 94-17-30" },
                    { 18, null, null, "", "Pauline", null, "(+212)6 57 69-91-46" },
                    { 17, null, null, "", "Adrien", null, "(+212)6 55 38-08-74" },
                    { 16, null, null, "", "Emilie", null, "(+212)6 88 45-30-89" },
                    { 15, null, null, "", "Léo", null, "(+212)6 64 11-53-54" },
                    { 14, null, null, "", "Maëlys", null, "(+212)6 30 41-93-99" },
                    { 13, null, null, "", "Alexis", null, "(+212)6 04 77-23-88" },
                    { 12, null, null, "", "Alicia", null, "(+212)6 85 39-05-25" },
                    { 11, null, null, "", "Mattéo", null, "(+212)6 36 19-65-78" },
                    { 10, null, null, "", "Maxime", null, "(+212)6 75 15-60-99" },
                    { 9, null, null, "", "Laura", null, "(+212)6 48 62-25-35" },
                    { 8, null, null, "", "Rayan", null, "(+212)6 60 19-23-27" },
                    { 7, null, null, "", "Célia", null, "(+212)6 79 25-80-53" },
                    { 6, null, null, "", "Mélissa", null, "(+212)6 46 23-30-00" },
                    { 5, null, null, "", "Sarah", null, "(+212)6 19 92-91-40" },
                    { 4, null, null, "", "Carla", null, "(+212)6 94 56-07-62" },
                    { 3, null, null, "", "Pierre", null, "(+212)6 05 47-63-97" },
                    { 2, null, null, "", "Antoine", null, "(+212)6 71 69-58-97" },
                    { 1, null, null, "00", "Client caisse 1", null, "00" }
                });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Nom", "Prenom", "Societe", "Telephone" },
                values: new object[,]
                {
                    { 1, "Hugo", "Da silva", "Guillaume - Bonnet", "(+212)6 46 30-28-30" },
                    { 2, "Elisa", "Julien", "Gonzalez GIE", "(+212)6 43 38-91-69" },
                    { 3, "Théo", "Mercier", "Le roux - Poirier", "(+212)6 63 40-96-67" }
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
                    { 4, 0m, 0m, new DateTime(2020, 10, 5, 18, 17, 28, 871, DateTimeKind.Local).AddTicks(5554), 3, "crédit", 45567m, "" },
                    { 7, 0m, 0m, new DateTime(2020, 5, 31, 17, 16, 54, 552, DateTimeKind.Local).AddTicks(1396), 1, "chèque", 30488m, "" },
                    { 8, 0m, 0m, new DateTime(2020, 4, 20, 3, 8, 59, 178, DateTimeKind.Local).AddTicks(7807), 1, "chèque", 1245m, "" },
                    { 9, 0m, 0m, new DateTime(2020, 4, 3, 23, 53, 0, 835, DateTimeKind.Local).AddTicks(9548), 1, "éspece", 3404m, "" },
                    { 10, 0m, 0m, new DateTime(2020, 7, 21, 19, 33, 16, 333, DateTimeKind.Local).AddTicks(1120), 1, "éspece", 5094m, "" },
                    { 2, 0m, 0m, new DateTime(2020, 6, 23, 21, 23, 22, 312, DateTimeKind.Local).AddTicks(8944), 1, "éspece", 32230m, "" },
                    { 6, 0m, 0m, new DateTime(2019, 12, 5, 12, 24, 9, 227, DateTimeKind.Local).AddTicks(4106), 2, "chèque", 44340m, "" },
                    { 1, 0m, 0m, new DateTime(2020, 4, 2, 23, 17, 12, 537, DateTimeKind.Local).AddTicks(1715), 3, "crédit", 25398m, "" },
                    { 3, 0m, 0m, new DateTime(2020, 7, 8, 17, 12, 54, 175, DateTimeKind.Local).AddTicks(5716), 3, "crédit", 72252m, "" },
                    { 5, 0m, 0m, new DateTime(2020, 9, 13, 7, 24, 24, 664, DateTimeKind.Local).AddTicks(4405), 2, "chèque", 36090m, "" }
                });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[,]
                {
                    { 7, 0m, 0m, new DateTime(2020, 5, 31, 9, 41, 31, 331, DateTimeKind.Local).AddTicks(1078), 2, "chèque", "", "", "00:00", 1216m },
                    { 8, 0m, 0m, new DateTime(2020, 2, 14, 1, 43, 19, 729, DateTimeKind.Local).AddTicks(2860), 1, "chèque", "", "", "00:00", 5053m },
                    { 9, 0m, 0m, new DateTime(2020, 7, 19, 17, 49, 37, 912, DateTimeKind.Local).AddTicks(6034), 1, "crédit", "", "", "00:00", 41581m },
                    { 10, 0m, 0m, new DateTime(2020, 10, 12, 21, 44, 27, 76, DateTimeKind.Local).AddTicks(9460), 1, "éspece", "", "", "00:00", 17457m },
                    { 12, 0m, 0m, new DateTime(2020, 2, 21, 3, 39, 22, 76, DateTimeKind.Local).AddTicks(353), 1, "crédit", "", "", "00:00", 62792m },
                    { 15, 0m, 0m, new DateTime(2020, 1, 31, 5, 48, 37, 432, DateTimeKind.Local).AddTicks(2837), 1, "chèque", "", "", "00:00", 6942m },
                    { 16, 0m, 0m, new DateTime(2020, 2, 14, 23, 17, 8, 990, DateTimeKind.Local).AddTicks(5745), 1, "éspece", "", "", "00:00", 902m },
                    { 18, 0m, 0m, new DateTime(2020, 1, 6, 19, 8, 11, 319, DateTimeKind.Local).AddTicks(1460), 1, "chèque", "", "", "00:00", 63388m },
                    { 2, 0m, 0m, new DateTime(2020, 5, 15, 13, 21, 27, 676, DateTimeKind.Local).AddTicks(8366), 2, "chèque", "", "", "00:00", 6683m },
                    { 17, 0m, 0m, new DateTime(2020, 7, 17, 14, 11, 55, 447, DateTimeKind.Local).AddTicks(3796), 2, "éspece", "", "", "00:00", 3501m },
                    { 3, 0m, 0m, new DateTime(2020, 2, 3, 22, 11, 43, 589, DateTimeKind.Local).AddTicks(9773), 3, "chèque", "", "", "00:00", 798m },
                    { 1, 0m, 0m, new DateTime(2020, 7, 31, 2, 27, 31, 294, DateTimeKind.Local).AddTicks(1101), 3, "éspece", "", "", "00:00", 10846m },
                    { 4, 0m, 0m, new DateTime(2020, 8, 7, 12, 19, 11, 517, DateTimeKind.Local).AddTicks(9811), 3, "chèque", "", "", "00:00", 8602m },
                    { 5, 0m, 0m, new DateTime(2020, 9, 21, 2, 32, 12, 501, DateTimeKind.Local).AddTicks(1489), 3, "chèque", "", "", "00:00", 27222m },
                    { 6, 0m, 0m, new DateTime(2020, 5, 29, 20, 36, 45, 736, DateTimeKind.Local).AddTicks(6717), 3, "crédit", "", "", "00:00", 912m },
                    { 11, 0m, 0m, new DateTime(2020, 6, 9, 12, 34, 50, 417, DateTimeKind.Local).AddTicks(3749), 3, "crédit", "", "", "00:00", 12232m },
                    { 13, 0m, 0m, new DateTime(2020, 11, 7, 14, 18, 34, 276, DateTimeKind.Local).AddTicks(8802), 3, "éspece", "", "", "00:00", 30624m },
                    { 14, 0m, 0m, new DateTime(2020, 9, 18, 15, 38, 52, 520, DateTimeKind.Local).AddTicks(7138), 3, "crédit", "", "", "00:00", 12692m },
                    { 19, 0m, 0m, new DateTime(2020, 2, 8, 0, 3, 43, 424, DateTimeKind.Local).AddTicks(9459), 3, "crédit", "", "", "00:00", 18914m },
                    { 20, 0m, 0m, new DateTime(2020, 1, 14, 8, 27, 33, 895, DateTimeKind.Local).AddTicks(9108), 2, "éspece", "", "", "00:00", 53312m }
                });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[,]
                {
                    { 26, 6, "Jeanne" },
                    { 36, 6, "Léa" },
                    { 35, 6, "Léa" },
                    { 31, 6, "Léa" },
                    { 27, 6, "Enzo" },
                    { 1, 1, "Generale" },
                    { 25, 6, "Camille" },
                    { 41, 5, "Noémie" },
                    { 23, 3, "Axel" },
                    { 21, 3, "Juliette" },
                    { 11, 3, "Mélissa" },
                    { 4, 3, "Clara" },
                    { 3, 3, "Adrien" },
                    { 2, 3, "Noa" },
                    { 37, 3, "Clara" },
                    { 33, 2, "Sarah" },
                    { 34, 1, "Arthur" },
                    { 24, 1, "Maeva" },
                    { 19, 1, "Paul" },
                    { 10, 1, "Louis" },
                    { 9, 1, "Lucas" },
                    { 5, 1, "Gabriel" },
                    { 22, 2, "Mael" },
                    { 6, 6, "Mathéo" },
                    { 39, 3, "Mathis" },
                    { 12, 4, "Célia" },
                    { 30, 5, "Rayan" },
                    { 29, 5, "Justine" },
                    { 28, 5, "Axel" },
                    { 16, 5, "Rayan" },
                    { 13, 5, "Hugo" },
                    { 8, 5, "Ines" },
                    { 7, 4, "Marie" },
                    { 40, 4, "Mattéo" },
                    { 32, 4, "Enzo" },
                    { 20, 4, "Océane" },
                    { 18, 4, "Clément" },
                    { 17, 4, "Julie" },
                    { 15, 4, "Mael" },
                    { 14, 4, "Lou" },
                    { 38, 4, "Valentin" }
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
                    { 13, false, "Code-13", "Constructeur1", new DateTime(2020, 10, 10, 8, 48, 21, 785, DateTimeKind.Local).AddTicks(1006), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 528m, -190m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-13", "titre long pour un produit avec la nature de super hasardouze-13", "L" },
                    { 68, false, "Code-68", "Constructeur1", new DateTime(2020, 7, 6, 7, 46, 35, 761, DateTimeKind.Local).AddTicks(9899), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 212m, -131m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-68", "titre long pour un produit avec la nature de super hasardouze-68", "U" },
                    { 34, false, "Code-34", "Constructeur1", new DateTime(2020, 10, 8, 10, 35, 21, 472, DateTimeKind.Local).AddTicks(9946), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 204m, -73m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-34", "titre long pour un produit avec la nature de super hasardouze-34", "L" },
                    { 97, true, "Code-97", "Constructeur3", new DateTime(2020, 3, 24, 0, 46, 49, 303, DateTimeKind.Local).AddTicks(8614), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 166m, -117m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-97", "titre long pour un produit avec la nature de super hasardouze-97", "L" },
                    { 91, true, "Code-91", "Constructeur1", new DateTime(2020, 8, 1, 3, 0, 41, 254, DateTimeKind.Local).AddTicks(3449), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 530m, -112m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-91", "titre long pour un produit avec la nature de super hasardouze-91", "L" },
                    { 84, false, "Code-84", "Constructeur1", new DateTime(2020, 2, 9, 11, 24, 37, 793, DateTimeKind.Local).AddTicks(7943), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 730m, -179m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-84", "titre long pour un produit avec la nature de super hasardouze-84", "U" },
                    { 83, true, "Code-83", "Constructeur2", new DateTime(2020, 5, 12, 1, 18, 48, 127, DateTimeKind.Local).AddTicks(9345), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 637m, -214m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-83", "titre long pour un produit avec la nature de super hasardouze-83", "Kg" },
                    { 78, false, "Code-78", "Constructeur2", new DateTime(2020, 8, 13, 4, 34, 50, 185, DateTimeKind.Local).AddTicks(9283), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 729m, -473m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-78", "titre long pour un produit avec la nature de super hasardouze-78", "L" },
                    { 74, false, "Code-74", "Constructeur1", new DateTime(2019, 12, 24, 4, 14, 36, 604, DateTimeKind.Local).AddTicks(2986), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 334m, -183m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-74", "titre long pour un produit avec la nature de super hasardouze-74", "L" },
                    { 65, false, "Code-65", "Constructeur3", new DateTime(2020, 7, 23, 11, 47, 23, 470, DateTimeKind.Local).AddTicks(326), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 503m, -405m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-65", "titre long pour un produit avec la nature de super hasardouze-65", "Kg" },
                    { 62, false, "Code-62", "Constructeur2", new DateTime(2020, 8, 15, 20, 0, 53, 126, DateTimeKind.Local).AddTicks(9838), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 106m, 25m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-62", "titre long pour un produit avec la nature de super hasardouze-62", "U" },
                    { 51, false, "Code-51", "Constructeur2", new DateTime(2020, 9, 25, 0, 41, 47, 231, DateTimeKind.Local).AddTicks(1887), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 647m, -318m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-51", "titre long pour un produit avec la nature de super hasardouze-51", "L" },
                    { 45, false, "Code-45", "Constructeur1", new DateTime(2020, 4, 16, 17, 55, 0, 118, DateTimeKind.Local).AddTicks(8635), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 873m, -233m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-45", "titre long pour un produit avec la nature de super hasardouze-45", "Kg" },
                    { 30, false, "Code-30", "Constructeur1", new DateTime(2019, 11, 27, 3, 3, 20, 925, DateTimeKind.Local).AddTicks(4966), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 967m, -248m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-30", "titre long pour un produit avec la nature de super hasardouze-30", "L" },
                    { 19, false, "Code-19", "Constructeur1", new DateTime(2020, 4, 28, 4, 3, 42, 711, DateTimeKind.Local).AddTicks(8885), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 973m, -244m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-19", "titre long pour un produit avec la nature de super hasardouze-19", "Kg" },
                    { 18, false, "Code-18", "Constructeur2", new DateTime(2020, 10, 27, 20, 16, 17, 272, DateTimeKind.Local).AddTicks(8065), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 358m, -289m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-18", "titre long pour un produit avec la nature de super hasardouze-18", "L" },
                    { 5, false, "Code-5", "Constructeur3", new DateTime(2020, 4, 25, 9, 48, 46, 815, DateTimeKind.Local).AddTicks(4960), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 566m, -447m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-5", "titre long pour un produit avec la nature de super hasardouze-5", "L" },
                    { 98, false, "Code-98", "Constructeur2", new DateTime(2020, 6, 23, 0, 27, 1, 59, DateTimeKind.Local).AddTicks(4510), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 851m, -288m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-98", "titre long pour un produit avec la nature de super hasardouze-98", "U" },
                    { 71, false, "Code-71", "Constructeur1", new DateTime(2019, 12, 6, 2, 45, 6, 952, DateTimeKind.Local).AddTicks(5524), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 465m, -403m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-71", "titre long pour un produit avec la nature de super hasardouze-71", "L" },
                    { 55, false, "Code-55", "Constructeur2", new DateTime(2019, 12, 18, 12, 47, 54, 994, DateTimeKind.Local).AddTicks(1710), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 892m, -205m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-55", "titre long pour un produit avec la nature de super hasardouze-55", "L" },
                    { 54, false, "Code-54", "Constructeur1", new DateTime(2020, 6, 28, 2, 26, 17, 122, DateTimeKind.Local).AddTicks(5505), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 386m, -213m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-54", "titre long pour un produit avec la nature de super hasardouze-54", "L" },
                    { 36, false, "Code-36", "Constructeur2", new DateTime(2019, 12, 11, 11, 56, 19, 3, DateTimeKind.Local).AddTicks(364), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 92m, -201m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-36", "titre long pour un produit avec la nature de super hasardouze-36", "U" },
                    { 70, false, "Code-70", "Constructeur3", new DateTime(2020, 1, 14, 16, 1, 15, 36, DateTimeKind.Local).AddTicks(1455), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 890m, -134m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-70", "titre long pour un produit avec la nature de super hasardouze-70", "U" },
                    { 27, false, "Code-27", "Constructeur2", new DateTime(2020, 2, 29, 8, 43, 45, 501, DateTimeKind.Local).AddTicks(1032), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 148m, -577m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-27", "titre long pour un produit avec la nature de super hasardouze-27", "L" },
                    { 73, false, "Code-73", "Constructeur3", new DateTime(2020, 1, 11, 12, 32, 48, 741, DateTimeKind.Local).AddTicks(5122), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 37m, -245m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-73", "titre long pour un produit avec la nature de super hasardouze-73", "U" },
                    { 86, false, "Code-86", "Constructeur3", new DateTime(2020, 4, 9, 15, 46, 34, 584, DateTimeKind.Local).AddTicks(8354), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 96m, -300m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-86", "titre long pour un produit avec la nature de super hasardouze-86", "Kg" },
                    { 72, false, "Code-72", "Constructeur3", new DateTime(2020, 5, 7, 10, 35, 38, 103, DateTimeKind.Local).AddTicks(8438), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 479m, -250m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-72", "titre long pour un produit avec la nature de super hasardouze-72", "U" },
                    { 66, false, "Code-66", "Constructeur3", new DateTime(2020, 10, 26, 1, 19, 37, 443, DateTimeKind.Local).AddTicks(5793), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 412m, 99m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-66", "titre long pour un produit avec la nature de super hasardouze-66", "U" },
                    { 61, false, "Code-61", "Constructeur1", new DateTime(2020, 11, 7, 1, 53, 33, 545, DateTimeKind.Local).AddTicks(5116), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 389m, -113m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-61", "titre long pour un produit avec la nature de super hasardouze-61", "U" },
                    { 60, false, "Code-60", "Constructeur1", new DateTime(2020, 4, 7, 1, 13, 54, 373, DateTimeKind.Local).AddTicks(602), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 183m, -253m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-60", "titre long pour un produit avec la nature de super hasardouze-60", "Kg" },
                    { 58, false, "Code-58", "Constructeur2", new DateTime(2020, 9, 24, 11, 19, 17, 118, DateTimeKind.Local).AddTicks(4062), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 78m, -308m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-58", "titre long pour un produit avec la nature de super hasardouze-58", "Kg" },
                    { 50, false, "Code-50", "Constructeur2", new DateTime(2020, 6, 21, 5, 4, 27, 811, DateTimeKind.Local).AddTicks(2500), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 747m, -127m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-50", "titre long pour un produit avec la nature de super hasardouze-50", "L" },
                    { 93, true, "Code-93", "Constructeur3", new DateTime(2020, 6, 9, 10, 50, 35, 380, DateTimeKind.Local).AddTicks(9327), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 163m, -282m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-93", "titre long pour un produit avec la nature de super hasardouze-93", "Kg" },
                    { 82, false, "Code-82", "Constructeur2", new DateTime(2020, 5, 8, 12, 51, 45, 511, DateTimeKind.Local).AddTicks(7701), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 955m, -155m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-82", "titre long pour un produit avec la nature de super hasardouze-82", "Kg" },
                    { 79, false, "Code-79", "Constructeur3", new DateTime(2019, 12, 26, 18, 38, 29, 649, DateTimeKind.Local).AddTicks(3494), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 939m, -317m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-79", "titre long pour un produit avec la nature de super hasardouze-79", "L" },
                    { 75, false, "Code-75", "Constructeur3", new DateTime(2020, 5, 2, 12, 13, 42, 599, DateTimeKind.Local).AddTicks(3478), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 428m, -166m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-75", "titre long pour un produit avec la nature de super hasardouze-75", "L" },
                    { 63, false, "Code-63", "Constructeur1", new DateTime(2020, 11, 6, 9, 38, 15, 756, DateTimeKind.Local).AddTicks(6718), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 40m, -282m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-63", "titre long pour un produit avec la nature de super hasardouze-63", "Kg" },
                    { 42, false, "Code-42", "Constructeur1", new DateTime(2020, 4, 11, 6, 23, 12, 900, DateTimeKind.Local).AddTicks(1272), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 229m, -113m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-42", "titre long pour un produit avec la nature de super hasardouze-42", "Kg" },
                    { 35, false, "Code-35", "Constructeur3", new DateTime(2020, 7, 12, 0, 52, 5, 582, DateTimeKind.Local).AddTicks(8139), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 765m, -409m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-35", "titre long pour un produit avec la nature de super hasardouze-35", "L" },
                    { 31, false, "Code-31", "Constructeur1", new DateTime(2020, 7, 7, 5, 59, 5, 572, DateTimeKind.Local).AddTicks(9135), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 706m, -107m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-31", "titre long pour un produit avec la nature de super hasardouze-31", "L" },
                    { 28, false, "Code-28", "Constructeur2", new DateTime(2020, 7, 24, 16, 20, 43, 941, DateTimeKind.Local).AddTicks(913), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 639m, -138m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-28", "titre long pour un produit avec la nature de super hasardouze-28", "U" },
                    { 17, false, "Code-17", "Constructeur2", new DateTime(2020, 8, 28, 8, 50, 17, 678, DateTimeKind.Local).AddTicks(548), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 127m, -55m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-17", "titre long pour un produit avec la nature de super hasardouze-17", "L" },
                    { 16, false, "Code-16", "Constructeur3", new DateTime(2020, 7, 5, 8, 23, 32, 213, DateTimeKind.Local).AddTicks(2558), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 249m, -326m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-16", "titre long pour un produit avec la nature de super hasardouze-16", "L" },
                    { 4, false, "Code-4", "Constructeur1", new DateTime(2020, 1, 23, 0, 30, 10, 692, DateTimeKind.Local).AddTicks(5060), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 739m, -163m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-4", "titre long pour un produit avec la nature de super hasardouze-4", "Kg" },
                    { 100, false, "Code-100", "Constructeur3", new DateTime(2020, 9, 22, 4, 47, 46, 426, DateTimeKind.Local).AddTicks(5785), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 288m, -184m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-100", "titre long pour un produit avec la nature de super hasardouze-100", "U" },
                    { 99, true, "Code-99", "Constructeur3", new DateTime(2020, 11, 16, 12, 6, 12, 42, DateTimeKind.Local).AddTicks(9501), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 833m, -466m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-99", "titre long pour un produit avec la nature de super hasardouze-99", "Kg" },
                    { 94, false, "Code-94", "Constructeur2", new DateTime(2020, 9, 11, 16, 49, 9, 763, DateTimeKind.Local).AddTicks(3021), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 231m, -442m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-94", "titre long pour un produit avec la nature de super hasardouze-94", "U" },
                    { 77, false, "Code-77", "Constructeur1", new DateTime(2020, 9, 15, 7, 12, 45, 673, DateTimeKind.Local).AddTicks(1008), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 88m, -357m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-77", "titre long pour un produit avec la nature de super hasardouze-77", "U" },
                    { 25, false, "Code-25", "Constructeur3", new DateTime(2020, 5, 9, 2, 12, 8, 427, DateTimeKind.Local).AddTicks(1736), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 401m, -316m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-25", "titre long pour un produit avec la nature de super hasardouze-25", "Kg" },
                    { 20, false, "Code-20", "Constructeur1", new DateTime(2020, 7, 14, 23, 40, 48, 8, DateTimeKind.Local).AddTicks(656), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 657m, -263m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-20", "titre long pour un produit avec la nature de super hasardouze-20", "U" },
                    { 12, false, "Code-12", "Constructeur1", new DateTime(2020, 5, 21, 18, 26, 50, 994, DateTimeKind.Local).AddTicks(4784), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 986m, -380m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-12", "titre long pour un produit avec la nature de super hasardouze-12", "Kg" },
                    { 69, false, "Code-69", "Constructeur1", new DateTime(2020, 10, 30, 0, 42, 24, 986, DateTimeKind.Local).AddTicks(2444), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 844m, -276m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-69", "titre long pour un produit avec la nature de super hasardouze-69", "L" },
                    { 59, false, "Code-59", "Constructeur2", new DateTime(2020, 1, 3, 9, 14, 42, 475, DateTimeKind.Local).AddTicks(8235), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 856m, 75m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-59", "titre long pour un produit avec la nature de super hasardouze-59", "L" },
                    { 52, false, "Code-52", "Constructeur1", new DateTime(2019, 12, 22, 0, 10, 30, 120, DateTimeKind.Local).AddTicks(8705), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 759m, -359m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-52", "titre long pour un produit avec la nature de super hasardouze-52", "U" },
                    { 48, false, "Code-48", "Constructeur3", new DateTime(2020, 4, 1, 14, 2, 3, 42, DateTimeKind.Local).AddTicks(3459), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 11m, -18m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-48", "titre long pour un produit avec la nature de super hasardouze-48", "L" },
                    { 47, false, "Code-47", "Constructeur3", new DateTime(2020, 2, 2, 1, 2, 57, 620, DateTimeKind.Local).AddTicks(5167), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 670m, -233m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-47", "titre long pour un produit avec la nature de super hasardouze-47", "L" },
                    { 39, false, "Code-39", "Constructeur2", new DateTime(2020, 8, 4, 17, 51, 13, 578, DateTimeKind.Local).AddTicks(685), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 859m, -364m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-39", "titre long pour un produit avec la nature de super hasardouze-39", "U" },
                    { 26, false, "Code-26", "Constructeur1", new DateTime(2020, 10, 23, 8, 52, 1, 7, DateTimeKind.Local).AddTicks(5286), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 796m, -225m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-26", "titre long pour un produit avec la nature de super hasardouze-26", "U" },
                    { 8, false, "Code-8", "Constructeur2", new DateTime(2020, 5, 3, 10, 59, 8, 121, DateTimeKind.Local).AddTicks(1872), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 780m, -259m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-8", "titre long pour un produit avec la nature de super hasardouze-8", "U" },
                    { 6, false, "Code-6", "Constructeur3", new DateTime(2020, 5, 6, 10, 30, 30, 191, DateTimeKind.Local).AddTicks(2167), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 623m, -408m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-6", "titre long pour un produit avec la nature de super hasardouze-6", "Kg" },
                    { 3, false, "Code-3", "Constructeur3", new DateTime(2020, 3, 14, 13, 3, 6, 648, DateTimeKind.Local).AddTicks(6973), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 906m, -388m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-3", "titre long pour un produit avec la nature de super hasardouze-3", "U" },
                    { 2, false, "Code-2", "Constructeur3", new DateTime(2020, 2, 26, 18, 13, 59, 960, DateTimeKind.Local).AddTicks(1627), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 247m, -155m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-2", "titre long pour un produit avec la nature de super hasardouze-2", "U" },
                    { 95, true, "Code-95", "Constructeur1", new DateTime(2020, 2, 11, 4, 7, 54, 436, DateTimeKind.Local).AddTicks(9767), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 880m, -385m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-95", "titre long pour un produit avec la nature de super hasardouze-95", "Kg" },
                    { 88, false, "Code-88", "Constructeur1", new DateTime(2020, 4, 3, 8, 56, 57, 232, DateTimeKind.Local).AddTicks(737), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 14m, -359m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-88", "titre long pour un produit avec la nature de super hasardouze-88", "Kg" },
                    { 46, false, "Code-46", "Constructeur1", new DateTime(2020, 5, 20, 20, 59, 3, 48, DateTimeKind.Local).AddTicks(5508), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 612m, -193m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-46", "titre long pour un produit avec la nature de super hasardouze-46", "U" },
                    { 44, false, "Code-44", "Constructeur3", new DateTime(2019, 12, 17, 19, 58, 52, 60, DateTimeKind.Local).AddTicks(4910), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 490m, -211m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-44", "titre long pour un produit avec la nature de super hasardouze-44", "L" },
                    { 38, false, "Code-38", "Constructeur3", new DateTime(2020, 11, 12, 15, 47, 19, 822, DateTimeKind.Local).AddTicks(6910), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 527m, -246m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-38", "titre long pour un produit avec la nature de super hasardouze-38", "U" },
                    { 37, false, "Code-37", "Constructeur3", new DateTime(2020, 10, 11, 2, 24, 5, 829, DateTimeKind.Local).AddTicks(4787), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 307m, -260m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-37", "titre long pour un produit avec la nature de super hasardouze-37", "U" },
                    { 33, false, "Code-33", "Constructeur3", new DateTime(2020, 8, 29, 22, 29, 56, 227, DateTimeKind.Local).AddTicks(4643), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 579m, -199m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-33", "titre long pour un produit avec la nature de super hasardouze-33", "L" },
                    { 32, false, "Code-32", "Constructeur1", new DateTime(2020, 9, 27, 19, 40, 29, 963, DateTimeKind.Local).AddTicks(283), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 39m, -216m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-32", "titre long pour un produit avec la nature de super hasardouze-32", "Kg" },
                    { 29, false, "Code-29", "Constructeur3", new DateTime(2020, 9, 3, 3, 43, 10, 79, DateTimeKind.Local).AddTicks(9900), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 595m, -235m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-29", "titre long pour un produit avec la nature de super hasardouze-29", "U" },
                    { 23, false, "Code-23", "Constructeur2", new DateTime(2020, 8, 18, 5, 32, 52, 971, DateTimeKind.Local).AddTicks(9073), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 586m, -476m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-23", "titre long pour un produit avec la nature de super hasardouze-23", "U" },
                    { 85, true, "Code-85", "Constructeur3", new DateTime(2020, 9, 15, 1, 34, 53, 344, DateTimeKind.Local).AddTicks(1841), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 848m, -158m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-85", "titre long pour un produit avec la nature de super hasardouze-85", "Kg" },
                    { 92, false, "Code-92", "Constructeur1", new DateTime(2020, 3, 18, 4, 15, 50, 673, DateTimeKind.Local).AddTicks(1385), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 624m, -175m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-92", "titre long pour un produit avec la nature de super hasardouze-92", "U" },
                    { 1, false, "Code-1", "Constructeur2", new DateTime(2020, 10, 29, 4, 31, 58, 281, DateTimeKind.Local).AddTicks(8403), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 450m, -277m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-1", "titre long pour un produit avec la nature de super hasardouze-1", "Kg" },
                    { 7, false, "Code-7", "Constructeur3", new DateTime(2020, 6, 24, 12, 37, 39, 482, DateTimeKind.Local).AddTicks(5684), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 802m, -411m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-7", "titre long pour un produit avec la nature de super hasardouze-7", "Kg" },
                    { 96, false, "Code-96", "Constructeur1", new DateTime(2020, 9, 26, 4, 51, 5, 385, DateTimeKind.Local).AddTicks(8695), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 859m, -306m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-96", "titre long pour un produit avec la nature de super hasardouze-96", "U" },
                    { 81, true, "Code-81", "Constructeur2", new DateTime(2020, 5, 13, 13, 49, 9, 643, DateTimeKind.Local).AddTicks(7644), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 554m, -190m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-81", "titre long pour un produit avec la nature de super hasardouze-81", "U" },
                    { 21, false, "Code-21", "Constructeur1", new DateTime(2020, 5, 6, 7, 25, 0, 377, DateTimeKind.Local).AddTicks(3841), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 907m, -270m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-21", "titre long pour un produit avec la nature de super hasardouze-21", "L" },
                    { 11, false, "Code-11", "Constructeur1", new DateTime(2020, 3, 7, 17, 52, 46, 535, DateTimeKind.Local).AddTicks(6814), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 349m, -177m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-11", "titre long pour un produit avec la nature de super hasardouze-11", "L" },
                    { 10, false, "Code-10", "Constructeur1", new DateTime(2020, 4, 14, 3, 42, 48, 73, DateTimeKind.Local).AddTicks(283), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 318m, -294m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-10", "titre long pour un produit avec la nature de super hasardouze-10", "L" },
                    { 9, false, "Code-9", "Constructeur1", new DateTime(2020, 1, 5, 8, 39, 22, 670, DateTimeKind.Local).AddTicks(9110), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 202m, -75m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-9", "titre long pour un produit avec la nature de super hasardouze-9", "U" },
                    { 90, false, "Code-90", "Constructeur2", new DateTime(2020, 8, 14, 14, 26, 47, 91, DateTimeKind.Local).AddTicks(8710), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 955m, -310m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-90", "titre long pour un produit avec la nature de super hasardouze-90", "Kg" },
                    { 87, true, "Code-87", "Constructeur3", new DateTime(2019, 12, 13, 22, 40, 41, 670, DateTimeKind.Local).AddTicks(9964), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 342m, -211m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-87", "titre long pour un produit avec la nature de super hasardouze-87", "L" },
                    { 67, false, "Code-67", "Constructeur2", new DateTime(2020, 2, 27, 0, 17, 34, 959, DateTimeKind.Local).AddTicks(5641), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 139m, -193m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-67", "titre long pour un produit avec la nature de super hasardouze-67", "Kg" },
                    { 57, false, "Code-57", "Constructeur3", new DateTime(2020, 2, 17, 1, 36, 39, 895, DateTimeKind.Local).AddTicks(7286), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 253m, -325m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-57", "titre long pour un produit avec la nature de super hasardouze-57", "L" },
                    { 76, false, "Code-76", "Constructeur1", new DateTime(2020, 5, 26, 19, 2, 55, 289, DateTimeKind.Local).AddTicks(3586), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 22m, -148m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-76", "titre long pour un produit avec la nature de super hasardouze-76", "Kg" },
                    { 56, false, "Code-56", "Constructeur1", new DateTime(2019, 12, 24, 19, 4, 7, 390, DateTimeKind.Local).AddTicks(5165), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 877m, -328m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-56", "titre long pour un produit avec la nature de super hasardouze-56", "Kg" },
                    { 49, false, "Code-49", "Constructeur3", new DateTime(2020, 2, 1, 20, 33, 55, 657, DateTimeKind.Local).AddTicks(6114), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 692m, -417m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-49", "titre long pour un produit avec la nature de super hasardouze-49", "Kg" },
                    { 43, false, "Code-43", "Constructeur3", new DateTime(2020, 10, 28, 7, 10, 51, 694, DateTimeKind.Local).AddTicks(4392), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 880m, -203m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-43", "titre long pour un produit avec la nature de super hasardouze-43", "U" },
                    { 41, false, "Code-41", "Constructeur2", new DateTime(2020, 2, 7, 1, 52, 36, 314, DateTimeKind.Local).AddTicks(3595), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 479m, -236m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-41", "titre long pour un produit avec la nature de super hasardouze-41", "U" },
                    { 40, false, "Code-40", "Constructeur2", new DateTime(2020, 3, 31, 11, 45, 36, 756, DateTimeKind.Local).AddTicks(5498), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 152m, -85m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-40", "titre long pour un produit avec la nature de super hasardouze-40", "L" },
                    { 24, false, "Code-24", "Constructeur2", new DateTime(2020, 11, 22, 14, 16, 12, 785, DateTimeKind.Local).AddTicks(9167), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 980m, -175m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-24", "titre long pour un produit avec la nature de super hasardouze-24", "Kg" },
                    { 89, true, "Code-89", "Constructeur3", new DateTime(2020, 7, 27, 8, 52, 55, 681, DateTimeKind.Local).AddTicks(8649), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 40m, -269m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-89", "titre long pour un produit avec la nature de super hasardouze-89", "Kg" },
                    { 64, false, "Code-64", "Constructeur2", new DateTime(2020, 2, 17, 21, 21, 29, 742, DateTimeKind.Local).AddTicks(1522), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 668m, -382m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-64", "titre long pour un produit avec la nature de super hasardouze-64", "Kg" },
                    { 22, false, "Code-22", "Constructeur2", new DateTime(2020, 11, 13, 14, 24, 46, 65, DateTimeKind.Local).AddTicks(5710), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 852m, -153m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-22", "titre long pour un produit avec la nature de super hasardouze-22", "Kg" },
                    { 15, false, "Code-15", "Constructeur3", new DateTime(2020, 11, 2, 12, 22, 44, 268, DateTimeKind.Local).AddTicks(1863), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 689m, -309m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-15", "titre long pour un produit avec la nature de super hasardouze-15", "L" },
                    { 14, false, "Code-14", "Constructeur1", new DateTime(2020, 1, 1, 5, 4, 18, 729, DateTimeKind.Local).AddTicks(5048), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 69m, -360m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-14", "titre long pour un produit avec la nature de super hasardouze-14", "L" },
                    { 53, false, "Code-53", "Constructeur1", new DateTime(2020, 11, 19, 20, 49, 57, 350, DateTimeKind.Local).AddTicks(17), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 186m, -446m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-53", "titre long pour un produit avec la nature de super hasardouze-53", "L" },
                    { 80, false, "Code-80", "Constructeur2", new DateTime(2020, 11, 9, 0, 21, 14, 873, DateTimeKind.Local).AddTicks(9618), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 554m, -175m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-80", "titre long pour un produit avec la nature de super hasardouze-80", "Kg" }
                });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[,]
                {
                    { 13, 10, 528m, 61m, 0m, 32208m },
                    { 18, 2, 358m, 16m, 0m, 5728m },
                    { 19, 19, 973m, 75m, 0m, 72975m },
                    { 19, 1, 973m, 59m, 0m, 57407m },
                    { 19, 2, 973m, 56m, 0m, 54488m },
                    { 19, 5, 973m, 54m, 0m, 52542m },
                    { 30, 12, 967m, 76m, 0m, 73492m },
                    { 30, 8, 967m, 54m, 0m, 52218m },
                    { 18, 4, 358m, 91m, 0m, 32578m },
                    { 30, 11, 967m, 64m, 0m, 61888m },
                    { 30, 9, 967m, 43m, 0m, 41581m },
                    { 45, 13, 873m, 9m, 0m, 7857m },
                    { 45, 8, 873m, 71m, 0m, 61983m },
                    { 45, 6, 873m, 75m, 0m, 65475m },
                    { 45, 17, 873m, 1m, 0m, 873m },
                    { 45, 7, 873m, 57m, 0m, 49761m },
                    { 45, 16, 873m, 69m, 0m, 60237m },
                    { 30, 7, 967m, 25m, 0m, 24175m },
                    { 45, 19, 873m, 45m, 0m, 39285m },
                    { 18, 15, 358m, 29m, 0m, 10382m },
                    { 18, 20, 358m, 49m, 0m, 17542m },
                    { 98, 3, 851m, 20m, 0m, 17020m },
                    { 98, 16, 851m, 87m, 0m, 74037m },
                    { 98, 8, 851m, 71m, 0m, 60421m },
                    { 5, 17, 566m, 40m, 0m, 22640m },
                    { 5, 9, 566m, 31m, 0m, 17546m },
                    { 5, 1, 566m, 44m, 0m, 24904m },
                    { 5, 18, 566m, 77m, 0m, 43582m },
                    { 18, 11, 358m, 40m, 0m, 14320m },
                    { 5, 7, 566m, 29m, 0m, 16414m },
                    { 5, 5, 566m, 43m, 0m, 24338m },
                    { 5, 14, 566m, 4m, 0m, 2264m },
                    { 5, 13, 566m, 18m, 0m, 10188m },
                    { 5, 16, 566m, 7m, 0m, 3962m },
                    { 5, 20, 566m, 8m, 0m, 4528m },
                    { 5, 2, 566m, 71m, 0m, 40186m },
                    { 18, 18, 358m, 64m, 0m, 22912m },
                    { 5, 8, 566m, 84m, 0m, 47544m },
                    { 51, 5, 647m, 73m, 0m, 47231m },
                    { 51, 9, 647m, 75m, 0m, 48525m },
                    { 51, 17, 647m, 2m, 0m, 1294m },
                    { 78, 1, 729m, 78m, 0m, 56862m },
                    { 78, 4, 729m, 72m, 0m, 52488m },
                    { 78, 5, 729m, 32m, 0m, 23328m },
                    { 78, 16, 729m, 54m, 0m, 39366m },
                    { 78, 12, 729m, 26m, 0m, 18954m },
                    { 78, 14, 729m, 41m, 0m, 29889m },
                    { 78, 18, 729m, 68m, 0m, 49572m },
                    { 78, 8, 729m, 57m, 0m, 41553m },
                    { 78, 9, 729m, 5m, 0m, 3645m },
                    { 78, 19, 729m, 14m, 0m, 10206m },
                    { 78, 2, 729m, 2m, 0m, 1458m },
                    { 83, 3, 637m, 78m, 0m, 49686m },
                    { 83, 17, 637m, 88m, 0m, 56056m },
                    { 83, 9, 637m, 37m, 0m, 23569m },
                    { 83, 10, 637m, 27m, 0m, 17199m },
                    { 84, 15, 730m, 63m, 0m, 45990m },
                    { 78, 15, 729m, 24m, 0m, 17496m },
                    { 74, 14, 334m, 38m, 0m, 12692m },
                    { 74, 20, 334m, 37m, 0m, 12358m },
                    { 74, 6, 334m, 19m, 0m, 6346m },
                    { 51, 13, 647m, 79m, 0m, 51113m },
                    { 51, 8, 647m, 89m, 0m, 57583m },
                    { 62, 16, 106m, 55m, 0m, 5830m },
                    { 62, 4, 106m, 7m, 0m, 742m },
                    { 62, 8, 106m, 8m, 0m, 848m },
                    { 62, 18, 106m, 5m, 0m, 530m },
                    { 62, 14, 106m, 74m, 0m, 7844m },
                    { 62, 19, 106m, 93m, 0m, 9858m },
                    { 65, 5, 503m, 71m, 0m, 35713m },
                    { 65, 15, 503m, 46m, 0m, 23138m },
                    { 65, 19, 503m, 18m, 0m, 9054m },
                    { 65, 17, 503m, 49m, 0m, 24647m },
                    { 65, 16, 503m, 42m, 0m, 21126m },
                    { 65, 18, 503m, 60m, 0m, 30180m },
                    { 65, 7, 503m, 48m, 0m, 24144m },
                    { 65, 11, 503m, 71m, 0m, 35713m },
                    { 74, 19, 334m, 89m, 0m, 29726m },
                    { 98, 19, 851m, 38m, 0m, 32338m },
                    { 84, 18, 730m, 85m, 0m, 62050m },
                    { 98, 17, 851m, 71m, 0m, 60421m },
                    { 71, 6, 465m, 53m, 0m, 24645m },
                    { 96, 6, 859m, 64m, 0m, 54976m },
                    { 80, 20, 554m, 25m, 0m, 13850m },
                    { 96, 4, 859m, 90m, 0m, 77310m },
                    { 96, 9, 859m, 86m, 0m, 73874m },
                    { 12, 16, 986m, 77m, 0m, 75922m },
                    { 12, 12, 986m, 14m, 0m, 13804m },
                    { 12, 9, 986m, 30m, 0m, 29580m },
                    { 96, 12, 859m, 80m, 0m, 68720m },
                    { 12, 14, 986m, 45m, 0m, 44370m },
                    { 12, 15, 986m, 20m, 0m, 19720m },
                    { 12, 10, 986m, 20m, 0m, 19720m },
                    { 12, 11, 986m, 86m, 0m, 84796m },
                    { 12, 1, 986m, 11m, 0m, 10846m },
                    { 20, 19, 657m, 88m, 0m, 57816m },
                    { 20, 14, 657m, 64m, 0m, 42048m },
                    { 20, 2, 657m, 31m, 0m, 20367m },
                    { 12, 7, 986m, 77m, 0m, 75922m },
                    { 20, 3, 657m, 15m, 0m, 9855m },
                    { 96, 2, 859m, 17m, 0m, 14603m },
                    { 96, 1, 859m, 38m, 0m, 32642m },
                    { 10, 16, 318m, 57m, 0m, 18126m },
                    { 11, 4, 349m, 37m, 0m, 12913m },
                    { 11, 6, 349m, 76m, 0m, 26524m },
                    { 11, 9, 349m, 12m, 0m, 4188m },
                    { 11, 15, 349m, 31m, 0m, 10819m },
                    { 11, 10, 349m, 6m, 0m, 2094m },
                    { 11, 5, 349m, 78m, 0m, 27222m },
                    { 96, 20, 859m, 30m, 0m, 25770m },
                    { 21, 6, 907m, 56m, 0m, 50792m },
                    { 21, 1, 907m, 37m, 0m, 33559m },
                    { 21, 2, 907m, 31m, 0m, 28117m },
                    { 21, 18, 907m, 76m, 0m, 68932m },
                    { 81, 14, 554m, 26m, 0m, 14404m },
                    { 81, 9, 554m, 65m, 0m, 36010m },
                    { 81, 10, 554m, 5m, 0m, 2770m },
                    { 81, 5, 554m, 94m, 0m, 52076m },
                    { 21, 19, 907m, 70m, 0m, 63490m },
                    { 20, 11, 657m, 36m, 0m, 23652m },
                    { 20, 6, 657m, 29m, 0m, 19053m },
                    { 25, 8, 401m, 44m, 0m, 17644m },
                    { 54, 8, 386m, 40m, 0m, 15440m },
                    { 54, 2, 386m, 27m, 0m, 10422m },
                    { 54, 1, 386m, 61m, 0m, 23546m },
                    { 54, 19, 386m, 49m, 0m, 18914m },
                    { 55, 6, 892m, 97m, 0m, 86524m },
                    { 55, 5, 892m, 28m, 0m, 24976m },
                    { 55, 10, 892m, 100m, 0m, 89200m },
                    { 54, 4, 386m, 71m, 0m, 27406m },
                    { 55, 14, 892m, 88m, 0m, 78496m },
                    { 71, 14, 465m, 51m, 0m, 23715m },
                    { 71, 11, 465m, 53m, 0m, 24645m },
                    { 71, 3, 465m, 78m, 0m, 36270m },
                    { 71, 12, 465m, 81m, 0m, 37665m },
                    { 71, 20, 465m, 49m, 0m, 22785m },
                    { 71, 8, 465m, 55m, 0m, 25575m },
                    { 71, 10, 465m, 69m, 0m, 32085m },
                    { 55, 1, 892m, 37m, 0m, 33004m },
                    { 36, 8, 92m, 85m, 0m, 7820m },
                    { 36, 13, 92m, 73m, 0m, 6716m },
                    { 36, 15, 92m, 17m, 0m, 1564m },
                    { 25, 5, 401m, 40m, 0m, 16040m },
                    { 25, 18, 401m, 80m, 0m, 32080m },
                    { 25, 3, 401m, 25m, 0m, 10025m },
                    { 25, 14, 401m, 95m, 0m, 38095m },
                    { 25, 2, 401m, 69m, 0m, 27669m },
                    { 27, 5, 148m, 28m, 0m, 4144m },
                    { 27, 7, 148m, 42m, 0m, 6216m },
                    { 27, 4, 148m, 80m, 0m, 11840m },
                    { 27, 14, 148m, 66m, 0m, 9768m },
                    { 27, 11, 148m, 34m, 0m, 5032m },
                    { 27, 19, 148m, 20m, 0m, 2960m },
                    { 27, 10, 148m, 5m, 0m, 740m },
                    { 27, 16, 148m, 26m, 0m, 3848m },
                    { 27, 2, 148m, 98m, 0m, 14504m },
                    { 27, 8, 148m, 95m, 0m, 14060m },
                    { 27, 13, 148m, 83m, 0m, 12284m },
                    { 36, 1, 92m, 26m, 0m, 2392m },
                    { 98, 14, 851m, 5m, 0m, 4255m },
                    { 10, 15, 318m, 71m, 0m, 22578m },
                    { 84, 13, 730m, 47m, 0m, 34310m },
                    { 91, 8, 530m, 2m, 0m, 1060m },
                    { 79, 19, 939m, 99m, 0m, 92961m },
                    { 79, 15, 939m, 55m, 0m, 51645m },
                    { 79, 14, 939m, 44m, 0m, 41316m },
                    { 79, 5, 939m, 9m, 0m, 8451m },
                    { 79, 20, 939m, 76m, 0m, 71364m },
                    { 79, 13, 939m, 34m, 0m, 31926m },
                    { 82, 6, 955m, 35m, 0m, 33425m },
                    { 75, 18, 428m, 7m, 0m, 2996m },
                    { 82, 8, 955m, 76m, 0m, 72580m },
                    { 82, 7, 955m, 26m, 0m, 24830m },
                    { 93, 15, 163m, 28m, 0m, 4564m },
                    { 93, 16, 163m, 60m, 0m, 9780m },
                    { 93, 18, 163m, 46m, 0m, 7498m },
                    { 93, 13, 163m, 50m, 0m, 8150m },
                    { 93, 3, 163m, 15m, 0m, 2445m },
                    { 93, 1, 163m, 66m, 0m, 10758m },
                    { 82, 11, 955m, 55m, 0m, 52525m },
                    { 93, 10, 163m, 51m, 0m, 8313m },
                    { 75, 3, 428m, 78m, 0m, 33384m },
                    { 63, 3, 40m, 1m, 0m, 40m },
                    { 35, 18, 765m, 16m, 0m, 12240m },
                    { 35, 4, 765m, 53m, 0m, 40545m },
                    { 35, 5, 765m, 98m, 0m, 74970m },
                    { 35, 9, 765m, 80m, 0m, 61200m },
                    { 35, 14, 765m, 54m, 0m, 41310m },
                    { 42, 8, 229m, 13m, 0m, 2977m },
                    { 42, 13, 229m, 48m, 0m, 10992m },
                    { 75, 13, 428m, 81m, 0m, 34668m },
                    { 42, 1, 229m, 27m, 0m, 6183m },
                    { 42, 18, 229m, 49m, 0m, 11221m },
                    { 42, 17, 229m, 38m, 0m, 8702m },
                    { 63, 10, 40m, 59m, 0m, 2360m },
                    { 63, 17, 40m, 54m, 0m, 2160m },
                    { 63, 5, 40m, 58m, 0m, 2320m },
                    { 63, 9, 40m, 81m, 0m, 3240m },
                    { 63, 13, 40m, 41m, 0m, 1640m },
                    { 42, 3, 229m, 32m, 0m, 7328m },
                    { 93, 2, 163m, 41m, 0m, 6683m },
                    { 93, 8, 163m, 31m, 0m, 5053m },
                    { 50, 11, 747m, 67m, 0m, 50049m },
                    { 66, 5, 412m, 58m, 0m, 23896m },
                    { 66, 20, 412m, 18m, 0m, 7416m },
                    { 72, 2, 479m, 13m, 0m, 6227m },
                    { 72, 12, 479m, 1m, 0m, 479m },
                    { 72, 16, 479m, 98m, 0m, 46942m },
                    { 72, 1, 479m, 44m, 0m, 21076m },
                    { 72, 11, 479m, 80m, 0m, 38320m },
                    { 66, 19, 412m, 18m, 0m, 7416m },
                    { 72, 8, 479m, 99m, 0m, 47421m },
                    { 76, 13, 22m, 16m, 0m, 352m },
                    { 76, 9, 22m, 31m, 0m, 682m },
                    { 76, 16, 22m, 41m, 0m, 902m },
                    { 80, 18, 554m, 13m, 0m, 7202m },
                    { 80, 7, 554m, 13m, 0m, 7202m },
                    { 80, 5, 554m, 74m, 0m, 40996m },
                    { 80, 3, 554m, 56m, 0m, 31024m },
                    { 76, 17, 22m, 60m, 0m, 1320m },
                    { 61, 17, 389m, 9m, 0m, 3501m },
                    { 61, 16, 389m, 50m, 0m, 19450m },
                    { 61, 9, 389m, 13m, 0m, 5057m },
                    { 50, 2, 747m, 25m, 0m, 18675m },
                    { 50, 18, 747m, 85m, 0m, 63495m },
                    { 50, 16, 747m, 32m, 0m, 23904m },
                    { 50, 8, 747m, 50m, 0m, 37350m },
                    { 50, 9, 747m, 57m, 0m, 42579m },
                    { 58, 6, 78m, 21m, 0m, 1638m },
                    { 58, 14, 78m, 73m, 0m, 5694m },
                    { 58, 16, 78m, 10m, 0m, 780m },
                    { 58, 4, 78m, 52m, 0m, 4056m },
                    { 58, 18, 78m, 51m, 0m, 3978m },
                    { 58, 17, 78m, 63m, 0m, 4914m },
                    { 58, 15, 78m, 89m, 0m, 6942m },
                    { 60, 16, 183m, 58m, 0m, 10614m },
                    { 60, 10, 183m, 95m, 0m, 17385m },
                    { 60, 3, 183m, 80m, 0m, 14640m },
                    { 60, 15, 183m, 20m, 0m, 3660m },
                    { 61, 1, 389m, 41m, 0m, 15949m },
                    { 35, 16, 765m, 63m, 0m, 48195m },
                    { 91, 12, 530m, 63m, 0m, 33390m },
                    { 35, 6, 765m, 34m, 0m, 26010m },
                    { 31, 3, 706m, 89m, 0m, 62834m },
                    { 73, 18, 37m, 71m, 0m, 2627m },
                    { 77, 13, 88m, 52m, 0m, 4576m },
                    { 77, 17, 88m, 81m, 0m, 7128m },
                    { 77, 12, 88m, 57m, 0m, 5016m },
                    { 77, 5, 88m, 40m, 0m, 3520m },
                    { 77, 2, 88m, 80m, 0m, 7040m },
                    { 77, 15, 88m, 47m, 0m, 4136m },
                    { 73, 16, 37m, 54m, 0m, 1998m },
                    { 86, 11, 96m, 56m, 0m, 5376m },
                    { 86, 9, 96m, 35m, 0m, 3360m },
                    { 86, 18, 96m, 39m, 0m, 3744m },
                    { 86, 12, 96m, 85m, 0m, 8160m },
                    { 94, 19, 231m, 32m, 0m, 7392m },
                    { 94, 8, 231m, 85m, 0m, 19635m },
                    { 94, 14, 231m, 26m, 0m, 6006m },
                    { 94, 4, 231m, 44m, 0m, 10164m },
                    { 86, 2, 96m, 85m, 0m, 8160m },
                    { 94, 16, 231m, 40m, 0m, 9240m },
                    { 73, 19, 37m, 54m, 0m, 1998m },
                    { 73, 20, 37m, 37m, 0m, 1369m },
                    { 91, 17, 530m, 47m, 0m, 24910m },
                    { 97, 15, 166m, 25m, 0m, 4150m },
                    { 97, 12, 166m, 44m, 0m, 7304m },
                    { 97, 17, 166m, 1m, 0m, 166m },
                    { 97, 2, 166m, 47m, 0m, 7802m },
                    { 34, 18, 204m, 88m, 0m, 17952m },
                    { 34, 10, 204m, 40m, 0m, 8160m },
                    { 73, 8, 37m, 80m, 0m, 2960m },
                    { 34, 14, 204m, 22m, 0m, 4488m },
                    { 68, 1, 212m, 30m, 0m, 6360m },
                    { 68, 2, 212m, 31m, 0m, 6572m },
                    { 68, 13, 212m, 26m, 0m, 5512m },
                    { 68, 19, 212m, 36m, 0m, 7632m },
                    { 68, 15, 212m, 8m, 0m, 1696m },
                    { 70, 2, 890m, 35m, 0m, 31150m },
                    { 70, 18, 890m, 99m, 0m, 88110m },
                    { 34, 20, 204m, 100m, 0m, 20400m },
                    { 94, 11, 231m, 69m, 0m, 15939m },
                    { 94, 6, 231m, 78m, 0m, 18018m },
                    { 94, 2, 231m, 73m, 0m, 16863m },
                    { 16, 13, 249m, 37m, 0m, 9213m },
                    { 16, 6, 249m, 58m, 0m, 14442m },
                    { 16, 12, 249m, 48m, 0m, 11952m },
                    { 17, 12, 127m, 6m, 0m, 762m },
                    { 17, 13, 127m, 48m, 0m, 6096m },
                    { 17, 18, 127m, 94m, 0m, 11938m },
                    { 28, 5, 639m, 4m, 0m, 2556m },
                    { 16, 15, 249m, 93m, 0m, 23157m },
                    { 28, 10, 639m, 3m, 0m, 1917m },
                    { 28, 2, 639m, 30m, 0m, 19170m },
                    { 28, 12, 639m, 22m, 0m, 14058m },
                    { 28, 15, 639m, 33m, 0m, 21087m },
                    { 31, 18, 706m, 18m, 0m, 12708m },
                    { 31, 1, 706m, 21m, 0m, 14826m },
                    { 31, 20, 706m, 33m, 0m, 23298m },
                    { 31, 4, 706m, 23m, 0m, 16238m },
                    { 28, 20, 639m, 49m, 0m, 31311m },
                    { 16, 20, 249m, 60m, 0m, 14940m },
                    { 16, 18, 249m, 35m, 0m, 8715m },
                    { 4, 15, 739m, 15m, 0m, 11085m },
                    { 99, 2, 833m, 92m, 0m, 76636m },
                    { 99, 10, 833m, 74m, 0m, 61642m },
                    { 99, 5, 833m, 88m, 0m, 73304m },
                    { 99, 19, 833m, 19m, 0m, 15827m },
                    { 99, 3, 833m, 94m, 0m, 78302m },
                    { 99, 1, 833m, 79m, 0m, 65807m },
                    { 99, 20, 833m, 64m, 0m, 53312m },
                    { 100, 7, 288m, 11m, 0m, 3168m },
                    { 100, 14, 288m, 16m, 0m, 4608m },
                    { 100, 3, 288m, 90m, 0m, 25920m },
                    { 100, 20, 288m, 67m, 0m, 19296m },
                    { 100, 9, 288m, 12m, 0m, 3456m },
                    { 4, 5, 739m, 58m, 0m, 42862m },
                    { 4, 12, 739m, 98m, 0m, 72422m },
                    { 4, 16, 739m, 42m, 0m, 31038m },
                    { 4, 2, 739m, 80m, 0m, 59120m },
                    { 4, 18, 739m, 15m, 0m, 11085m },
                    { 35, 7, 765m, 84m, 0m, 64260m },
                    { 10, 3, 318m, 78m, 0m, 24804m },
                    { 96, 11, 859m, 25m, 0m, 21475m },
                    { 10, 10, 318m, 43m, 0m, 13674m },
                    { 8, 12, 780m, 87m, 0m, 67860m },
                    { 8, 8, 780m, 96m, 0m, 74880m },
                    { 8, 20, 780m, 29m, 0m, 22620m },
                    { 8, 5, 780m, 77m, 0m, 60060m },
                    { 8, 10, 780m, 45m, 0m, 35100m },
                    { 8, 4, 780m, 52m, 0m, 40560m },
                    { 26, 17, 796m, 52m, 0m, 41392m },
                    { 26, 11, 796m, 60m, 0m, 47760m },
                    { 26, 18, 796m, 41m, 0m, 32636m },
                    { 26, 7, 796m, 60m, 0m, 47760m },
                    { 26, 15, 796m, 32m, 0m, 25472m },
                    { 26, 19, 796m, 79m, 0m, 62884m },
                    { 26, 12, 796m, 22m, 0m, 17512m },
                    { 39, 6, 859m, 100m, 0m, 85900m },
                    { 39, 19, 859m, 90m, 0m, 77310m },
                    { 8, 7, 780m, 35m, 0m, 27300m },
                    { 8, 16, 780m, 8m, 0m, 6240m },
                    { 6, 8, 623m, 49m, 0m, 30527m },
                    { 6, 2, 623m, 1m, 0m, 623m },
                    { 2, 2, 247m, 32m, 0m, 7904m },
                    { 2, 12, 247m, 12m, 0m, 2964m },
                    { 2, 9, 247m, 18m, 0m, 4446m },
                    { 3, 10, 906m, 74m, 0m, 67044m },
                    { 3, 2, 906m, 33m, 0m, 29898m }
                });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[,]
                {
                    { 3, 7, 906m, 63m, 0m, 57078m },
                    { 3, 5, 906m, 85m, 0m, 77010m },
                    { 39, 9, 859m, 72m, 0m, 61848m },
                    { 3, 18, 906m, 98m, 0m, 88788m },
                    { 3, 14, 906m, 8m, 0m, 7248m },
                    { 6, 4, 623m, 87m, 0m, 54201m },
                    { 6, 11, 623m, 72m, 0m, 44856m },
                    { 6, 13, 623m, 53m, 0m, 33019m },
                    { 6, 6, 623m, 96m, 0m, 59808m },
                    { 6, 18, 623m, 28m, 0m, 17444m },
                    { 6, 16, 623m, 54m, 0m, 33642m },
                    { 3, 6, 906m, 87m, 0m, 78822m },
                    { 2, 6, 247m, 24m, 0m, 5928m },
                    { 39, 20, 859m, 20m, 0m, 17180m },
                    { 39, 11, 859m, 85m, 0m, 73015m },
                    { 69, 13, 844m, 67m, 0m, 56548m },
                    { 69, 20, 844m, 28m, 0m, 23632m },
                    { 69, 10, 844m, 94m, 0m, 79336m },
                    { 69, 12, 844m, 61m, 0m, 51484m },
                    { 85, 8, 848m, 27m, 0m, 22896m },
                    { 85, 13, 848m, 34m, 0m, 28832m },
                    { 85, 19, 848m, 97m, 0m, 82256m },
                    { 92, 11, 624m, 25m, 0m, 15600m },
                    { 92, 2, 624m, 69m, 0m, 43056m },
                    { 92, 13, 624m, 19m, 0m, 11856m },
                    { 92, 3, 624m, 3m, 0m, 1872m },
                    { 92, 4, 624m, 51m, 0m, 31824m },
                    { 92, 19, 624m, 8m, 0m, 4992m },
                    { 1, 12, 450m, 56m, 0m, 25200m },
                    { 1, 7, 450m, 17m, 0m, 7650m },
                    { 69, 9, 844m, 7m, 0m, 5908m },
                    { 69, 15, 844m, 69m, 0m, 58236m },
                    { 59, 20, 856m, 26m, 0m, 22256m },
                    { 59, 7, 856m, 26m, 0m, 22256m },
                    { 39, 7, 859m, 46m, 0m, 39514m },
                    { 39, 12, 859m, 9m, 0m, 7731m },
                    { 47, 19, 670m, 4m, 0m, 2680m },
                    { 47, 18, 670m, 13m, 0m, 8710m },
                    { 47, 7, 670m, 50m, 0m, 33500m },
                    { 47, 16, 670m, 85m, 0m, 56950m },
                    { 47, 11, 670m, 81m, 0m, 54270m },
                    { 39, 17, 859m, 36m, 0m, 30924m },
                    { 48, 13, 11m, 18m, 0m, 198m },
                    { 52, 12, 759m, 81m, 0m, 61479m },
                    { 52, 6, 759m, 86m, 0m, 65274m },
                    { 52, 15, 759m, 11m, 0m, 8349m },
                    { 52, 5, 759m, 39m, 0m, 29601m },
                    { 52, 7, 759m, 44m, 0m, 33396m },
                    { 10, 8, 318m, 45m, 0m, 14310m },
                    { 59, 13, 856m, 28m, 0m, 23968m },
                    { 52, 14, 759m, 37m, 0m, 28083m },
                    { 2, 19, 247m, 2m, 0m, 494m },
                    { 2, 15, 247m, 34m, 0m, 8398m },
                    { 2, 5, 247m, 22m, 0m, 5434m },
                    { 29, 13, 595m, 78m, 0m, 46410m },
                    { 29, 1, 595m, 7m, 0m, 4165m },
                    { 29, 9, 595m, 9m, 0m, 5355m },
                    { 32, 11, 39m, 84m, 0m, 3276m },
                    { 32, 3, 39m, 37m, 0m, 1443m },
                    { 32, 1, 39m, 55m, 0m, 2145m },
                    { 32, 10, 39m, 40m, 0m, 1560m },
                    { 33, 3, 579m, 29m, 0m, 16791m },
                    { 33, 9, 579m, 25m, 0m, 14475m },
                    { 33, 1, 579m, 76m, 0m, 44004m },
                    { 33, 16, 579m, 36m, 0m, 20844m },
                    { 33, 17, 579m, 77m, 0m, 44583m },
                    { 33, 13, 579m, 29m, 0m, 16791m },
                    { 37, 6, 307m, 78m, 0m, 23946m },
                    { 37, 10, 307m, 39m, 0m, 11973m },
                    { 29, 10, 595m, 87m, 0m, 51765m },
                    { 29, 11, 595m, 76m, 0m, 45220m },
                    { 29, 14, 595m, 23m, 0m, 13685m },
                    { 29, 8, 595m, 32m, 0m, 19040m },
                    { 13, 9, 528m, 70m, 0m, 36960m },
                    { 13, 4, 528m, 54m, 0m, 28512m },
                    { 13, 18, 528m, 5m, 0m, 2640m },
                    { 13, 3, 528m, 28m, 0m, 14784m },
                    { 13, 19, 528m, 11m, 0m, 5808m },
                    { 13, 13, 528m, 58m, 0m, 30624m },
                    { 23, 3, 586m, 99m, 0m, 58014m },
                    { 37, 17, 307m, 29m, 0m, 8903m },
                    { 23, 18, 586m, 98m, 0m, 57428m },
                    { 23, 8, 586m, 69m, 0m, 40434m },
                    { 23, 17, 586m, 27m, 0m, 15822m },
                    { 23, 6, 586m, 32m, 0m, 18752m },
                    { 23, 7, 586m, 85m, 0m, 49810m },
                    { 23, 2, 586m, 28m, 0m, 16408m },
                    { 23, 15, 586m, 27m, 0m, 15822m },
                    { 23, 9, 586m, 94m, 0m, 55084m },
                    { 23, 11, 586m, 73m, 0m, 42778m },
                    { 37, 3, 307m, 49m, 0m, 15043m },
                    { 37, 20, 307m, 25m, 0m, 7675m },
                    { 37, 5, 307m, 46m, 0m, 14122m },
                    { 88, 9, 14m, 7m, 0m, 98m },
                    { 88, 18, 14m, 52m, 0m, 728m },
                    { 88, 3, 14m, 57m, 0m, 798m },
                    { 88, 8, 14m, 80m, 0m, 1120m },
                    { 95, 11, 880m, 9m, 0m, 7920m },
                    { 95, 17, 880m, 33m, 0m, 29040m },
                    { 95, 15, 880m, 29m, 0m, 25520m },
                    { 88, 14, 14m, 100m, 0m, 1400m },
                    { 95, 8, 880m, 57m, 0m, 50160m },
                    { 95, 9, 880m, 36m, 0m, 31680m },
                    { 95, 7, 880m, 91m, 0m, 80080m },
                    { 95, 20, 880m, 46m, 0m, 40480m },
                    { 95, 1, 880m, 67m, 0m, 58960m },
                    { 95, 19, 880m, 26m, 0m, 22880m },
                    { 2, 13, 247m, 3m, 0m, 741m },
                    { 2, 7, 247m, 32m, 0m, 7904m },
                    { 95, 13, 880m, 67m, 0m, 58960m },
                    { 1, 3, 450m, 22m, 0m, 9900m },
                    { 88, 11, 14m, 63m, 0m, 882m },
                    { 46, 20, 612m, 9m, 0m, 5508m },
                    { 37, 2, 307m, 42m, 0m, 12894m },
                    { 38, 8, 527m, 54m, 0m, 28458m },
                    { 38, 5, 527m, 53m, 0m, 27931m },
                    { 38, 3, 527m, 76m, 0m, 40052m },
                    { 38, 6, 527m, 22m, 0m, 11594m },
                    { 38, 10, 527m, 54m, 0m, 28458m },
                    { 44, 3, 490m, 40m, 0m, 19600m },
                    { 46, 19, 612m, 67m, 0m, 41004m },
                    { 44, 13, 490m, 7m, 0m, 3430m },
                    { 44, 8, 490m, 62m, 0m, 30380m },
                    { 44, 16, 490m, 34m, 0m, 16660m },
                    { 44, 2, 490m, 46m, 0m, 22540m },
                    { 46, 1, 612m, 25m, 0m, 15300m },
                    { 46, 10, 612m, 21m, 0m, 12852m },
                    { 46, 8, 612m, 64m, 0m, 39168m },
                    { 46, 3, 612m, 81m, 0m, 49572m },
                    { 44, 1, 490m, 22m, 0m, 10780m },
                    { 1, 19, 450m, 69m, 0m, 31050m },
                    { 52, 8, 759m, 61m, 0m, 46299m },
                    { 1, 6, 450m, 84m, 0m, 37800m },
                    { 57, 10, 253m, 69m, 0m, 17457m },
                    { 43, 12, 880m, 51m, 0m, 44880m },
                    { 57, 4, 253m, 34m, 0m, 8602m },
                    { 41, 6, 479m, 53m, 0m, 25387m },
                    { 41, 20, 479m, 24m, 0m, 11496m },
                    { 41, 7, 479m, 24m, 0m, 11496m },
                    { 41, 5, 479m, 94m, 0m, 45026m },
                    { 41, 18, 479m, 60m, 0m, 28740m },
                    { 67, 7, 139m, 98m, 0m, 13622m },
                    { 41, 13, 479m, 6m, 0m, 2874m },
                    { 67, 12, 139m, 78m, 0m, 10842m },
                    { 40, 6, 152m, 6m, 0m, 912m },
                    { 40, 7, 152m, 8m, 0m, 1216m },
                    { 1, 13, 450m, 49m, 0m, 22050m },
                    { 40, 11, 152m, 99m, 0m, 15048m },
                    { 40, 17, 152m, 47m, 0m, 7144m },
                    { 40, 5, 152m, 43m, 0m, 6536m },
                    { 67, 19, 139m, 5m, 0m, 695m },
                    { 24, 2, 980m, 76m, 0m, 74480m },
                    { 67, 11, 139m, 88m, 0m, 12232m },
                    { 24, 19, 980m, 78m, 0m, 76440m },
                    { 24, 9, 980m, 34m, 0m, 33320m },
                    { 56, 8, 877m, 83m, 0m, 72791m },
                    { 89, 2, 40m, 18m, 0m, 720m },
                    { 89, 5, 40m, 4m, 0m, 160m },
                    { 89, 17, 40m, 39m, 0m, 1560m },
                    { 89, 1, 40m, 77m, 0m, 3080m },
                    { 89, 20, 40m, 57m, 0m, 2280m },
                    { 67, 14, 139m, 11m, 0m, 1529m },
                    { 43, 10, 880m, 65m, 0m, 57200m },
                    { 43, 19, 880m, 43m, 0m, 37840m },
                    { 43, 2, 880m, 89m, 0m, 78320m },
                    { 56, 14, 877m, 6m, 0m, 5262m },
                    { 56, 3, 877m, 77m, 0m, 67529m },
                    { 56, 19, 877m, 18m, 0m, 15786m },
                    { 56, 9, 877m, 23m, 0m, 20171m },
                    { 53, 2, 186m, 36m, 0m, 6696m },
                    { 56, 13, 877m, 26m, 0m, 22802m },
                    { 53, 19, 186m, 33m, 0m, 6138m },
                    { 53, 20, 186m, 66m, 0m, 12276m },
                    { 53, 9, 186m, 82m, 0m, 15252m },
                    { 53, 13, 186m, 95m, 0m, 17670m },
                    { 53, 3, 186m, 35m, 0m, 6510m },
                    { 53, 4, 186m, 1m, 0m, 186m },
                    { 53, 8, 186m, 76m, 0m, 14136m },
                    { 53, 10, 186m, 25m, 0m, 4650m },
                    { 49, 5, 692m, 19m, 0m, 13148m },
                    { 57, 13, 253m, 5m, 0m, 1265m },
                    { 49, 14, 692m, 81m, 0m, 56052m },
                    { 49, 19, 692m, 69m, 0m, 47748m },
                    { 49, 4, 692m, 69m, 0m, 47748m },
                    { 49, 13, 692m, 70m, 0m, 48440m },
                    { 49, 8, 692m, 93m, 0m, 64356m },
                    { 49, 2, 692m, 70m, 0m, 48440m },
                    { 49, 18, 692m, 96m, 0m, 66432m },
                    { 57, 19, 253m, 55m, 0m, 13915m },
                    { 57, 18, 253m, 95m, 0m, 24035m },
                    { 57, 15, 253m, 37m, 0m, 9361m },
                    { 57, 17, 253m, 98m, 0m, 24794m },
                    { 57, 1, 253m, 19m, 0m, 4807m },
                    { 43, 13, 880m, 83m, 0m, 73040m },
                    { 87, 7, 342m, 100m, 0m, 34200m },
                    { 87, 3, 342m, 96m, 0m, 32832m },
                    { 89, 19, 40m, 74m, 0m, 2960m },
                    { 90, 4, 955m, 84m, 0m, 80220m },
                    { 15, 10, 689m, 89m, 0m, 61321m },
                    { 87, 1, 342m, 15m, 0m, 5130m },
                    { 15, 2, 689m, 25m, 0m, 17225m },
                    { 15, 3, 689m, 9m, 0m, 6201m },
                    { 90, 3, 955m, 50m, 0m, 47750m },
                    { 90, 20, 955m, 18m, 0m, 17190m },
                    { 14, 14, 69m, 53m, 0m, 3657m },
                    { 14, 2, 69m, 86m, 0m, 5934m },
                    { 14, 17, 69m, 78m, 0m, 5382m },
                    { 14, 19, 69m, 52m, 0m, 3588m },
                    { 14, 3, 69m, 40m, 0m, 2760m },
                    { 90, 12, 955m, 91m, 0m, 86905m },
                    { 14, 18, 69m, 1m, 0m, 69m },
                    { 15, 17, 689m, 21m, 0m, 14469m },
                    { 14, 13, 69m, 16m, 0m, 1104m },
                    { 14, 1, 69m, 3m, 0m, 207m },
                    { 7, 9, 802m, 33m, 0m, 26466m },
                    { 9, 18, 202m, 25m, 0m, 5050m },
                    { 9, 14, 202m, 12m, 0m, 2424m },
                    { 9, 16, 202m, 98m, 0m, 19796m },
                    { 9, 12, 202m, 12m, 0m, 2424m },
                    { 7, 13, 802m, 44m, 0m, 35288m },
                    { 7, 7, 802m, 16m, 0m, 12832m },
                    { 7, 4, 802m, 91m, 0m, 72982m },
                    { 7, 1, 802m, 96m, 0m, 76992m },
                    { 7, 8, 802m, 54m, 0m, 43308m },
                    { 7, 2, 802m, 80m, 0m, 64160m },
                    { 7, 16, 802m, 42m, 0m, 33684m },
                    { 14, 11, 69m, 31m, 0m, 2139m },
                    { 15, 20, 689m, 50m, 0m, 34450m },
                    { 90, 15, 955m, 92m, 0m, 87860m },
                    { 15, 14, 689m, 55m, 0m, 37895m },
                    { 64, 12, 668m, 94m, 0m, 62792m },
                    { 64, 2, 668m, 39m, 0m, 26052m },
                    { 64, 13, 668m, 60m, 0m, 40080m },
                    { 64, 7, 668m, 69m, 0m, 46092m },
                    { 64, 9, 668m, 68m, 0m, 45424m },
                    { 64, 5, 668m, 91m, 0m, 60788m },
                    { 64, 17, 668m, 3m, 0m, 2004m },
                    { 64, 4, 668m, 13m, 0m, 8684m },
                    { 15, 11, 689m, 50m, 0m, 34450m },
                    { 90, 11, 955m, 57m, 0m, 54435m },
                    { 22, 4, 852m, 45m, 0m, 38340m },
                    { 22, 2, 852m, 51m, 0m, 43452m },
                    { 22, 7, 852m, 98m, 0m, 83496m },
                    { 90, 5, 955m, 18m, 0m, 17190m },
                    { 56, 10, 877m, 98m, 0m, 85946m },
                    { 15, 18, 689m, 92m, 0m, 63388m },
                    { 90, 7, 955m, 37m, 0m, 35335m }
                });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[,]
                {
                    { 56, new DateTime(2020, 9, 20, 9, 20, 21, 320, DateTimeKind.Local).AddTicks(2130), 4, 37, 3, 307m, 48m },
                    { 14, new DateTime(2020, 9, 5, 15, 37, 3, 135, DateTimeKind.Local).AddTicks(2281), 10, 67, 2, 139m, 54m },
                    { 57, new DateTime(2020, 6, 4, 4, 22, 29, 339, DateTimeKind.Local).AddTicks(1710), 1, 23, 1, 586m, 21m },
                    { 74, new DateTime(2020, 1, 6, 9, 39, 16, 803, DateTimeKind.Local).AddTicks(2519), 10, 23, 1, 586m, 29m },
                    { 53, new DateTime(2020, 10, 23, 2, 38, 3, 272, DateTimeKind.Local).AddTicks(8538), 6, 66, 3, 412m, 51m },
                    { 66, new DateTime(2020, 5, 8, 22, 19, 40, 108, DateTimeKind.Local).AddTicks(8576), 9, 90, 1, 955m, 83m },
                    { 81, new DateTime(2020, 1, 5, 8, 49, 16, 129, DateTimeKind.Local).AddTicks(8864), 10, 33, 3, 579m, 65m },
                    { 12, new DateTime(2020, 10, 30, 17, 9, 32, 592, DateTimeKind.Local).AddTicks(5975), 8, 57, 1, 253m, 65m },
                    { 48, new DateTime(2020, 11, 2, 9, 44, 21, 408, DateTimeKind.Local).AddTicks(4395), 8, 67, 1, 139m, 33m },
                    { 61, new DateTime(2020, 10, 28, 21, 43, 6, 787, DateTimeKind.Local).AddTicks(2993), 3, 57, 1, 253m, 22m },
                    { 97, new DateTime(2020, 11, 1, 13, 52, 39, 738, DateTimeKind.Local).AddTicks(7818), 2, 23, 2, 586m, 55m },
                    { 18, new DateTime(2020, 6, 29, 18, 45, 48, 793, DateTimeKind.Local).AddTicks(6174), 10, 58, 1, 78m, 51m },
                    { 21, new DateTime(2020, 3, 5, 5, 35, 33, 126, DateTimeKind.Local).AddTicks(9018), 9, 9, 3, 202m, 72m },
                    { 42, new DateTime(2020, 6, 19, 12, 8, 48, 258, DateTimeKind.Local).AddTicks(3965), 4, 66, 1, 412m, 68m },
                    { 45, new DateTime(2020, 9, 27, 16, 35, 49, 137, DateTimeKind.Local).AddTicks(1868), 4, 56, 2, 877m, 3m },
                    { 73, new DateTime(2020, 1, 6, 6, 34, 24, 714, DateTimeKind.Local).AddTicks(7083), 6, 93, 3, 163m, 57m },
                    { 7, new DateTime(2019, 12, 3, 21, 43, 5, 819, DateTimeKind.Local).AddTicks(7728), 6, 82, 2, 955m, 9m },
                    { 6, new DateTime(2020, 4, 16, 20, 43, 50, 67, DateTimeKind.Local).AddTicks(602), 9, 33, 1, 579m, 8m },
                    { 95, new DateTime(2020, 8, 15, 0, 8, 43, 830, DateTimeKind.Local).AddTicks(4382), 4, 50, 3, 747m, 61m },
                    { 17, new DateTime(2020, 7, 8, 2, 18, 38, 947, DateTimeKind.Local).AddTicks(9274), 10, 96, 1, 859m, 36m },
                    { 49, new DateTime(2020, 5, 8, 17, 58, 19, 534, DateTimeKind.Local).AddTicks(6389), 10, 50, 1, 747m, 94m },
                    { 50, new DateTime(2020, 10, 6, 6, 8, 1, 146, DateTimeKind.Local).AddTicks(7932), 7, 96, 1, 859m, 88m },
                    { 11, new DateTime(2020, 4, 28, 10, 14, 6, 792, DateTimeKind.Local).AddTicks(4397), 6, 90, 1, 955m, 35m },
                    { 98, new DateTime(2020, 8, 8, 8, 7, 22, 203, DateTimeKind.Local).AddTicks(8709), 1, 50, 1, 747m, 34m },
                    { 28, new DateTime(2020, 5, 10, 1, 58, 21, 750, DateTimeKind.Local).AddTicks(1435), 7, 11, 2, 349m, 63m },
                    { 83, new DateTime(2020, 7, 7, 5, 34, 49, 633, DateTimeKind.Local).AddTicks(4343), 7, 66, 2, 412m, 74m },
                    { 40, new DateTime(2020, 9, 4, 19, 18, 6, 144, DateTimeKind.Local).AddTicks(3250), 2, 90, 1, 955m, 19m },
                    { 1, new DateTime(2020, 8, 15, 17, 55, 23, 534, DateTimeKind.Local).AddTicks(7485), 2, 93, 3, 163m, 49m },
                    { 51, new DateTime(2020, 9, 9, 23, 4, 18, 120, DateTimeKind.Local).AddTicks(9677), 6, 29, 1, 595m, 77m },
                    { 89, new DateTime(2019, 12, 8, 15, 30, 48, 274, DateTimeKind.Local).AddTicks(949), 2, 13, 1, 528m, 97m },
                    { 36, new DateTime(2020, 3, 8, 9, 33, 13, 841, DateTimeKind.Local).AddTicks(2293), 4, 82, 3, 955m, 28m },
                    { 60, new DateTime(2019, 12, 3, 4, 38, 14, 118, DateTimeKind.Local).AddTicks(5168), 2, 72, 3, 479m, 85m },
                    { 5, new DateTime(2020, 1, 21, 9, 6, 53, 621, DateTimeKind.Local).AddTicks(3950), 3, 23, 2, 586m, 51m },
                    { 86, new DateTime(2020, 1, 31, 8, 12, 38, 166, DateTimeKind.Local).AddTicks(8324), 3, 55, 3, 892m, 81m },
                    { 64, new DateTime(2020, 11, 14, 7, 4, 7, 493, DateTimeKind.Local).AddTicks(8946), 1, 53, 2, 186m, 3m },
                    { 68, new DateTime(2020, 8, 19, 5, 12, 46, 808, DateTimeKind.Local).AddTicks(4623), 1, 8, 3, 780m, 13m },
                    { 79, new DateTime(2019, 12, 12, 11, 33, 6, 299, DateTimeKind.Local).AddTicks(1425), 2, 8, 1, 780m, 71m },
                    { 87, new DateTime(2020, 10, 20, 23, 6, 8, 516, DateTimeKind.Local).AddTicks(7882), 8, 8, 1, 780m, 10m },
                    { 99, new DateTime(2020, 4, 29, 15, 1, 31, 893, DateTimeKind.Local).AddTicks(5584), 10, 5, 2, 566m, 9m },
                    { 92, new DateTime(2020, 11, 15, 20, 10, 38, 256, DateTimeKind.Local).AddTicks(6197), 5, 64, 2, 668m, 55m },
                    { 4, new DateTime(2020, 7, 28, 11, 16, 56, 948, DateTimeKind.Local).AddTicks(6566), 1, 26, 1, 796m, 75m },
                    { 32, new DateTime(2020, 11, 5, 1, 45, 31, 381, DateTimeKind.Local).AddTicks(8815), 7, 26, 3, 796m, 46m },
                    { 85, new DateTime(2020, 10, 20, 3, 17, 21, 666, DateTimeKind.Local).AddTicks(2185), 9, 22, 3, 852m, 41m },
                    { 52, new DateTime(2020, 10, 22, 9, 8, 56, 591, DateTimeKind.Local).AddTicks(4382), 3, 73, 1, 37m, 51m },
                    { 71, new DateTime(2020, 1, 3, 0, 55, 39, 874, DateTimeKind.Local).AddTicks(9117), 2, 15, 2, 689m, 82m },
                    { 15, new DateTime(2020, 4, 15, 18, 21, 42, 772, DateTimeKind.Local).AddTicks(1299), 1, 39, 2, 859m, 94m },
                    { 13, new DateTime(2020, 11, 18, 13, 8, 11, 830, DateTimeKind.Local).AddTicks(5397), 1, 30, 2, 967m, 14m },
                    { 41, new DateTime(2020, 6, 19, 5, 42, 18, 120, DateTimeKind.Local).AddTicks(5613), 8, 34, 1, 204m, 67m },
                    { 33, new DateTime(2020, 1, 24, 16, 15, 32, 893, DateTimeKind.Local).AddTicks(4915), 7, 34, 2, 204m, 55m },
                    { 19, new DateTime(2020, 11, 20, 16, 32, 13, 388, DateTimeKind.Local).AddTicks(2061), 5, 34, 1, 204m, 55m },
                    { 2, new DateTime(2020, 1, 9, 7, 59, 34, 418, DateTimeKind.Local).AddTicks(4378), 9, 45, 2, 873m, 75m },
                    { 20, new DateTime(2020, 9, 17, 21, 6, 31, 417, DateTimeKind.Local).AddTicks(6329), 6, 45, 1, 873m, 19m },
                    { 8, new DateTime(2020, 2, 3, 1, 34, 38, 339, DateTimeKind.Local).AddTicks(1952), 8, 59, 3, 856m, 62m },
                    { 35, new DateTime(2020, 6, 14, 19, 5, 47, 80, DateTimeKind.Local).AddTicks(574), 3, 59, 2, 856m, 21m },
                    { 54, new DateTime(2020, 3, 26, 13, 52, 50, 132, DateTimeKind.Local).AddTicks(8513), 1, 84, 2, 730m, 16m },
                    { 44, new DateTime(2020, 6, 25, 5, 16, 42, 225, DateTimeKind.Local).AddTicks(4514), 1, 59, 2, 856m, 72m },
                    { 69, new DateTime(2020, 2, 9, 20, 52, 15, 294, DateTimeKind.Local).AddTicks(7767), 3, 83, 3, 637m, 16m },
                    { 96, new DateTime(2019, 12, 7, 9, 7, 55, 771, DateTimeKind.Local).AddTicks(5709), 5, 7, 3, 802m, 45m },
                    { 67, new DateTime(2020, 11, 12, 9, 10, 17, 730, DateTimeKind.Local).AddTicks(5274), 9, 69, 3, 844m, 50m },
                    { 38, new DateTime(2019, 12, 28, 8, 31, 35, 115, DateTimeKind.Local).AddTicks(817), 5, 62, 3, 106m, 38m },
                    { 70, new DateTime(2020, 1, 29, 18, 53, 14, 751, DateTimeKind.Local).AddTicks(4481), 6, 62, 1, 106m, 53m },
                    { 75, new DateTime(2019, 12, 10, 1, 55, 34, 295, DateTimeKind.Local).AddTicks(67), 3, 62, 2, 106m, 76m },
                    { 77, new DateTime(2019, 12, 8, 12, 18, 3, 576, DateTimeKind.Local).AddTicks(1652), 7, 62, 2, 106m, 100m },
                    { 9, new DateTime(2020, 8, 18, 11, 59, 35, 992, DateTimeKind.Local).AddTicks(2306), 3, 1, 1, 450m, 20m },
                    { 24, new DateTime(2020, 11, 3, 13, 34, 40, 794, DateTimeKind.Local).AddTicks(6436), 6, 8, 1, 780m, 76m },
                    { 27, new DateTime(2020, 10, 26, 5, 46, 4, 493, DateTimeKind.Local).AddTicks(8658), 7, 94, 3, 231m, 5m },
                    { 63, new DateTime(2020, 3, 12, 15, 35, 29, 578, DateTimeKind.Local).AddTicks(5841), 1, 6, 3, 623m, 32m },
                    { 65, new DateTime(2020, 7, 15, 13, 31, 16, 599, DateTimeKind.Local).AddTicks(8549), 7, 99, 2, 833m, 16m },
                    { 76, new DateTime(2020, 10, 14, 8, 8, 28, 525, DateTimeKind.Local).AddTicks(160), 1, 25, 2, 401m, 37m },
                    { 88, new DateTime(2019, 11, 27, 16, 11, 36, 628, DateTimeKind.Local).AddTicks(4281), 10, 63, 3, 40m, 12m },
                    { 34, new DateTime(2020, 4, 21, 21, 9, 58, 354, DateTimeKind.Local).AddTicks(3098), 8, 42, 3, 229m, 94m },
                    { 43, new DateTime(2020, 3, 16, 1, 16, 2, 429, DateTimeKind.Local).AddTicks(4961), 8, 46, 2, 612m, 74m },
                    { 58, new DateTime(2020, 11, 24, 13, 51, 13, 814, DateTimeKind.Local).AddTicks(3635), 4, 49, 3, 692m, 85m },
                    { 55, new DateTime(2020, 3, 29, 19, 11, 47, 360, DateTimeKind.Local).AddTicks(2599), 6, 49, 1, 692m, 65m },
                    { 22, new DateTime(2020, 5, 31, 16, 23, 26, 676, DateTimeKind.Local).AddTicks(7196), 6, 35, 1, 765m, 73m },
                    { 90, new DateTime(2020, 8, 23, 10, 17, 19, 767, DateTimeKind.Local).AddTicks(2531), 8, 43, 1, 880m, 33m },
                    { 30, new DateTime(2020, 9, 24, 13, 1, 21, 644, DateTimeKind.Local).AddTicks(9953), 4, 31, 1, 706m, 26m },
                    { 3, new DateTime(2020, 2, 29, 16, 21, 36, 657, DateTimeKind.Local).AddTicks(6019), 6, 31, 2, 706m, 51m },
                    { 46, new DateTime(2020, 9, 23, 21, 22, 19, 479, DateTimeKind.Local).AddTicks(1175), 4, 54, 1, 386m, 35m },
                    { 10, new DateTime(2020, 3, 5, 11, 56, 39, 631, DateTimeKind.Local).AddTicks(4893), 3, 43, 2, 880m, 95m },
                    { 37, new DateTime(2020, 1, 25, 6, 45, 12, 282, DateTimeKind.Local).AddTicks(9121), 5, 95, 3, 880m, 76m },
                    { 29, new DateTime(2020, 1, 20, 8, 14, 14, 621, DateTimeKind.Local).AddTicks(3083), 6, 28, 2, 639m, 3m },
                    { 25, new DateTime(2020, 8, 19, 6, 51, 34, 135, DateTimeKind.Local).AddTicks(6390), 7, 38, 3, 527m, 13m },
                    { 94, new DateTime(2020, 3, 22, 17, 28, 46, 648, DateTimeKind.Local).AddTicks(6196), 1, 55, 2, 892m, 64m },
                    { 26, new DateTime(2020, 9, 18, 19, 53, 17, 414, DateTimeKind.Local).AddTicks(3871), 7, 17, 1, 127m, 93m },
                    { 23, new DateTime(2020, 8, 11, 23, 37, 35, 68, DateTimeKind.Local).AddTicks(2139), 9, 41, 1, 479m, 2m },
                    { 91, new DateTime(2020, 2, 21, 11, 33, 40, 951, DateTimeKind.Local).AddTicks(4994), 8, 16, 2, 249m, 5m },
                    { 16, new DateTime(2020, 4, 9, 1, 46, 33, 629, DateTimeKind.Local).AddTicks(9446), 8, 2, 1, 247m, 24m }
                });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[,]
                {
                    { 82, new DateTime(2020, 4, 6, 5, 23, 55, 645, DateTimeKind.Local).AddTicks(9935), 10, 71, 3, 465m, 86m },
                    { 100, new DateTime(2020, 10, 11, 5, 11, 50, 765, DateTimeKind.Local).AddTicks(3544), 6, 4, 1, 739m, 60m },
                    { 72, new DateTime(2020, 6, 24, 11, 17, 34, 32, DateTimeKind.Local).AddTicks(7443), 4, 4, 1, 739m, 85m },
                    { 84, new DateTime(2020, 9, 2, 4, 36, 41, 372, DateTimeKind.Local).AddTicks(2083), 6, 40, 3, 152m, 60m },
                    { 39, new DateTime(2020, 1, 13, 6, 36, 36, 188, DateTimeKind.Local).AddTicks(1856), 3, 40, 1, 152m, 58m },
                    { 78, new DateTime(2020, 1, 9, 16, 58, 2, 493, DateTimeKind.Local).AddTicks(7855), 8, 3, 1, 906m, 60m },
                    { 62, new DateTime(2020, 3, 18, 12, 39, 30, 76, DateTimeKind.Local).AddTicks(4097), 3, 100, 2, 288m, 12m },
                    { 93, new DateTime(2020, 7, 13, 10, 5, 50, 798, DateTimeKind.Local).AddTicks(5898), 9, 98, 1, 851m, 4m },
                    { 31, new DateTime(2020, 3, 23, 6, 47, 32, 185, DateTimeKind.Local).AddTicks(4324), 2, 24, 1, 980m, 13m },
                    { 80, new DateTime(2020, 8, 21, 5, 43, 30, 547, DateTimeKind.Local).AddTicks(3260), 1, 99, 1, 833m, 28m },
                    { 59, new DateTime(2020, 1, 27, 6, 40, 21, 909, DateTimeKind.Local).AddTicks(5122), 2, 41, 2, 479m, 23m },
                    { 47, new DateTime(2020, 4, 26, 16, 25, 3, 216, DateTimeKind.Local).AddTicks(6506), 1, 80, 2, 554m, 6m }
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
