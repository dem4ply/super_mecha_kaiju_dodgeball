using UnityEngine;
using System.Collections.Generic;
using weapon.ammo;
using chibi.motor.weapons.gun.bullet;

namespace chibi.pool
{
	public class Pool_behaviour : chibi.Chibi_object
	{
		public GameObject prefab;
		public Transform container;
		protected Stack<chibi.Chibi_behaviour> _pool_stack;

		public string container_name
		{
			get {
				return "generic pool";
			}
		}

		protected virtual void OnEnable()
		{
			if ( !container )
			{
				var generic_pool = helper.game_object.prepare.stuff_container(
					container_name ).transform;

				container = helper.game_object.prepare.stuff_container(
					name, generic_pool ).transform;
			}
		}

		public virtual chibi.Chibi_behaviour pop()
		{
			chibi.Chibi_behaviour result = null;
			var stack = _pool_stack;
			if ( _pool_stack.Count > 0 )
				result = _pool_stack.Pop();
			if ( result == null )
				result = instantiate();
			result.transform.parent = null;
			return result;
		}

		public virtual void push( chibi.Chibi_behaviour obj )
		{
			move_to_container( obj );
			_pool_stack.Push( obj );
		}

		public virtual void move_to_container( chibi.Chibi_behaviour obj )
		{
			obj.gameObject.SetActive( false );
			obj.transform.parent = container;
		}

		protected chibi.Chibi_behaviour instantiate()
		{
			if ( prefab == null )
			{
				Debug.LogError( "no tiene prefab defino" );
				return null;
			}
			var obj = helper.instantiate._( prefab );
			return obj.transform.GetComponent<chibi.Chibi_behaviour>();
		}
	}
}
