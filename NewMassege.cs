using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient
{
    class NewMassege
    {
		private string To;

		public string to
		{
			get { return To; }
			set { To = value; }
		}
		private string Theme;

		public string theme
		{
			get { return Theme; }
			set { Theme = value; }
		}
		private string Text;

		public string text
		{
			get { return Text; }
			set { Text = value; }
		}
		private bool IsImportant;

		public bool isImportant
		{
			get { return IsImportant; }
			set { IsImportant = value; }
		}

	}
}
