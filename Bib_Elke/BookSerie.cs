using System;
using System.Collections.Generic;
using System.Linq;
using static Bib_Elke.LibraryItem;

namespace Bib_Elke
{
    internal class BookSerie : LibraryItem
    {
        public enum BookSeriesInfoOptions { Naam = 1, Genres, Boeken }

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
                    throw new EmptyInputException("Boek serie naam");

                }
            }
        }

        private SortedDictionary<int, Book> bookSerieOrder;
        public SortedDictionary<int, Book> BookSerieOrder
        {
            get 
            { 
                return bookSerieOrder; 
            }
            private set 
            { 
                bookSerieOrder = value; 
            }
        }

        public BookSerie(string seriesName, Library currentLibrary)
        {
            this.BookSerieOrder = new SortedDictionary<int, Book>();
            this.Name = seriesName;

            currentLibrary.BookSeries.Add(this);


        }

        public string ShowCurrentSeriesInfo()
        {

            string toReturn = "";
            toReturn += $"--{this.Name}--\n\n";

            toReturn += LoopOverCurrentGenres();

            toReturn += "\nBoeken: \n";

            toReturn += ShowBooks();

            return toReturn;
        }

        public string ShowBooks()
        {
            string toReturn = "";
            if (this.BookSerieOrder.Count() > 0)
            {
                foreach ((int order, Book book) in this.BookSerieOrder)
                {
                    toReturn += $"\t{order}. {book.Title}\n";
                }
            }
            else
            {
                toReturn += "Nog geen boeken in deze serie.";
            }

            return toReturn;
        }
    }
}