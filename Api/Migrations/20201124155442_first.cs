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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                values: new object[] { 1, "plombie" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Libelle" },
                values: new object[] { 2, "electricite" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Libelle" },
                values: new object[] { 3, "quincaillerie" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Libelle" },
                values: new object[] { 4, "peinture" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Libelle" },
                values: new object[] { 5, "divers" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Libelle" },
                values: new object[] { 6, "outillage" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 21, null, null, "", "Alexis", null, "(+212)6 68 77-24-35" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 20, null, null, "", "Mélissa", null, "(+212)6 31 94-85-11" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 19, null, null, "", "Célia", null, "(+212)6 76 30-92-19" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 18, null, null, "", "Clément", null, "(+212)6 86 41-06-81" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 17, null, null, "", "Paul", null, "(+212)6 33 61-12-75" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 16, null, null, "", "Léo", null, "(+212)6 86 76-58-63" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 15, null, null, "", "Valentin", null, "(+212)6 08 00-95-43" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 14, null, null, "", "Hugo", null, "(+212)6 74 35-93-55" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 13, null, null, "", "Maëlys", null, "(+212)6 73 53-63-86" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 12, null, null, "", "Antoine", null, "(+212)6 13 45-21-25" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 11, null, null, "", "Justine", null, "(+212)6 73 49-98-35" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 10, null, null, "", "Valentin", null, "(+212)6 19 77-44-05" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 9, null, null, "", "Camille", null, "(+212)6 79 82-05-45" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 8, null, null, "", "Chloé", null, "(+212)6 18 99-84-26" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 7, null, null, "", "Lola", null, "(+212)6 66 91-81-70" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 6, null, null, "", "Tom", null, "(+212)6 33 05-87-37" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 5, null, null, "", "Lilou", null, "(+212)6 43 16-88-79" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 4, null, null, "", "Baptiste", null, "(+212)6 56 58-26-15" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 3, null, null, "", "Lou", null, "(+212)6 67 18-55-86" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 2, null, null, "", "Mathilde", null, "(+212)6 62 69-99-08" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Email", "Ice", "Nom", "Prenom", "Tel" },
                values: new object[] { 1, null, null, "00", "Client caisse 1", null, "00" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Nom", "Prenom", "Societe", "Telephone" },
                values: new object[] { 1, "Noémie", "Charles", "Guyot - Faure", "(+212)6 84 77-08-92" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Nom", "Prenom", "Societe", "Telephone" },
                values: new object[] { 2, "Kylian", "Meyer", "Brun - Baron", "(+212)6 49 08-12-46" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Nom", "Prenom", "Societe", "Telephone" },
                values: new object[] { 3, "Mattéo", "Berger", "Lefevre SAS", "(+212)6 09 41-48-60" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 1, "Commercial" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 2, "Manager" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 3, "Administrateur" });

            migrationBuilder.InsertData(
                table: "Achats",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdFournisseur", "ModePayement", "Montant", "NumCheque" },
                values: new object[] { 10, 0m, 0m, new DateTime(2020, 4, 27, 9, 17, 4, 258, DateTimeKind.Local).AddTicks(5173), 3, "crédit", 6568m, "" });

            migrationBuilder.InsertData(
                table: "Achats",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdFournisseur", "ModePayement", "Montant", "NumCheque" },
                values: new object[] { 8, 0m, 0m, new DateTime(2020, 10, 30, 14, 45, 0, 307, DateTimeKind.Local).AddTicks(7470), 1, "chèque", 3906m, "" });

            migrationBuilder.InsertData(
                table: "Achats",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdFournisseur", "ModePayement", "Montant", "NumCheque" },
                values: new object[] { 2, 0m, 0m, new DateTime(2020, 2, 7, 23, 3, 14, 477, DateTimeKind.Local).AddTicks(1363), 2, "chèque", 17775m, "" });

            migrationBuilder.InsertData(
                table: "Achats",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdFournisseur", "ModePayement", "Montant", "NumCheque" },
                values: new object[] { 4, 0m, 0m, new DateTime(2020, 1, 4, 21, 57, 55, 660, DateTimeKind.Local).AddTicks(8928), 2, "crédit", 15600m, "" });

            migrationBuilder.InsertData(
                table: "Achats",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdFournisseur", "ModePayement", "Montant", "NumCheque" },
                values: new object[] { 6, 0m, 0m, new DateTime(2020, 2, 20, 17, 4, 16, 394, DateTimeKind.Local).AddTicks(9960), 2, "éspece", 7281m, "" });

            migrationBuilder.InsertData(
                table: "Achats",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdFournisseur", "ModePayement", "Montant", "NumCheque" },
                values: new object[] { 7, 0m, 0m, new DateTime(2020, 5, 3, 17, 40, 53, 15, DateTimeKind.Local).AddTicks(2691), 1, "crédit", 3120m, "" });

            migrationBuilder.InsertData(
                table: "Achats",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdFournisseur", "ModePayement", "Montant", "NumCheque" },
                values: new object[] { 3, 0m, 0m, new DateTime(2020, 3, 7, 18, 36, 16, 573, DateTimeKind.Local).AddTicks(7070), 3, "crédit", 8892m, "" });

            migrationBuilder.InsertData(
                table: "Achats",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdFournisseur", "ModePayement", "Montant", "NumCheque" },
                values: new object[] { 5, 0m, 0m, new DateTime(2020, 7, 5, 17, 8, 30, 236, DateTimeKind.Local).AddTicks(7896), 3, "crédit", 9450m, "" });

            migrationBuilder.InsertData(
                table: "Achats",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdFournisseur", "ModePayement", "Montant", "NumCheque" },
                values: new object[] { 9, 0m, 0m, new DateTime(2019, 12, 22, 6, 1, 38, 224, DateTimeKind.Local).AddTicks(3877), 3, "chèque", 37620m, "" });

            migrationBuilder.InsertData(
                table: "Achats",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdFournisseur", "ModePayement", "Montant", "NumCheque" },
                values: new object[] { 1, 0m, 0m, new DateTime(2020, 9, 26, 9, 37, 17, 874, DateTimeKind.Local).AddTicks(5463), 3, "crédit", 479m, "" });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 2, 0m, 0m, new DateTime(2019, 12, 26, 23, 51, 41, 995, DateTimeKind.Local).AddTicks(4524), 2, "crédit", "", "", "00:00", 59057m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 5, 0m, 0m, new DateTime(2020, 1, 26, 15, 6, 13, 472, DateTimeKind.Local).AddTicks(8672), 1, "crédit", "", "", "00:00", 46488m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 7, 0m, 0m, new DateTime(2020, 1, 9, 12, 18, 55, 691, DateTimeKind.Local).AddTicks(1785), 1, "éspece", "", "", "00:00", 58156m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 10, 0m, 0m, new DateTime(2020, 11, 13, 13, 0, 41, 566, DateTimeKind.Local).AddTicks(9057), 1, "chèque", "", "", "00:00", 38359m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 12, 0m, 0m, new DateTime(2019, 12, 13, 14, 15, 46, 593, DateTimeKind.Local).AddTicks(456), 1, "éspece", "", "", "00:00", 19600m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 15, 0m, 0m, new DateTime(2019, 12, 7, 20, 13, 4, 165, DateTimeKind.Local).AddTicks(8537), 1, "éspece", "", "", "00:00", 26880m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 17, 0m, 0m, new DateTime(2020, 7, 19, 23, 32, 23, 14, DateTimeKind.Local).AddTicks(3312), 1, "chèque", "", "", "00:00", 68628m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 20, 0m, 0m, new DateTime(2020, 9, 20, 13, 35, 28, 772, DateTimeKind.Local).AddTicks(4835), 1, "chèque", "", "", "00:00", 41181m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 1, 0m, 0m, new DateTime(2020, 9, 19, 17, 56, 35, 558, DateTimeKind.Local).AddTicks(7666), 2, "crédit", "", "", "00:00", 41124m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 6, 0m, 0m, new DateTime(2020, 9, 22, 15, 55, 44, 174, DateTimeKind.Local).AddTicks(6793), 2, "éspece", "", "", "00:00", 24490m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 3, 0m, 0m, new DateTime(2020, 3, 10, 9, 51, 45, 660, DateTimeKind.Local).AddTicks(8150), 3, "crédit", "", "", "00:00", 21812m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 16, 0m, 0m, new DateTime(2020, 3, 27, 11, 53, 48, 92, DateTimeKind.Local).AddTicks(1130), 2, "crédit", "", "", "00:00", 16016m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 4, 0m, 0m, new DateTime(2020, 10, 22, 6, 1, 32, 128, DateTimeKind.Local).AddTicks(3310), 3, "crédit", "", "", "00:00", 16268m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 8, 0m, 0m, new DateTime(2020, 9, 22, 10, 29, 12, 465, DateTimeKind.Local).AddTicks(1250), 3, "crédit", "", "", "00:00", 42240m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 9, 0m, 0m, new DateTime(2020, 9, 15, 17, 4, 14, 464, DateTimeKind.Local).AddTicks(3160), 3, "chèque", "", "", "00:00", 21032m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 11, 0m, 0m, new DateTime(2020, 9, 26, 22, 11, 3, 976, DateTimeKind.Local).AddTicks(8221), 3, "crédit", "", "", "00:00", 17158m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 13, 0m, 0m, new DateTime(2020, 11, 14, 7, 3, 26, 369, DateTimeKind.Local).AddTicks(1802), 3, "chèque", "", "", "00:00", 1534m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 18, 0m, 0m, new DateTime(2020, 5, 20, 11, 50, 59, 331, DateTimeKind.Local).AddTicks(6524), 3, "chèque", "", "", "00:00", 88992m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 19, 0m, 0m, new DateTime(2020, 1, 24, 9, 30, 6, 213, DateTimeKind.Local).AddTicks(8293), 3, "crédit", "", "", "00:00", 17875m });

            migrationBuilder.InsertData(
                table: "Commandes",
                columns: new[] { "Id", "Avance", "Credit", "Date", "IdClient", "ModePayement", "NomClient", "NumCheque", "Time", "Total" },
                values: new object[] { 14, 0m, 0m, new DateTime(2020, 8, 10, 7, 4, 58, 700, DateTimeKind.Local).AddTicks(1218), 2, "chèque", "", "", "00:00", 44944m });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 28, 6, "Maëlle" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 36, 6, "Enzo" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 35, 6, "Louise" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 32, 6, "Baptiste" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 31, 6, "Lola" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 1, 1, "Generale" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 20, 6, "Enzo" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 2, 6, "Noa" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 7, 3, "Sacha" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 40, 2, "Léa" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 30, 2, "Axel" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 24, 2, "Pauline" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 19, 2, "Mathis" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 16, 2, "Alexandre" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 21, 3, "Jade" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 4, 2, "Pauline" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 22, 1, "Maëlle" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 15, 1, "Raphaël" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 13, 1, "Camille" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 10, 1, "Romane" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 8, 1, "Lisa" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 6, 1, "Tom" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 39, 1, "Lucie" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 14, 6, "Alicia" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 23, 3, "Quentin" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 3, 4, "Maxence" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 41, 5, "Yanis" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 37, 5, "Lena" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 34, 5, "Lou" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 33, 5, "Maxence" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 27, 5, "Célia" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 18, 5, "Clémence" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 38, 3, "Adrien" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 17, 5, "Gabriel" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 9, 5, "Alexandre" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 29, 4, "Adam" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 26, 4, "Jules" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 25, 4, "Jules" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 11, 4, "Elisa" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 5, 4, "Maxime" });

            migrationBuilder.InsertData(
                table: "SousCategories",
                columns: new[] { "Id", "IdCategorie", "Libelle" },
                values: new object[] { 12, 5, "Tom" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IdRole", "NomComplete", "Password", "Tel" },
                values: new object[] { 1, "admin@angular.io", 3, "admin", "123", "" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 9, false, "Code-9", "Constructeur2", new DateTime(2020, 1, 5, 15, 11, 56, 31, DateTimeKind.Local).AddTicks(7527), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 894m, -305m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-9", "titre long pour un produit avec la nature de super hasardouze-9", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 68, false, "Code-68", "Constructeur3", new DateTime(2020, 9, 19, 10, 47, 12, 411, DateTimeKind.Local).AddTicks(6828), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 446m, -496m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-68", "titre long pour un produit avec la nature de super hasardouze-68", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 44, false, "Code-44", "Constructeur3", new DateTime(2020, 5, 20, 23, 55, 5, 827, DateTimeKind.Local).AddTicks(5505), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 902m, -260m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-44", "titre long pour un produit avec la nature de super hasardouze-44", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 42, false, "Code-42", "Constructeur2", new DateTime(2020, 10, 4, 1, 53, 49, 476, DateTimeKind.Local).AddTicks(3820), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 423m, -79m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-42", "titre long pour un produit avec la nature de super hasardouze-42", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 36, false, "Code-36", "Constructeur3", new DateTime(2020, 5, 10, 19, 9, 58, 804, DateTimeKind.Local).AddTicks(7415), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 173m, -397m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-36", "titre long pour un produit avec la nature de super hasardouze-36", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 24, false, "Code-24", "Constructeur3", new DateTime(2020, 2, 23, 11, 31, 58, 335, DateTimeKind.Local).AddTicks(2768), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 53m, -227m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-24", "titre long pour un produit avec la nature de super hasardouze-24", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 13, false, "Code-13", "Constructeur3", new DateTime(2020, 8, 29, 19, 35, 16, 969, DateTimeKind.Local).AddTicks(9535), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 321m, -70m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-13", "titre long pour un produit avec la nature de super hasardouze-13", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 2, false, "Code-2", "Constructeur2", new DateTime(2020, 5, 25, 2, 53, 1, 459, DateTimeKind.Local).AddTicks(7730), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 814m, -180m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-2", "titre long pour un produit avec la nature de super hasardouze-2", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 1, false, "Code-1", "Constructeur2", new DateTime(2020, 3, 14, 13, 52, 15, 339, DateTimeKind.Local).AddTicks(7059), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 578m, -86m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-1", "titre long pour un produit avec la nature de super hasardouze-1", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 100, false, "Code-100", "Constructeur1", new DateTime(2020, 8, 31, 0, 16, 36, 240, DateTimeKind.Local).AddTicks(358), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 735m, -225m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-100", "titre long pour un produit avec la nature de super hasardouze-100", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 91, true, "Code-91", "Constructeur1", new DateTime(2020, 1, 17, 10, 17, 35, 25, DateTimeKind.Local).AddTicks(2364), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 904m, -307m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-91", "titre long pour un produit avec la nature de super hasardouze-91", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 60, false, "Code-60", "Constructeur2", new DateTime(2020, 6, 25, 22, 38, 32, 545, DateTimeKind.Local).AddTicks(7637), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 479m, -224m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-60", "titre long pour un produit avec la nature de super hasardouze-60", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 57, false, "Code-57", "Constructeur3", new DateTime(2020, 8, 3, 23, 4, 38, 191, DateTimeKind.Local).AddTicks(4666), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 371m, -307m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-57", "titre long pour un produit avec la nature de super hasardouze-57", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 56, false, "Code-56", "Constructeur2", new DateTime(2020, 10, 31, 21, 45, 47, 288, DateTimeKind.Local).AddTicks(2576), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 228m, -284m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-56", "titre long pour un produit avec la nature de super hasardouze-56", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 45, false, "Code-45", "Constructeur3", new DateTime(2020, 5, 7, 1, 46, 48, 608, DateTimeKind.Local).AddTicks(4172), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 998m, -391m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-45", "titre long pour un produit avec la nature de super hasardouze-45", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 40, false, "Code-40", "Constructeur3", new DateTime(2020, 5, 31, 16, 0, 46, 360, DateTimeKind.Local).AddTicks(2171), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 198m, -288m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-40", "titre long pour un produit avec la nature de super hasardouze-40", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 32, false, "Code-32", "Constructeur2", new DateTime(2020, 10, 28, 7, 9, 24, 763, DateTimeKind.Local).AddTicks(1840), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 450m, -132m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-32", "titre long pour un produit avec la nature de super hasardouze-32", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 15, false, "Code-15", "Constructeur1", new DateTime(2019, 12, 29, 17, 16, 33, 223, DateTimeKind.Local).AddTicks(3459), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 943m, -329m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-15", "titre long pour un produit avec la nature de super hasardouze-15", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 11, false, "Code-11", "Constructeur1", new DateTime(2020, 8, 19, 6, 3, 26, 257, DateTimeKind.Local).AddTicks(8377), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 56m, -257m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-11", "titre long pour un produit avec la nature de super hasardouze-11", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 7, false, "Code-7", "Constructeur3", new DateTime(2020, 11, 4, 19, 56, 1, 803, DateTimeKind.Local).AddTicks(2343), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 122m, -265m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-7", "titre long pour un produit avec la nature de super hasardouze-7", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 3, false, "Code-3", "Constructeur3", new DateTime(2020, 1, 4, 6, 0, 36, 64, DateTimeKind.Local).AddTicks(4337), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 3, "", 692m, -187m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-3", "titre long pour un produit avec la nature de super hasardouze-3", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 90, false, "Code-90", "Constructeur1", new DateTime(2020, 6, 7, 3, 59, 59, 247, DateTimeKind.Local).AddTicks(4078), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 59m, -441m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-90", "titre long pour un produit avec la nature de super hasardouze-90", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 75, false, "Code-75", "Constructeur3", new DateTime(2020, 11, 18, 10, 4, 26, 456, DateTimeKind.Local).AddTicks(9815), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 777m, -427m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-75", "titre long pour un produit avec la nature de super hasardouze-75", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 83, true, "Code-83", "Constructeur3", new DateTime(2020, 10, 17, 22, 57, 24, 804, DateTimeKind.Local).AddTicks(6801), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 448m, -133m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-83", "titre long pour un produit avec la nature de super hasardouze-83", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 76, false, "Code-76", "Constructeur3", new DateTime(2020, 11, 17, 4, 5, 38, 273, DateTimeKind.Local).AddTicks(4800), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 868m, -263m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-76", "titre long pour un produit avec la nature de super hasardouze-76", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 93, true, "Code-93", "Constructeur3", new DateTime(2019, 12, 26, 6, 25, 42, 940, DateTimeKind.Local).AddTicks(5610), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 171m, -216m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-93", "titre long pour un produit avec la nature de super hasardouze-93", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 61, false, "Code-61", "Constructeur3", new DateTime(2020, 9, 28, 3, 54, 18, 551, DateTimeKind.Local).AddTicks(2361), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 135m, -191m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-61", "titre long pour un produit avec la nature de super hasardouze-61", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 59, false, "Code-59", "Constructeur3", new DateTime(2020, 10, 19, 19, 0, 24, 521, DateTimeKind.Local).AddTicks(7970), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 532m, -430m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-59", "titre long pour un produit avec la nature de super hasardouze-59", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 49, false, "Code-49", "Constructeur2", new DateTime(2020, 6, 14, 15, 12, 8, 842, DateTimeKind.Local).AddTicks(5864), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 491m, -441m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-49", "titre long pour un produit avec la nature de super hasardouze-49", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 37, false, "Code-37", "Constructeur2", new DateTime(2020, 6, 13, 15, 49, 53, 504, DateTimeKind.Local).AddTicks(5746), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 911m, -200m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-37", "titre long pour un produit avec la nature de super hasardouze-37", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 27, false, "Code-27", "Constructeur3", new DateTime(2020, 8, 11, 9, 57, 4, 169, DateTimeKind.Local).AddTicks(8208), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 12m, -532m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-27", "titre long pour un produit avec la nature de super hasardouze-27", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 23, false, "Code-23", "Constructeur1", new DateTime(2020, 2, 20, 6, 42, 43, 888, DateTimeKind.Local).AddTicks(5432), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 52m, -233m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-23", "titre long pour un produit avec la nature de super hasardouze-23", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 19, false, "Code-19", "Constructeur3", new DateTime(2020, 4, 21, 22, 43, 51, 979, DateTimeKind.Local).AddTicks(3561), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 450m, -82m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-19", "titre long pour un produit avec la nature de super hasardouze-19", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 17, false, "Code-17", "Constructeur2", new DateTime(2020, 7, 14, 5, 36, 40, 751, DateTimeKind.Local).AddTicks(354), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 491m, -284m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-17", "titre long pour un produit avec la nature de super hasardouze-17", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 4, false, "Code-4", "Constructeur2", new DateTime(2019, 12, 2, 1, 34, 28, 121, DateTimeKind.Local).AddTicks(4657), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 737m, -282m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-4", "titre long pour un produit avec la nature de super hasardouze-4", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 82, false, "Code-82", "Constructeur1", new DateTime(2020, 9, 10, 15, 16, 40, 658, DateTimeKind.Local).AddTicks(2114), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 876m, -417m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-82", "titre long pour un produit avec la nature de super hasardouze-82", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 79, false, "Code-79", "Constructeur3", new DateTime(2019, 12, 28, 2, 31, 46, 572, DateTimeKind.Local).AddTicks(183), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 848m, -491m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-79", "titre long pour un produit avec la nature de super hasardouze-79", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 64, false, "Code-64", "Constructeur1", new DateTime(2020, 6, 10, 3, 15, 11, 664, DateTimeKind.Local).AddTicks(3469), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 441m, -293m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-64", "titre long pour un produit avec la nature de super hasardouze-64", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 54, false, "Code-54", "Constructeur1", new DateTime(2019, 12, 9, 4, 1, 54, 441, DateTimeKind.Local).AddTicks(3405), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 821m, -387m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-54", "titre long pour un produit avec la nature de super hasardouze-54", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 52, false, "Code-52", "Constructeur2", new DateTime(2020, 7, 5, 8, 2, 25, 444, DateTimeKind.Local).AddTicks(5855), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 881m, -89m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-52", "titre long pour un produit avec la nature de super hasardouze-52", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 50, false, "Code-50", "Constructeur3", new DateTime(2019, 12, 3, 14, 38, 59, 20, DateTimeKind.Local).AddTicks(250), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 664m, -305m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-50", "titre long pour un produit avec la nature de super hasardouze-50", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 46, false, "Code-46", "Constructeur3", new DateTime(2019, 12, 6, 3, 15, 12, 682, DateTimeKind.Local).AddTicks(3659), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 325m, -171m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-46", "titre long pour un produit avec la nature de super hasardouze-46", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 43, false, "Code-43", "Constructeur1", new DateTime(2019, 12, 27, 20, 31, 16, 818, DateTimeKind.Local).AddTicks(2369), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 759m, 34m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-43", "titre long pour un produit avec la nature de super hasardouze-43", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 41, false, "Code-41", "Constructeur2", new DateTime(2020, 7, 6, 10, 18, 30, 687, DateTimeKind.Local).AddTicks(8886), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 476m, -227m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-41", "titre long pour un produit avec la nature de super hasardouze-41", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 5, false, "Code-5", "Constructeur1", new DateTime(2020, 5, 19, 9, 28, 55, 783, DateTimeKind.Local).AddTicks(818), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 9, "", 287m, 74m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-5", "titre long pour un produit avec la nature de super hasardouze-5", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 99, true, "Code-99", "Constructeur3", new DateTime(2020, 4, 9, 1, 38, 7, 946, DateTimeKind.Local).AddTicks(9995), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 799m, -488m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-99", "titre long pour un produit avec la nature de super hasardouze-99", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 97, true, "Code-97", "Constructeur1", new DateTime(2020, 10, 11, 9, 4, 49, 267, DateTimeKind.Local).AddTicks(9448), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 500m, -96m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-97", "titre long pour un produit avec la nature de super hasardouze-97", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 85, true, "Code-85", "Constructeur3", new DateTime(2020, 10, 14, 11, 49, 24, 362, DateTimeKind.Local).AddTicks(4340), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 5, "", 395m, -320m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-85", "titre long pour un produit avec la nature de super hasardouze-85", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 77, false, "Code-77", "Constructeur3", new DateTime(2020, 8, 10, 18, 47, 32, 974, DateTimeKind.Local).AddTicks(9053), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 465m, -132m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-77", "titre long pour un produit avec la nature de super hasardouze-77", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 62, false, "Code-62", "Constructeur1", new DateTime(2020, 2, 21, 16, 21, 31, 354, DateTimeKind.Local).AddTicks(9534), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 804m, -153m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-62", "titre long pour un produit avec la nature de super hasardouze-62", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 58, false, "Code-58", "Constructeur3", new DateTime(2020, 9, 4, 4, 16, 35, 902, DateTimeKind.Local).AddTicks(5827), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 664m, -340m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-58", "titre long pour un produit avec la nature de super hasardouze-58", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 51, false, "Code-51", "Constructeur1", new DateTime(2020, 4, 25, 9, 20, 31, 216, DateTimeKind.Local).AddTicks(8382), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 136m, -103m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-51", "titre long pour un produit avec la nature de super hasardouze-51", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 28, false, "Code-28", "Constructeur3", new DateTime(2020, 9, 20, 19, 50, 33, 732, DateTimeKind.Local).AddTicks(2315), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 199m, -235m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-28", "titre long pour un produit avec la nature de super hasardouze-28", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 21, false, "Code-21", "Constructeur2", new DateTime(2020, 5, 8, 8, 20, 54, 455, DateTimeKind.Local).AddTicks(9917), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 195m, -292m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-21", "titre long pour un produit avec la nature de super hasardouze-21", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 18, false, "Code-18", "Constructeur2", new DateTime(2020, 11, 21, 21, 4, 58, 203, DateTimeKind.Local).AddTicks(7734), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 420m, -204m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-18", "titre long pour un produit avec la nature de super hasardouze-18", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 16, false, "Code-16", "Constructeur1", new DateTime(2020, 4, 10, 1, 11, 52, 219, DateTimeKind.Local).AddTicks(1837), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 660m, -344m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-16", "titre long pour un produit avec la nature de super hasardouze-16", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 92, false, "Code-92", "Constructeur2", new DateTime(2020, 4, 19, 22, 26, 48, 225, DateTimeKind.Local).AddTicks(3541), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 988m, -312m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-92", "titre long pour un produit avec la nature de super hasardouze-92", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 87, true, "Code-87", "Constructeur2", new DateTime(2020, 6, 26, 4, 7, 19, 262, DateTimeKind.Local).AddTicks(1206), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 281m, -572m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-87", "titre long pour un produit avec la nature de super hasardouze-87", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 69, false, "Code-69", "Constructeur1", new DateTime(2020, 6, 23, 18, 24, 11, 294, DateTimeKind.Local).AddTicks(6378), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 286m, -189m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-69", "titre long pour un produit avec la nature de super hasardouze-69", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 66, false, "Code-66", "Constructeur3", new DateTime(2020, 9, 21, 22, 4, 37, 579, DateTimeKind.Local).AddTicks(9347), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 118m, -312m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-66", "titre long pour un produit avec la nature de super hasardouze-66", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 63, false, "Code-63", "Constructeur1", new DateTime(2020, 9, 23, 22, 0, 43, 899, DateTimeKind.Local).AddTicks(455), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 835m, -367m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-63", "titre long pour un produit avec la nature de super hasardouze-63", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 22, false, "Code-22", "Constructeur3", new DateTime(2020, 7, 29, 1, 45, 25, 385, DateTimeKind.Local).AddTicks(9758), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 925m, -634m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-22", "titre long pour un produit avec la nature de super hasardouze-22", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 12, false, "Code-12", "Constructeur3", new DateTime(2020, 6, 25, 1, 56, 4, 308, DateTimeKind.Local).AddTicks(9238), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 6, "", 50m, -185m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-12", "titre long pour un produit avec la nature de super hasardouze-12", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 94, false, "Code-94", "Constructeur1", new DateTime(2020, 1, 26, 6, 31, 54, 542, DateTimeKind.Local).AddTicks(8505), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 581m, -412m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-94", "titre long pour un produit avec la nature de super hasardouze-94", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 89, true, "Code-89", "Constructeur2", new DateTime(2020, 7, 2, 7, 22, 3, 574, DateTimeKind.Local).AddTicks(6097), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 927m, -275m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-89", "titre long pour un produit avec la nature de super hasardouze-89", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 73, false, "Code-73", "Constructeur3", new DateTime(2020, 4, 1, 14, 14, 44, 849, DateTimeKind.Local).AddTicks(5171), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 357m, -231m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-73", "titre long pour un produit avec la nature de super hasardouze-73", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 53, false, "Code-53", "Constructeur2", new DateTime(2020, 1, 28, 10, 53, 13, 664, DateTimeKind.Local).AddTicks(3202), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 40m, -90m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-53", "titre long pour un produit avec la nature de super hasardouze-53", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 48, false, "Code-48", "Constructeur3", new DateTime(2019, 12, 3, 1, 32, 34, 505, DateTimeKind.Local).AddTicks(8679), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 814m, -33m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-48", "titre long pour un produit avec la nature de super hasardouze-48", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 47, false, "Code-47", "Constructeur2", new DateTime(2020, 7, 19, 10, 0, 5, 941, DateTimeKind.Local).AddTicks(3958), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 950m, -368m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-47", "titre long pour un produit avec la nature de super hasardouze-47", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 38, false, "Code-38", "Constructeur3", new DateTime(2020, 1, 14, 1, 57, 4, 908, DateTimeKind.Local).AddTicks(5146), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 215m, -354m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-38", "titre long pour un produit avec la nature de super hasardouze-38", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 29, false, "Code-29", "Constructeur1", new DateTime(2020, 10, 24, 21, 49, 8, 77, DateTimeKind.Local).AddTicks(700), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 823m, -14m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-29", "titre long pour un produit avec la nature de super hasardouze-29", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 25, false, "Code-25", "Constructeur3", new DateTime(2020, 7, 15, 4, 13, 16, 191, DateTimeKind.Local).AddTicks(5355), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 1, "", 478m, -204m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-25", "titre long pour un produit avec la nature de super hasardouze-25", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 65, false, "Code-65", "Constructeur1", new DateTime(2020, 8, 6, 23, 7, 26, 458, DateTimeKind.Local).AddTicks(1460), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 195m, -216m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-65", "titre long pour un produit avec la nature de super hasardouze-65", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 70, false, "Code-70", "Constructeur1", new DateTime(2020, 8, 19, 12, 4, 47, 977, DateTimeKind.Local).AddTicks(3000), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 886m, -167m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-70", "titre long pour un produit avec la nature de super hasardouze-70", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 81, true, "Code-81", "Constructeur3", new DateTime(2019, 11, 29, 15, 17, 7, 330, DateTimeKind.Local).AddTicks(5270), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 678m, -276m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-81", "titre long pour un produit avec la nature de super hasardouze-81", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 84, false, "Code-84", "Constructeur1", new DateTime(2020, 9, 16, 17, 4, 41, 172, DateTimeKind.Local).AddTicks(4904), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 8, "", 225m, -290m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-84", "titre long pour un produit avec la nature de super hasardouze-84", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 26, false, "Code-26", "Constructeur3", new DateTime(2020, 6, 9, 9, 46, 20, 17, DateTimeKind.Local).AddTicks(4907), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 903m, -113m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-26", "titre long pour un produit avec la nature de super hasardouze-26", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 14, false, "Code-14", "Constructeur2", new DateTime(2020, 2, 14, 15, 8, 1, 290, DateTimeKind.Local).AddTicks(3181), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 564m, -291m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-14", "titre long pour un produit avec la nature de super hasardouze-14", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 10, false, "Code-10", "Constructeur1", new DateTime(2020, 10, 16, 9, 31, 53, 300, DateTimeKind.Local).AddTicks(2843), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 7, "", 581m, -303m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-10", "titre long pour un produit avec la nature de super hasardouze-10", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 95, true, "Code-95", "Constructeur3", new DateTime(2020, 6, 14, 16, 49, 43, 696, DateTimeKind.Local).AddTicks(7012), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 38m, -260m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-95", "titre long pour un produit avec la nature de super hasardouze-95", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 88, false, "Code-88", "Constructeur1", new DateTime(2020, 4, 13, 20, 19, 27, 325, DateTimeKind.Local).AddTicks(8175), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 746m, -267m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-88", "titre long pour un produit avec la nature de super hasardouze-88", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 86, false, "Code-86", "Constructeur3", new DateTime(2020, 9, 22, 22, 11, 7, 781, DateTimeKind.Local).AddTicks(6919), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 298m, -325m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-86", "titre long pour un produit avec la nature de super hasardouze-86", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 80, false, "Code-80", "Constructeur3", new DateTime(2020, 10, 29, 23, 18, 47, 396, DateTimeKind.Local).AddTicks(8789), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 611m, -209m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-80", "titre long pour un produit avec la nature de super hasardouze-80", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 74, false, "Code-74", "Constructeur3", new DateTime(2020, 9, 21, 17, 13, 0, 165, DateTimeKind.Local).AddTicks(3584), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 286m, -164m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-74", "titre long pour un produit avec la nature de super hasardouze-74", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 39, false, "Code-39", "Constructeur2", new DateTime(2020, 3, 1, 15, 9, 22, 227, DateTimeKind.Local).AddTicks(5577), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 596m, -581m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-39", "titre long pour un produit avec la nature de super hasardouze-39", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 35, false, "Code-35", "Constructeur1", new DateTime(2020, 5, 3, 9, 33, 58, 234, DateTimeKind.Local).AddTicks(4689), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 392m, -404m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-35", "titre long pour un produit avec la nature de super hasardouze-35", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 67, false, "Code-67", "Constructeur2", new DateTime(2020, 4, 22, 5, 8, 29, 866, DateTimeKind.Local).AddTicks(198), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 995m, -197m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-67", "titre long pour un produit avec la nature de super hasardouze-67", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 33, false, "Code-33", "Constructeur1", new DateTime(2020, 6, 23, 0, 46, 10, 510, DateTimeKind.Local).AddTicks(8685), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 605m, -267m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-33", "titre long pour un produit avec la nature de super hasardouze-33", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 20, false, "Code-20", "Constructeur1", new DateTime(2020, 4, 29, 13, 33, 35, 994, DateTimeKind.Local).AddTicks(6714), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 344m, -379m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-20", "titre long pour un produit avec la nature de super hasardouze-20", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 8, false, "Code-8", "Constructeur2", new DateTime(2020, 4, 6, 21, 8, 53, 614, DateTimeKind.Local).AddTicks(4862), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 84m, -240m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-8", "titre long pour un produit avec la nature de super hasardouze-8", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 6, false, "Code-6", "Constructeur1", new DateTime(2019, 12, 16, 0, 53, 15, 279, DateTimeKind.Local).AddTicks(2749), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 271m, -437m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-6", "titre long pour un produit avec la nature de super hasardouze-6", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 98, false, "Code-98", "Constructeur1", new DateTime(2020, 5, 21, 8, 55, 52, 134, DateTimeKind.Local).AddTicks(5474), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 809m, -112m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-98", "titre long pour un produit avec la nature de super hasardouze-98", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 96, false, "Code-96", "Constructeur3", new DateTime(2020, 9, 17, 5, 43, 52, 314, DateTimeKind.Local).AddTicks(1454), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 755m, -66m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-96", "titre long pour un produit avec la nature de super hasardouze-96", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 72, false, "Code-72", "Constructeur1", new DateTime(2019, 12, 5, 17, 56, 53, 62, DateTimeKind.Local).AddTicks(9677), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 279m, -95m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-72", "titre long pour un produit avec la nature de super hasardouze-72", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 71, false, "Code-71", "Constructeur2", new DateTime(2019, 12, 2, 5, 13, 22, 303, DateTimeKind.Local).AddTicks(7015), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 326m, -301m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-71", "titre long pour un produit avec la nature de super hasardouze-71", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 55, false, "Code-55", "Constructeur3", new DateTime(2020, 3, 13, 1, 18, 27, 26, DateTimeKind.Local).AddTicks(3765), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 828m, -135m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-55", "titre long pour un produit avec la nature de super hasardouze-55", "U" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 34, false, "Code-34", "Constructeur3", new DateTime(2020, 2, 21, 2, 33, 40, 410, DateTimeKind.Local).AddTicks(3468), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 172m, -332m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-34", "titre long pour un produit avec la nature de super hasardouze-34", "L" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 31, false, "Code-31", "Constructeur3", new DateTime(2020, 5, 15, 16, 5, 27, 268, DateTimeKind.Local).AddTicks(4501), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 10, "", 431m, -327m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-31", "titre long pour un produit avec la nature de super hasardouze-31", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 30, false, "Code-30", "Constructeur2", new DateTime(2020, 5, 7, 13, 25, 51, 686, DateTimeKind.Local).AddTicks(4272), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 4, "", 21m, -186m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-30", "titre long pour un produit avec la nature de super hasardouze-30", "Kg" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "BestSell", "Code", "Constructeur", "DateDernierAchat", "Description", "EmplacementDepot", "EmplacementMagasin", "IdSousCategorie", "Image", "PrixUnitaire", "QteStock", "StockMin", "TitreAr", "TitreFr", "Unite" },
                values: new object[] { 78, false, "Code-78", "Constructeur2", new DateTime(2020, 8, 17, 4, 46, 39, 591, DateTimeKind.Local).AddTicks(501), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit rerum, voluptates debitis, blanditiis quibusdam consequatur maxime repudiandae placeat a molestias dolores molestiae incidunt, nobis tempore doloribus expedita maiores. Atque, magnam!", null, null, 2, "", 71m, -199m, 10m, "عنوان طويل لمنتج ذي طبيعة فائقة الخطورة-78", "titre long pour un produit avec la nature de super hasardouze-78", "Kg" });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 9, 8, 894m, 29m, 0m, 25926m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 57, 18, 371m, 34m, 0m, 12614m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 57, 1, 371m, 95m, 0m, 35245m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 57, 14, 371m, 67m, 0m, 24857m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 57, 4, 371m, 29m, 0m, 10759m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 57, 3, 371m, 52m, 0m, 19292m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 57, 7, 371m, 30m, 0m, 11130m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 60, 15, 479m, 54m, 0m, 25866m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 60, 10, 479m, 73m, 0m, 34967m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 60, 2, 479m, 8m, 0m, 3832m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 60, 20, 479m, 23m, 0m, 11017m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 60, 3, 479m, 10m, 0m, 4790m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 60, 4, 479m, 57m, 0m, 27303m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 91, 14, 904m, 19m, 0m, 17176m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 91, 15, 904m, 80m, 0m, 72320m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 91, 8, 904m, 33m, 0m, 29832m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 57, 15, 371m, 40m, 0m, 14840m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 57, 11, 371m, 95m, 0m, 35245m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 57, 2, 371m, 9m, 0m, 3339m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 56, 13, 228m, 87m, 0m, 19836m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 40, 13, 198m, 93m, 0m, 18414m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 45, 10, 998m, 100m, 0m, 99800m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 45, 13, 998m, 70m, 0m, 69860m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 45, 8, 998m, 47m, 0m, 46906m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 45, 5, 998m, 66m, 0m, 65868m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 45, 15, 998m, 19m, 0m, 18962m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 45, 18, 998m, 30m, 0m, 29940m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 91, 9, 904m, 66m, 0m, 59664m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 45, 11, 998m, 15m, 0m, 14970m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 56, 10, 228m, 70m, 0m, 15960m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 56, 19, 228m, 68m, 0m, 15504m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 56, 20, 228m, 75m, 0m, 17100m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 56, 3, 228m, 62m, 0m, 14136m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 56, 6, 228m, 27m, 0m, 6156m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 56, 12, 228m, 13m, 0m, 2964m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 56, 5, 228m, 37m, 0m, 8436m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 45, 6, 998m, 44m, 0m, 43912m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 91, 1, 904m, 53m, 0m, 47912m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 91, 7, 904m, 13m, 0m, 11752m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 91, 6, 904m, 43m, 0m, 38872m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 24, 4, 53m, 57m, 0m, 3021m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 24, 5, 53m, 32m, 0m, 1696m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 24, 20, 53m, 96m, 0m, 5088m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 24, 13, 53m, 3m, 0m, 159m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 36, 3, 173m, 93m, 0m, 16089m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 36, 12, 173m, 29m, 0m, 5017m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 36, 4, 173m, 67m, 0m, 11591m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 24, 1, 53m, 80m, 0m, 4240m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 36, 15, 173m, 19m, 0m, 3287m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 36, 10, 173m, 6m, 0m, 1038m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 36, 2, 173m, 87m, 0m, 15051m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 42, 2, 423m, 44m, 0m, 18612m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 42, 1, 423m, 35m, 0m, 14805m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 44, 17, 902m, 74m, 0m, 66748m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 44, 7, 902m, 97m, 0m, 87494m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 44, 19, 902m, 89m, 0m, 80278m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 36, 11, 173m, 96m, 0m, 16608m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 40, 15, 198m, 73m, 0m, 14454m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 24, 16, 53m, 4m, 0m, 212m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 13, 18, 321m, 61m, 0m, 19581m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 100, 6, 735m, 41m, 0m, 30135m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 100, 17, 735m, 21m, 0m, 15435m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 100, 2, 735m, 23m, 0m, 16905m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 100, 5, 735m, 93m, 0m, 68355m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 100, 4, 735m, 8m, 0m, 5880m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 100, 10, 735m, 63m, 0m, 46305m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 1, 5, 578m, 91m, 0m, 52598m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 24, 2, 53m, 81m, 0m, 4293m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 1, 6, 578m, 37m, 0m, 21386m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 1, 20, 578m, 29m, 0m, 16762m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 1, 17, 578m, 21m, 0m, 12138m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 1, 1, 578m, 16m, 0m, 9248m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 2, 19, 814m, 98m, 0m, 79772m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 2, 9, 814m, 60m, 0m, 48840m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 2, 4, 814m, 94m, 0m, 76516m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 13, 5, 321m, 22m, 0m, 7062m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 1, 9, 578m, 16m, 0m, 9248m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 40, 8, 198m, 86m, 0m, 17028m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 40, 2, 198m, 36m, 0m, 7128m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 32, 17, 450m, 13m, 0m, 5850m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 62, 15, 804m, 68m, 0m, 54672m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 62, 6, 804m, 1m, 0m, 804m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 62, 18, 804m, 77m, 0m, 61908m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 78, 3, 71m, 50m, 0m, 3550m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 77, 17, 465m, 59m, 0m, 27435m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 77, 13, 465m, 13m, 0m, 6045m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 77, 2, 465m, 14m, 0m, 6510m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 62, 8, 804m, 80m, 0m, 64320m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 77, 8, 465m, 96m, 0m, 44640m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 83, 19, 448m, 93m, 0m, 41664m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 90, 10, 59m, 21m, 0m, 1239m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 90, 18, 59m, 30m, 0m, 1770m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 90, 12, 59m, 45m, 0m, 2655m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 90, 20, 59m, 74m, 0m, 4366m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 90, 4, 59m, 16m, 0m, 944m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 90, 14, 59m, 72m, 0m, 4248m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 83, 20, 448m, 69m, 0m, 30912m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 90, 3, 59m, 92m, 0m, 5428m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 58, 1, 664m, 61m, 0m, 40504m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 58, 16, 664m, 80m, 0m, 53120m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 10, 7, 581m, 41m, 0m, 23821m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 10, 8, 581m, 62m, 0m, 36022m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 10, 13, 581m, 2m, 0m, 1162m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 10, 4, 581m, 28m, 0m, 16268m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 14, 1, 564m, 77m, 0m, 43428m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 14, 17, 564m, 45m, 0m, 25380m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 14, 12, 564m, 94m, 0m, 53016m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 58, 12, 664m, 62m, 0m, 41168m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 14, 15, 564m, 16m, 0m, 9024m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 26, 14, 903m, 58m, 0m, 52374m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 26, 6, 903m, 21m, 0m, 18963m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 26, 8, 903m, 28m, 0m, 25284m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 26, 11, 903m, 16m, 0m, 14448m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 26, 17, 903m, 76m, 0m, 68628m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 58, 17, 664m, 46m, 0m, 30544m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 58, 7, 664m, 91m, 0m, 60424m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 14, 10, 564m, 59m, 0m, 33276m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 68, 18, 446m, 63m, 0m, 28098m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 90, 2, 59m, 88m, 0m, 5192m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 90, 16, 59m, 11m, 0m, 649m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 11, 8, 56m, 73m, 0m, 4088m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 15, 18, 943m, 3m, 0m, 2829m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 15, 4, 943m, 27m, 0m, 25461m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 15, 7, 943m, 22m, 0m, 20746m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 15, 15, 943m, 75m, 0m, 70725m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 15, 1, 943m, 7m, 0m, 6601m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 15, 12, 943m, 45m, 0m, 42435m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 11, 16, 56m, 30m, 0m, 1680m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 15, 16, 943m, 86m, 0m, 81098m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 15, 6, 943m, 27m, 0m, 25461m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 15, 11, 943m, 19m, 0m, 17917m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 32, 2, 450m, 79m, 0m, 35550m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 32, 4, 450m, 77m, 0m, 34650m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 32, 7, 450m, 8m, 0m, 3600m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 32, 14, 450m, 28m, 0m, 12600m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 32, 11, 450m, 33m, 0m, 14850m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 15, 14, 943m, 84m, 0m, 79212m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 90, 7, 59m, 89m, 0m, 5251m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 11, 12, 56m, 94m, 0m, 5264m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 11, 11, 56m, 6m, 0m, 336m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 3, 6, 692m, 57m, 0m, 39444m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 3, 7, 692m, 31m, 0m, 21452m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 3, 8, 692m, 90m, 0m, 62280m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 3, 1, 692m, 9m, 0m, 6228m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 7, 16, 122m, 71m, 0m, 8662m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 7, 1, 122m, 93m, 0m, 11346m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 7, 14, 122m, 38m, 0m, 4636m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 11, 1, 56m, 49m, 0m, 2744m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 7, 7, 122m, 10m, 0m, 1220m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 7, 19, 122m, 12m, 0m, 1464m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 7, 13, 122m, 56m, 0m, 6832m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 7, 8, 122m, 36m, 0m, 4392m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 7, 12, 122m, 25m, 0m, 3050m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 7, 11, 122m, 38m, 0m, 4636m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 7, 10, 122m, 74m, 0m, 9028m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 11, 2, 56m, 59m, 0m, 3304m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 7, 20, 122m, 65m, 0m, 7930m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 10, 15, 581m, 67m, 0m, 38927m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 68, 13, 446m, 56m, 0m, 24976m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 68, 19, 446m, 54m, 0m, 24084m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 17, 13, 491m, 60m, 0m, 29460m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 17, 2, 491m, 67m, 0m, 32897m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 17, 18, 491m, 6m, 0m, 2946m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 19, 2, 450m, 8m, 0m, 3600m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 19, 9, 450m, 64m, 0m, 28800m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 19, 5, 450m, 75m, 0m, 33750m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 19, 12, 450m, 13m, 0m, 5850m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 19, 15, 450m, 15m, 0m, 6750m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 23, 15, 52m, 2m, 0m, 104m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 23, 1, 52m, 97m, 0m, 5044m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 23, 16, 52m, 55m, 0m, 2860m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 23, 9, 52m, 79m, 0m, 4108m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 27, 1, 12m, 70m, 0m, 840m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 27, 8, 12m, 50m, 0m, 600m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 27, 10, 12m, 24m, 0m, 288m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 17, 10, 491m, 92m, 0m, 45172m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 17, 17, 491m, 28m, 0m, 13748m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 17, 9, 491m, 31m, 0m, 15221m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 4, 7, 737m, 3m, 0m, 2211m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 79, 2, 848m, 86m, 0m, 72928m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 79, 13, 848m, 44m, 0m, 37312m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 79, 14, 848m, 53m, 0m, 44944m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 82, 16, 876m, 21m, 0m, 18396m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 82, 3, 876m, 92m, 0m, 80592m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 82, 5, 876m, 77m, 0m, 67452m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 82, 18, 876m, 83m, 0m, 72708m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 27, 12, 12m, 49m, 0m, 588m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 82, 4, 876m, 56m, 0m, 49056m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 82, 9, 876m, 17m, 0m, 14892m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 4, 8, 737m, 48m, 0m, 35376m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 4, 6, 737m, 45m, 0m, 33165m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 4, 1, 737m, 19m, 0m, 14003m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 4, 17, 737m, 4m, 0m, 2948m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 4, 2, 737m, 87m, 0m, 64119m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 4, 10, 737m, 76m, 0m, 56012m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 82, 6, 876m, 81m, 0m, 70956m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 27, 16, 12m, 74m, 0m, 888m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 27, 15, 12m, 56m, 0m, 672m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 27, 5, 12m, 23m, 0m, 276m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 59, 5, 532m, 85m, 0m, 45220m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 59, 20, 532m, 74m, 0m, 39368m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 59, 14, 532m, 5m, 0m, 2660m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 59, 13, 532m, 27m, 0m, 14364m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 59, 3, 532m, 41m, 0m, 21812m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 61, 5, 135m, 49m, 0m, 6615m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 61, 10, 135m, 6m, 0m, 810m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 59, 19, 532m, 83m, 0m, 44156m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 61, 11, 135m, 83m, 0m, 11205m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 61, 12, 135m, 59m, 0m, 7965m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 61, 19, 135m, 41m, 0m, 5535m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 67, 9, 995m, 54m, 0m, 53730m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 67, 14, 995m, 100m, 0m, 99500m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 67, 15, 995m, 3m, 0m, 2985m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 67, 6, 995m, 68m, 0m, 67660m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 78, 4, 71m, 51m, 0m, 3621m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 61, 17, 135m, 19m, 0m, 2565m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 79, 12, 848m, 93m, 0m, 78864m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 59, 4, 532m, 25m, 0m, 13300m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 49, 14, 491m, 47m, 0m, 23077m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 27, 18, 12m, 65m, 0m, 780m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 27, 20, 12m, 82m, 0m, 984m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 27, 9, 12m, 39m, 0m, 468m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 37, 9, 911m, 27m, 0m, 24597m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 37, 19, 911m, 99m, 0m, 90189m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 37, 15, 911m, 31m, 0m, 28241m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 37, 12, 911m, 43m, 0m, 39173m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 59, 16, 532m, 90m, 0m, 47880m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 49, 20, 491m, 86m, 0m, 42226m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 49, 10, 491m, 24m, 0m, 11784m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 49, 9, 491m, 41m, 0m, 20131m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 49, 17, 491m, 16m, 0m, 7856m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 49, 6, 491m, 20m, 0m, 9820m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 49, 13, 491m, 64m, 0m, 31424m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 49, 4, 491m, 96m, 0m, 47136m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 49, 12, 491m, 52m, 0m, 25532m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 49, 7, 491m, 76m, 0m, 37316m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 79, 20, 848m, 71m, 0m, 60208m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 79, 9, 848m, 52m, 0m, 44096m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 79, 7, 848m, 92m, 0m, 78016m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 85, 5, 395m, 42m, 0m, 16590m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 85, 17, 395m, 34m, 0m, 13430m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 85, 12, 395m, 87m, 0m, 34365m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 85, 6, 395m, 62m, 0m, 24490m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 93, 8, 171m, 59m, 0m, 10089m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 93, 18, 171m, 54m, 0m, 9234m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 93, 6, 171m, 69m, 0m, 11799m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 85, 7, 395m, 58m, 0m, 22910m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 93, 9, 171m, 93m, 0m, 15903m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 93, 1, 171m, 1m, 0m, 171m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 97, 3, 500m, 56m, 0m, 28000m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 97, 19, 500m, 53m, 0m, 26500m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 97, 8, 500m, 20m, 0m, 10000m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 99, 20, 799m, 100m, 0m, 79900m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 99, 10, 799m, 36m, 0m, 28764m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 99, 13, 799m, 88m, 0m, 70312m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 93, 4, 171m, 95m, 0m, 16245m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 99, 16, 799m, 99m, 0m, 79101m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 85, 8, 395m, 37m, 0m, 14615m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 76, 7, 868m, 67m, 0m, 58156m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 68, 16, 446m, 42m, 0m, 18732m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 68, 10, 446m, 95m, 0m, 42370m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 68, 17, 446m, 84m, 0m, 37464m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 68, 9, 446m, 16m, 0m, 7136m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 75, 7, 777m, 78m, 0m, 60606m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 75, 4, 777m, 61m, 0m, 47397m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 75, 3, 777m, 30m, 0m, 23310m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 76, 11, 868m, 73m, 0m, 63364m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 75, 11, 777m, 95m, 0m, 73815m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 75, 5, 777m, 35m, 0m, 27195m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 75, 15, 777m, 39m, 0m, 30303m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 75, 20, 777m, 53m, 0m, 41181m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 76, 12, 868m, 21m, 0m, 18228m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 76, 3, 868m, 20m, 0m, 17360m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 76, 1, 868m, 91m, 0m, 78988m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 76, 6, 868m, 74m, 0m, 64232m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 75, 16, 777m, 95m, 0m, 73815m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 68, 20, 446m, 86m, 0m, 38356m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 99, 18, 799m, 21m, 0m, 16779m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 99, 19, 799m, 71m, 0m, 56729m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 50, 14, 664m, 28m, 0m, 18592m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 52, 19, 881m, 1m, 0m, 881m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 52, 15, 881m, 49m, 0m, 43169m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 52, 3, 881m, 16m, 0m, 14096m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 52, 8, 881m, 23m, 0m, 20263m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 54, 19, 821m, 58m, 0m, 47618m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 54, 4, 821m, 82m, 0m, 67322m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 50, 19, 664m, 25m, 0m, 16600m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 54, 6, 821m, 48m, 0m, 39408m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 54, 15, 821m, 38m, 0m, 31198m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 54, 1, 821m, 62m, 0m, 50902m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 54, 13, 821m, 97m, 0m, 79637m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 64, 14, 441m, 60m, 0m, 26460m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 64, 17, 441m, 89m, 0m, 39249m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 64, 9, 441m, 86m, 0m, 37926m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 64, 12, 441m, 80m, 0m, 35280m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 54, 18, 821m, 65m, 0m, 53365m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 99, 17, 799m, 7m, 0m, 5593m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 50, 20, 664m, 46m, 0m, 30544m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 50, 8, 664m, 59m, 0m, 39176m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 99, 6, 799m, 24m, 0m, 19176m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 99, 4, 799m, 42m, 0m, 33558m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 5, 7, 287m, 20m, 0m, 5740m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 41, 3, 476m, 53m, 0m, 25228m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 41, 17, 476m, 82m, 0m, 39032m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 41, 4, 476m, 51m, 0m, 24276m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 41, 6, 476m, 41m, 0m, 19516m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 50, 11, 664m, 52m, 0m, 34528m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 43, 5, 759m, 19m, 0m, 14421m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 46, 6, 325m, 91m, 0m, 29575m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 46, 1, 325m, 4m, 0m, 1300m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 46, 5, 325m, 86m, 0m, 27950m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 46, 10, 325m, 19m, 0m, 6175m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 46, 2, 325m, 23m, 0m, 7475m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 46, 19, 325m, 55m, 0m, 17875m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 50, 2, 664m, 95m, 0m, 63080m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 43, 9, 759m, 35m, 0m, 26565m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 10, 3, 581m, 41m, 0m, 23821m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 62, 9, 804m, 61m, 0m, 49044m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 10, 12, 581m, 4m, 0m, 2324m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 92, 1, 988m, 44m, 0m, 43472m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 92, 20, 988m, 43m, 0m, 42484m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 92, 17, 988m, 15m, 0m, 14820m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 92, 16, 988m, 2m, 0m, 1976m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 92, 19, 988m, 99m, 0m, 97812m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 92, 2, 988m, 79m, 0m, 78052m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 16, 6, 660m, 42m, 0m, 27720m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 16, 7, 660m, 4m, 0m, 2640m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 16, 3, 660m, 3m, 0m, 1980m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 16, 19, 660m, 7m, 0m, 4620m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 16, 5, 660m, 78m, 0m, 51480m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 16, 10, 660m, 20m, 0m, 13200m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 16, 13, 660m, 95m, 0m, 62700m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 16, 2, 660m, 95m, 0m, 62700m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 16, 18, 660m, 89m, 0m, 58740m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 92, 6, 988m, 22m, 0m, 21736m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 92, 7, 988m, 95m, 0m, 93860m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 87, 5, 281m, 76m, 0m, 21356m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 87, 9, 281m, 6m, 0m, 1686m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 66, 12, 118m, 55m, 0m, 6490m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 66, 10, 118m, 92m, 0m, 10856m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 66, 19, 118m, 36m, 0m, 4248m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 66, 18, 118m, 78m, 0m, 9204m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 66, 3, 118m, 38m, 0m, 4484m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 66, 13, 118m, 13m, 0m, 1534m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 69, 19, 286m, 38m, 0m, 10868m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 16, 8, 660m, 64m, 0m, 42240m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 69, 3, 286m, 8m, 0m, 2288m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 69, 14, 286m, 95m, 0m, 27170m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 87, 20, 281m, 60m, 0m, 16860m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 87, 18, 281m, 82m, 0m, 23042m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 87, 1, 281m, 84m, 0m, 23604m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 87, 16, 281m, 79m, 0m, 22199m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 87, 19, 281m, 96m, 0m, 26976m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 87, 4, 281m, 89m, 0m, 25009m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 69, 2, 286m, 48m, 0m, 13728m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 18, 3, 420m, 71m, 0m, 29820m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 18, 4, 420m, 100m, 0m, 42000m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 18, 15, 420m, 64m, 0m, 26880m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 65, 4, 195m, 33m, 0m, 6435m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 65, 12, 195m, 95m, 0m, 18525m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 65, 9, 195m, 1m, 0m, 195m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 70, 18, 886m, 61m, 0m, 54046m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 70, 4, 886m, 1m, 0m, 886m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 70, 12, 886m, 46m, 0m, 40756m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 70, 8, 886m, 84m, 0m, 74424m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 65, 17, 195m, 86m, 0m, 16770m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 81, 13, 678m, 29m, 0m, 19662m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 81, 1, 678m, 71m, 0m, 48138m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 81, 6, 678m, 12m, 0m, 8136m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 81, 9, 678m, 86m, 0m, 58308m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 84, 16, 225m, 17m, 0m, 3825m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 84, 14, 225m, 59m, 0m, 13275m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 84, 7, 225m, 57m, 0m, 12825m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 84, 3, 225m, 51m, 0m, 11475m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 81, 17, 678m, 85m, 0m, 57630m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 63, 11, 835m, 5m, 0m, 4175m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 65, 7, 195m, 17m, 0m, 3315m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 51, 9, 136m, 16m, 0m, 2176m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 21, 8, 195m, 64m, 0m, 12480m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 21, 20, 195m, 81m, 0m, 15795m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 21, 15, 195m, 77m, 0m, 15015m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 21, 19, 195m, 46m, 0m, 8970m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 21, 13, 195m, 23m, 0m, 4485m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 21, 4, 195m, 100m, 0m, 19500m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 21, 12, 195m, 100m, 0m, 19500m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 10, 6, 581m, 58m, 0m, 33698m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 28, 1, 199m, 1m, 0m, 199m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 28, 17, 199m, 67m, 0m, 13333m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 28, 20, 199m, 35m, 0m, 6965m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 28, 2, 199m, 73m, 0m, 14527m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 51, 7, 136m, 63m, 0m, 8568m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 51, 6, 136m, 18m, 0m, 2448m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 51, 3, 136m, 35m, 0m, 4760m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 51, 5, 136m, 61m, 0m, 8296m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 28, 16, 199m, 59m, 0m, 11741m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 84, 1, 225m, 35m, 0m, 7875m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 63, 5, 835m, 12m, 0m, 10020m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 63, 16, 835m, 89m, 0m, 74315m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 38, 8, 215m, 5m, 0m, 1075m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 38, 16, 215m, 12m, 0m, 2580m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 47, 4, 950m, 16m, 0m, 15200m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 47, 13, 950m, 72m, 0m, 68400m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 47, 8, 950m, 79m, 0m, 75050m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 47, 6, 950m, 19m, 0m, 18050m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 47, 19, 950m, 44m, 0m, 41800m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 47, 17, 950m, 51m, 0m, 48450m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 47, 20, 950m, 87m, 0m, 82650m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 48, 3, 814m, 47m, 0m, 38258m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 48, 4, 814m, 23m, 0m, 18722m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 53, 13, 40m, 83m, 0m, 3320m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 53, 15, 40m, 66m, 0m, 2640m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 53, 14, 40m, 94m, 0m, 3760m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 53, 11, 40m, 7m, 0m, 280m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 38, 19, 215m, 83m, 0m, 17845m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 38, 14, 215m, 48m, 0m, 10320m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 38, 11, 215m, 85m, 0m, 18275m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 38, 9, 215m, 33m, 0m, 7095m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 9, 6, 894m, 77m, 0m, 68838m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 9, 3, 894m, 52m, 0m, 46488m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 9, 7, 894m, 25m, 0m, 22350m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 9, 13, 894m, 77m, 0m, 68838m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 9, 4, 894m, 69m, 0m, 61686m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 25, 10, 478m, 93m, 0m, 44454m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 25, 6, 478m, 72m, 0m, 34416m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 73, 2, 357m, 14m, 0m, 4998m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 25, 20, 478m, 44m, 0m, 21032m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 25, 8, 478m, 53m, 0m, 25334m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 25, 16, 478m, 85m, 0m, 40630m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 25, 9, 478m, 44m, 0m, 21032m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 29, 7, 823m, 17m, 0m, 13991m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 29, 13, 823m, 41m, 0m, 33743m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 29, 16, 823m, 83m, 0m, 68309m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 38, 2, 215m, 88m, 0m, 18920m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 25, 17, 478m, 96m, 0m, 45888m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 73, 11, 357m, 24m, 0m, 8568m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 73, 19, 357m, 62m, 0m, 22134m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 73, 9, 357m, 41m, 0m, 14637m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 22, 2, 925m, 78m, 0m, 72150m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 22, 5, 925m, 53m, 0m, 49025m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 22, 18, 925m, 16m, 0m, 14800m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 22, 7, 925m, 38m, 0m, 35150m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 22, 14, 925m, 71m, 0m, 65675m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 22, 10, 925m, 86m, 0m, 79550m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 22, 11, 925m, 19m, 0m, 17575m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 22, 20, 925m, 79m, 0m, 73075m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 22, 19, 925m, 85m, 0m, 78625m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 22, 3, 925m, 86m, 0m, 79550m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 63, 20, 835m, 12m, 0m, 10020m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 63, 15, 835m, 7m, 0m, 5845m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 63, 8, 835m, 33m, 0m, 27555m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 63, 3, 835m, 69m, 0m, 57615m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 63, 4, 835m, 54m, 0m, 45090m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 63, 1, 835m, 12m, 0m, 10020m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 22, 16, 925m, 23m, 0m, 21275m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 63, 6, 835m, 74m, 0m, 61790m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 12, 13, 50m, 11m, 0m, 550m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 12, 4, 50m, 83m, 0m, 4150m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 73, 15, 357m, 89m, 0m, 31773m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 73, 3, 357m, 99m, 0m, 35343m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 73, 17, 357m, 27m, 0m, 9639m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 89, 13, 927m, 94m, 0m, 87138m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 89, 3, 927m, 15m, 0m, 13905m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 89, 6, 927m, 27m, 0m, 25029m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 89, 4, 927m, 63m, 0m, 58401m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 12, 18, 50m, 91m, 0m, 4550m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 89, 1, 927m, 35m, 0m, 32445m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 94, 8, 581m, 78m, 0m, 45318m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 94, 17, 581m, 9m, 0m, 5229m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 94, 16, 581m, 68m, 0m, 39508m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 94, 6, 581m, 65m, 0m, 37765m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 94, 18, 581m, 90m, 0m, 52290m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 94, 20, 581m, 34m, 0m, 19754m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 94, 1, 581m, 68m, 0m, 39508m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 89, 18, 927m, 96m, 0m, 88992m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 84, 19, 225m, 88m, 0m, 19800m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 78, 15, 71m, 98m, 0m, 6958m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 20, 16, 344m, 35m, 0m, 12040m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 8, 18, 84m, 86m, 0m, 7224m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 74, 17, 286m, 87m, 0m, 24882m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 74, 16, 286m, 56m, 0m, 16016m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 8, 9, 84m, 65m, 0m, 5460m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 8, 15, 84m, 95m, 0m, 7980m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 8, 10, 84m, 81m, 0m, 6804m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 6, 12, 271m, 17m, 0m, 4607m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 6, 8, 271m, 47m, 0m, 12737m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 74, 12, 286m, 14m, 0m, 4004m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 6, 9, 271m, 75m, 0m, 20325m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 6, 11, 271m, 13m, 0m, 3523m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 6, 13, 271m, 50m, 0m, 13550m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 6, 16, 271m, 69m, 0m, 18699m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 20, 20, 344m, 58m, 0m, 19952m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 80, 14, 611m, 79m, 0m, 48269m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 6, 19, 271m, 20m, 0m, 5420m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 6, 4, 271m, 29m, 0m, 7859m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 6, 20, 271m, 43m, 0m, 11653m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 80, 5, 611m, 23m, 0m, 14053m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 98, 2, 809m, 73m, 0m, 59057m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 98, 7, 809m, 44m, 0m, 35596m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 98, 5, 809m, 64m, 0m, 51776m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 80, 12, 611m, 95m, 0m, 58045m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 39, 8, 596m, 91m, 0m, 54236m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 80, 8, 611m, 12m, 0m, 7332m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 96, 6, 755m, 97m, 0m, 73235m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 86, 18, 298m, 42m, 0m, 12516m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 86, 14, 298m, 6m, 0m, 1788m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 6, 18, 271m, 74m, 0m, 20054m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 20, 6, 344m, 90m, 0m, 30960m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 20, 13, 344m, 63m, 0m, 21672m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 20, 7, 344m, 87m, 0m, 29928m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 39, 20, 596m, 36m, 0m, 21456m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 39, 19, 596m, 65m, 0m, 38740m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 35, 12, 392m, 50m, 0m, 19600m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 39, 9, 596m, 92m, 0m, 54832m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 35, 20, 392m, 30m, 0m, 11760m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 35, 3, 392m, 74m, 0m, 29008m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 35, 8, 392m, 9m, 0m, 3528m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 35, 2, 392m, 76m, 0m, 29792m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 35, 1, 392m, 9m, 0m, 3528m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 35, 15, 392m, 68m, 0m, 26656m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 35, 11, 392m, 36m, 0m, 14112m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 35, 9, 392m, 52m, 0m, 20384m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 39, 14, 596m, 38m, 0m, 22648m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 33, 16, 605m, 90m, 0m, 54450m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 33, 14, 605m, 41m, 0m, 24805m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 33, 18, 605m, 84m, 0m, 50820m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 39, 11, 596m, 68m, 0m, 40528m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 39, 18, 596m, 39m, 0m, 23244m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 33, 19, 605m, 48m, 0m, 29040m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 33, 15, 605m, 18m, 0m, 10890m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 39, 1, 596m, 69m, 0m, 41124m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 39, 5, 596m, 78m, 0m, 46488m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 30, 19, 21m, 79m, 0m, 1659m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 30, 4, 21m, 22m, 0m, 462m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 30, 6, 21m, 28m, 0m, 588m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 74, 6, 286m, 72m, 0m, 20592m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 30, 12, 21m, 74m, 0m, 1554m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 30, 20, 21m, 79m, 0m, 1659m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 20, 17, 344m, 55m, 0m, 18920m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 86, 11, 298m, 39m, 0m, 11622m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 96, 4, 755m, 5m, 0m, 3775m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 98, 11, 809m, 35m, 0m, 28315m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 86, 13, 298m, 21m, 0m, 6258m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 55, 15, 828m, 6m, 0m, 4968m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 55, 12, 828m, 77m, 0m, 63756m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 88, 20, 746m, 22m, 0m, 16412m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 86, 16, 298m, 93m, 0m, 27714m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 88, 12, 746m, 83m, 0m, 61918m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 34, 4, 172m, 35m, 0m, 6020m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 34, 7, 172m, 25m, 0m, 4300m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 88, 7, 746m, 57m, 0m, 42522m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 34, 8, 172m, 60m, 0m, 10320m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 34, 17, 172m, 58m, 0m, 9976m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 34, 16, 172m, 32m, 0m, 5504m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 34, 5, 172m, 72m, 0m, 12384m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 88, 14, 746m, 20m, 0m, 14920m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 88, 4, 746m, 72m, 0m, 53712m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 88, 11, 746m, 23m, 0m, 17158m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 31, 10, 431m, 89m, 0m, 38359m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 31, 12, 431m, 70m, 0m, 30170m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 31, 9, 431m, 35m, 0m, 15085m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 31, 19, 431m, 1m, 0m, 431m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 95, 7, 38m, 71m, 0m, 2698m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 95, 5, 38m, 11m, 0m, 418m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 31, 6, 431m, 46m, 0m, 19826m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 31, 15, 431m, 86m, 0m, 37066m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 95, 11, 38m, 96m, 0m, 3648m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 31, 5, 431m, 23m, 0m, 9913m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 95, 6, 38m, 18m, 0m, 684m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 31, 14, 431m, 95m, 0m, 40945m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 95, 19, 38m, 64m, 0m, 2432m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 84, 10, 225m, 62m, 0m, 13950m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 55, 7, 828m, 52m, 0m, 43056m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 71, 16, 326m, 84m, 0m, 27384m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 34, 13, 172m, 70m, 0m, 12040m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 72, 16, 279m, 51m, 0m, 14229m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 72, 19, 279m, 48m, 0m, 13392m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 86, 9, 298m, 99m, 0m, 29502m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 86, 8, 298m, 4m, 0m, 1192m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 86, 5, 298m, 43m, 0m, 12814m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 72, 6, 279m, 26m, 0m, 7254m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 72, 1, 279m, 1m, 0m, 279m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 72, 15, 279m, 39m, 0m, 10881m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 71, 1, 326m, 84m, 0m, 27384m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 71, 20, 326m, 27m, 0m, 8802m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 71, 14, 326m, 65m, 0m, 21190m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 71, 9, 326m, 12m, 0m, 3912m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 86, 19, 298m, 7m, 0m, 2086m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 39, 13, 596m, 83m, 0m, 49468m });

            migrationBuilder.InsertData(
                table: "DetailCmds",
                columns: new[] { "IdArticle", "IdCommande", "PrixVente", "QtePrise", "Remise", "Total" },
                values: new object[] { 71, 17, 326m, 29m, 0m, 9454m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 57, new DateTime(2020, 8, 11, 21, 37, 27, 182, DateTimeKind.Local).AddTicks(7326), 1, 49, 3, 491m, 57m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 62, new DateTime(2020, 7, 31, 10, 14, 9, 385, DateTimeKind.Local).AddTicks(9768), 6, 25, 2, 478m, 89m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 89, new DateTime(2020, 6, 18, 8, 14, 55, 502, DateTimeKind.Local).AddTicks(5476), 1, 25, 3, 478m, 87m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 91, new DateTime(2020, 8, 17, 3, 9, 32, 92, DateTimeKind.Local).AddTicks(6926), 10, 67, 1, 995m, 21m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 1, new DateTime(2019, 12, 26, 1, 33, 48, 327, DateTimeKind.Local).AddTicks(6264), 2, 67, 1, 995m, 7m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 14, new DateTime(2020, 5, 17, 7, 30, 6, 467, DateTimeKind.Local).AddTicks(3632), 3, 53, 3, 40m, 98m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 25, new DateTime(2019, 12, 27, 14, 45, 10, 946, DateTimeKind.Local).AddTicks(3425), 8, 53, 1, 40m, 62m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 39, new DateTime(2020, 7, 25, 0, 49, 53, 280, DateTimeKind.Local).AddTicks(4010), 6, 26, 2, 903m, 30m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 71, new DateTime(2020, 10, 12, 23, 35, 9, 658, DateTimeKind.Local).AddTicks(5304), 10, 29, 3, 823m, 69m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 46, new DateTime(2020, 1, 7, 7, 4, 52, 280, DateTimeKind.Local).AddTicks(4839), 7, 77, 1, 465m, 50m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 76, new DateTime(2020, 6, 8, 16, 17, 33, 574, DateTimeKind.Local).AddTicks(4992), 5, 86, 2, 298m, 29m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 51, new DateTime(2020, 1, 3, 5, 10, 52, 51, DateTimeKind.Local).AddTicks(2377), 4, 62, 2, 804m, 92m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 50, new DateTime(2019, 12, 19, 12, 26, 59, 766, DateTimeKind.Local).AddTicks(2853), 6, 48, 1, 814m, 19m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 30, new DateTime(2020, 1, 10, 5, 28, 47, 550, DateTimeKind.Local).AddTicks(7356), 8, 29, 1, 823m, 58m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 40, new DateTime(2020, 5, 20, 11, 13, 18, 534, DateTimeKind.Local).AddTicks(6215), 4, 61, 2, 135m, 62m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 6, new DateTime(2020, 2, 20, 11, 9, 43, 946, DateTimeKind.Local).AddTicks(2862), 4, 61, 3, 135m, 4m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 80, new DateTime(2020, 10, 30, 12, 28, 52, 855, DateTimeKind.Local).AddTicks(6740), 10, 73, 1, 357m, 43m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 59, new DateTime(2020, 9, 8, 16, 1, 3, 758, DateTimeKind.Local).AddTicks(9060), 6, 73, 2, 357m, 7m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 56, new DateTime(2020, 3, 4, 23, 25, 39, 98, DateTimeKind.Local).AddTicks(9212), 6, 73, 2, 357m, 75m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 95, new DateTime(2020, 7, 30, 20, 40, 45, 12, DateTimeKind.Local).AddTicks(1682), 6, 62, 3, 804m, 42m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 15, new DateTime(2020, 10, 8, 2, 32, 17, 535, DateTimeKind.Local).AddTicks(4295), 8, 26, 1, 903m, 56m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 13, new DateTime(2020, 1, 15, 8, 38, 43, 389, DateTimeKind.Local).AddTicks(298), 3, 25, 2, 478m, 80m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 26, new DateTime(2020, 9, 24, 14, 24, 44, 722, DateTimeKind.Local).AddTicks(6169), 8, 88, 2, 746m, 10m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 29, new DateTime(2020, 7, 22, 23, 52, 0, 154, DateTimeKind.Local).AddTicks(5989), 9, 83, 2, 448m, 29m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 16, new DateTime(2020, 7, 31, 16, 43, 42, 147, DateTimeKind.Local).AddTicks(3237), 2, 48, 2, 814m, 18m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 60, new DateTime(2020, 3, 20, 7, 6, 38, 375, DateTimeKind.Local).AddTicks(4627), 4, 39, 3, 596m, 78m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 31, new DateTime(2020, 10, 5, 13, 3, 17, 441, DateTimeKind.Local).AddTicks(7406), 2, 74, 3, 286m, 65m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 27, new DateTime(2020, 3, 27, 7, 3, 4, 54, DateTimeKind.Local).AddTicks(743), 7, 19, 1, 450m, 93m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 52, new DateTime(2020, 5, 1, 22, 22, 4, 411, DateTimeKind.Local).AddTicks(6644), 7, 49, 2, 491m, 24m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 20, new DateTime(2020, 8, 25, 8, 32, 30, 15, DateTimeKind.Local).AddTicks(9995), 7, 9, 1, 894m, 24m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 43, new DateTime(2020, 10, 15, 2, 55, 29, 570, DateTimeKind.Local).AddTicks(5673), 5, 25, 3, 478m, 27m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 7, new DateTime(2020, 1, 18, 17, 51, 40, 700, DateTimeKind.Local).AddTicks(8219), 8, 1, 2, 578m, 82m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 54, new DateTime(2020, 4, 20, 13, 19, 14, 346, DateTimeKind.Local).AddTicks(8706), 3, 89, 1, 927m, 55m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 12, new DateTime(2020, 8, 9, 4, 38, 45, 150, DateTimeKind.Local).AddTicks(7651), 6, 16, 2, 660m, 58m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 53, new DateTime(2020, 9, 25, 8, 42, 13, 913, DateTimeKind.Local).AddTicks(3356), 7, 16, 2, 660m, 38m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 79, new DateTime(2020, 4, 11, 8, 1, 28, 875, DateTimeKind.Local).AddTicks(2588), 9, 16, 2, 660m, 57m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 68, new DateTime(2019, 11, 27, 22, 37, 52, 56, DateTimeKind.Local).AddTicks(118), 9, 76, 2, 868m, 83m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 24, new DateTime(2020, 4, 22, 9, 17, 38, 22, DateTimeKind.Local).AddTicks(9982), 2, 18, 2, 420m, 31m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 37, new DateTime(2020, 7, 8, 23, 48, 17, 908, DateTimeKind.Local).AddTicks(4496), 10, 75, 3, 777m, 23m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 23, new DateTime(2020, 10, 20, 2, 36, 37, 880, DateTimeKind.Local).AddTicks(6681), 6, 75, 1, 777m, 26m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 9, new DateTime(2020, 5, 24, 15, 9, 0, 420, DateTimeKind.Local).AddTicks(5852), 2, 75, 1, 777m, 10m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 5, new DateTime(2020, 5, 27, 4, 19, 24, 216, DateTimeKind.Local).AddTicks(6471), 7, 57, 2, 371m, 68m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 4, new DateTime(2020, 7, 22, 14, 55, 20, 133, DateTimeKind.Local).AddTicks(7044), 6, 21, 1, 195m, 56m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 38, new DateTime(2020, 5, 15, 3, 10, 15, 133, DateTimeKind.Local).AddTicks(2961), 5, 21, 2, 195m, 79m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 48, new DateTime(2019, 12, 27, 16, 18, 38, 601, DateTimeKind.Local).AddTicks(3845), 7, 21, 2, 195m, 64m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 47, new DateTime(2020, 3, 5, 8, 1, 12, 358, DateTimeKind.Local).AddTicks(7923), 6, 57, 2, 371m, 76m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 88, new DateTime(2020, 3, 4, 23, 55, 7, 389, DateTimeKind.Local).AddTicks(8739), 10, 34, 1, 172m, 20m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 98, new DateTime(2020, 5, 16, 18, 7, 4, 371, DateTimeKind.Local).AddTicks(1693), 6, 56, 3, 228m, 95m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 92, new DateTime(2020, 8, 26, 17, 33, 28, 618, DateTimeKind.Local).AddTicks(6741), 1, 60, 1, 479m, 1m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 93, new DateTime(2020, 2, 14, 6, 33, 50, 557, DateTimeKind.Local).AddTicks(64), 5, 31, 1, 431m, 1m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 42, new DateTime(2020, 1, 19, 4, 19, 8, 606, DateTimeKind.Local).AddTicks(9551), 3, 31, 1, 431m, 26m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 97, new DateTime(2020, 8, 25, 8, 58, 20, 77, DateTimeKind.Local).AddTicks(5987), 7, 65, 3, 195m, 16m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 28, new DateTime(2020, 6, 2, 12, 58, 19, 552, DateTimeKind.Local).AddTicks(9117), 3, 31, 3, 431m, 91m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 33, new DateTime(2020, 3, 25, 6, 27, 19, 609, DateTimeKind.Local).AddTicks(2978), 9, 70, 1, 886m, 25m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 99, new DateTime(2020, 3, 18, 11, 31, 12, 445, DateTimeKind.Local).AddTicks(1519), 6, 24, 1, 53m, 95m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 32, new DateTime(2020, 4, 12, 8, 17, 39, 441, DateTimeKind.Local).AddTicks(3487), 2, 24, 1, 53m, 31m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 41, new DateTime(2020, 4, 21, 13, 52, 43, 151, DateTimeKind.Local).AddTicks(6265), 5, 100, 2, 735m, 18m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 70, new DateTime(2020, 11, 24, 9, 40, 0, 115, DateTimeKind.Local).AddTicks(4175), 4, 100, 3, 735m, 6m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 67, new DateTime(2020, 7, 5, 5, 15, 52, 548, DateTimeKind.Local).AddTicks(6625), 1, 81, 3, 678m, 7m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 74, new DateTime(2019, 12, 24, 15, 18, 30, 321, DateTimeKind.Local).AddTicks(4975), 5, 13, 3, 321m, 13m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 90, new DateTime(2020, 7, 31, 17, 5, 19, 846, DateTimeKind.Local).AddTicks(2601), 2, 84, 3, 225m, 79m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 85, new DateTime(2020, 10, 6, 10, 3, 59, 137, DateTimeKind.Local).AddTicks(2246), 4, 2, 3, 814m, 65m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 45, new DateTime(2019, 12, 17, 9, 7, 23, 485, DateTimeKind.Local).AddTicks(3938), 1, 2, 2, 814m, 7m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 19, new DateTime(2020, 6, 11, 14, 55, 29, 395, DateTimeKind.Local).AddTicks(8951), 10, 51, 2, 136m, 68m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 34, new DateTime(2020, 6, 30, 19, 19, 51, 466, DateTimeKind.Local).AddTicks(9771), 3, 56, 1, 228m, 60m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 83, new DateTime(2020, 2, 12, 19, 34, 18, 781, DateTimeKind.Local).AddTicks(8064), 4, 72, 1, 279m, 56m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 84, new DateTime(2020, 9, 5, 7, 15, 18, 838, DateTimeKind.Local).AddTicks(192), 8, 72, 1, 279m, 14m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 75, new DateTime(2020, 8, 17, 20, 12, 16, 714, DateTimeKind.Local).AddTicks(3724), 1, 82, 1, 876m, 10m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 81, new DateTime(2020, 5, 8, 3, 32, 32, 923, DateTimeKind.Local).AddTicks(5460), 5, 33, 3, 605m, 14m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 2, new DateTime(2020, 9, 1, 19, 46, 15, 316, DateTimeKind.Local).AddTicks(816), 3, 7, 3, 122m, 56m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 3, new DateTime(2020, 8, 10, 0, 36, 24, 159, DateTimeKind.Local).AddTicks(9452), 2, 7, 3, 122m, 82m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 87, new DateTime(2020, 5, 31, 13, 30, 13, 216, DateTimeKind.Local).AddTicks(9644), 2, 64, 1, 441m, 22m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 22, new DateTime(2020, 7, 11, 18, 13, 46, 138, DateTimeKind.Local).AddTicks(8555), 1, 7, 1, 122m, 41m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 77, new DateTime(2020, 9, 6, 11, 58, 7, 942, DateTimeKind.Local).AddTicks(3245), 10, 7, 1, 122m, 74m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 94, new DateTime(2020, 4, 9, 7, 20, 36, 862, DateTimeKind.Local).AddTicks(5667), 10, 54, 1, 821m, 8m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 69, new DateTime(2020, 1, 21, 19, 8, 45, 543, DateTimeKind.Local).AddTicks(6928), 2, 54, 2, 821m, 55m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 55, new DateTime(2020, 11, 11, 22, 37, 32, 405, DateTimeKind.Local).AddTicks(5853), 6, 30, 2, 21m, 96m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 11, new DateTime(2020, 9, 28, 15, 5, 19, 796, DateTimeKind.Local).AddTicks(5152), 5, 11, 3, 56m, 54m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 64, new DateTime(2020, 10, 21, 18, 45, 1, 804, DateTimeKind.Local).AddTicks(4823), 6, 20, 1, 344m, 9m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 82, new DateTime(2020, 10, 25, 8, 52, 34, 44, DateTimeKind.Local).AddTicks(6736), 1, 1, 3, 578m, 42m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 58, new DateTime(2020, 6, 23, 22, 49, 38, 435, DateTimeKind.Local).AddTicks(5643), 1, 8, 2, 84m, 87m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 18, new DateTime(2020, 7, 17, 13, 35, 1, 863, DateTimeKind.Local).AddTicks(5985), 7, 15, 1, 943m, 66m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 86, new DateTime(2020, 6, 30, 10, 33, 35, 755, DateTimeKind.Local).AddTicks(7925), 4, 46, 3, 325m, 48m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 61, new DateTime(2020, 3, 1, 21, 0, 55, 676, DateTimeKind.Local).AddTicks(105), 3, 46, 3, 325m, 59m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 36, new DateTime(2020, 11, 10, 20, 45, 6, 772, DateTimeKind.Local).AddTicks(2050), 6, 93, 3, 171m, 28m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 63, new DateTime(2020, 11, 20, 6, 59, 49, 742, DateTimeKind.Local).AddTicks(8369), 3, 93, 3, 171m, 52m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 66, new DateTime(2020, 5, 15, 14, 0, 40, 873, DateTimeKind.Local).AddTicks(5980), 2, 93, 1, 171m, 75m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 73, new DateTime(2020, 10, 8, 21, 55, 0, 674, DateTimeKind.Local).AddTicks(215), 8, 96, 3, 755m, 36m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 17, new DateTime(2020, 5, 28, 12, 43, 57, 374, DateTimeKind.Local).AddTicks(5662), 3, 97, 1, 500m, 33m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 44, new DateTime(2020, 3, 13, 7, 13, 22, 800, DateTimeKind.Local).AddTicks(8292), 7, 92, 3, 988m, 87m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 8, new DateTime(2020, 11, 24, 12, 43, 29, 727, DateTimeKind.Local).AddTicks(4018), 3, 90, 3, 59m, 97m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 78, new DateTime(2020, 5, 31, 14, 55, 25, 453, DateTimeKind.Local).AddTicks(881), 8, 98, 1, 809m, 95m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 49, new DateTime(2020, 7, 30, 9, 1, 31, 862, DateTimeKind.Local).AddTicks(343), 3, 5, 1, 287m, 94m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 96, new DateTime(2020, 11, 1, 19, 56, 2, 706, DateTimeKind.Local).AddTicks(9413), 5, 32, 3, 450m, 21m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 72, new DateTime(2020, 8, 21, 22, 30, 19, 98, DateTimeKind.Local).AddTicks(178), 4, 32, 2, 450m, 2m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 10, new DateTime(2020, 3, 10, 9, 23, 19, 596, DateTimeKind.Local).AddTicks(3217), 3, 43, 2, 759m, 75m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 65, new DateTime(2020, 4, 30, 15, 30, 15, 689, DateTimeKind.Local).AddTicks(9511), 5, 43, 1, 759m, 13m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 35, new DateTime(2020, 7, 6, 4, 57, 23, 604, DateTimeKind.Local).AddTicks(30), 3, 32, 2, 450m, 83m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 100, new DateTime(2020, 11, 15, 7, 32, 16, 685, DateTimeKind.Local).AddTicks(7677), 6, 98, 3, 809m, 9m });

            migrationBuilder.InsertData(
                table: "Fournitures",
                columns: new[] { "Id", "DateAchat", "IdAchat", "IdArticle", "IdFournisseur", "PrixAchat", "Qte" },
                values: new object[] { 21, new DateTime(2020, 6, 26, 23, 36, 27, 601, DateTimeKind.Local).AddTicks(3787), 1, 51, 2, 136m, 22m });

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
