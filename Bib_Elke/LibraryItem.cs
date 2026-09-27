using System;
using System.Collections.Generic;
using System.Linq;

namespace Bib_Elke
{
    internal class LibraryItem
    {
        public enum GenreEnum { Fictie = 1, Non_Fictie, Fantasie, Romantiek, Thriller, Science_Fiction, Roman, Young_Adult, Schoolboek }

        private List<GenreEnum> genres;

        
        public List<GenreEnum> Genres
        {
            get 
            { 
                return genres;
            }
            set 
            { 
                genres = value; 
            }
        }

        public LibraryItem()
        {
            this.Genres = new List<GenreEnum>();
        }

        public string LoopOverCurrentGenres()
        {
            string toReturn = "";
            toReturn += $"\nGenre's:\n\n";

            for (int i = 0; i < this.Genres.Count(); i++)
            {
                toReturn += $"\t{i + 1}. {this.Genres[i].ToString().Replace("_", " ")}\n";
            }

            if (this.Genres.Count() <= 0)
            {
                toReturn += "Nog geen genres toegevoegd\n";
            }

            return toReturn;
        }

        public List<GenreEnum> GetGenreEnumList()
        {
            int index = 0;
            List<GenreEnum> genreEnumList = new List<GenreEnum>();

            foreach (GenreEnum genre in Enum.GetValues(typeof(GenreEnum)))
            {
                if (!this.Genres.Contains(genre))
                {
                    genreEnumList.Add(genre);
                    index++;
                }
            }

            return genreEnumList;
        }

        public bool CheckGenresForOpposites()
        {
            bool fictionOrNonFictionExists = false;

            if (this.Genres.Contains(GenreEnum.Fictie) || this.Genres.Contains(GenreEnum.Non_Fictie))
            {
                fictionOrNonFictionExists = true;
            }

            return fictionOrNonFictionExists;
        }

    }
}