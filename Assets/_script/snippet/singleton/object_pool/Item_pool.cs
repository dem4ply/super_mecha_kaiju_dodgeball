using UnityEngine;
using System.Collections.Generic;
using weapon.ammo;
using chibi.motor.weapons.gun.bullet;
using chibi.inventory.item;

namespace singleton
{
	namespace object_pool
	{
		public class Item_pool<T> : Singleton<T>
			where T : chibi.Chibi_object
		{
			public virtual string container_name
			{
				get {
					return "item_pool";
				}
			}

			public Transform container;

			protected Dictionary<Item, Stack<GameObject>> _dict;

			public Stack<GameObject> this[ Item key ] {
				get {
					Stack<GameObject> result;
					_dict.TryGetValue( key, out result );
					return result;
				}
			}

			protected virtual void OnEnable()
			{
				_dict = new Dictionary<Item, Stack<GameObject>>();
				if ( !container )
					container = helper.game_object.prepare.stuff_container(
						container_name ).transform;
			}

			public virtual GameObject pop( Item key )
			{
				GameObject result = null;
				if ( _dict.ContainsKey( key ) )
				{
					var stack = _dict[ key ];
					if ( stack.Count > 0 )
						result = stack.Pop();
				}
				if ( result == null )
				{
					// result = helper.instantiate.inactive._( key );
					result = instantiate( key );
				}
				else
				{
					result.transform.parent = null;
					result.gameObject.SetActive( true );
				}
				return result;
			}

			public virtual void push( Item key, GameObject value )
			{
				move_to_container( value );
				if ( _dict.ContainsKey( key ) )
					_dict[ key ].Push( value );
				else
				{
					Stack<GameObject> stack_tmp =
						new Stack<GameObject>();
					stack_tmp.Push( value );
					_dict.Add( key, stack_tmp );
				}
			}

			protected virtual void move_to_container( GameObject obj )
			{
				obj.transform.parent = container;
				obj.gameObject.SetActive( false );
			}

			public virtual GameObject instantiate( Item key )
			{
				Debug.Log( "puta madre" );
				var obj = key.instantiate();
				// obj.ammo = key;
				return obj.gameObject;
			}

			public void clean_container_immediate()
			{
				while ( container.childCount > 0 )
				{
					var child = container.GetChild( 0 );
					GameObject.DestroyImmediate( child.gameObject );
				}
				_dict = new Dictionary<Item, Stack<GameObject>>();
			}
		}
	}
}
