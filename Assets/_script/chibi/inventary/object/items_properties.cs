using UnityEngine;
using System.Collections.Generic;
using System.Linq;


namespace chibi.inventory.obj
{
	[System.Serializable]
	public class items_properties
	{
		[SerializeField]
		public item.Item item;
		public int amount = 0;

		public int add_amount( int amount )
		{
			int max_amount_can_be_add = item.max_stack_amount - this.amount;
			if ( amount > max_amount_can_be_add )
			{
				this.amount = item.max_stack_amount;
				return amount - max_amount_can_be_add;
			}
			else
			{
				this.amount += amount;
				return 0;
			}
		}

		public int remove_amount( int amount )
		{
			int max_amount_can_be_add = this.amount;
			if ( amount > this.amount )
			{
				var result = amount - this.amount;
				this.amount = 0;
				return result;
			}
			else
			{
				this.amount -= amount;
				return 0;
			}
		}
	}
}
