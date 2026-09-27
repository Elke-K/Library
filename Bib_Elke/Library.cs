using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bib_Elke
{
    internal class Library
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;

                }
                else
                {
                    throw new EmptyInputException("Bibliotheek naam");
                }
            }
        }
        private List<Book> books;
        public List<Book> Books
        {
            get
            {
                return books;
            }
            private set
            {
                books = value;
            }
        }

        private List<BookSerie> bookSeries;
        public List<BookSerie> BookSeries
        {
            get
            {
                return bookSeries;
            }
            private set
            {
                bookSeries = value;
            }
        }
            
        private Dictionary<DateTime, ReadingRoomItem> allReadingRoom;

        public Dictionary<DateTime, ReadingRoomItem> AllReadingRoom
        {
            get { return allReadingRoom; }
        }


        public Library(string name)
        {
            this.Name = name;
            this.Books = new List<Book>();
            this.BookSeries = new List<BookSerie>();
            this.allReadingRoom = new Dictionary<DateTime, ReadingRoomItem>();
        }

        public void AddBook(string title, string author)
        {
            Book newBook = new Book(title, author, this);
        }

        public void AddNewspaper(string title, string publisher, string date)
        {
            NewsPaper newNewspaper = new NewsPaper(title, publisher, date);
            this.AllReadingRoom.Add(DateTime.Today, newNewspaper);
        }

        public void AddMagazine(string title, string publisher, byte month, uint year)
        {

            Magazine newMagazine = new Magazine(title, publisher, month, year);
            this.AllReadingRoom.Add(DateTime.Today, newMagazine);
        }

        public void AddBookSerie(string newSerieName)
        {
            BookSerie newSerie = new BookSerie(newSerieName, this);
        }

        public void RemoveBook(Book bookToRemove)
        {
            this.Books.Remove(bookToRemove);

        }

        public List<Book> ReturnUnavailableBooks()
        {
            List<Book> unavailableBooks = new List<Book>();

            foreach (Book book in this.books)
            {
                if (!book.IsAvailable)
                {
                    unavailableBooks.Add(book);
                }
            }

            return unavailableBooks;
        }
        public string ShowGivenBooks(List<Book> givenBooks)
        {
            string toReturn = "";
            toReturn += $"{this.Name} boeken: \n\n";

            if (givenBooks.Count() > 0)
            {
                for (int i = 0; i < givenBooks.Count(); i++)
                {
                    toReturn += $"{i + 1}. Titel: {givenBooks[i].Title} -- Auteur: {givenBooks[i].Author}\n";
                }
            }
            else
            {
                toReturn += "Er zijn nog geen boeken.";
            }

            return toReturn;
        }

        public string ShowAllNewspapers()
        {
            string toReturn = "";
            toReturn += "Alle kranten uit de leeszaal:\n\n";

            bool hasNewspaper = false;

            if(this.AllReadingRoom.Count > 0)
            {
                foreach ((DateTime date, ReadingRoomItem currentItem) in AllReadingRoom)
                {
                    if (currentItem is NewsPaper np)
                    {
                        hasNewspaper = true;
                        toReturn += $"- {currentItem.Title} van {np.DateReleased.ToString("dddd d MMMM yyyy")} van uitgeverij {currentItem.Publisher}\n";

                    }
                }
            }
            else if(!hasNewspaper)
            {
                toReturn += "Er zijn nog geen kranten in deze bibliotheek.";

            }


            return toReturn;
        }

        public string ShowAllMagazines()
        {
            string toReturn = "";
            toReturn += "Alle maandbladen uit de leeszaal:\n\n";
            bool hasMagazine = false;

            if (this.AllReadingRoom.Count > 0)
            {
                foreach ((DateTime date, ReadingRoomItem currentItem) in AllReadingRoom)
                {
                    if (currentItem is Magazine m)
                    {
                        hasMagazine = true;
                        toReturn += $"- {currentItem.Title} van {m.Month}/{m.Year} van uitgeverij {currentItem.Publisher}\n";
                    }
                }
            }
            else if (!hasMagazine)
            {
                toReturn += "Er zijn nog geen maandbladen in deze bibliotheek.";

            }

            return toReturn;
        }

        public string AcquisitionsReadingRoomToday()
        {
            string toReturn = "";
            bool hasAcquisitionsToday = false;
            DateTime today = DateTime.Now;
            toReturn += $"Aanwinsten in de leeszaal van {today.ToString("dddd d MMMM yyyy")}:\n\n";

            foreach ((DateTime date, ReadingRoomItem currentItem) in AllReadingRoom)
            {
                if (date.Day == today.Day && date.Month == today.Month)
                {
                    hasAcquisitionsToday = true;
                    toReturn += $"- {currentItem.Title} met id {currentItem.Identification}\n";

                }
            }

            if (!hasAcquisitionsToday)
            {
                toReturn += "Er zijn vandaag (nog) geen aanwinsten.";
            }

            return toReturn;
        }

        public void ShowBooksFound(List<Book> booksFound)
        {
        }

        public string ShowAllBookSeries(bool showBooks)
        {
            string toReturn = "";
            toReturn += $"{this.Name} boek series: \n";

            for (int i = 0; i < this.BookSeries.Count(); i++)
            {
                toReturn += $"\n{i + 1}. Serie naam: {this.BookSeries[i].Name}\n";

                if (showBooks)
                {
                    toReturn += " -- Boeken: \n\n";
                }
                else
                {
                    toReturn += "\n";
                }
            }

            if (showBooks)
            {
                toReturn += this.ShowAllBookSeriesBooks();
            }

            return toReturn;
        }

        public string ShowAllBookSeriesBooks()
        {
            string toReturn = "";

            for (int i = 0; i < this.BookSeries.Count(); i++)
            {
                toReturn += this.BookSeries[i].ShowBooks();
            }

            return toReturn;
        }

        public string ShowAllBookEditions()
        {
            string toReturn = "";

            for (int i = 0; i < Enum.GetValues(typeof(Book.EditionsEnum)).Length; i++)
            {
                toReturn += $"\n{i + 1}. Editie naam: {((Book.EditionsEnum)i+1).ToString().Replace("_", " ")}";
            }
            return toReturn;
        }


        public string ShowAllGenres()
        {
            string toReturn = "";
            for (int i = 0; i < Enum.GetValues(typeof(LibraryItem.GenreEnum)).Length; i++)
            {
                toReturn += $"\n{i + 1}. Genre naam: {((LibraryItem.GenreEnum)i + 1).ToString().Replace("_", " ")}";
            }

            return toReturn;
        }

        public bool CheckBooksWithGenres()
        {
            bool genresFound = false;

            foreach(Book book in this.Books)
            {
                if(book.Genres.Count() > 0)
                {
                    genresFound = true;
                }
            }

            return genresFound;
        }

        public bool CheckBooksWithEditions()
        {
            bool editionsFound = false;

            foreach (Book book in this.Books)
            {
                if (book.EditionAndIsbn.Count() > 0)
                {
                    editionsFound = true;
                }
            }

            return editionsFound;
        }
        public Book SearchBookTitleAuthor(string title, string author)
        {

            Book foundBook = null;

            foreach(Book book in this.Books)
            {
                if(book.Title.ToLower().Trim() == title.ToLower().Trim() && book.Author.ToLower().Trim() == author.ToLower().Trim())
                {
                    foundBook = book;
                }
            }

            return foundBook;
        }

        public Book SearchBookIsbn(string isbn)
        {
            Book foundBook = null;

            foreach(Book book in this.Books)
            {
                if(book.EditionAndIsbn.ContainsValue(isbn))
                {
                    foundBook = book;
                }
            }

            return foundBook;
        
        }

        public List<Book> SearchBooksFromAuthor(string author)
        {
            List<Book> foundBooks = new List<Book>();

            foreach(Book book in this.Books)
            {
                if(book.Author.ToLower().Trim() == author.ToLower().Trim())
                {
                    foundBooks.Add(book);
                }
            }

            return foundBooks;
        }

        public List<Book> SearchBooksFromBookSerie(BookSerie bookSerie)
        {
            List<Book> foundBooks = new List<Book>();

            foreach(Book book in this.Books)
            {
                if(book.Serie == bookSerie)
                {
                    foundBooks.Add(book);
                }
            }

            return foundBooks;
        }

        public List<Book> SearchBooksFromEdition(Book.EditionsEnum edition)
        {
            List<Book> foundBooks = new List<Book>();           

            foreach(Book book in this.Books)
            {
                if (book.EditionAndIsbn.ContainsKey(edition))
                {
                    foundBooks.Add(book);
                }
            }

            return foundBooks;
        }

        public List<Book> SearchBooksGenre(LibraryItem.GenreEnum genre)
        {
            List<Book> foundBooks = new List<Book>();

            foreach(Book book in this.Books)
            {
                if (book.Genres.Contains(genre))
                {
                    foundBooks.Add(book);
                }
            }

            return foundBooks;
        }

        public List<Book> ReadBooksFile(string path)
        {
            List<Book> books = new List<Book>();

            string[] booksFile = [];
            int totalMessages = 0;

            try
            {
                booksFile = File.ReadAllLines(path);
            }
            catch (FileNotFoundException)
            {
                Console.Write("Het bestand was niet gevonden.");
            }

            foreach (string book in booksFile)
            {
                try
                {
                    //Assume everything is correct when adding a book from csv file
                    List<LibraryItem.GenreEnum> genres = new List<LibraryItem.GenreEnum>();
                    Dictionary<Book.EditionsEnum, string> editionsAndIsbn = new Dictionary<Book.EditionsEnum, string>();

                    string[] bookAttributes = book.Split("|");

                    string title = bookAttributes[0];
                    string author = bookAttributes[1];

                    if (bookAttributes.Length == 2)
                    { 
                        Book newBook = new Book(title, author, this);
                        books.Add(newBook);
                    }
                    else if(bookAttributes.Length == 7)
                    {
                        string[] bookGenresSplit = bookAttributes[2].Split(",");
                        string[] bookEditionsSplit = bookAttributes[3].Split(",");

                        foreach(string genre in bookGenresSplit)
                        {
                            int genreInt = Convert.ToInt32(genre);
                            genres.Add((LibraryItem.GenreEnum)genreInt);

                        }
                        foreach (string edition in bookEditionsSplit)
                        {
                            string[] editionSplit = edition.Split("-");

                            string foundEdition = editionSplit[0];
                            string foundIsbn = editionSplit[1];

                            int foundEditionInt = Convert.ToInt32(foundEdition);

                            editionsAndIsbn.Add((Book.EditionsEnum)foundEditionInt, foundIsbn);
                        }


                        int releaseYear = Convert.ToInt32(bookAttributes[4]);
                        int totalPages = Convert.ToInt32(bookAttributes[5]);

                        string about = bookAttributes[6];

                        Book newBook = new Book(title, author, genres, editionsAndIsbn, releaseYear, totalPages, about, this);
                        books.Add(newBook);
                    }
                    totalMessages++;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Write("\nDit boek is niet geldig. Gebruik: titel|auteur als sjabloon voor het csv bestand. Of titel|auteur|(Non_Fictie, Fantasie, Romantiek, Thriller, Science_Fiction, Roman, Young_Adult)|(Hardcover, Paperback, Special_Binding)-isbn|uitgebrongen jaar|totale pagina's|over dit boek");
                    Console.ReadLine();

                }
            }


            return books;
        }

        public List<Magazine> ReadMagazinesFile(string path)
        {
            List<Magazine> magazines = new List<Magazine>();

            string[] magazineFile = [];

            try
            {
                magazineFile = File.ReadAllLines(path);
            }
            catch (FileNotFoundException)
            {
                Console.Write("Het bestand was niet gevonden.");
            }

            foreach (string magazineLine in magazineFile)
            {
                try
                {
                    string[] magazine = magazineLine.Split("|");
                    string title = magazine[0];
                    string publisher = magazine[1];
                    byte month = Convert.ToByte(magazine[2]);
                    uint year = Convert.ToUInt32(magazine[3]);

                    Magazine newMagazine = new Magazine(title, publisher, month, year);

                    magazines.Add(newMagazine);

                    this.AllReadingRoom.Add(DateTime.Now, newMagazine);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Write("\nDit magazine is niet geldig. Gebruik: titel|uitgever|maand|jaar als sjabloon voor het csv bestand.");
                    Console.ReadLine();

                }
            }


            return magazines;
        }

        public List<NewsPaper> ReadNewspapersFile(string path)
        {
            List<NewsPaper> newspapers = new List<NewsPaper>();

            string[] newspaperFile = [];

            try
            {
                newspaperFile = File.ReadAllLines(path);
            }
            catch (FileNotFoundException)
            {
                Console.Write("Het bestand was niet gevonden.");
            }

            foreach (string newspaperLine in newspaperFile)
            {
                try
                {
                    string[] newspaper = newspaperLine.Split("|");
                    string title = newspaper[0];
                    string publisher = newspaper[1];
                    string date = newspaper[2];

                    NewsPaper newNewspaper = new NewsPaper(title, publisher, date);
                    newspapers.Add(newNewspaper);

                    this.AllReadingRoom.Add(DateTime.Now, newNewspaper);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Write("\nDeze krant is niet geldig. Gebruik: titel|uitgever|datum als sjabloon voor het csv bestand.");
                    Console.ReadLine();

                }
            }


            return newspapers;
        }


    }
}
