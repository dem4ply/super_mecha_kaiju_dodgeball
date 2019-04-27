using UnityEngine;
using System.Collections;

public class Inventory_player : MonoBehaviour {

	public void AddItem() {
		Inventory inventory = GetComponent<Inventory>();
		inventory.add_item( List_of_items.instance.test.test_1.GetComponent<Item_2>(), 1 );
	}
	
	public void AddItem2() {
		Inventory inventory = GetComponent<Inventory>();
		inventory.add_item( List_of_items.instance.test.test_2.GetComponent<Item_2>(), 1 );
	}
	
	public void AddItem3() {
		Inventory inventory = GetComponent<Inventory>();
		inventory.add_item( List_of_items.instance.test.test_2.GetComponent<Item_2>(), 10 );
	}
	
	public void AddItem4() {
		Inventory inventory = GetComponent<Inventory>();
		inventory.add_item( List_of_items.instance.test.test_1.GetComponent<Item_2>(), 10 );
	}
	
	public void AddItem5() {
		Inventory inventory = GetComponent<Inventory>();
		inventory.add_item( List_of_items.instance.test.test_3.GetComponent<Item_2>(), 10 );
	}
	
	public void AddItem6() {
		Inventory inventory = GetComponent<Inventory>();
		inventory.add_item( List_of_items.instance.test.test_3.GetComponent<Item_2>(), 1 );
	}
	
	protected virtual void FixedUpdate(){
		if (Input.GetKeyUp(KeyCode.A)) {
			this.AddItem();
		}
		
		if (Input.GetKeyUp(KeyCode.B)) {
			this.AddItem2();
		}
		
		if (Input.GetKeyUp(KeyCode.C)) {
			this.AddItem3();
		}
		
		if (Input.GetKeyUp(KeyCode.D)) {
			this.AddItem4();
		}
		
		if (Input.GetKeyUp(KeyCode.R)) {
			this.AddItem5();
		}
		
		if (Input.GetKeyUp(KeyCode.E)) {
			this.AddItem6();
		}
	}
}
