using System;
using System.Collections;
using System.Windows.Forms;

namespace BandProgram
{
	public class IntCompare : IComparer
	{
		private int col;

		public string sort = "asc";

		public IntCompare()
		{
			this.col = 0;
		}

		public IntCompare(int column, string sort)
		{
			this.col = column;
			this.sort = sort;
		}

		public int Compare(object x, object y)
		{
			if (this.sort == "asc")
			{
				if (int.Parse(((ListViewItem)x).SubItems[this.col].Text) > int.Parse(((ListViewItem)y).SubItems[this.col].Text))
				{
					return 1;
				}
				return 0;
			}
			if (int.Parse(((ListViewItem)x).SubItems[this.col].Text) > int.Parse(((ListViewItem)y).SubItems[this.col].Text))
			{
				return 0;
			}
			return 1;
		}
	}
}