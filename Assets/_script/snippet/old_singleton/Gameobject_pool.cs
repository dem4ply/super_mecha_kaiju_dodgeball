using UnityEngine;
using System.Collections.Generic;

public class Mono_pool: Singleton<MonoBehaviour> {
	public Transform container;

	protected Mono_pool() { }

	protected Dictionary<MonoBehaviour, Stack<MonoBehaviour>> _dict;


	public virtual MonoBehaviour pop( MonoBehaviour key ) {
		MonoBehaviour result = null;
		if ( _dict.ContainsKey( key ) ) {
			Stack<MonoBehaviour> stack = _dict[key];
			if ( stack.Count > 0 )
				result = stack.Pop();
		}
		if ( result == null ) {
			result = helper.instantiate.inactive._<MonoBehaviour>( key );
		}
		else
			result.transform.parent = null;
		return result;
	}

	public virtual void push( MonoBehaviour value ) {
		move_to_container( value );
		if ( _dict.ContainsKey( value ) )
			_dict[value].Push( value );
		else {
			Stack<MonoBehaviour> stack_tmp = new Stack<MonoBehaviour>();
			stack_tmp.Push( value );
			_dict.Add( value, stack_tmp );
		}
	}

	public virtual void prepare_objects( MonoBehaviour obj, int amount ) {
		Stack<MonoBehaviour> stack;
		if ( _dict.ContainsKey( obj ) )
			stack = _dict[obj];
		else
			stack = new Stack<MonoBehaviour>( amount );
		for ( ; amount > 0; --amount ) {
			MonoBehaviour obj_tmp = helper.instantiate.inactive.parent<MonoBehaviour>( obj, container );
			stack.Push( obj_tmp );
		}
		_dict.Add( obj, stack );
	}


	protected virtual void move_to_container( MonoBehaviour obj ) {
		obj.transform.parent = container;
		obj.gameObject.SetActive( false );
	}

	protected virtual void Awake() {
		_dict = new Dictionary<MonoBehaviour, Stack<MonoBehaviour>>();
		if ( !container )
			container = this.transform;
		try {
			// prepara 10 instancias de la bala simple
			// prepare_objects( List_of_items.instance.test.test_1.GetComponent<MonoBehaviour>(), 10 );
		}
		catch ( System.Exception e ) {
			Debug.LogError( e );
		}
	}
}