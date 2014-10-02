using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
	class List<T> :IEnumerable<T> where T : IComparable 
	{
		private ListItem Head;
		private ListItem Tail;

		public class ListItem
		{
			public T value;
			public ListItem next;
			public ListItem() 
			{
			}
			public ListItem(T val)
			{
				value = val;
			}
		}

		public List()
		{
			Head = new ListItem();
			Tail = new ListItem();

			Head.next = Tail;
			Tail.next = null;
		}


		public ListItem Insert(T val)
		{
			var ItemToInsert = new ListItem(val);

			ListItem i = Head; 
			
			while (i.next != Tail && val.CompareTo(i.next.value) > 0)
				i = i.next;
			
			ListItem temp = i.next;
			i.next = ItemToInsert;
			ItemToInsert.next = temp;

			return ItemToInsert;
		}

		public bool Delete(T val)
		{
			ListItem i = Head;

			// look for the target or the tail at the NEXT node in the list
			while (i.next != Tail && val.CompareTo(i.next.value) > 0)
				i = i.next;

			// if the NEXT node is target, remove it from the list
			if (val.CompareTo(i.next.value) == 0) { 
				i.next = i.next.next;
				return true;
			}

			return false;
		}


		class ListEnumerator : IEnumerator<T>
		{
			ListItem _Current;
			ListItem _Head;

			public ListEnumerator(ListItem head)
			{
				_Head = head;
				_Current = head;
			}

			public T Current
			{
				get { return _Current.value; }
			}

			public void Dispose()	{}

			object System.Collections.IEnumerator.Current
			{
				get { return _Current.value; }
			}

			public bool MoveNext()
			{
				if (_Current.next.next == null)
					return false;

				_Current = _Current.next;
				return true;
			}

			public void Reset()
			{
				_Current = _Head;
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new ListEnumerator(Head);
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return new ListEnumerator(Head);
		}
	}
}
