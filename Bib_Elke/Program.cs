using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Bib_Elke.Book;
using static Bib_Elke.LibraryItem;

namespace Bib_Elke
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SubMenu();
        }

        public static void SubMenu()
        {
            Library library = new Library("BookLib");

            List<string> menuOptions = new List<string>
            {
                "Toon boeken menu.",
                "Toon magazines menu.",
                "Toon kranten menu.",
                "Toon boek series menu.",
                "Afsluiten."
            };

            string choice = "";




            string menuOptionsCount = menuOptions.Count().ToString();

            do
            {
                Console.Clear();
                Console.WriteLine($"Welkom bij {library.Name}!\n");

                for (int i = 0; i < menuOptions.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}. {menuOptions[i]}");
                }

                Console.Write("\nJouw keuze: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        BookOptions(library);
                        break;
                    case "2":                 
                        Console.Clear();
                        MagazineOptions(library);
                        break;
                    case "3":
                        Console.Clear();
                        NewspaperOptions(library);
                        break;
                    case "4":
                        Console.Clear();
                        BookSerieOptions(library);
                        break;
                    case "5":
                        break;
                    default:
                        Console.Write("\nGeen geldige keuze!");
                        Console.ReadLine();
                        break;
                }
            }
            while (choice != menuOptionsCount);
        }

        public static void BookOptions(Library library)
        {
            string bookPath = "books.csv";

            List<string> menuOptions = new List<string>
            {
                "Voeg een boek toe.",
                "Voeg informatie toe aan een boek of verwijder informatie van een boek.",
                "Alle info tonen van een boek op basis van titel en auteur.",
                "Een boek opzoeken op verschillende manieren.",
                "Een boek verwijderen uit de bibliotheek.",
                "Alle boeken tonen uit de bibliotheek met titel en auteur.",
                "Boek lenen.",
                "Boek terugbrengen.",
                "Boeken bestand inlezen.",
                "Terug naar het vorig menu."
            };

            for (int i = 0; i < menuOptions.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {menuOptions[i]}");
            }

            Console.Write("\nJouw keuze: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook(library);
                    break;
                case "2":
                    AddBookInfo(library);
                    break;
                case "3":
                    GetAuthorAndTitleToSearch(library);
                    break;
                case "4":
                    SearchBooksSubmenu(library);
                    break;
                case "5":
                    RemoveBook(library);
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine(library.ShowGivenBooks(library.Books));
                    Console.ReadLine();
                    break;
                case "7":
                    Console.Clear();
                    BorrowBook(library);
                    break;
                case "8":
                    Console.Clear();
                    ReturnBook(library);
                    break;
                case "9":
                    try
                    {
                        library.ReadBooksFile(bookPath);

                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                        Console.ReadLine();
                    }
                    break;
                case "10":
                    break;
                default:
                    Console.Write("\nGeen geldige keuze!");
                    Console.ReadLine();
                    break;

            }
        }
        public static void MagazineOptions(Library library)
        {
            string magazinesPath = "magazines.csv";

            List<string> menuOptions = new List<string>
            {
                "Voeg een maandblad toe.",
                "Alle maandbladen tonen.",
                "Aanwinsten van de leeszaal van vandaag tonen.",
                "Maandbladen bestand inlezen.",
                "Terug naar het vorig menu."
            };

            for (int i = 0; i < menuOptions.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {menuOptions[i]}");
            }

            Console.Write("\nJouw keuze: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddMagazine(library);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine(library.ShowAllMagazines());
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine(library.AcquisitionsReadingRoomToday());
                    Console.ReadLine();
                    break;
                case "4":
                    break;
                case "5":
                    try
                    {
                        library.ReadMagazinesFile(magazinesPath);

                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                        Console.ReadLine();
                    }
                    break;
                default:
                    Console.Write("\nGeen geldige keuze!");
                    Console.ReadLine();
                    break;

            }
        }
        public static void NewspaperOptions(Library library)
        {
            string newspaperPath = "newspapers.csv";

            List<string> menuOptions = new List<string>
            {
                "Voeg een krant toe.",
                "Alle kranten tonen.",
                "Aanwinsten van de leeszaal van vandaag tonen.",
                "Kranten bestand inlezen.",
                "Terug naar het vorig menu."
            };

            for (int i = 0; i < menuOptions.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {menuOptions[i]}");
            }

            Console.Write("\nJouw keuze: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewspaper(library);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine(library.ShowAllNewspapers());
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine(library.AcquisitionsReadingRoomToday());
                    Console.ReadLine();
                    break;
                case "4":
                    try
                    {
                        library.ReadNewspapersFile(newspaperPath);

                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                        Console.ReadLine();
                    }
                    break;
                case "5":
                    break;
                default:
                    Console.Write("\nGeen geldige keuze!");
                    Console.ReadLine();
                    break;
            }
        }
        public static void BookSerieOptions(Library library)
        {
            List<string> menuOptions = new List<string>
            {
                "Voeg een boek serie toe.",
                "Voeg informatie toe aan een boek serie of verwijder informatie van een boek serie.",
                "Terug naar het vorig menu."
            };

            for (int i = 0; i < menuOptions.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {menuOptions[i]}");
            }

            Console.Write("\nJouw keuze: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBookSerie(library);
                    break;
                case "2":
                    Console.Clear();
                    AddBookSerieInfo(library);
                    break;
                case "3":
                    break;
                default:
                    Console.Write("\nGeen geldige keuze!");
                    Console.ReadLine();
                    break;
            }
        }

        public static void BorrowBook(Library library)
        {
            if(library.Books.Count <= 0)
            {
                Console.Write("Er zijn nog geen boeken om te lenen.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine(library.ShowGivenBooks(library.Books));
            Console.Write("\nWelk boek wil je lenen: ");
            int choice = CheckIfInt(Console.ReadLine()) - 1;

            Book bookToBorrow;


            if(choice >= 0 && choice < library.Books.Count)
            {
                bookToBorrow = library.Books[choice];

                try
                {
                    bookToBorrow.Borrow();

                    Console.Write($"\n{bookToBorrow.Title} moet ten laatste op {DateTime.Today.AddDays(bookToBorrow.BorrowDays).ToShortDateString()} binnengebracht worden.");
                }

                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }
            else
            {
                Console.Write("\nJe hebt geen geldig boek gekozen. Je wordt teruggestuurd naar het vorig menu.");
            }

            Console.ReadLine();


        }

        public static void ReturnBook(Library library)
        {
            if (library.Books.Count <= 0)
            {
                Console.Write("Er zijn nog geen boeken om te ontlenen.");
                Console.ReadLine();
                return;
            }

            List<Book> unavailableBooks = library.ReturnUnavailableBooks();


            Console.WriteLine(library.ShowGivenBooks(unavailableBooks));
            Console.Write("\nWelk boek wil je terugbrengen: ");
            int choice = CheckIfInt(Console.ReadLine()) - 1;

            Book bookToReturn;


            if (choice >= 0 && choice < library.Books.Count)
            {
                bookToReturn = unavailableBooks[choice];

                try
                {
                    bookToReturn.Return();

                    if (bookToReturn.BorrowingDate > DateTime.Now)
                    {
                        Console.Write($"Boek werd te laat teruggebracht!");
                    }
                    else
                    {
                        Console.Write($"Boek werd op tijd teruggebracht!");
                    }

                    Console.ReadLine();
                }

                catch (Exception e)
                {
                    Console.Write(e.Message);
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Write("\nJe hebt geen geldig boek gekozen. Je wordt teruggestuurd naar het vorig menu.");
                Console.ReadLine();
            }
        }

        public static void AddBook(Library library)
        {
            Console.Clear();
            Console.WriteLine("--Boek toevoegen--\n");

            Console.WriteLine("Geef de titel in van het boek dat je wil toevoegen");
            Console.Write("> ");

            string title = Console.ReadLine();

            Console.WriteLine("Geef de auteur in van het boek dat je wil toevoegen");
            Console.Write("> ");

            string author = Console.ReadLine();

            try
            {
                library.AddBook(title, author);
                Console.Write($"Boek {title} succesvol toegevoegd!");


            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            Console.ReadLine();

        }

        public static void AddMagazine(Library library)
        {
            Console.Clear();
            Console.WriteLine("--Maandblad toevoegen--\n");

            Console.WriteLine("Wat is de naam van het maandblad?");
            Console.Write("> ");

            string title = Console.ReadLine();

            Console.WriteLine("Wat is de maand van het maandblad?");
            Console.Write("> ");

            byte month = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Wat is het jaar van het maandblad?");
            Console.Write("> ");

            uint year = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine("Wat is de uitgeverij van het maandblad?");
            Console.Write("> ");

            string publisher = Console.ReadLine();

            try
            {
                library.AddMagazine(title, publisher, month, year);
                Console.Write($"Magazine {title} succesvol toegevoegd!");

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            Console.ReadLine();

        }

        public static void AddNewspaper(Library library)
        {
            Console.Clear();
            Console.WriteLine("--Krant toevoegen--\n");

            Console.WriteLine("Wat is de naam van de krant?");
            Console.Write("> ");

            string title = Console.ReadLine();

            Console.WriteLine("Wat is de datum van de krant?");
            Console.Write("> ");

            string date = Console.ReadLine();

            Console.WriteLine("Wat is de uitgeverij van de krant?");
            Console.Write("> ");

            string publisher = Console.ReadLine();

            try
            {
                library.AddNewspaper(title, publisher, date);
                Console.Write($"Krant {title} succesvol toegevoegd!");
    
            }
            catch (FormatException)
            {
                Console.Write("Je hebt geen geldige datum ingevoerd. Vul het in als: dag/maand/jaar.");
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            Console.ReadLine();


        }

        public static void AddBookSerie(Library library)
        {
            Console.Clear();
            Console.WriteLine("--Voeg een boek serie toe--");

            Console.WriteLine("\nGeef de naam in van de boek serie die je wilt toevoegen:");
            Console.Write("> ");
            string newSerieName = Console.ReadLine();

            try
            {
                library.AddBookSerie(newSerieName);
                Console.WriteLine($"Boek serie {newSerieName} successvol toegevoegd!");

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            Console.ReadLine();


        }

        public static void AddBookInfo(Library library)
        {
            if (library.Books.Count() > 0)
            {
                Console.Clear();
                Console.WriteLine(library.ShowGivenBooks(library.Books));

                Console.Write($"\nGeef het nummer in van het boek waarvan je de info wilt veranderen of wilt toevoegen: ");
                int choice = CheckIfInt(Console.ReadLine()) - 1;

                if (choice >= 0 && choice < library.Books.Count())
                {
                    Book chosenBook = library.Books[choice];

                    int toDo = -1;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine(chosenBook.ShowBookInfo());

                        Console.WriteLine("\n1. Auteur aanpassen");
                        Console.WriteLine("2. Titel aanpassen");
                        Console.WriteLine("3. Uitgebrongen jaar aanpassen");
                        Console.WriteLine("4. Totale pagina's aanpassen");
                        Console.WriteLine("5. Over dit boek aanpassen");
                        Console.WriteLine("6. Genre toevoegen");
                        Console.WriteLine("7. Genre verwijderen");
                        Console.WriteLine("8. Editie toevoegen");
                        Console.WriteLine("9. Editie verwijderen");

                        Console.Write("\nWat wil je aanpassen ('0' om te stoppen): ");
                        toDo = Program.CheckIfInt(Console.ReadLine());

                        switch (toDo) {

                            case 1:

                                string oldAuthor = chosenBook.Author;

                                Console.Write("\nNieuwe auteur: ");
                                string newAuthor = Console.ReadLine();

                                try
                                {
                                    chosenBook.Author = newAuthor;
                                    Console.Write($"Auteur is successvol veranderd van {oldAuthor} naar {newAuthor}!");
                                }
                                catch (Exception e)
                                {
                                    Console.Write(e.Message);

                                }
                                Console.ReadLine();

                                break;

                            case 2:

                                string oldTitle = chosenBook.Title;

                                Console.Write("\nNieuwe titel: ");
                                string newTitle = Console.ReadLine();

                                try
                                {
                                    chosenBook.Title = newTitle;
                                    Console.Write($"Titel is successvol veranderd van {oldTitle} naar {newTitle}!");
                                }
                                catch (Exception e)
                                {
                                    Console.Write(e.Message);

                                }
                                Console.ReadLine();

                                break;

                            case 3:

                                int oldYear = chosenBook.ReleaseYear;

                                Console.Write("\nNieuw uitgebrongen jaar: ");
                                int newReleaseYearInt = Program.CheckIfInt(Console.ReadLine());

                                try
                                {
                                    chosenBook.ReleaseYear = newReleaseYearInt;
                                    Console.Write($"Uitgebrongen jaar is successvol veranderd van {oldYear} naar {newReleaseYearInt}!");
                                }
                                catch (Exception e)
                                {
                                    Console.Write(e.Message);

                                }
                                Console.ReadLine();

                                break;

                            case 4:

                                int oldTotalPages = chosenBook.TotalPages;

                                Console.Write("\nNieuw totale aantal pagina's: ");
                                int newTotalPagesInt = Program.CheckIfInt(Console.ReadLine());

                                try
                                {
                                    chosenBook.TotalPages = newTotalPagesInt;
                                    Console.Write($"Totale aantal pagina's is successvol veranderd van {oldTotalPages} naar {newTotalPagesInt}!");
                                }
                                catch (Exception e)
                                {
                                    Console.Write(e.Message);

                                }
                                Console.ReadLine();

                                break;

                            case 5:

                                Console.Write("\nNieuwe beschrijving: ");
                                string newAbout = Console.ReadLine();

                                Console.Write($"Over dit boek is successvol veranderd van {chosenBook.About} naar {newAbout}!");
                                chosenBook.About = newAbout;
                                Console.ReadLine();

                                break;

                            case 6:

                                Console.WriteLine("\nKies uit volgende genre's: \n");

                                List<GenreEnum> genreEnumList = chosenBook.GetGenreEnumList();

                                for (int i = 0; i < genreEnumList.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {genreEnumList[i].ToString().Replace("_", " ")}");

                                }



                                if (genreEnumList.Count() <= 0)
                                {
                                    Console.Write("\nEr zijn geen genre's meer om toe te voegen.");
                                }
                                else
                                {
                                    int genreChoice = Program.PickValidIndex(genreEnumList.Count(), "Welke genre wil je toevoegen");
                                    GenreEnum chosenGenre = genreEnumList[genreChoice];

                                    bool fictionOrNonFictionExists = chosenBook.CheckGenresForOpposites();

                                    if (fictionOrNonFictionExists && (chosenGenre == GenreEnum.Non_Fictie || chosenGenre == GenreEnum.Fictie))
                                    {
                                        Console.Write("Je kan niet tegelijk fictie en non fictie toevoegen als genre.");
                                    }
                                    else
                                    {
                                        chosenBook.Genres.Add(chosenGenre);
                                        Console.Write($"{chosenGenre.ToString().Replace("_", " ")} is successvol toegevoegd aan dit boek als genre!");
                                    }
                                }
                                Console.ReadLine();
                                break;

                            case 7:

                                Console.WriteLine(chosenBook.LoopOverCurrentGenres());

                                if (chosenBook.Genres.Count() <= 0)
                                {
                                    Console.Write("\nJe kan geen genre van dit boek verwijderen want er zijn er nog geen toegevoegd.");
                                }
                                else
                                {
                                    int toRemoveGenreIndex = PickValidIndex(chosenBook.Genres.Count(), "Welke genre wil je verwijderen");

                                    Console.Write($"{chosenBook.Genres[toRemoveGenreIndex].ToString().Replace("_", " ")} is successvol verwijderd van dit boek als genre!");
                                    chosenBook.Genres.RemoveAt(toRemoveGenreIndex);
                                }
                                Console.ReadLine();

                                break;

                            case 8:


                                List<EditionsEnum> editionsEnumList = chosenBook.GetEditionsEnumList();

                                Console.WriteLine("\nKies uit volgende edities: \n");

                                for (int i = 0; i < editionsEnumList.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {editionsEnumList[i].ToString().Replace("_", " ")}");

                                }


                                if (editionsEnumList.Count() <= 0)
                                {
                                    Console.Write("\nEr zijn geen edities meer om toe te voegen.");
                                }
                                else
                                {
                                    int editionChoice = PickValidIndex(editionsEnumList.Count(), "Welke editie wil je toevoegen");
                                    EditionsEnum chosenEdition = editionsEnumList[editionChoice];

                                    Console.Write("\nWelke ISBN heeft deze boek editie: ");
                                    string isbn = Console.ReadLine();

                                    try
                                    {
                                        Dictionary<EditionsEnum, string> tempDict = new Dictionary<EditionsEnum, string>(chosenBook.EditionAndIsbn);
                                        tempDict.Add(chosenEdition, isbn);
                                        chosenBook.EditionAndIsbn = tempDict;

                                        Console.Write($"{chosenEdition.ToString().Replace("_", " ")} is successvol toegevoegd!");
                                    }
                                    catch (Exception e)
                                    {
                                        Console.Write(e.Message);
                                    }
                                }
                                Console.ReadLine();

                                break;

                            case 9:

                                Console.WriteLine(chosenBook.LoopOverCurrentEditions());

                                if (chosenBook.EditionAndIsbn.Count() <= 0)
                                {
                                    Console.Write("\nJe kan geen editie van dit boek verwijderen want er zijn er nog geen toegevoegd.");
                                }
                                else
                                {
                                    int toRemoveEditionIndex = Program.PickValidIndex(chosenBook.EditionAndIsbn.Count(), "Welke editie wil je verwijderen");
                                    KeyValuePair<EditionsEnum, string> toRemove = chosenBook.EditionAndIsbn.ElementAt(toRemoveEditionIndex);

                                    Console.Write($"{toRemove.Key.ToString().Replace("_", " ")} - ISBN: {toRemove.Value} is successvol verwijderd van dit boek als editie!");
                                    chosenBook.EditionAndIsbn.Remove(toRemove.Key);
                                }
                                Console.ReadLine();
                                break;

                            case 0:
                                break;

                            default:
                                Console.Write("Geen geldige keuze.");
                                break;
                        }

                    }
                    while (toDo != 0);
                }
                else
                {
                    Console.WriteLine("Dit is geen geldige keuze.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Write("\nEr zijn nog geen boeken om informatie aan toe te voegen of te veranderen.");
                Console.ReadLine();
            }
        }

        public static void AddBookSerieInfo(Library library)
        {
            if(library.BookSeries.Count() > 0)
            {
                Console.WriteLine(library.ShowAllBookSeries(true));
                Console.Write($"\nGeef het nummer in van de boek serie waarvan je de info wilt veranderen of wilt toevoegen: ");
                int choice = CheckIfInt(Console.ReadLine()) - 1;

                if (choice >= 0 && choice < library.BookSeries.Count())
                {
                    BookSerie chosenSerie = library.BookSeries[choice];
                    int toDo = -1;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine(chosenSerie.ShowCurrentSeriesInfo());

                        Console.WriteLine("\n1. Naam aanpassen");
                        Console.WriteLine("2. Genre toevoegen");
                        Console.WriteLine("3. Genre verwijderen");
                        Console.WriteLine("4. Boek toevoegen aan serie");
                        Console.WriteLine("5. Boek verwijderen uit serie");
                        Console.Write("\nWat wil je aanpassen ('0' om te stoppen): ");

                        toDo = Program.CheckIfInt(Console.ReadLine());

                        switch (toDo)
                        {
                            case 1:
                                Console.Write("\nNieuwe naam: ");
                                string newName = Console.ReadLine();

                                try
                                {
                                    chosenSerie.Name = newName; 
                                    Console.Write($"Naam veranderd naar {newName}!");
                                }
                                catch (Exception e)
                                {
                                    Console.Write(e.Message);
                                    Console.ReadLine();

                                }
                                break;

                            case 2:
                                Console.WriteLine("\nKies uit volgende genre's: \n");

                                List<GenreEnum> genreEnumList = chosenSerie.GetGenreEnumList();

                                for (int i = 0; i < genreEnumList.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {genreEnumList[i].ToString().Replace("_", " ")}");

                                }

                                if (genreEnumList.Count() <= 0)
                                {
                                    Console.Write("\nEr zijn geen genre's meer om toe te voegen.");
                                }
                                else
                                {
                                    int genreChoice = Program.PickValidIndex(genreEnumList.Count(), "Welke genre wil je toevoegen");
                                    GenreEnum chosenGenre = genreEnumList[genreChoice];

                                    bool genreExistsInBook = false;
                                    bool fictionOrNonFictionExists = chosenSerie.CheckGenresForOpposites();

                                    foreach (Book book in chosenSerie.BookSerieOrder.Values)
                                    {
                                        if (book.Genres.Contains(chosenGenre))
                                        {
                                            genreExistsInBook = true;
                                        }
                                    }

                                    if (fictionOrNonFictionExists && (chosenGenre == GenreEnum.Non_Fictie || chosenGenre == GenreEnum.Fictie))
                                    {
                                        Console.Write("Je kan niet tegelijk fictie en non fictie toevoegen als genre.");

                                    }
                                    else if (genreExistsInBook)
                                    {
                                        chosenSerie.Genres.Add(chosenGenre); Console.Write($"{chosenGenre} is succesvol toegevoegd!");
                                    }
                                    else
                                    {
                                        Console.Write($"{chosenGenre} kan je niet toevoegen omdat geen enkel boek in de serie dit genre heeft.");

                                    }
                                }
                                break;

                            case 3:
                                Console.WriteLine(chosenSerie.LoopOverCurrentGenres());

                                if (chosenSerie.Genres.Count() <= 0)
                                {
                                    Console.Write("\nEr zijn geen genres om te verwijderen.");

                                }
                                else
                                {
                                    int toRemoveIndex = Program.PickValidIndex(chosenSerie.Genres.Count(), "Welke genre wil je verwijderen");

                                    Console.Write($"{chosenSerie.Genres[toRemoveIndex].ToString().Replace("_", " ")} is verwijderd!");
                                    chosenSerie.Genres.RemoveAt(toRemoveIndex);
                                }
                                break;

                            case 4:
                                int bookIndex = 0;

                                Console.WriteLine("\nKies uit volgende boeken: \n");

                                List<Book> booksList = new List<Book>();

                                foreach (Book book in library.Books)
                                {
                                    if (!chosenSerie.BookSerieOrder.ContainsValue(book))
                                    {
                                        booksList.Add(book);
                                        bookIndex++;
                                        Console.WriteLine($"{bookIndex}. Titel: {book.Title} -- auteur: {book.Author}");
                                    }
                                }

                                if (booksList.Count() <= 0)
                                {
                                    Console.Write("\nEr zijn geen boeken meer om toe te voegen.");
                                }
                                else
                                {
                                    int choice2 = PickValidIndex(booksList.Count(), "Welke boek wil je toevoegen");
                                    Book newBook = booksList[choice2];

                                    if (newBook.IsSerie)
                                    {
                                        Console.Write("Dit boek is al lid van een serie. Verwijder die eerst.");
                                    }
                                    else
                                    {
                                        int orderNum = 0;
                                        bool alreadyExists;

                                        do
                                        {
                                            Console.Write("\nHoeveelste boek in serie is dit (-1 voor te stoppen): ");
                                            orderNum = Program.CheckIfInt(Console.ReadLine());
                                            alreadyExists = chosenSerie.BookSerieOrder.ContainsKey(orderNum);

                                            if (alreadyExists)
                                            {
                                                Console.WriteLine("\nEr bestaat al een boek op deze plaats. Probeer opnieuw");

                                            }
                                            if (orderNum == -1)
                                            {
                                                newBook = null;

                                            }
                                        }
                                        while (alreadyExists && orderNum != -1);

                                        if (!(newBook is null))
                                        {
                                            newBook.Serie = chosenSerie;

                                            chosenSerie.BookSerieOrder.Add(orderNum, newBook);
                                            Console.Write($"\n{newBook.Title} is succesvol toegevoegd aan deze boek serie!");
                                        }
                                    }
                                }
                                break;

                            case 5:
                                chosenSerie.ShowBooks();

                                if (chosenSerie.BookSerieOrder.Count() <= 0)
                                {
                                    Console.Write("\nEr zijn geen boeken om te verwijderen.");
                                }
                                else
                                {
                                    Console.Write("\nWelk boek wil je verwijderen (geef het nummer in de serie): ");
                                    int toRemoveIndex = Program.CheckIfInt(Console.ReadLine());

                                    while (!chosenSerie.BookSerieOrder.ContainsKey(toRemoveIndex))
                                    {
                                        Console.Write("\nDit is geen geldige keuze. Probeer opnieuw: ");
                                        toRemoveIndex = Program.CheckIfInt(Console.ReadLine());
                                    }

                                    Book currentBook = chosenSerie.BookSerieOrder[toRemoveIndex];

                                    Console.Write($"\n{currentBook.Title} is verwijderd uit de serie!");

                                    currentBook.Serie = null;
                                    chosenSerie.BookSerieOrder.Remove(toRemoveIndex);
                                }
                                break;

                            case 0:
                                break;

                            default:
                                Console.Write("Geen geldige keuze.");
                                break;
                        }

                        if (toDo != 0)
                        {
                            Console.ReadLine();
                        }
                    }
                    while (toDo != 0);
                }
                else
                {
                    Console.WriteLine("Dit is geen geldige keuze.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Write("\nEr zijn nog geen boek series om informatie aan toe te voegen of te veranderen.");
                Console.ReadLine();
            }
        }

        public static void GetAuthorAndTitleToSearch(Library library)
        {
            Console.Clear();

            if (library.Books.Count() > 0)
            {
                Console.Write($"Welke titel heeft het boek die je wil zoeken in bibliotheek {library.Name}: ");
                string title = Console.ReadLine();

                Console.Write($"Welke auteur heeft het boek die je wil zoeken in bibliotheek {library.Name}: ");
                string author = Console.ReadLine();

                if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author))
                {
                    Book foundBook = library.SearchBookTitleAuthor(title, author);
                    if (!(foundBook is null))
                    {
                        Console.WriteLine(foundBook.ShowBookInfo());
                    }
                    else
                    {
                        Console.Write("\nGeen boek gevonden met deze criteria.");
                    }
                }
                else
                {
                    Console.Write("\nJe hebt de titel of auteur niet ingevuld dus kan je niet verder gaan. Je wordt terug gestuurd naar het vorig menu.");
                }
            }
            else
            {
                Console.Write("Er zijn nog geen boeken om te vinden.");
            }

            Console.ReadLine();


        }

        public static void SearchBooksSubmenu(Library library)
        {
            string choice = "";

            List<string> searchBookOptions = new List<string>
            {
                "Op basis van ISBN",
                "Op basis van titel en auteur",
                "Alle boeken op basis van een auteur",
                "Alle boeken van een bepaalde serie",
                "Alle boeken met bepaalde edities",
                "Alle boeken van een bepaalde genre",
                "Terug naar het vorig menu"
            };

            if (library.Books.Count() > 0)
            {
                do
                {
                    Console.Clear();

                    Console.WriteLine($"--Zoek boek(en)--\n");

                    for (int i = 0; i < searchBookOptions.Count(); i++)
                    {
                        Console.WriteLine($"{i + 1}. {searchBookOptions[i]}");
                    }

                    Console.Write("\nJouw keuze: ");
                    choice = Console.ReadLine();

                    Console.Clear();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Op welke isbn wil je zoeken: ");
                            string isbnToSearch = Console.ReadLine();
                            Book foundBook = library.SearchBookIsbn(isbnToSearch);

                            if (!(foundBook is null))
                            {
                                Console.WriteLine(foundBook.ShowBookInfo());
                            }
                            else
                            {
                                Console.Write("Geen boek gevonden.");
                            }
                            Console.ReadLine();

                            break;
                        case "2":
                            GetAuthorAndTitleToSearch(library);
                            break;
                        case "3":
                            Console.Write("Van welke auteur wil je boeken zoeken: ");
                            string authorToSearch = Console.ReadLine();
                            List<Book> foundBooksAuthor = library.SearchBooksFromAuthor(authorToSearch);
                            ShowBooksFound(library, foundBooksAuthor);
                            break;
                        case "4":

                            if (library.BookSeries.Count() > 0)
                            {
                                Console.WriteLine(library.ShowAllBookSeries(false));

                                Console.Write("\nVan welke serie wil je boeken zoeken: ");
                                int bookSerieToSearchIndex = Program.CheckIfInt(Console.ReadLine()) - 1;

                                if (bookSerieToSearchIndex < library.BookSeries.Count() && bookSerieToSearchIndex >= 0)
                                {
                                    BookSerie bookSerieToSearch = library.BookSeries[bookSerieToSearchIndex];

                                    List<Book> foundBooksBookSerie = library.SearchBooksFromBookSerie(bookSerieToSearch);

                                    ShowBooksFound(library, foundBooksBookSerie);
                                }
                                else
                                {
                                    Console.Write("Geen geldige keuze.");
                                }
                            }
                            else
                            {
                                Console.Write("Nog geen boek series in deze bibliotheek.");

                            }
                            Console.ReadLine();
                            break;
                        case "5":
                            Console.Clear();
                            bool booksWithEditions = library.CheckBooksWithEditions();

                            if (booksWithEditions)
                            {
                                Console.WriteLine(library.ShowAllBookEditions());

                                Console.Write("\n\nVan welke editie wil je boeken zoeken: ");
                                int editionToSearchIndex = Program.CheckIfInt(Console.ReadLine());

                                if (editionToSearchIndex <= Enum.GetValues(typeof(Book.EditionsEnum)).Length && editionToSearchIndex > 0)
                                {
                                    Book.EditionsEnum editionToSearch = (Book.EditionsEnum)editionToSearchIndex;

                                    List<Book> foundBooksEdition = library.SearchBooksFromEdition(editionToSearch);

                                    ShowBooksFound(library, foundBooksEdition);
                                }
                                else
                                {
                                    Console.Write("Geen geldige keuze.");
                                }
                            }
                            else
                            {
                                Console.Write("Nog geen boeken met edities.");

                            }

                            Console.ReadLine();
                            break;
                        case "6":
                            Console.Clear();
                            bool booksWithGenres = library.CheckBooksWithGenres();

                            if (booksWithGenres)
                            {
                                Console.WriteLine(library.ShowAllGenres());

                                Console.Write("\n\nVan welke genre wil je boeken zoeken: ");
                                int genreToSearchIndex = Program.CheckIfInt(Console.ReadLine());

                                if (genreToSearchIndex <= Enum.GetValues(typeof(LibraryItem.GenreEnum)).Length && genreToSearchIndex >= 0)
                                {
                                    LibraryItem.GenreEnum genreToSearch = (LibraryItem.GenreEnum)genreToSearchIndex;

                                    List<Book> foundBooksGenre = library.SearchBooksGenre(genreToSearch);

                                    ShowBooksFound(library, foundBooksGenre);
                                }
                                else
                                {
                                    Console.Write("Geen geldige keuze.");
                                }
                            }
                            else
                            {
                                Console.Write("Nog geen boeken met genres.");
                            }

                            Console.ReadLine();

                            break;
                        case "7":
                            break;
                        default:
                            Console.Write("Geen geldige keuze!");
                            Console.ReadLine();
                            break;
                    }

                }
                while (choice != searchBookOptions.Count().ToString());

            }

            else
            {
                Console.Write("Er zijn nog geen boeken om op te sorteren.");
                Console.ReadLine();
            }


        }

        public static void RemoveBook(Library library)
        {
            library.ShowGivenBooks(library.Books);

            if (library.Books.Count() > 0)
            {
                Console.Write("\nWelk boek wil je verwijderen van deze bibliotheek: ");
                int bookToRemoveChoice = CheckIfInt(Console.ReadLine()) - 1;

                if (bookToRemoveChoice >= library.Books.Count() || bookToRemoveChoice < 0)
                {
                    Console.Write("Dit is geen keuze. Je wordt terug gestuurd naar het vorig menu.");
                }
                else
                {
                    Book bookToRemove = library.Books[bookToRemoveChoice];
                    library.RemoveBook(bookToRemove);

                    Console.Write($"{bookToRemove.Title} is succesvol verwijderd van {library.Name}!");
                }

            }

            Console.ReadLine();
        }

        public static void ShowBooksFound(Library library, List<Book> booksFound)
        {
            Console.Clear();
            Console.WriteLine($"{library.Name} boeken gevonden: \n");

            if (booksFound.Count() > 0)
            {
                for (int i = 0; i < booksFound.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}. Titel: {booksFound[i].Title} -- Auteur: {booksFound[i].Author}");
                }
            }
            else
            {
                Console.Write("Er zijn geen boeken gevonden met deze criteria.");
            }
        }

        public static string GetInfoChoice(string toChange, string newToChange)
        {
            Console.Write($"\nNaar wat wil je de {toChange} veranderen: ");
            newToChange = Console.ReadLine();

            if (toChange.Contains("titel") || toChange.Contains("auteur") || toChange.Contains("naam"))
            {
                while (string.IsNullOrEmpty(newToChange))
                {
                    Console.Write($"\n{toChange} kan niet leeg zijn! Probeer opnieuw: ");
                    newToChange = Console.ReadLine();
                }
            }

            return newToChange;
        }

        public static int PickValidIndex(int listCount, string prompt)
        {
            Console.Write($"\n{prompt}: ");
            int choice = CheckIfInt(Console.ReadLine()) - 1;

            while (choice < 0 || choice >= listCount)
            {
                Console.Write("\nDit is geen geldige keuze. Probeer opnieuw: ");
                choice = CheckIfInt(Console.ReadLine()) - 1;
            }

            return choice;
        }

        public static int CheckIfInt(string numToCheck)
        {
            int num = 0;
            bool isInt = false;

            while (!isInt)
            {
                try
                {
                    num = Convert.ToInt32(numToCheck);
                    isInt = true;
                }
                catch
                {
                    Console.Write("Dit is geen geldig nummer. Probeer opnieuw: ");
                    numToCheck = Console.ReadLine();
                }
            }

            return num;
        }
    }
}