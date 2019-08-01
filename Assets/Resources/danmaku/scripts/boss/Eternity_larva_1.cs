using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using danmaku.controller.weapon.gun;
using chibi.controller.steering.behavior;
using chibi.controller.steering;

namespace danmaku.boss_behaviour
{
	public class Eternity_larva_1 : Boss_behaviour
	{
		Steering steering;

		protected override IEnumerator do_behaviour()
		{
			get_sterring();
			set_follow_waypoint();
			yield return null;
			end_behaviour();
		}

		protected void get_sterring()
		{
			steering = touha.GetComponent<Steering>();
			if ( !steering )
				steering = touha.gameObject.AddComponent<Steering>();
		}

		protected void set_follow_waypoint()
		{
			var behavior = Follow_waypoints.CreateInstance<Follow_waypoints>();
			steering.behaviors.Add( behavior );
			steering.reload();
		}
	}
}
