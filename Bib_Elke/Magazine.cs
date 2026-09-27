using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Elke
{
    internal class Magazine : ReadingRoomItem
    {

        private byte month;

        public byte Month
        {
            get { return month; }
            set 
            { 
                if(value > 12)
                {
                    throw new Exception("De maand is maximaal 12.");
                }
                else
                {
                    month = value;
                }
            }
        }

        private uint year;

        public uint Year
        {
            get { return year; }
            set 
            { 
                if(value > 2500)
                {
                    throw new Exception("Het jaartal is maximaal 2500");
                 
                }
                else
                {
                    year = value;
                }
            }
        }


        public override string Identification
        {
            get
            {
                string[] titleSplit = Title.Split(" ");
                string id = "";

                for (int i = 0; i < titleSplit.Length; i++)
                {
                    if(i < 3)
                    {
                        id += titleSplit[i].Substring(0, 1).ToUpper();
                    }
                }

                id += month;
                id += year;

                return id;
            }
        }

        public override string Categorie
        {
            get
            {
                return "Maandblad";
            }
        }

        public Magazine(string givenTitle, string givenPublisher, byte givenMonth, uint givenYear) : base(givenTitle, givenPublisher)
        {
            this.Month = givenMonth;
            this.Year = givenYear;
        }
    }
}
