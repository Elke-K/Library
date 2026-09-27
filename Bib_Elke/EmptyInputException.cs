using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Elke
{
    internal class EmptyInputException : Exception
    {
		private string inputName;

		public string InputName
		{
			get { return inputName; }
			set { inputName = value; }
		}

        public EmptyInputException(string inputName) : base($"{inputName} kan niet leeg zijn!")
        {
            InputName = inputName;
        }
    }
}
