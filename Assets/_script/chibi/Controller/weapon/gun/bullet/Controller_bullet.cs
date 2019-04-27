using UnityEngine;
using System.Collections.Generic;
using chibi.motor;
using damage;

namespace chibi.controller.weapon.gun.bullet
{
	public class Controller_bullet : Controller
	{
		public Damage[] damages
		{
			get {
				var damage = GetComponent<Damage>();
				var damages = GetComponentsInChildren<Damage>();
				var result = new List<Damage>( damages );
				if ( damage != null )
					result.Add( damage );
				return result.ToArray();
			}
		}
	}
}
