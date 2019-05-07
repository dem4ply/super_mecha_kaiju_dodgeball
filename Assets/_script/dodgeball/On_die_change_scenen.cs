﻿using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using rol_sheet;
using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using rol_sheet;
using damage.motor;

namespace chibi.controller
{
	public class On_die_change_scenen: Chibi_behaviour
	{
		public float time_to_change_scene = 10f;
		public float _delta_time;

		private void Update()
		{
			var hp_motor = GetComponent<HP_motor_old>();
			if ( hp_motor.is_dead )
			{
				_delta_time += Time.deltaTime;
				if ( _delta_time > time_to_change_scene )
				{
					SceneManager.LoadScene( "Resources/SMKD/scene/game_mode_mvp" );
				}
			}
		}
	}
}
