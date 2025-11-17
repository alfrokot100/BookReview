using BookReview.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReview.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {}
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var bookEntity = modelBuilder.Entity<Book>();
            var reviewEntity = modelBuilder.Entity<Review>();
            var userEntity = modelBuilder.Entity<User>();

            bookEntity.HasData(
                new Book 
                {
                    Id = 1,
                    Title = "Den osynliga staden",
                    Author = "Italo Calvino",
                    Genre = "Fiktion",
                    Description = "En poetisk samling av berättelser om tänkta städer.",
                    PublishedYear = 1972
                },

                new Book 
                {
                    Id = 2,
                    Title = "Den eviga striden",
                    Author = "Stieg Larsson",
                    Genre = "Thriller",
                    Description = "Första delen i Millennium-serien.",
                    PublishedYear = 2005
                },

                new Book
                {
                    Id = 3,
                    Title = "Mannen utan öde",
                    Author = "Imre Kertész",
                    Genre = "Historisk roman",
                    Description = "En stark berättelse om en ung pojkes upplevelser under Förintelsen.",
                    PublishedYear = 1975
                },

                new Book
                {
                    Id = 4,
                    Title = "Stolthet och fördom",
                    Author = "Jane Austen",
                    Genre = "Klassiker",
                    Description = "En tidlös berättelse om kärlek, stolthet och samhällsnormer i 1800-talets England.",
                    PublishedYear = 1813
                },



                new Book
                {
                    Id = 5,
                    Title = "Harry Potter och de vises sten",
                    Author = "J.K. Rowling",
                    Genre = "Fantasy",
                    Description = "Den föräldralöse Harry Potter upptäcker på sin elfte födelsedag att han är en trollkarl och börjar på Hogwarts skola för häxkonster och trolldom.",
                    PublishedYear = 1997
                },

                new Book
                {
                    Id = 6,
                    Title = "Harry Potter och Hemligheternas kammare",
                    Author = "J.K. Rowling",
                    Genre = "Fantasy",
                    Description = "Harrys andra år på Hogwarts involverar en mörk hemlighet, en gammal dagbok och en mystisk varelse som attackerar elever.",
                    PublishedYear = 1998
                },

                new Book
                {
                    Id = 7,
                    Title = "Harry Potter och fången från Azkaban",
                    Author = "J.K. Rowling",
                    Genre = "Fantasy",
                    Description = "Harry får veta att en farlig fånge, Sirius Black, har rymt från trollkarlsfängelset Azkaban och verkar vara ute efter honom.",
                    PublishedYear = 1999
                },

                new Book
                {
                    Id = 8,
                    Title = "Harry Potter och den flammande bägaren",
                    Author = "J.K. Rowling",
                    Genre = "Fantasy",
                    Description = "Hogwarts står värd för den magiska trekampen, en farlig tävling mellan tre magiskolor, men Harry blir oförklarligt vald som en fjärde deltagare.",
                    PublishedYear = 2000
                },

                new Book
                {
                    Id = 9,
                    Title = "Harry Potter och Fenixorden",
                    Author = "J.K. Rowling",
                    Genre = "Fantasy",
                    Description = "Efter Voldemorts återkomst möter Harry misstro från magiministeriet samtidigt som han i hemlighet tränar en grupp elever i försvar mot mörkrets krafter.",
                    PublishedYear = 2003
                },

                new Book
                {
                    Id = 10,
                    Title = "Harry Potter och halvblodsprinsen",
                    Author = "J.K. Rowling",
                    Genre = "Fantasy",
                    Description = "Harry och Dumbledore utforskar Voldemorts förflutna för att hitta ett sätt att besegra honom, samtidigt som mörka krafter infiltrerar Hogwarts.",
                    PublishedYear = 2005
                },

                new Book
                {
                    Id = 11,
                    Title = "Harry Potter och dödsrelikerna",
                    Author = "J.K. Rowling",
                    Genre = "Fantasy",
                    Description = "I den sista boken måste Harry, Ron och Hermione hitta och förstöra Voldemorts horrokruxer, vilket leder till en slutgiltig strid om Hogwarts.",
                    PublishedYear = 2007
                },


                new Book
                {
                    Id = 12,
                    Title = "Kampen om järntronen",
                    Author = "George R.R. Martin",
                    Genre = "Fantasy",
                    Description = "I kontinenten Westeros kämpar de adliga husen Stark, Lannister och Baratheon om makten över Järntronen efter kungens död.",
                    PublishedYear = 1996
                },

                new Book
                {
                    Id = 13,
                    Title = "Kungarnas krig",
                    Author = "George R.R. Martin",
                    Genre = "Fantasy",
                    Description = "Flera kungar gör anspråk på tronen, vilket leder till ett fullskaligt inbördeskrig samtidigt som ett hot växer i norr bortom muren.",
                    PublishedYear = 1998
                },

                new Book
                {
                    Id = 14,
                    Title = "Svärdets makt",
                    Author = "George R.R. Martin",
                    Genre = "Fantasy",
                    Description = "Kriget i Westeros intensifieras med nya allianser och chockerande svek. Daenerys Targaryen bygger sin armé i öster.",
                    PublishedYear = 2000
                },

                new Book
                {
                    Id = 15,
                    Title = "Kråkornas fest",
                    Author = "George R.R. Martin",
                    Genre = "Fantasy",
                    Description = "Efter de stora striderna fokuserar boken på maktintrigerna i King's Landing, Järnöarna och Arryns dal.",
                    PublishedYear = 2005
                },

                new Book
                {
                    Id = 16,
                    Title = "Drakarnas dans",
                    Author = "George R.R. Martin",
                    Genre = "Fantasy",
                    Description = "Parallellt med händelserna i 'Kråkornas fest' följer denna bok karaktärerna i norr och i öster, inklusive Daenerys och Jon Snow.",
                    PublishedYear = 2011
                },

                new Book
                {
                    Id = 17,
                    Title = "Hobbiten",
                    Author = "J.R.R. Tolkien",
                    Genre = "Fantasy",
                    Description = "Hobbiten Bilbo Bagger följer med trollkarlen Gandalf och en grupp dvärgar på ett äventyr för att återta sitt hemland från draken Smaug.",
                    PublishedYear = 1937
                },

                new Book
                {
                    Id = 18,
                    Title = "Sagan om ringen",
                    Author = "J.R.R. Tolkien",
                    Genre = "Fantasy",
                    Description = "Bilbos brorson Frodo ärver en magisk ring och får veta att det är Den Enda Ringen, smidd av mörkrets herre Sauron. Han måste föra den till Mordor för att förstöra den.",
                    PublishedYear = 1954
                },

                new Book
                {
                    Id = 19,
                    Title = "Sagan om de två tornen",
                    Author = "J.R.R. Tolkien",
                    Genre = "Fantasy",
                    Description = "Brödraskapet splittras. Frodo och Sam fortsätter mot Mordor, medan deras vänner dras in i kriget mot Sarumans arméer.",
                    PublishedYear = 1954
                },

                new Book
                {
                    Id = 20,
                    Title = "Sagan om konungens återkomst",
                    Author = "J.R.R. Tolkien",
                    Genre = "Fantasy",
                    Description = "Den sista striden om Midgård utkämpas vid Minas Tirith, samtidigt som Frodo och Sam kämpar för att nå Domedagsberget och förstöra Ringen.",
                    PublishedYear = 1955
                },

                new Book
                {
                    Id = 21,
                    Title = "Isprinsessan",
                    Author = "Camilla Läckberg",
                    Genre = "Kriminalroman",
                    Description = "Författaren Erica Falck återvänder till Fjällbacka och dras in i utredningen av sin barndomsväns mystiska död, tillsammans med polisen Patrik Hedström.",
                    PublishedYear = 2003
                },

                new Book
                {
                    Id = 22,
                    Title = "Predikanten",
                    Author = "Camilla Läckberg",
                    Genre = "Kriminalroman",
                    Description = "Erica och Patrik utreder mordet på en ung kvinna vars kropp hittas tillsammans med två äldre skelett, vilket väcker en mörk familjehemlighet till liv.",
                    PublishedYear = 2004
                },

                new Book
                {
                    Id = 23,
                    Title = "Stenhuggaren",
                    Author = "Camilla Läckberg",
                    Genre = "Kriminalroman",
                    Description = "En sjuårig flicka hittas drunknad i Fjällbacka, och utredningen leder Patrik och Erica mot en familjetragedi och ett mörkt förflutet.",
                    PublishedYear = 2005
                },

                new Book
                {
                    Id = 24,
                    Title = "Olycksfågeln",
                    Author = "Camilla Läckberg",
                    Genre = "Kriminalroman",
                    Description = "En dokusåpa spelas in i Fjällbacka, men när en deltagare mördas måste Patrik Hedström utreda fallet samtidigt som en våldsam olycka drabbar polisstationen.",
                    PublishedYear = 2006
                },

                new Book
                {
                    Id = 25,
                    Title = "Tyskungen",
                    Author = "Camilla Läckberg",
                    Genre = "Kriminalroman",
                    Description = "Erica Falck utforskar sin mammas förflutna efter hennes död och hittar kopplingar till andra världskriget och ett olöst mord.",
                    PublishedYear = 2007
                },

                new Book
                {
                    Id = 26,
                    Title = "Sjöjungfrun",
                    Author = "Camilla Läckberg",
                    Genre = "Kriminalroman",
                    Description = "En man hittas död i sitt hem. Han har tagit emot hotbrev, och Patrik och Erica nystar i ett fall som involverar en försvunnen författare.",
                    PublishedYear = 2008
                },

                new Book
                {
                    Id = 27,
                    Title = "Fyrvaktaren",
                    Author = "Camilla Läckberg",
                    Genre = "Kriminalroman",
                    Description = "En kvinna och hennes son flyr till Gråskär, men ön bär på mörka hemligheter. Patrik Hedström utreder ett mord som verkar ha kopplingar till öns fyrvaktare.",
                    PublishedYear = 2009
                },

                new Book
                {
                    Id = 28,
                    Title = "Änglamakerskan",
                    Author = "Camilla Läckberg",
                    Genre = "Kriminalroman",
                    Description = "Ett gammalt fall med en 'änglamakerska' från 1970-talet får ny aktualitet när en serie nya brott med liknande mönster inträffar i Fjällbacka.",
                    PublishedYear = 2011
                },

                new Book
                {
                    Id = 29,
                    Title = "Lejontämjaren",
                    Author = "Camilla Läckberg",
                    Genre = "Kriminalroman",
                    Description = "En ung flicka försvinner från en ridskola, och fallet påminner kusligt mycket om ett liknande försvinnande trettio år tidigare.",
                    PublishedYear = 2014
                },

                new Book
                {
                    Id = 30,
                    Title = "Häxan",
                    Author = "Camilla Läckberg",
                    Genre = "Kriminalroman",
                    Description = "Ett fyraårigt flickebarn försvinner, och fallet väcker minnen från ett 30 år gammalt mord på en flicka, vilket skakar om Fjällbacka.",
                    PublishedYear = 2017
                },

                new Book
                {
                    Id = 31,
                    Title = "Gökungen",
                    Author = "Camilla Läckberg",
                    Genre = "Kriminalroman",
                    Description = "Två brutala mord inträffar i Fjällbacka, och utredningen leder Patrik och Erica mot hemligheter som rör fotografi och konstvärlden.",
                    PublishedYear = 2022
                },

                new Book
                {
                    Id = 32,
                    Title = "En man som heter Ove",
                    Author = "Fredrik Backman",
                    Genre = "Roman",
                    Description = "En humoristisk och rörande berättelse om en vresig änkling som är kvarterets ordningsman, vars liv vänds upp och ner av nya, stökiga grannar.",
                    PublishedYear = 2012
                },

                new Book
                {
                    Id = 33,
                    Title = "Män som hatar kvinnor",
                    Author = "Stieg Larsson",
                    Genre = "Kriminalroman",
                    Description = "Den första boken i Millennium-serien där journalisten Mikael Blomkvist och hackern Lisbeth Salander utreder ett gammalt försvinnande.",
                    PublishedYear = 2005
                },

                new Book
                {
                    Id = 34,
                    Title = "1984",
                    Author = "George Orwell",
                    Genre = "Dystopi",
                    Description = "En klassisk roman om ett totalitärt övervakningssamhälle i Oceanien, där Storebror ser allt och historien ständigt skrivs om.",
                    PublishedYear = 1949
                },

                new Book
                {
                    Id = 35,
                    Title = "Sapiens: En kort historik över mänskligheten",
                    Author = "Yuval Noah Harari",
                    Genre = "Facklitteratur",
                    Description = "En genomgång av mänsklighetens historia, från de första människorna till de kognitiva, jordbruksmässiga och vetenskapliga revolutionerna.",
                    PublishedYear = 2011
                },

                new Book
                {
                    Id = 36,
                    Title = "Utvandrarna",
                    Author = "Vilhelm Moberg",
                    Genre = "Historisk roman",
                    Description = "Den första delen i eposet om Karl Oskar och Kristina och deras resa från ett fattigt Småland till ett nytt liv i Amerika på 1850-talet.",
                    PublishedYear = 1949
                },

                new Book
                {
                    Id = 37,
                    Title = "Dune",
                    Author = "Frank Herbert",
                    Genre = "Science Fiction",
                    Description = "En episk berättelse om maktkamp, politik och religion på ökenplaneten Arrakis, den enda källan till den värdefulla kryddan 'melange'.",
                    PublishedYear = 1965
                },

                new Book
                {
                    Id = 38,
                    Title = "Där kräftorna sjunger",
                    Author = "Delia Owens",
                    Genre = "Roman",
                    Description = "Berättelsen om Kya, 'Träskflickan', som växer upp isolerad i North Carolinas våtmarker och blir misstänkt när en ung man hittas död.",
                    PublishedYear = 2018
                },

                new Book
                {
                    Id = 39,
                    Title = "Den store Gatsby",
                    Author = "F. Scott Fitzgerald",
                    Genre = "Klassiker",
                    Description = "En roman om 1920-talets 'jazz-era', som utforskar teman som dekadens, rikedom och den amerikanska drömmen genom den mystiske miljonären Jay Gatsby.",
                    PublishedYear = 1925
                },

                new Book
                {
                    Id = 40,
                    Title = "Alkemisten",
                    Author = "Paulo Coelho",
                    Genre = "Roman",
                    Description = "En filosofisk berättelse om den andalusiske herdepojken Santiago som följer sin dröm om att hitta en skatt vid Egyptens pyramider.",
                    PublishedYear = 1988
                },

                new Book
                {
                    Id = 41,
                    Title = "Låt mig aldrig gå",
                    Author = "Kazuo Ishiguro",
                    Genre = "Dystopisk roman",
                    Description = "En gripande berättelse om Kathy H. och hennes vänner från internatskolan Hailsham, där de långsamt upptäcker det mörka syftet med deras existens.",
                    PublishedYear = 2005
                },

                new Book
                {
                    Id = 42,
                    Title = "Processen",
                    Author = "Franz Kafka",
                    Genre = "Roman",
                    Description = "Banktjänstemannen Josef K. blir en morgon arresterad utan att veta vad han anklagas för. Han dras in i en absurd och obegriplig rättsprocess i en labyrintisk byråkrati.",
                    PublishedYear = 1925
                },

                new Book
                {
                    Id = 43,
                    Title = "Förvandlingen",
                    Author = "Franz Kafka",
                    Genre = "Kortroman",
                    Description = "Handelsresanden Gregor Samsa vaknar en morgon och upptäcker att han har förvandlats till en jättelik insekt, vilket får fruktansvärda konsekvenser för honom och hans familj.",
                    PublishedYear = 1915
                },

                new Book
                {
                    Id = 44,
                    Title = "Slottet",
                    Author = "Franz Kafka",
                    Genre = "Roman",
                    Description = "En man känd som 'K.' anländer till en by för att arbeta som lantmätare åt det lokala slottet, men han kämpar förgäves mot en oåtkomlig byråkrati för att ens få sitt uppdrag bekräftat.",
                    PublishedYear = 1926
                },

                new Book
                {
                    Id = 45,
                    Title = "Amerika (Den försvunne)",
                    Author = "Franz Kafka",
                    Genre = "Roman",
                    Description = "Den unge Karl Rossmann skickas till Amerika av sina föräldrar. Romanen skildrar hans pikareskartade och ofta surrealistiska resa genom det främmande landet.",
                    PublishedYear = 1927
                }
             );

            reviewEntity.HasData(
                new Review 
                {
                    Id = 1,
                    ReviewerName = "Alice Andersson",
                    Rating = 5,
                    Text = "Otroligt gripande bok – kunde inte sluta läsa!",
                    CreatedDate = new DateTime(2025, 10, 10),
                    BookId_FK = 1
                },

                new Review 
                {
                    Id = 2,
                    ReviewerName = "Björn Berg",
                    Rating = 4,
                    Text = "Riktigt spännande, men lite förutsägbar på slutet.",
                    CreatedDate = new DateTime(2025,10,10),
                    BookId_FK = 2
                }
                );

            userEntity.HasData(
                new User 
                {
                    Id = 1,
                    Name = "Vicke Andersson",
                    Email = "alice@example.com",
                    PasswordHash = "hash123", //Testdata
                    Role = "Admin",
                    CreatedAt = new DateTime(2025, 10, 10)
                },
                new User 
                {
                    Id = 2,
                    Name = "Björn Berg",
                    Email = "bjorn@example.com",
                    PasswordHash = "hash456",
                    Role = "User",
                    CreatedAt = new DateTime(2025, 10, 10)
                },
                new User
                {
                    Id = 3,
                    Name = "Anders Hertig",
                    Email = "clara@example.com",
                    PasswordHash = "hash789",
                    Role = "User",
                    CreatedAt = new DateTime(2025, 10, 10)
                }

                );

        }


    }
}
