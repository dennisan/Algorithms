using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
	class ListItem
	{
		public int value;
		internal ListItem next;
		public ListItem(int val)
		{
			value = val;
		}
	}
}
