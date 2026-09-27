using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Elke
{
    internal class NewsPaper : ReadingRoomItem
    {
		private DateTime dateReleased;

        public DateTime DateReleased
		{
			get { return dateReleased; }
			set { dateReleased = value; }
		}

        public override string Identification
        {
            get
            {
                string[] titleSplit = Title.Split(" ");
                string id = "";

                for (int i = 0; i < titleSplit.Length; i++)
                {
                    if (i < 3)
                    {
                        id += titleSplit[i].Substring(0, 1).ToUpper();
                    }
                }

                id += dateReleased.ToString("ddMMyyyy");

                return id;
            }
        }

        public override string Categorie
        {
            get
            {
                return "Krant";
            }
        }

        public NewsPaper(string givenTitle, string givenPublisher, string givenDate) : base(givenTitle, givenPublisher)
        {
            DateTime givenDateConvert = Convert.ToDateTime(givenDate);
            this.DateReleased = givenDateConvert;
        }
    }
}
