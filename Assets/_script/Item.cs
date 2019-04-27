using UnityEngine;
using System.Collections;

public class Item_2 : MonoBehaviour {

	public bool is_stackable;
	public int amount;
	public int limit_stack;
	
	public int id;
	
	public GameObject item;
	
	public bool stack_is_infinite {
		get {
			return limit_stack == 0;
		}
	}
	
	public bool is_empty {
		get {
			return amount == 0;
		}
	}
	
	public bool is_full {
		get {
			if ( stack_is_infinite )
				return false;
			return amount == limit_stack;
		}
	}
	
	/// <summary>
	/// regresa lo neseario para llegar al limite
	/// si la pila es infinita regresa el entero maximo menos la cantidad
	/// </summary>
	public virtual int needed_limit{
		get{
			if (is_stackable)
				if (stack_is_infinite)
					return int.MaxValue - amount;
			else
				return limit_stack - amount;
			return 1 - amount;
		}
	}
	
	public override int GetHashCode(){
		return id;
	}
	
	/// <summary>
	/// si el item permite que se apile agregara la cantidad y en caso de que la cantidad sobrepase
	/// la cantidad maxima de apilamiento regresara los que no pudo agregar
	/// </summary>
	/// <param name="amount">cantidad a agregar a la pila del item</param>
	public int add_amount(int amount) {
		if (is_stackable) {
			int needed_limit = this.needed_limit;
			int residue = 0;
			if (amount > needed_limit){
				residue =  amount - needed_limit;
				amount = needed_limit;
			}
			this.amount += amount;
			return residue;
		}
		else if (is_empty) {
			this.amount += 1;
			return amount - 1;
		}
		else
			return amount;
	}

}
