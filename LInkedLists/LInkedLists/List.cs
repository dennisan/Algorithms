using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
	class List
	{
		private ListItem Head;
		private ListItem Tail;

		public List()
		{
			Head = new ListItem(int.MinValue);
			Tail = new ListItem(int.MaxValue);

			Head.next = Tail;
			Tail.next = null;
		}


		public ListItem Insert(int val)
		{
			var ItemToInsert = new ListItem(val);

			ListItem i = Head; 
			
			while (i.next != Tail && i.next.value <= val)
				i = i.next;
			
			ListItem temp = i.next;
			i.next = ItemToInsert;
			ItemToInsert.next = temp;

			return ItemToInsert;
		}

		public bool Delete(int val)
		{
			ListItem i = Head;

			while (i.next != Tail && i.next.value < val)
				i = i.next;

			if (i.next.value == val) { 
				i.next = i.next.next;
				return true;
			}

			return false;
		}



		public void Dump()
		{
			ListItem i = Head.next;

			while (i != Tail)
			{
				Console.WriteLine(i.value);
				i = i.next;

			}
		}
	}
}
