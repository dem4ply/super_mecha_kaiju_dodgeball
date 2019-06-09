using UnityEngine;
using System.Collections.Generic;
using weapon.ammo;
using chibi.motor.weapons.gun.bullet;

namespace singleton.pomodoro
{
	public class Pomodoro_singleton : Singleton<chibi.pomodoro.Pomodoro>
	{
		protected List<chibi.pomodoro.Pomodoro> _list;

		protected virtual void OnEnable()
		{
			_list = new List<chibi.pomodoro.Pomodoro>();
		}
	}
}