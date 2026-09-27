using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Elke
{
    internal class InvalidIsbnValueException : Exception
    {

        public InvalidIsbnValueException(string isbn) : base($"\nISBN '{isbn}' is ongeldig. " +
                            "Het moet 10 cijfers lang zijn, of 13 cijfers lang beginnend met 978/979.")
        {
        }
    }
}
