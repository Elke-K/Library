using System;
using System.Collections.Generic;
using System.Linq;
using static Bib_Elke.LibraryItem;

namespace Bib_Elke
{
    internal class Book : LibraryItem, ILendable
    {
        public enum EditionsEnum { Hardcover = 1, Paperback, Special_Binding }
        public enum BookInfoOptions { Auteur = 1, Titel, Uitgebrongen_jaar, Totale_paginas, Over_dit_boek, Genres, Boek_Edities }

        private string author;
        public string Author
        {
            get 
            { 
                return author; 
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    author = value;
                }
                else
                {
                    throw new EmptyInputException("Auteur");
                }
            }
        }

        private string title;
        public string Title
        {
            get 
            { 
                return title; 
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    title = value;

                }
                else
                {
                    throw new EmptyInputException("Titel");
                }
            }
        }

        private Dictionary<EditionsEnum, string> editionAndIsbn;
        public Dictionary<EditionsEnum, string> EditionAndIsbn
        {
            get
            {
                return editionAndIsbn;
            }
            set
            {
                foreach ((EditionsEnum edition, string isbn) in value)
                {
                    bool isAllNum = false;

                    try
                    {
                        long isbnLong = long.Parse(isbn);
                        isAllNum = true;
                    }
                    catch
                    {
                        
                    }

                    bool isValid10 = (isbn.Length == 10 && isAllNum);

                    bool isValid13 = (isbn.Length == 13 &&
                                     (isbn.Substring(0, 3) == "978" || isbn.Substring(0, 3) == "979") &&
                                     isAllNum);

                    //If it's not 10 long and also not 13 long starting with 978 or 979. Using an or would give an error if either are true, even for an isbn10 value since it is not a isbn 13 value.
                    if (!isValid10 && !isValid13)
                    {
                        throw new InvalidIsbnValueException(isbn);
                    }
                }
                editionAndIsbn = value;
            }
        }

        private int releaseYear;
        public int ReleaseYear
        {
            get 
            { 
                return releaseYear; 
            }
            set
            {
                if (value >= 1000 && value <= DateTime.Now.Year)
                {
                    releaseYear = value;
                }
                else
                {
                    throw new ArgumentException("\nJaar kan niet vroeger vallen dan 1000 of hoger dan het jaar nu.");
                }
            }
        }

        private int totalPages;
        public int TotalPages
        {
            get 
            { 
                return totalPages; 
            }
            set
            {
                if (value >= 24)
                {
                    totalPages = value;

                }
                else
                {
                    throw new ArgumentException("\nEen boek moet minstens 24 pagina's hebben voor de binding.");

                }
            }
        }

        private string about;
        public string About
        {
            get 
            { 
                return about; 
            }
            set 
            {
                about = value; 
            }
        }

        private bool isSerie;
        public bool IsSerie
        {
            get 
            { 
                return isSerie; 
            }
            private set 
            { 
                isSerie = value; 
            }
        }

        private BookSerie serie;
        public BookSerie Serie
        {
            get 
            { 
                return serie; 
            }
            set 
            { 
                if (value == null)
                {
                    IsSerie = false;
                    serie = null;
                }
                else
                {
                    IsSerie = true;
                    serie = value;
                }
            }
        }

        private bool isAvailable;
        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }

        private DateTime borrowingDate;
        public DateTime BorrowingDate
        {
            get { return borrowingDate; }
            set { borrowingDate = value; }
        }

        private int borrowDays;
        public int BorrowDays
        {
            get 
            {
                if (Genres.Contains((GenreEnum)9))
                {
                    return 10;
                }
                return 20;
            }
            set
            {
                borrowDays = value;
            }
        }

        public Book(string title, string author, Library givenLibrary)
        {

            this.EditionAndIsbn = new Dictionary<EditionsEnum, string>();
            this.Title = title;
            this.Author = author;
            this.IsAvailable = true;

            bool bookExists = this.Equals(givenLibrary);

            if (!bookExists)
            {
                givenLibrary.Books.Add(this);

            }
        }

        public Book(string title, string author, List<GenreEnum> genres, Dictionary<EditionsEnum, string> editions, int releaseYear, int totalPages, string about, Library givenLibrary)
        {
            this.Title = title;
            this.Author = author;
            this.ReleaseYear = releaseYear;
            this.TotalPages = totalPages;
            this.About = about;
            this.Genres = genres;
            this.EditionAndIsbn = editions;
            this.IsAvailable = true;
            bool bookExists = this.Equals(givenLibrary);

            if (!bookExists)
            {
                givenLibrary.Books.Add(this);

            }

        }

        public override bool Equals(object? obj)
        {
            if(obj is null || obj is not Library)
            {
                return false;
            }

            Library libraryObject = (Library)obj;
            bool isEqual = false;

            foreach(Book objectBook in libraryObject.Books)
            {
                if(objectBook.Title.ToLower().Trim() == this.Title.ToLower().Trim() && objectBook.Author.ToLower().Trim() == this.Author.ToLower().Trim())
                {
                    isEqual = true;
                }
            }


            return isEqual;
        }

        public string ShowBookInfo()
        {

            string toReturn = "";

            string isASerie = "Nee";
            if (this.IsSerie)
            {
                isASerie = "Ja";
            }

            string hasAbout = "Nog geen informatie ingevoerd voor dit boek.";
            if (!string.IsNullOrEmpty(this.About))
            {
                hasAbout = this.About;
            }

            string hasReleaseYear = "Nog geen uitgebronnen jaar ingevoerd voor dit boek.";
            if (this.ReleaseYear > 0)
            {
                hasReleaseYear = this.ReleaseYear.ToString();
            }

            string hasTotalPages = "Nog geen totale pagina's ingevoerd.";
            if (this.TotalPages > 0)
            {
                hasTotalPages = this.TotalPages.ToString();
            }

            string hasSerie = "Nog geen lid van een boek serie.";
            if (!(this.Serie is null))
            {
                int orderInSerie = 0;

                foreach ((int order, Book book) in this.Serie.BookSerieOrder)
                {
                    if (book == this)
                    {
                        orderInSerie = order;
                    }
                }

                hasSerie = $"{this.Serie.Name} ({orderInSerie})";
            }

            toReturn += $"--{this.Title}--\n";
            toReturn += $"\nAuteur: {this.Author}\n";
            toReturn += $"Maakt deel uit van een serie? {isASerie}\n";
            toReturn += $"Over dit boek: {hasAbout}\n";
            toReturn += $"Uitgebrongen jaar: {hasReleaseYear}\n";
            toReturn += $"Totale pagina's: {hasTotalPages}\n";
            toReturn += $"Book serie: {hasSerie}\n";

            toReturn += LoopOverCurrentGenres();
            toReturn += LoopOverCurrentEditions();

            return toReturn;

        }

        public string LoopOverCurrentEditions()
        {
            string toReturn = "";
            toReturn += "\nBoek edities:\n\n";

            int index = 0;

            foreach((EditionsEnum edition, string isbn) in this.EditionAndIsbn)
            {
                toReturn += $"\t{index + 1}. {edition.ToString().Replace("_", " ")} - ISBN: {isbn}\n";
                index++;
            }
            if (this.EditionAndIsbn.Count() <= 0)
            {
                toReturn += "Nog geen boek edities toegevoegd";
            }

            return toReturn;
        }

        public List<EditionsEnum> GetEditionsEnumList()
        {
            List<EditionsEnum> editionsEnumList = new List<EditionsEnum>();
            int index = 0;

            foreach (EditionsEnum edition in Enum.GetValues(typeof(EditionsEnum)))
            {
                if (!this.EditionAndIsbn.ContainsKey(edition))
                {
                    editionsEnumList.Add(edition);
                    index++;
                }
            }

            return editionsEnumList;
        }

        public void Borrow()
        {
            if (IsAvailable)
            {
                BorrowingDate = DateTime.Now;
                IsAvailable = false;
            }
            else
            {
                throw new BookLendingException($"\n'{Title}' is momenteel niet beschikbaar om te lenen..");
            }
        }

        public void Return()
        {
            if (!IsAvailable)
            {
                IsAvailable = true;
            }
            else
            {
                throw new BookLendingException($"\n'{Title}' is nog niet uitgeleend geweest.");

            }
        }
    }
}