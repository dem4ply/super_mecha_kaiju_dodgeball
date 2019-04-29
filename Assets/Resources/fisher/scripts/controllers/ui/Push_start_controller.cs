using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using chibi.controller.weapon.gun.bullet;
using rol_sheet;

namespace fisher.controller
{
	public class Push_start_controller : chibi.controller.Controller
	{
		public GameObject push_start_panel;

		public chibi.controller.npc.Dodger_controller dodget_tutortial;
		public Controller_bullet bullet;

		public GameObject current;
		public GameObject tuto_1;
		public GameObject tuto_2;
		public GameObject tuto_3;

		public override void action( string name, string e )
		{
			//base.action( name, e );
			if ( current == push_start_panel )
			{
				dodget_tutortial.grab_ball( bullet.transform );
				dodget_tutortial.shot();
				push_start_panel.SetActive( false );
				current = tuto_1;
			}
			else
			{
				current.SetActive( false );
			}
		}

		public void action_tutorial( string action )
		{
			switch ( action )
			{
				case "dodge":
					tuto_1.SetActive( true );
					current = tuto_1;
					break;

				case "catch":
					tuto_2.SetActive( true );
					current = tuto_2;
					break;

				case "shot":
					tuto_3.SetActive( true );
					current = tuto_3;
					break;
			}
		}

		public override Vector3 desire_direction
		{
			get {
				return base.desire_direction;
			}

			set {
				//base.desire_direction = value;
			}
		}

		public override float speed
		{
			get {
				return base.speed;
			}

			set {
				//base.speed = value;
			}
		}

		protected override void load_actuator_controller()
		{
			// base.load_actuator_controller();
		}

		protected override void load_motors()
		{
			// base.load_motors();
		}
	}
}
