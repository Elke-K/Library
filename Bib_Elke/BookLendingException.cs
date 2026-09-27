using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Elke
{
    internal class BookLendingException : Exception
    {

		private string message;

		public string Message
		{
			get { return message; }
			set { message = value; }
		}

        public BookLendingException(string message) : base(message)
        {
            Message = message;
        }
    }
}
