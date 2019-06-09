using UnityEngine;
using System.Collections.Generic;
using weapon.ammo;
using chibi.motor.weapons.gun.bullet;

namespace singleton.pomodoro
{
	public class Pomodoro_singleton : Singleton<Pomodoro_singleton>
	{
		protected List<chibi.pomodoro.Pomodoro> _list;

		protected virtual void OnEnable()
		{
			_list = new List<chibi.pomodoro.Pomodoro>();
		}

		public void add( chibi.pomodoro.Pomodoro pomodoro )
		{
			_list.Add( pomodoro );
		}
	}
}