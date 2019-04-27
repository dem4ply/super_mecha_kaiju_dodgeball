using UnityEngine;
using System.Collections.Generic;

public class Items_pool : Singleton<Items_pool> {
	public Transform container;

	protected Items_pool() { }
	
	protected Dictionary<Item_2, Stack<Item_2>> _dict;
	
	
	public virtual Item_2 pop(Item_2 key){
		Item_2 result = null;
		if (_dict.ContainsKey(key)) {
			Stack<Item_2> stack = _dict[key];
			if (stack.Count > 0)
				result = stack.Pop();
		}
		if (result == null){
			result = helper.instantiate.inactive._<Item_2>(key);
		}
		else
			result.transform.parent = null;
		return result;
	}
	
	public virtual void push(Item_2 value){
		move_to_container(value);
		if (_dict.ContainsKey(value))
			_dict[value].Push(value);
		else {
			Stack<Item_2> stack_tmp = new Stack<Item_2>();
			stack_tmp.Push(value);
			_dict.Add(value ,stack_tmp);
		}
	}
	
	public virtual void prepare_objects(Item_2 obj, int amount){
		Stack<Item_2> stack;
		if (_dict.ContainsKey(obj))
			stack = _dict[obj];
		else
			stack = new Stack<Item_2>(amount);
		for (; amount > 0; --amount){
			Item_2 obj_tmp = helper.instantiate.inactive.parent<Item_2>(obj, container);
			stack.Push(obj_tmp);
		}
		_dict.Add(obj, stack);
	}
	
	
	protected virtual void move_to_container(Item_2 obj){
		obj.transform.parent = container;
		obj.gameObject.SetActive(false);
	}
	
	protected virtual void Awake(){
		_dict = new Dictionary<Item_2, Stack<Item_2>>();
		if (!container)
			container = this.transform;
		try {
			//prepara 10 instancias de la bala simple
			prepare_objects( List_of_items.instance.test.test_1.GetComponent<Item_2>(), 10 );
		}
		catch(System.Exception e) {
			Debug.LogError(e);
		}
	}
}

