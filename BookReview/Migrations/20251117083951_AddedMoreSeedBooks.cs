using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookReview.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreSeedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 5, "J.K. Rowling", "Den föräldralöse Harry Potter upptäcker på sin elfte födelsedag att han är en trollkarl och börjar på Hogwarts skola för häxkonster och trolldom.", "Fantasy", 1997, "Harry Potter och de vises sten" },
                    { 6, "J.K. Rowling", "Harrys andra år på Hogwarts involverar en mörk hemlighet, en gammal dagbok och en mystisk varelse som attackerar elever.", "Fantasy", 1998, "Harry Potter och Hemligheternas kammare" },
                    { 7, "J.K. Rowling", "Harry får veta att en farlig fånge, Sirius Black, har rymt från trollkarlsfängelset Azkaban och verkar vara ute efter honom.", "Fantasy", 1999, "Harry Potter och fången från Azkaban" },
                    { 8, "J.K. Rowling", "Hogwarts står värd för den magiska trekampen, en farlig tävling mellan tre magiskolor, men Harry blir oförklarligt vald som en fjärde deltagare.", "Fantasy", 2000, "Harry Potter och den flammande bägaren" },
                    { 9, "J.K. Rowling", "Efter Voldemorts återkomst möter Harry misstro från magiministeriet samtidigt som han i hemlighet tränar en grupp elever i försvar mot mörkrets krafter.", "Fantasy", 2003, "Harry Potter och Fenixorden" },
                    { 10, "J.K. Rowling", "Harry och Dumbledore utforskar Voldemorts förflutna för att hitta ett sätt att besegra honom, samtidigt som mörka krafter infiltrerar Hogwarts.", "Fantasy", 2005, "Harry Potter och halvblodsprinsen" },
                    { 11, "J.K. Rowling", "I den sista boken måste Harry, Ron och Hermione hitta och förstöra Voldemorts horrokruxer, vilket leder till en slutgiltig strid om Hogwarts.", "Fantasy", 2007, "Harry Potter och dödsrelikerna" },
                    { 12, "George R.R. Martin", "I kontinenten Westeros kämpar de adliga husen Stark, Lannister och Baratheon om makten över Järntronen efter kungens död.", "Fantasy", 1996, "Kampen om järntronen" },
                    { 13, "George R.R. Martin", "Flera kungar gör anspråk på tronen, vilket leder till ett fullskaligt inbördeskrig samtidigt som ett hot växer i norr bortom muren.", "Fantasy", 1998, "Kungarnas krig" },
                    { 14, "George R.R. Martin", "Kriget i Westeros intensifieras med nya allianser och chockerande svek. Daenerys Targaryen bygger sin armé i öster.", "Fantasy", 2000, "Svärdets makt" },
                    { 15, "George R.R. Martin", "Efter de stora striderna fokuserar boken på maktintrigerna i King's Landing, Järnöarna och Arryns dal.", "Fantasy", 2005, "Kråkornas fest" },
                    { 16, "George R.R. Martin", "Parallellt med händelserna i 'Kråkornas fest' följer denna bok karaktärerna i norr och i öster, inklusive Daenerys och Jon Snow.", "Fantasy", 2011, "Drakarnas dans" },
                    { 17, "J.R.R. Tolkien", "Hobbiten Bilbo Bagger följer med trollkarlen Gandalf och en grupp dvärgar på ett äventyr för att återta sitt hemland från draken Smaug.", "Fantasy", 1937, "Hobbiten" },
                    { 18, "J.R.R. Tolkien", "Bilbos brorson Frodo ärver en magisk ring och får veta att det är Den Enda Ringen, smidd av mörkrets herre Sauron. Han måste föra den till Mordor för att förstöra den.", "Fantasy", 1954, "Sagan om ringen" },
                    { 19, "J.R.R. Tolkien", "Brödraskapet splittras. Frodo och Sam fortsätter mot Mordor, medan deras vänner dras in i kriget mot Sarumans arméer.", "Fantasy", 1954, "Sagan om de två tornen" },
                    { 20, "J.R.R. Tolkien", "Den sista striden om Midgård utkämpas vid Minas Tirith, samtidigt som Frodo och Sam kämpar för att nå Domedagsberget och förstöra Ringen.", "Fantasy", 1955, "Sagan om konungens återkomst" },
                    { 21, "Camilla Läckberg", "Författaren Erica Falck återvänder till Fjällbacka och dras in i utredningen av sin barndomsväns mystiska död, tillsammans med polisen Patrik Hedström.", "Kriminalroman", 2003, "Isprinsessan" },
                    { 22, "Camilla Läckberg", "Erica och Patrik utreder mordet på en ung kvinna vars kropp hittas tillsammans med två äldre skelett, vilket väcker en mörk familjehemlighet till liv.", "Kriminalroman", 2004, "Predikanten" },
                    { 23, "Camilla Läckberg", "En sjuårig flicka hittas drunknad i Fjällbacka, och utredningen leder Patrik och Erica mot en familjetragedi och ett mörkt förflutet.", "Kriminalroman", 2005, "Stenhuggaren" },
                    { 24, "Camilla Läckberg", "En dokusåpa spelas in i Fjällbacka, men när en deltagare mördas måste Patrik Hedström utreda fallet samtidigt som en våldsam olycka drabbar polisstationen.", "Kriminalroman", 2006, "Olycksfågeln" },
                    { 25, "Camilla Läckberg", "Erica Falck utforskar sin mammas förflutna efter hennes död och hittar kopplingar till andra världskriget och ett olöst mord.", "Kriminalroman", 2007, "Tyskungen" },
                    { 26, "Camilla Läckberg", "En man hittas död i sitt hem. Han har tagit emot hotbrev, och Patrik och Erica nystar i ett fall som involverar en försvunnen författare.", "Kriminalroman", 2008, "Sjöjungfrun" },
                    { 27, "Camilla Läckberg", "En kvinna och hennes son flyr till Gråskär, men ön bär på mörka hemligheter. Patrik Hedström utreder ett mord som verkar ha kopplingar till öns fyrvaktare.", "Kriminalroman", 2009, "Fyrvaktaren" },
                    { 28, "Camilla Läckberg", "Ett gammalt fall med en 'änglamakerska' från 1970-talet får ny aktualitet när en serie nya brott med liknande mönster inträffar i Fjällbacka.", "Kriminalroman", 2011, "Änglamakerskan" },
                    { 29, "Camilla Läckberg", "En ung flicka försvinner från en ridskola, och fallet påminner kusligt mycket om ett liknande försvinnande trettio år tidigare.", "Kriminalroman", 2014, "Lejontämjaren" },
                    { 30, "Camilla Läckberg", "Ett fyraårigt flickebarn försvinner, och fallet väcker minnen från ett 30 år gammalt mord på en flicka, vilket skakar om Fjällbacka.", "Kriminalroman", 2017, "Häxan" },
                    { 31, "Camilla Läckberg", "Två brutala mord inträffar i Fjällbacka, och utredningen leder Patrik och Erica mot hemligheter som rör fotografi och konstvärlden.", "Kriminalroman", 2022, "Gökungen" },
                    { 32, "Fredrik Backman", "En humoristisk och rörande berättelse om en vresig änkling som är kvarterets ordningsman, vars liv vänds upp och ner av nya, stökiga grannar.", "Roman", 2012, "En man som heter Ove" },
                    { 33, "Stieg Larsson", "Den första boken i Millennium-serien där journalisten Mikael Blomkvist och hackern Lisbeth Salander utreder ett gammalt försvinnande.", "Kriminalroman", 2005, "Män som hatar kvinnor" },
                    { 34, "George Orwell", "En klassisk roman om ett totalitärt övervakningssamhälle i Oceanien, där Storebror ser allt och historien ständigt skrivs om.", "Dystopi", 1949, "1984" },
                    { 35, "Yuval Noah Harari", "En genomgång av mänsklighetens historia, från de första människorna till de kognitiva, jordbruksmässiga och vetenskapliga revolutionerna.", "Facklitteratur", 2011, "Sapiens: En kort historik över mänskligheten" },
                    { 36, "Vilhelm Moberg", "Den första delen i eposet om Karl Oskar och Kristina och deras resa från ett fattigt Småland till ett nytt liv i Amerika på 1850-talet.", "Historisk roman", 1949, "Utvandrarna" },
                    { 37, "Frank Herbert", "En episk berättelse om maktkamp, politik och religion på ökenplaneten Arrakis, den enda källan till den värdefulla kryddan 'melange'.", "Science Fiction", 1965, "Dune" },
                    { 38, "Delia Owens", "Berättelsen om Kya, 'Träskflickan', som växer upp isolerad i North Carolinas våtmarker och blir misstänkt när en ung man hittas död.", "Roman", 2018, "Där kräftorna sjunger" },
                    { 39, "F. Scott Fitzgerald", "En roman om 1920-talets 'jazz-era', som utforskar teman som dekadens, rikedom och den amerikanska drömmen genom den mystiske miljonären Jay Gatsby.", "Klassiker", 1925, "Den store Gatsby" },
                    { 40, "Paulo Coelho", "En filosofisk berättelse om den andalusiske herdepojken Santiago som följer sin dröm om att hitta en skatt vid Egyptens pyramider.", "Roman", 1988, "Alkemisten" },
                    { 41, "Kazuo Ishiguro", "En gripande berättelse om Kathy H. och hennes vänner från internatskolan Hailsham, där de långsamt upptäcker det mörka syftet med deras existens.", "Dystopisk roman", 2005, "Låt mig aldrig gå" },
                    { 42, "Franz Kafka", "Banktjänstemannen Josef K. blir en morgon arresterad utan att veta vad han anklagas för. Han dras in i en absurd och obegriplig rättsprocess i en labyrintisk byråkrati.", "Roman", 1925, "Processen" },
                    { 43, "Franz Kafka", "Handelsresanden Gregor Samsa vaknar en morgon och upptäcker att han har förvandlats till en jättelik insekt, vilket får fruktansvärda konsekvenser för honom och hans familj.", "Kortroman", 1915, "Förvandlingen" },
                    { 44, "Franz Kafka", "En man känd som 'K.' anländer till en by för att arbeta som lantmätare åt det lokala slottet, men han kämpar förgäves mot en oåtkomlig byråkrati för att ens få sitt uppdrag bekräftat.", "Roman", 1926, "Slottet" },
                    { 45, "Franz Kafka", "Den unge Karl Rossmann skickas till Amerika av sina föräldrar. Romanen skildrar hans pikareskartade och ofta surrealistiska resa genom det främmande landet.", "Roman", 1927, "Amerika (Den försvunne)" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45);
        }
    }
}
